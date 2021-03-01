[<RequireQualifiedAccess>]
module SnabbdomStore

open System
open Fable
open Fable.Core
open Browser.Types
open Feliz.Snabbdom


let private cache = JS.Constructors.WeakMap.Create()

let mountOnVNode (store: Lazy<IStore<'Value> * ('Value -> Node)>) =
    Html.div [
      Hook.insert (fun vnode ->
        let mutable tree = vnode

        let store, view = store.Value
        let disp = store.Subscribe(fun v ->
            let newTree = view v |> Node.AsVNode
            Snabbdom.Helper.Patch(tree, newTree)
            tree <- newTree
        )

        cache.set(vnode.elm, disp) |> ignore
      )

      // The virtual node instance will change if this function is called multiple times
      // but the underlying HTMLElement should remain the same (even if it's not actually
      // in the Dom because it has been replaced by Program.view)
      Hook.destroy (fun vnode ->
        cache.get(vnode.elm)
        |> Option.ofObj
        |> Option.iter (fun d -> d.Dispose())
      )
    ]

let mountOnElement (el: HTMLElement) (store: IStore<'Value>, view: 'Value -> Node) =
    let mutable tree: Snabbdom.VNode option = None
    store.Subscribe(fun v ->
        let newTree = view v |> Node.AsVNode
        match tree with
        | None -> Snabbdom.Helper.Patch(el, newTree)
        | Some oldTree -> Snabbdom.Helper.Patch(oldTree, newTree)
        tree <- Some newTree
    )

let mountWithId (id: string) store =
    let el = Browser.Dom.document.getElementById(id)
    mountOnElement el store

let mountWithSelector (selector: string) store =
    let el = Browser.Dom.document.querySelector(selector) :?> HTMLElement
    mountOnElement el store
