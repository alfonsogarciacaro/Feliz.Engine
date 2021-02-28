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
    | El of VNode
    | Hook of string * obj
    | Style of string * obj * StyleHook
    | Attr of string * obj
    | Event of string * obj
    | Fragment of Node list
    static member AsVNode = function
        | El vnode -> vnode
        | _ -> failwith "not a vnode"

type Helper() =
    member _.MakeNode(tag, nodes) =
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
                | El vnode -> children.Add(vnode)
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
        Snabbdom.h(tag, props, children) |> El

    member _.StringToNode(v) = Text v
    member _.EmptyNode = Fragment []

    interface HtmlHelper<Node> with
        member this.MakeNode(tag, nodes) = this.MakeNode(tag, nodes)
        member this.StringToNode(v) = this.StringToNode(v)
        member this.EmptyNode = this.EmptyNode

    interface SvgHelper<Node> with
        member this.MakeSvgNode(tag, nodes) = this.MakeNode(tag, nodes)
        member this.StringToSvgNode(v) = this.StringToNode(v)
        member this.EmptySvgNode = this.EmptyNode

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

module Hook =
    /// the patch process begins
    let pre (f: unit -> unit) = Hook("pre", f)
    /// a vnode has been added
    let init (f: VNode -> unit) = Hook("init", f)
    /// a DOM element has been created based on a vnode
    let create (f: VNode -> VNode -> unit) = Hook("create", f)
    /// an element has been inserted into the DOM
    let insert (f: VNode -> unit) = Hook("insert", f)
    /// an element is about to be patched
    let prepatch (f: VNode -> VNode -> unit) = Hook("prepatch", f)
    /// an element is being updated
    let update (f: VNode -> VNode -> unit) = Hook("update", f)
    /// an element has been patched
    let postpatch (f: VNode -> VNode -> unit) = Hook("postpatch", f)
    /// an element is directly or indirectly being removed
    let destroy (f: VNode -> unit) = Hook("destroy", f)
    /// an element is directly being removed from the DOM
    let remove (f: VNode -> (unit -> unit) -> unit) = Hook("remove", f)
    /// the patch process is done
    let post (f: unit -> unit) = Hook("post", f)

let key k = Key k

let inline getId x = (^a: (member Id: Guid) x)

let inline memoize (render: 'Model -> Node) model =
    Helper.Thunk("memo", (getId model), (fun m -> render m |> Node.AsVNode), [|model|]) |> El
