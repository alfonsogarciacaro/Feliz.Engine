module Timer

open System
open Fable.Core
open Elmish
open Elmish.Snabbdom
open Feliz.Snabbdom

type Model =
  {
    StartedOrResumed: DateTime
    Elapsed: TimeSpan
    Timeout: TimeSpan
    Active: bool
    Finished: bool
  }

type ExtMsg =
  | Timeout

type Msg =
  | Tick
  | Toggle of active: bool

let init active =
  {
    StartedOrResumed = DateTime.Now
    Elapsed = TimeSpan.FromSeconds(0.)
    Timeout = TimeSpan.FromSeconds(5.)
    Active = active
    Finished = false
  }

let update msg (model: Model) =
  match msg with
  | Tick ->
    if model.Active then
      let model = { model with Elapsed = DateTime.Now - model.StartedOrResumed }
      if not model.Finished && model.Elapsed > model.Timeout then
        { model with Finished = true }, Some Timeout
      else
        model, None
    else
      model, None

  | Toggle v ->
    if v = model.Active then model, None
    elif v then { model with Active = true
                             Finished = false
                             StartedOrResumed = DateTime.Now
                             Elapsed = TimeSpan.FromSeconds(0.) }, None
    else { model with Active = false }, None

let view (model: Model) dispatch =
  Html.p [
    Hook.insert(fun _ ->
      let intervalId = JS.setInterval (fun _ -> dispatch Tick) 1000
      printfn "Set interval %i" intervalId

      Disposable.make(fun () ->
        JS.clearInterval intervalId
        printfn "Clear interval %i" intervalId))

    Html.text (String.Format("{0:00}:{1:00}",
                floor model.Elapsed.TotalMinutes,
                 (floor model.Elapsed.TotalSeconds |> int) % 60))
  ]

let mkProgram (dispatch: ExtMsg -> unit) =
  let update msg model =
    let model, extMsg = update msg model
    extMsg |> Option.iter dispatch
    model

  Program.mkSimple init update view
  |> Program.withSetNewArg Toggle
