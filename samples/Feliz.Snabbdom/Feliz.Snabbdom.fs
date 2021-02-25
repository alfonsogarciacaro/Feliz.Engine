module Feliz.Snabbdom

open System
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Snabbdom

[<RequireQualifiedAccess>]
type StyleHook =
    | None
    | Delayed
    | Remove
    | Destroy

type Node =
    | Key of Guid
    | Text of string
    | El of string * Node list
    | Hook of string * obj
    | Style of string * obj * StyleHook
    | Attr of string * obj
    | Event of string * obj
    | Fragment of Node list
    static member AsEl = function
        | El(tag, nodes) -> tag, nodes
        | _ -> failwith "Not an el"

type Helper() =
    member this.MakeVNode(tag, nodes) =
        let rec add (o: obj) keys (v: obj) =
            match keys with
            | [] -> failwith "Empty key list"
            | [key] -> o?(key) <- v
            | key::keys ->
                if isNull o?(key) then o?(key) <- obj()
                add (o?(key)) keys v

        let rec addNodes (props: obj) (children: ResizeArray<_>) (nodes: Node seq) =
            nodes |> Seq.iter (function
                | Key k -> props?key <- k
                | Text s -> children.Add(Helper.Text s)
                | El(tag, nodes) -> children.Add(this.MakeVNode(tag, nodes))
                | Hook(k, v) -> add props ["hook"; k] v
                | Style(k, v, StyleHook.None) -> add props ["style"; k] v
                | Style(k, v, StyleHook.Delayed) -> add props ["style"; "delayed"; k] v
                | Style(k, v, StyleHook.Remove) -> add props ["style"; "remove"; k] v
                | Style(k, v, StyleHook.Destroy) -> add props ["style"; "destroy"; k] v
                | Attr(k, v) -> add props ["attrs"; k] v
                | Event(k, v) -> add props ["on"; k] v
                | Fragment nodes -> addNodes props children nodes
            )

        let props = obj()
        let children = ResizeArray()
        addNodes props children nodes
        h(tag, props, children)

    interface HtmlHelper<Node> with
        member _.MakeNode(tag, nodes) = El(tag, List.ofSeq nodes)
        member _.StringToNode(v) = Text v
        member _.EmptyNode = Fragment []

    interface AttrHelper<Node> with
        member _.MakeAttr(key, value) = Attr(key, value)
        member _.MakeBooleanAttr(key, value) = Attr(key, value)

    interface CssHelper<Node> with
        member _.MakeStyle(k, v) = Style(k, v, StyleHook.None)

    interface EventHelper<Node> with
        member _.MakeEvent(k, f) = Event(k.ToLowerInvariant(), f)

open System.Runtime.CompilerServices

[<Extension>]
type Extensions() =
    static let withStyleHook hook nodes =
        nodes |> Seq.choose (function
            | Style(k, v, _) -> Some(Style(k, v, hook))
            | _ -> None // error?
        ) |> Seq.toList |> Fragment

    [<Extension>]
    static member delayed(e: CssEngine<Node>, nodes: Node seq) =
        withStyleHook StyleHook.Delayed nodes

    [<Extension>]
    static member remove(e: CssEngine<Node>, nodes: Node seq) =
        withStyleHook StyleHook.Remove nodes

    [<Extension>]
    static member destroy(e: CssEngine<Node>, nodes: Node seq) =
        withStyleHook StyleHook.Destroy nodes

let private h = Helper()

let Html = HtmlEngine(h)
let Attr = AttrEngine(h)
let Css = CssEngine(h)
let Ev = EventEngine(h)

let key k = Key k

// TODO: Other hooks https://github.com/snabbdom/snabbdom#hooks
module Hook =
    let insert (f: VirtualNode -> unit) = Hook("insert", f)
    let destroy (f: VirtualNode -> unit) = Hook("destroy", f)

module Elmish =
    open System.Collections.Generic

    let private cache = Dictionary<Guid, obj>()

    let memoize (render: 'Model -> ('Msg -> unit) -> Node) (getKey: 'Model -> Guid) model dispatch =
        let cacheAndRender replace key model dispatch =
            let removeCache() =
                // printfn $"Removing {key} from cache"
                cache.Remove(key) |> ignore
            let node =
                match render model dispatch with
                | El(tag, nodes) ->
                    let mutable replaced = false
                    let nodes = nodes |> List.map (fun node ->
                        if replaced then node else
                        match node with
                        | Hook("destroy", cb) ->
                            replaced <- true
                            Hook("destroy", fun n ->
                                removeCache()
                                (unbox<VirtualNode -> unit> cb) n)
                        | n -> n)
                    let nodes =
                        if replaced then nodes
                        else (Hook("destroy", removeCache))::nodes
                    El(tag, nodes)
                | node -> node // Error?
            if replace then cache.[key] <- (node, model)
            else cache.Add(key, (node, model))
            node

        let key = getKey model
        match cache.TryGetValue(key) with
        | true, v ->
            let (node, oldModel) = unbox v
            if obj.ReferenceEquals(model, oldModel) then node
            else cacheAndRender true key model dispatch
        | false, _ ->
            cacheAndRender false key model dispatch

    let app id (init: unit -> 'Model) update view =
        let event = new Event<'Msg>()
        let trigger e = event.Trigger(e)
        let mutable state = init()
        let mutable tree = view state trigger |> Node.AsEl |> h.MakeVNode
        Helper.Patch(Browser.Dom.document.getElementById(id) |> Helper.AsNode, tree)

        let handleEvent evt =
            state <- update evt state
            let newTree = view state trigger |> Node.AsEl |> h.MakeVNode
            Helper.Patch(tree, newTree)
            tree <- newTree

        event.Publish.Add(handleEvent)
