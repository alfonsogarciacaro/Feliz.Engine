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
      dimension: float*float
      offset: float*float }

let init() =
    let w = 100.
    let h = 100.
    let positionW = (window.innerWidth / 2.) - (w / 2.)
    let positionH = (window.innerHeight / 2.) - (h / 2.)
    { dragging = false
      dimension = w, h
      position = positionW, positionH
      offset = 0., 0. }

let update msg model =
    match model.dragging, msg with
    | true, MouseMove(x, y) -> { model with position=(x, y) }
    | true, MouseUp -> { model with dragging = false }

    | false, MouseDown(x, y, offsetX, offsetY) ->
        { model with dragging = true
                     position = (x, y)
                     offset = (offsetX, offsetY) }

    | _ -> model

let view (model: Model) dispatch =
    let left = fst model.position - fst model.offset
    let top = snd model.position - snd model.offset

    Svg.svg [
        Css.positionFixed
        Css.left(px left)
        Css.top(px top)

        Svg.rect [
            Css.fill color.limeGreen
            Attr.width(fst model.dimension |> px)
            Attr.height(snd model.dimension |> px)

            // Make sure the body height is 100% for this to work properly
            Hook.insert(fun _vnode ->
                Disposable.concat [
                    Disposable.make(fun _ -> printfn "Disposing")
                    BodyEv.onMouseMove (fun ev -> MouseMove(ev.x, ev.y) |> dispatch)
                    BodyEv.onMouseUp (fun _ -> MouseUp |> dispatch)
                ])

            Ev.onMouseDown (fun ev ->
                let rect = (ev.target :?> HTMLElement).getBoundingClientRect()
                MouseDown(ev.x, ev.y, ev.x - rect.left, ev.y - rect.top) |> dispatch
            )
        ]
    ]

let mkProgram() =
    Elmish.Program.mkSimple init update view
