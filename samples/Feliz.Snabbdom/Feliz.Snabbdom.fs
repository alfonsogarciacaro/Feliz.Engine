module Feliz.Snabbdom

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Snabbdom

type Node =
    | El of VirtualNode
    | Style of string * obj
    | Attr of string * obj
    | Event of string * obj
    static member AsVNode = function
        | El n -> n
        | _ -> failwith "Not a virtual node"

let Html =
    HtmlEngine
        { new HtmlHelper<Node> with
            member _.MakeNode(tag, nodes) =
                let styles = obj()
                let attrs = obj()
                let evs = obj()
                let children = ResizeArray()
                nodes |> Seq.iter (function
                    | El node -> children.Add(node)
                    | Style(k, v) -> styles?(k) <- v
                    | Attr(k, v) -> attrs?(k) <- v
                    | Event(k, v) -> evs?(k) <- v)
                let props = createObj [
                    if JS.Constructors.Object.keys(styles).Count > 0 then "style", styles
                    if JS.Constructors.Object.keys(attrs).Count > 0 then "attrs", attrs
                    if JS.Constructors.Object.keys(evs).Count > 0 then "on", evs
                ]
                h(tag, props, children) |> El
            member _.StringToNode(v) = Helper.Text v |> El
            member _.EmptyNode = Helper.Empty |> El }

let Attr =
    AttrEngine
        { new AttrHelper<Node> with
            member _.MakeAttr(key, value) = Attr(key, value)
            member _.MakeBooleanAttr(key, value) = Attr(key, value) }

let Css =
    CssEngine
        { new CssHelper<Node> with
            member _.MakeStyle(k, v) = Style(k, v) }

let Ev =
    EventEngine
        { new EventHelper<Node> with
            member _.MakeEvent(k, f) = Event(k.ToLowerInvariant(), f) }


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
