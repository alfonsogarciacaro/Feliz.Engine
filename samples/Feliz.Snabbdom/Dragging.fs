module Dragging

open Browser
open Browser.Types
open Feliz
open Feliz.Snabbdom
open type length

type Msg =
    | MouseDown of x:float * y:float * offsetX:float * offsetY:float
    | MouseMove of x:float * y:float
    | MouseUp

type Model =
    { dragging: bool
      position: float*float
      offset: float*float }

let init() =
    { dragging = false
      position = (0., 0.)
      offset = (0., 0.) }

let update msg model =
    match model.dragging, msg with
    | true, MouseMove(x, y) -> { model with position=(x, y) }
    | true, MouseUp -> { model with dragging = false }

    | false, MouseDown(x, y, offsetX, offsetY) ->
        { dragging = true
          position = (x, y)
          offset = (offsetX, offsetY) }

    | _ -> model

let bodyEvents events =
    events |> List.iter (function
        | Event(e, fn) -> document.body.addEventListener(e, unbox fn)
        | _ -> ())

let view (model: Model) dispatch =
    let left = fst model.position - fst model.offset
    let top = snd model.position - snd model.offset
    Svg.svg [
        // Add mouse move/up events to page body because sometimes cursor leaves
        // the boundaries of the rectangle while dragging
        Hook.insert (fun _ ->
            bodyEvents [
                Ev.onMouseMove (fun ev -> MouseMove(ev.x, ev.y) |> dispatch)
                Ev.onMouseUp (fun _ -> MouseUp |> dispatch)
            ]
        )

        Css.positionFixed
        Css.left(px left)
        Css.top(px top)

        Svg.rect [
            Attr.width 100
            Attr.height 100

            Css.fill(color.rgb(0,255,33))

            // Ev.onMouseMove (fun ev -> MouseMove(ev.x, ev.y) |> dispatch)
            // Ev.onMouseUp (fun _ -> MouseUp |> dispatch)

            Ev.onMouseDown (fun ev ->
                let rect = (ev.target :?> HTMLElement).getBoundingClientRect()
                MouseDown(ev.x, ev.y, ev.x - rect.left, ev.y - rect.top) |> dispatch
            )
        ]
    ]
