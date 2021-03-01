module App

open Todos

mkStore ()
|> SnabbdomStore.mountWithId "app-container"
|> ignore