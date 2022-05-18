module Feliz.Solid

open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Style = Style of string * obj

type AttrVal = obj
type EvFn = obj

type Node =
    | Text of string
    | El of SolidElement
    | Styles of Style list
    | ReactiveStyles of (unit -> Style list)
    | Attr of string * AttrVal
    | Event of string * EvFn

let toSolid = function
    | El el -> el
    | Text text -> Solid.text text
    | _ -> failwith "Not a Solid element"

let styles styles = Styles styles

let reactiveStyles (f: unit -> Style list) = ReactiveStyles f

let reactiveEl (f: unit -> Node) = El(unbox(fun _ -> f() |> toSolid))

let reactiveVal (f: unit -> 'T): AttrVal = box f

let fragment (els: Node seq) =
    els
    |> Seq.choose (function El e -> Some e | _ -> None)
    |> Seq.toArray
    |> Solid.fragment
    |> El

let private makeStyles (styles: Style list) =
    (obj(), styles) ||> List.fold (fun o (Style(k, v)) -> o?(k) <- v; o)

let private makeNode tag nodes =
    let rec addNodes (props: obj) (children: ResizeArray<_>) (nodes: Node seq) =
        nodes |> Seq.iter (function
            | Text s -> children.Add(Solid.text s)
            | El vnode -> children.Add(vnode)
            | Styles styles -> props?style <- makeStyles styles
            | ReactiveStyles f -> props?style <- (fun () -> f() |> makeStyles)
            | Attr(k, v) -> props?(k) <- v
            | Event(k, v) ->
                let k = "on" + k[0].ToString().ToUpperInvariant() + k[1..]
                props?(k) <- v)

    let props = obj()
    let children = ResizeArray()
    addNodes props children nodes
    Solid.h(tag, props, children) |> El

let Html = HtmlEngine(makeNode, Text, fun () -> fragment [])

// let Svg = SvgEngine(makeNode, Text, fun () -> Fragment [])

let Attr = AttrEngine((fun k v -> Attr(k, v)), (fun k v -> Attr(k, v)))

let Css = CssEngine(fun k v -> Style(k, v))

let Ev = EventEngine(fun k f -> Event(k, f))

