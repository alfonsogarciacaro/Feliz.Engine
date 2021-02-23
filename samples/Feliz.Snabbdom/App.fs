module App

open Feliz
open Feliz.Snabbdom

let app =
    Html.div [
        Html.h1 "1"
        Html.button [
            Attr.className "my-button"
            Html.text "Increment"
        ]
        Html.input [
            Attr.type' "checkbox"
            Attr.isChecked true
            Html.text "Check me!"
        ]

    ]

open Browser

let el = document.getElementById("app-container")
Snabbdom.Helper.Patch(el, app.VNode)