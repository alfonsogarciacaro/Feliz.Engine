[<RequireQualifiedAccess>]
module Elmish.Snabbdom.Program

open System
open Elmish
open Browser.Types
open Feliz.Snabbdom

let mountOnDisposableVNodeWith (subscribe: 'model -> ('msg -> unit) -> IDisposable) (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    let disp = ref { new IDisposable with member _.Dispose() = () }

    Html.div [
      Hook.insert (fun vnode ->
        let mutable tree = vnode
        let setState model dispatch =
            let newTree = Program.view program model dispatch |> Node.AsVNode
            Snabbdom.Helper.Patch(tree, newTree)
            tree <- newTree

        if isNull(box subscribe) then program
        else
            program |> Program.withSubscription (fun model -> [fun dispatch ->
                disp := subscribe model dispatch ])
        |> Program.withSetState setState
        |> Program.runWith arg
      )
      Hook.destroy (fun _ ->
        disp.Value.Dispose()
      )
    ]

let mountOnVNodeWith (arg: 'Arg) (program: Program<_,_,_,_>): Node =
    program |> mountOnDisposableVNodeWith Unchecked.defaultof<_> arg

let mountOnDisposableVNode subscribe (program: Program<_,_,_,_>): Node =
    program |> mountOnDisposableVNodeWith subscribe ()

let mountOnVNode (program: Program<_,_,_,_>): Node =
    program |> mountOnDisposableVNodeWith Unchecked.defaultof<_> ()

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
