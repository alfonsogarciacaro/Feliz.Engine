module App

open Elmish
open Elmish.Snabbdom
open Elmish.Snabbdom.HMR

open Todos

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.mountWithId "app-container"
|> Program.run
