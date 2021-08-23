module App

open Feliz
open Feliz.StaticHtml

let circleFill = "#0B79CE"

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

        html $"""
    <svg viewBox="0 0 100 100"
         width="350px">

      <circle
        cx="50"
        cy="50"
        r="45"
        fill="{circleFill}"></circle>

      {Svg.circle [
          Attr.cx 50
          Attr.cy 50
          Attr.r 3
          Attr.fill circleFill
          Attr.stroke "#023963"
          Attr.strokeWidth 1
      ]}
    </svg>
"""
    ]
]
|> toString
|> printfn "%s"
