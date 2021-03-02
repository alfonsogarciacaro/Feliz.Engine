[<RequireQualifiedAccess>]
module Elmish.Snabbdom.Program

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Browser.Types
open Feliz.Snabbdom

module private rec Util =
    [<Emit("$1 in $0")>]
    let hasKey (o: obj) (key: string): bool = jsNative

    let copyTo (target: obj) (source: obj) =
        JS.Constructors.Object.assign(target, source) |> ignore

    let partialPatch (oldVNode: Snabbdom.VNode) (newVnode: Snabbdom.VNode) =
        Snabbdom.Helper.Patch(oldVNode, newVnode) |> copyTo oldVNode

open Util

let withSetNewArg (setNewArg: 'arg -> 'msg) (program: Program<'arg, 'model, 'msg, Node>) =
    program?setNewArg <- setNewArg
    program

let private __mountOnVNodeWith (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    Html.custom("elmish", [
      Hook.insert (fun vnode ->
        let mutable oldVNode = vnode

        let setState model dispatch =
            let newVNode =
                Html.custom("elmish", [
                    Program.view program model dispatch
                ]) |> Node.AsVNode

            if oldVNode.children.Length = 0 && hasKey program "setNewArg" then
                newVNode.data?setNewArg <- (program?setNewArg >> dispatch)

            partialPatch oldVNode newVNode
            oldVNode <- newVNode

        program
        |> Program.withSetState setState
        |> Program.runWith arg
      )

      Hook.prepatch (fun oldVNode newVNode ->
        oldVNode |> copyTo newVNode
        if hasKey newVNode.data "setNewArg" then
            newVNode.data?setNewArg(arg)
      )
    ])

let mountOnVNodeWith (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    program |> __mountOnVNodeWith arg

let mountOnVNode (program: Program<_,_,_,_>): Node =
    program |> __mountOnVNodeWith ()

let mountOnElement (el: HTMLElement) (program: Program<_,_,_,_>) =
    let mutable tree: Snabbdom.VNode option = None

    let setState model dispatch =
        let newTree = Program.view program model dispatch |> Node.AsVNode
        match tree with
        | None -> Snabbdom.Helper.Patch(el, newTree) |> ignore
        | Some oldTree -> Snabbdom.Helper.Patch(oldTree, newTree) |> ignore
        tree <- Some newTree

    program
    |> Program.withSetState setState

let mountWithId (id: string) program =
    let el = Browser.Dom.document.getElementById(id)
    mountOnElement el program

let mountWithSelector (selector: string) program =
    let el = Browser.Dom.document.querySelector(selector) :?> HTMLElement
    mountOnElement el program
