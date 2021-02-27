module App

open Feliz
open Feliz.Css

let myColor = color.rebeccaPurple

seq {
    rule ".my-class" [
        Css.backgroundColor myColor

        rule ".child" [
            Css.margin(length.em 1.2, length.px 25)
        ]

        directChild ".child" [
            Css.maxWidth 40
            Css.color myColor
            Css.borderRadius 5
        ]

        and' ".another-class" [
            Css.flexDirectionColumn
        ]
    ]
}
|> print "./dist/styles.css"
