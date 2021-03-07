module Leaflet

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser
open Browser.Types
open Feliz
open Feliz.Snabbdom
open type length

type Msg =
    | TogglePopup

type Model =
    { containerId: string
      isPopupOpen: bool }

let initMap(m: Model): (Model -> unit) = importMember "./leaflet.js"

let init() =
    { containerId = "map-container"
      isPopupOpen = true }

let update msg model =
    match msg with
    | TogglePopup -> { model with isPopupOpen = not model.isPopupOpen }

let view (model: Model) dispatch =
    Html.div [
        Html.div [
            Attr.id model.containerId
            Css.height 400
            Hook.subscribe(model, fun _vnode -> initMap model)
        ]

        Html.button [
            Attr.className "button"
            Ev.onClick (fun _ -> dispatch TogglePopup)
            Html.text $"""{if model.isPopupOpen then "Close" else "Open"} popup"""
        ]
    ]

let mkProgram() =
    Elmish.Program.mkSimple init update view
