module App

open Elmish
open Elmish.Snabbdom
open Feliz
open Feliz.Snabbdom

type Tab =
    | Todos
    | Dragging
    | Leaflet

type Model =
    { CurrentTab: Tab }

type Msg =
    | UpdateTab of Tab

let init()=
    { CurrentTab = Todos }

let update msg model =
    match msg with
    | UpdateTab t -> { model with CurrentTab = t }

let tab model dispatch t =
    Html.li [
        Attr.classes [
            model.CurrentTab = t, "is-active"
        ]
        Html.a [
            Html.text (Fable.Core.Reflection.getCaseName t)
            Ev.onClick (fun ev ->
                ev.preventDefault()
                UpdateTab t |> dispatch
            )
        ]
    ]

let view model dispatch =
    Html.div [
        Attr.className "container"
        Css.marginTop 20

        Html.div [
            Attr.className "tabs"
            Html.ul [
                tab model dispatch Todos
                tab model dispatch Dragging
                tab model dispatch Leaflet
            ]
        ]

        match model.CurrentTab with
        // Make sure to use a different selector so the node is updated when the tab changes
        | Todos -> Program.importAndMountOnVNode "./Todos.fs.js" "div.todos"
        | Dragging -> Program.importAndMountOnVNode "./Dragging.fs.js" "div.dragging"
        | Leaflet -> Program.importAndMountOnVNode "./Leaflet.fs.js" "div.leaflet"
    ]

// When working on a specific module, you can initialize it directly to activate HMR
// open Elmish.Snabbdom.HMR
// open Dragging

Program.mkSimple init update view
// |> Program.withConsoleTrace
|> Program.mountWithId "app-container"
|> Program.run
