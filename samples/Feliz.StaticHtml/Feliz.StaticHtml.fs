module Feliz.StaticHtml

open System
open System.IO
open Feliz

type Node =
    | El of tag: string * Node list
    | Attr of key: string * value: Choice<string, bool>
    | Fragment of Node list
    | Text of string
    | Template of FormattableString

/// ATTENTION: html is not sanitized
let html (fmt: FormattableString) = Template fmt

let Html = HtmlEngine((fun tag nodes -> El(tag, List.ofSeq nodes)), Text, (fun () -> Fragment []))

let Svg = SvgEngine((fun tag nodes -> El(tag, List.ofSeq nodes)), Text, (fun () -> Fragment []))

let Attr = AttrEngine((fun k v -> Attr(k, Choice1Of2 v)), (fun k v -> Attr(k, Choice2Of2 v)))

let write (stream: Stream) (nodes: Node seq) =
    let encoding = new Text.UTF8Encoding()

    let write (stream: Stream) (str: string) =
        let bytes = encoding.GetBytes(str)
        stream.Write(bytes, 0, bytes.Length)

    let indented (stream: Stream) indent str =
        (String.replicate (indent * 4) " ") + str |> write stream

    let rec getChildren nodes =
        nodes |> List.collect (function
            | El(tag, nodes) -> [Choice1Of2(tag, nodes)]
            | Template html -> [Choice2Of2 html]
            // TODO: Fail if Attr found in fragment?
            // TODO: Try pick text node in fragment?
            | Fragment nodes -> getChildren nodes
            | _ -> [])

    let printAttr (stream: Stream) key value =
        match value with
        | Choice1Of2 v -> " " + key + "=\"" + v + "\"" |> write stream
        | Choice2Of2 true -> " " + key |> write stream
        | Choice2Of2 false -> ()

    // TODO: Try to regularize indentation?
    // TODO: Add quotes for attribute values if necessary
    let rec printTemplate (stream: Stream) indent (fmt: FormattableString) =
        let strs = Text.RegularExpressions.Regex(@"\{\d+\}").Split(fmt.Format)
        let args = fmt.GetArguments()
        let lastStr = strs.Length - 1 
        for i = 0 to lastStr do
            strs.[i] |> write stream
            if i < lastStr then
                match args.[i] with
                | :? Node as node ->
                    match node with
                    | El(tag, nodes) -> printEl stream indent tag nodes
                    | _ -> () // TODO: other nodes
                | arg -> arg.ToString() |> write stream

    and printEl stream indent tag nodes =
        indented stream indent ("<" + tag)
        nodes |> List.iter (function Attr(k, v) -> printAttr stream k v | _ -> ())

        nodes
        |> List.tryPick (function Text s -> Some s | _ -> None)
        |> function
            // TODO: Fail if there's a text node and children is not empty?
            | Some str -> ">" + str + "</" + tag + ">" + Environment.NewLine |> write stream
            | None ->
                match getChildren nodes with
                | [] -> "></" + tag + ">" + Environment.NewLine |> write stream
                | children ->
                    ">" + Environment.NewLine |> write stream
                    children |> List.iter (function
                        | Choice1Of2(tag, nodes) -> printEl stream (indent + 1) tag nodes
                        | Choice2Of2 template -> printTemplate stream indent template
                    )
                    indented stream indent ("</" + tag + ">" + Environment.NewLine)

    nodes
    |> Seq.toList
    |> getChildren
    |> List.iter (function
        | Choice1Of2(tag, nodes) -> printEl stream 0 tag nodes
        | Choice2Of2 template -> printTemplate stream 0 template)

let toString (nodes: Node seq) =
    use stream = new MemoryStream()
    write stream nodes
    stream.Seek(0L, SeekOrigin.Begin) |> ignore
    let reader = new StreamReader(stream)
    reader.ReadToEnd()
