module Feliz.Snabbdom

open System
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

        let rec addNodes (data: obj) (children: ResizeArray<_>) (nodes: Node seq) =
            nodes |> Seq.iter (function
                | Key k -> data?key <- k
                | Text s -> children.Add(Helper.Text s)
                | El vnode -> children.Add(vnode)
                | Hook(k, v) -> add data ["hook"; k] v
                | Style(k, v, StyleHook.None) -> add data ["style"; k] v
                | Style(k, v, StyleHook.Delayed) -> add data ["style"; "delayed"; k] v
                | Style(k, v, StyleHook.Remove) -> add data ["style"; "remove"; k] v
                | Style(k, v, StyleHook.Destroy) -> add data ["style"; "destroy"; k] v
                | Attr(k, v) -> add data ["attrs"; k] v
                | Event(k, v) -> add data ["on"; k] v
                | Fragment nodes -> addNodes data children nodes
            )

        let data = obj()
        let children = ResizeArray()
        addNodes data children nodes
        Snabbdom.h(tag, data, children) |> El

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
let private cache = Fable.Core.JS.Constructors.WeakMap.Create()

let Html = HtmlEngine(h)
let Svg = SvgEngine(h)
let Attr = AttrEngine(h)
let Css = CssEngine(h)
let Ev = EventEngine(h)

type Hook =
    /// a vnode has been added
    static member init (f: Func<VNode, unit>) = Node.Hook("init", f)
    /// a DOM element has been created based on a vnode
    static member create (f: Func<VNode, VNode, unit>) = Node.Hook("create", f)
    /// an element has been inserted into the DOM
    static member insert (f: Func<VNode, unit>) = Node.Hook("insert", f)
    /// an element is about to be patched
    static member prepatch (f: Func<VNode, VNode, unit>) = Node.Hook("prepatch", f)
    /// an element is being updated
    static member update (f: Func<VNode, VNode, unit>) = Node.Hook("update", f)
    /// an element has been patched
    static member postpatch (f: Func<VNode, VNode, unit>) = Node.Hook("postpatch", f)
    /// an element is directly or indirectly being removed
    static member destroy (f: Func<VNode, unit>) = Node.Hook("destroy", f)
    /// an element is directly being removed from the DOM
    static member remove (f: Func<VNode, (unit -> unit), unit>) = Node.Hook("remove", f)

    /// The disposable returned by the hook when the element is inserted into the DOM
    /// will be disposed when that element is directly or indirectly removed from the DOM
    static member insert (f: VNode -> IDisposable) =
        Fragment [
            Hook.insert (fun (v: VNode) ->
                let disp = f v
                cache.set(v.elm, disp) |> ignore)

            Hook.destroy (fun (v: VNode) ->
                cache.get(v.elm)
                |> Option.ofObj
                |> Option.iter (fun d -> d.Dispose()))
        ]

let key k = Key k

let inline getId x = (^a: (member Id: Guid) x)

let memoizeWith (render: 'arg -> Node) getId equals arg =
    Helper.Thunk("memo", getId arg, (fun m -> render m |> Node.AsVNode), arg, equals) |> El

let memoizeWithId (render: 'arg -> Node) getId arg =
    Helper.Thunk("memo", getId arg, (fun m -> render m |> Node.AsVNode), arg) |> El

let inline memoize (render: 'arg -> Node) arg =
    memoizeWithId render getId arg
