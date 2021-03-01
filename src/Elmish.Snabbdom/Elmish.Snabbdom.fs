[<RequireQualifiedAccess>]
module Elmish.Snabbdom.Program

open System
open Fable.Core
open Elmish
open Browser.Types
open Feliz.Snabbdom

let private cache = JS.Constructors.WeakMap.Create()

[<Emit("$0 && typeof $0.Dispose === 'function' ? $0 : void 0")>]
let tryDisposable (o: obj): IDisposable option = jsNative

let mountOnVNodeWith (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    Html.div [
      Hook.insert (fun vnode ->
        let el = vnode.elm
        let mutable tree = vnode

        let setState model dispatch =
            cache.set(el, box model) |> ignore
            let newTree = Program.view program model dispatch |> Node.AsVNode
            Snabbdom.Helper.Patch(tree, newTree)
            tree <- newTree

        program
        |> Program.withSetState setState
        |> Program.runWith arg
      )

      // The virtual node instance will change if this function is called multiple times
      // but the underlying HTMLElement should remain the same (even if it's not actually
      // in the Dom because it has been replaced by Program.view)
      Hook.destroy (fun vnode ->
        cache.get(vnode.elm)
        |> tryDisposable
        |> Option.iter (fun d -> d.Dispose())
      )
    ]

let mountOnVNode (program: Program<_,_,_,_>): Node =
    program |> mountOnVNodeWith ()

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
