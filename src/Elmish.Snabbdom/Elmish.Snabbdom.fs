[<RequireQualifiedAccess>]
module Elmish.Snabbdom.Program

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Browser.Types
open Feliz.Snabbdom

module private Util =
    let rec tryPath (o: obj) (keys: string list): obj option =
        Option.ofObj o
        |> Option.bind (fun o ->
            match keys with
            | [] -> failwith "empty keys"
            | [key] -> o?(key) |> Option.ofObj
            | key::rest ->
                o?(key)
                |> Option.ofObj
                |> Option.bind (fun o -> tryPath o rest))

    type ElmishData() =
        member val VNode: Snabbdom.VNode = Unchecked.defaultof<_> with get, set
        member val Dispatch: obj -> unit = ignore with get, set
        member this.Dispose() =
            let vnode = this.VNode
            match tryPath vnode ["data"; "hook"; "destroy"] with
            | None -> ()
            | Some h -> (h :?> _) vnode

    let cache = JS.Constructors.WeakMap.Create<HTMLElement, ElmishData>()

open Util

let private __mountOnVNodeWith (arg: 'arg) (onNewArg: ('arg -> 'msg) option) (program: Program<'arg, 'model, 'msg, Node>): Node =
    Html.div [
      Hook.insert (fun vnode ->
        let el = vnode.elm
        let mutable oldVNode = vnode
        cache.set(el, ElmishData()) |> ignore

        let setState model dispatch =
            let newVNode = Program.view program model dispatch |> Node.AsVNode

            // Snabbdom keeps a reference to the original node, not the patched one, so we save in the cache
            let data = cache.get(el)
            data.VNode <- newVNode
            data.Dispatch <- unbox dispatch

            Snabbdom.Helper.Patch(oldVNode, newVNode)
            oldVNode <- newVNode

        program
        |> Program.withSetState setState
        |> Program.runWith arg
      )

      Hook.prepatch (fun vnode _ ->
        match onNewArg with
        | Some onNewArg -> cache.get(vnode.elm).Dispatch(box(onNewArg arg))
        | None -> ()
      )

      Hook.destroy (fun vnode ->
        cache.get(vnode.elm).Dispose())
    ]

let mountOnVNodeWith (arg: 'arg) (onNewArg: 'arg -> 'msg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    program |> __mountOnVNodeWith arg (Some onNewArg)

let mountOnVNode (program: Program<_,_,_,_>): Node =
    program |> __mountOnVNodeWith ()  None

let mountOnElement (el: HTMLElement) (program: Program<_,_,_,_>) =
    let mutable tree: Snabbdom.VNode option = None

    let setState model dispatch =
        let newTree = Program.view program model dispatch |> Node.AsVNode
        match tree with
        | None -> Snabbdom.Helper.Patch(el, newTree)
        | Some oldTree -> Snabbdom.Helper.Patch(oldTree, newTree)
        tree <- Some newTree

    program
    |> Program.withSetState setState

let mountWithId (id: string) program =
    let el = Browser.Dom.document.getElementById(id)
    mountOnElement el program

let mountWithSelector (selector: string) program =
    let el = Browser.Dom.document.querySelector(selector) :?> HTMLElement
    mountOnElement el program
