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
    | El of VirtualNode
    | Style of string * obj * StyleHook
    | Attr of string * obj
    | Event of string * obj
    | Fragment of Node list
    static member AsVNode = function
        | El n -> n
        | _ -> failwith "Not a virtual node"

type Helper() =
    interface HtmlHelper<Node> with
        member _.MakeNode(tag, nodes) =
            let addSub (o: obj) (key1: string) (key2: string) (v: obj) =
                if isNull o?(key1) then o?(key1) <- createObj [ key2, v ]
                else o?(key1)?(key2) <- v

            let mutable key = Guid.Empty
            let styles = obj()
            let attrs = obj()
            let evs = obj()
            let children = ResizeArray()

            let rec addNodes (nodes: Node seq) =
                nodes |> Seq.iter (function
                    | Key k -> key <- k
                    | El node -> children.Add(node)
                    | Style(k, v, StyleHook.None) -> styles?(k) <- v
                    | Style(k, v, StyleHook.Delayed) -> addSub styles "delayed" k v
                    | Style(k, v, StyleHook.Remove) -> addSub styles "remove" k v
                    | Style(k, v, StyleHook.Destroy) -> addSub styles "destroy" k v
                    | Attr(k, v) -> attrs?(k) <- v
                    | Event(k, v) -> evs?(k) <- v
                    | Fragment nodes -> addNodes nodes
                )

            addNodes nodes
            let props = createObj [
                if key <> Guid.Empty then "key", box key
                if JS.Constructors.Object.keys(styles).Count > 0 then "style", styles
                if JS.Constructors.Object.keys(attrs).Count > 0 then "attrs", attrs
                if JS.Constructors.Object.keys(evs).Count > 0 then "on", evs
            ]
            h(tag, props, children) |> El

        member _.StringToNode(v) = Helper.Text v |> El
        member _.EmptyNode = Helper.Empty |> El

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

module Elmish =
    let app id (init: unit -> 'Model) update view =
        let event = new Event<'Msg>()
        let trigger e = event.Trigger(e)
        let mutable state = init()
        let mutable tree = view state trigger |> Node.AsVNode
        Helper.Patch(Browser.Dom.document.getElementById(id) |> Helper.AsNode, tree)

        let handleEvent evt =
            state <- update evt state
            let newTree = view state trigger |> Node.AsVNode
            Helper.Patch(tree, newTree)
            tree <- newTree

        event.Publish.Add(handleEvent)
