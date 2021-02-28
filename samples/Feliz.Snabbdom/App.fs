module App

open Elmish
open Elmish.Snabbdom

open Todos

Program.mkSimple init update view
|> Program.mountWithId "app-container"
|> Program.run
