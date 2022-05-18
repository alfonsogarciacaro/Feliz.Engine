module App

open Browser
open Feliz
open Feliz.Solid
open Fable.Core.JS

let App() =
    let num, setNum = Solid.createSignal(0)
    let _ = setInterval (fun () -> num() + 1 % 255 |> setNum) 30

    Html.div [
        reactiveStyles(fun _ -> [
            Css.color $"rgb({num()}, 180, {num()})"
            Css.fontWeight 800
            Css.fontSize (length.px(num()))
        ])
        reactiveEl(fun _ -> Html.text $"Number is {num()}")
    ]

Solid.render(
    (fun () -> App() |> toSolid),
    document.getElementById("app-container"))