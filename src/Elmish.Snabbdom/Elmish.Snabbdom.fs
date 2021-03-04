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

let private __mountOnVNodeWith (arg: 'arg) (init: (Program<'arg, 'model, 'msg, Node> -> unit) -> unit): Node =
    Html.custom("elmish", [
      Hook.insert (fun vnode -> init(fun program ->
        let mutable oldVNode = vnode
        let mutable oldModel: 'model option = None


        let setState model dispatch =
            match oldModel with
            | Some m when obj.ReferenceEquals(m, model) -> ()
            | _ ->
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
      ))

      Hook.prepatch (fun oldVNode newVNode ->
        oldVNode |> copyTo newVNode
        if hasKey newVNode.data "setNewArg" then
            newVNode.data?setNewArg(arg)
      )
    ])

let mountOnVNodeWith (arg: 'arg) (program: Program<'arg, 'model, 'msg, Node>): Node =
    __mountOnVNodeWith arg (fun cont -> cont(program))

let mountOnVNode (program: Program<_,_,_,_>): Node =
    __mountOnVNodeWith () (fun cont -> cont(program))

[<Emit("cont => import($0).then(m => cont(m.mkProgram(arg)))")>]
let private importAndMkProgram(path: string): (Program<'arg, 'model, 'msg, Node> -> unit) -> unit = jsNative

let inline importAndMountOnVNodeWith (path: string) (arg: 'arg): Node =
    __mountOnVNodeWith arg (importAndMkProgram path)

let inline importAndMountOnVNode (path: string): Node =
    __mountOnVNodeWith () (importAndMkProgram path)

let mountWithId (id: string) program =
    let el = Browser.Dom.document.getElementById(id)
    let mutable oldVNode: Snabbdom.VNode option = None
    let mutable oldModel: 'model option = None

    let setState model dispatch =
        match oldModel with
        | Some m when obj.ReferenceEquals(m, model) -> ()
        | _ ->
            let newVNode = Program.view program model dispatch |> Node.AsVNode
            // Make sure the generated element has the same id so we can find it again in HMR reloads
            newVNode.sel <- newVNode.sel + "#" + id
            match oldVNode with
            | None ->
                // Snabbdom expects el to be empty, but this is not the case in HMR reloads
                if el.children.length > 0 then el.innerHTML <- ""
                Snabbdom.Helper.Patch(el, newVNode) |> ignore
            | Some oldVNode -> Snabbdom.Helper.Patch(oldVNode, newVNode) |> ignore
            oldVNode <- Some newVNode
            oldModel <- Some model

    program
    |> Program.withSetState setState
