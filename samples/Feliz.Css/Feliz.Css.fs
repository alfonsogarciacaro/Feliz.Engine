module Feliz.Css

open Feliz

type Node =
    | Rule of connector: string * selector: string * Node list
    | Prop of key: string * value: string

let Css =
    CssEngine<Node>
        { new CssHelper<Node> with
            member _.MakeStyle(k, v) = Prop(k, v) }

let rule selector nodes =
    Rule(" ", selector, nodes)

let and' selector nodes =
    Rule("", selector, nodes)

let directChild selector nodes =
    Rule(" > ", selector, nodes)


let print (path: string) (nodes: Node seq) =
    let rec printRule (stream: Node.Fs.WriteStream<string>) selector nodes =
        stream.write(selector + " {" + Node.Api.os.EOL) |> ignore

        nodes |> List.iter (function
            | Prop(key, value) ->
                stream.write("    " + key + ": " + value + ";" + Node.Api.os.EOL) |> ignore
            | _ -> ())

        stream.write("}" + Node.Api.os.EOL + Node.Api.os.EOL) |> ignore

        nodes |> List.iter (function
            | Rule(connector, selector2, nodes) ->
                let selector = selector + connector + selector2
                printRule stream selector nodes
            | _ -> ())

    let stream = Node.Api.fs.createWriteStream(path)
    try
        nodes |> Seq.iter (function
            | Prop _ -> () // Error?
            | Rule(_, selector, nodes) -> // Error if connector is not " "?
                printRule stream selector nodes)
    finally
        stream.``end``()
