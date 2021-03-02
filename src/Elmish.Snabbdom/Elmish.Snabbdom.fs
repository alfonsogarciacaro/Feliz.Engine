[<RequireQualifiedAccess>]
module Elmish.Snabbdom.Program

open System
open System.Collections.Generic
open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Browser.Types
open Feliz.Snabbdom

module private rec Util =
    let rec tryPath (o: obj) (keys: string list): 'a option =
        Option.ofObj o
        |> Option.bind (fun o ->
            match keys with
            | [] -> failwith "empty keys"
            | [key] -> o?(key) |> Option.ofObj |> unbox
            | key::rest ->
                o?(key)
                |> Option.ofObj
                |> Option.bind (fun o -> tryPath o rest))

    let cache = Dictionary<Guid, ElmishData>()

    type ElmishData(vnode) =
        let mutable timeoutId: int option = None
        member val VNode: Snabbdom.VNode = vnode with get, set
        member val DispatchNewArg: obj -> unit  = ignore with get, set
        member val Model: obj = null with get, set
        member _.TimeoutDisposal(guid) =
            timeoutId <- JS.setTimeout (fun _ ->
                cache.Remove(guid) |> ignore) 0 |> Some
        member _.CancelDisposal() =
            timeoutId |> Option.iter JS.clearTimeout

open Util

let withSetNewArg (setNewArg: 'arg -> 'msg) (program: Program<'arg, 'model, 'msg, Node>) =
    // HACK: add the function dynamically
    program?setNewArg <- setNewArg
    program

let private __mountOnVNodeWith (guid: Guid) (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    Html.custom("elmish", [
      Key guid
      Hook.insert (fun vnode ->
        let setState model dispatch =
            let data = cache.[guid]
            let isInvalid =
                if data.VNode.children.Length = 0 then
                    tryPath program ["setNewArg"]
                    |> Option.iter (fun f -> data.DispatchNewArg <- (f >> dispatch))
                    true
                else
                    obj.ReferenceEquals(model, data.Model) |> not

            if isInvalid then
                let newVNode =
                    Html.custom("elmish", [
                        Key guid
                        Program.view program model dispatch
                    ]) |> Node.AsVNode
                Snabbdom.Helper.Patch(data.VNode, newVNode)
                data.VNode <- newVNode
                data.Model <- box model

        let program =
            match cache.TryGetValue(guid) with
            | true, data ->
                data.CancelDisposal()
                data.VNode <- vnode
                Program.map (fun _ _ -> !!data.Model, []) id id id id program
            | false, _ ->
                cache.Add(guid, ElmishData(vnode)) |> ignore
                program

        program
        |> Program.withSetState setState
        |> Program.runWith arg
      )

      Hook.prepatch (fun _oldVNode _newVNode ->
        let data = cache.[guid]
        data.DispatchNewArg(box arg)
      )

      Hook.destroy (fun vnode ->
        let data = cache.[guid]
        data.TimeoutDisposal(guid)
        if not(obj.ReferenceEquals(vnode, data.VNode)) then
            for vnode in data.VNode.children do
                tryPath vnode.data ["hook"; "destroy"]
                |> Option.iter (fun h -> h vnode)
      )
    ])

let mountOnVNodeWith id (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    program |> __mountOnVNodeWith id arg

let mountOnVNode id (program: Program<_,_,_,_>): Node =
    program |> __mountOnVNodeWith id ()

let mountOnElement (el: HTMLElement) (program: Program<_,_,_,_>) =
    let mutable oldModel = Unchecked.defaultof<_>
    let mutable tree: Snabbdom.VNode option = None

    let setState model dispatch =
        if not(obj.ReferenceEquals(model, oldModel)) then
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
