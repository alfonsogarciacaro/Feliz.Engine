module App

open Feliz
open Feliz.StaticHtml

[
    Html.div [
        Html.h1 "1"
        Html.button [
            Attr.classes [
                true, "my-button"
                false, "is-active"
            ]
            Html.text "Increment"
        ]
        Html.input [
            Attr.type' "checkbox"
            Attr.isChecked true
            Html.text "Check me!"
        ]

    ]
]
|> print "./dist/index.html"
