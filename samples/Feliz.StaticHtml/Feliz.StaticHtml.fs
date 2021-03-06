﻿module Feliz.StaticHtml

open Feliz

type Node =
    | El of tag: string * Node list
    | Attr of key: string * value: Choice<string, bool>
    | Fragment of Node list
    | Text of string

let Html = HtmlEngine((fun tag nodes -> El(tag, List.ofSeq nodes)), Text, (fun () -> Fragment []))

let Attr = AttrEngine((fun k v -> Attr(k, Choice1Of2 v)), (fun k v -> Attr(k, Choice2Of2 v)))

let print (path: string) (nodes: Node seq) =
    let indented (stream: Node.Fs.WriteStream<string>) indent str =
        stream.write(String.replicate (indent * 4) " " + str) |> ignore

    let rec getChildren nodes =
        nodes |> List.collect (function
            | El(tag, nodes) -> [tag, nodes]
            // TODO: Fail if Attr found in fragment?
            // TODO: Try pick text node in fragment?
            | Fragment nodes -> getChildren nodes
            | _ -> [])

    let printAttr (stream: Node.Fs.WriteStream<string>) key value =
        match value with
        | Choice1Of2 v -> stream.write(" " + key + "=\"" + v + "\"") |> ignore
        | Choice2Of2 true -> stream.write(" " + key) |> ignore
        | Choice2Of2 false -> ()

    let rec printEl stream indent tag nodes =
        indented stream indent ("<" + tag)
        nodes |> List.iter (function Attr(k, v) -> printAttr stream k v | _ -> ())

        nodes
        |> List.tryPick (function Text s -> Some s | _ -> None)
        |> function
            // TODO: Fail if there's a text node and children is not empty?
            | Some str -> stream.write(">" + str + "</" + tag + ">" + Node.Api.os.EOL) |> ignore
            | None ->
                match getChildren nodes with
                | [] -> stream.write("></" + tag + ">" + Node.Api.os.EOL) |> ignore
                | children ->
                    stream.write(">" + Node.Api.os.EOL) |> ignore
                    children |> List.iter (fun (tag, nodes) -> printEl stream (indent + 1) tag nodes)
                    indented stream indent ("</" + tag + ">" + Node.Api.os.EOL)

    let stream = Node.Api.fs.createWriteStream(path)
    try
        nodes
        |> Seq.toList
        |> getChildren
        |> List.iter (fun (tag, nodes) -> printEl stream 0 tag nodes)
    finally
        stream.``end``()
