module App

open Feliz
open Feliz.Css

let bgColor = color.aliceBlue

seq {
    rule ".my-class" [
        Css.backgroundColor bgColor

        rule ".child" [
            Css.margin(length.em 1.2, length.px 25)
        ]

        directChild ".child" [
            Css.maxWidth 40
        ]

        and' ".another-class" [
            Css.flexDirection.rowReverse
        ]
    ]
}
|> print "./dist/styles.css"
