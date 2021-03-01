module Timer

open System
open Fable.Core
open Feliz.Snabbdom

type Model =
  {
    StartedOrResumed: DateTime
    Elapsed: TimeSpan
    Timeout: TimeSpan
    Active: bool
    Finished: bool
  }

type InMsg =
  | Toggle of bool

type OutMsg =
  | Timeout

type Msg =
  | Tick
  | InMsg of InMsg

let update msg (model: Model) =
  match msg with
  | Tick ->
    if model.Active then
      let model = { model with Elapsed = DateTime.Now - model.StartedOrResumed }
      if not model.Finished && model.Elapsed > model.Timeout then
        { model with Finished = true }, [], Some Timeout
      else
        model, [], None
    else
      model, [], None

  | InMsg(Toggle v) ->
    if v then { model with Active = true; StartedOrResumed = DateTime.Now }, [], None
    else { model with Active = false }, [], None

let view (model: Model) =
  Html.p [
    Html.text (String.Format("{0:00}:{1:00}",
                floor model.Elapsed.TotalMinutes,
                 (floor model.Elapsed.TotalSeconds |> int) % 60))
  ]

let mkStore (obs: IObservable<InMsg>) (extDispatch: OutMsg -> unit) =
  let dispatch = ref Unchecked.defaultof<_>
  let disposable = ref Unchecked.defaultof<_>

  let init () =
    let disp = obs.Subscribe(InMsg >> dispatch.Value)
    let intervalId = JS.setInterval (fun _ -> dispatch.Value Tick) 1000
    printfn "Set interval %i" intervalId

    disposable :=
      { new IDisposable with
          member _.Dispose() =
            disp.Dispose()
            JS.clearInterval intervalId
            printfn "Clear interval %i" intervalId }
    {
      StartedOrResumed = DateTime.Now
      Elapsed = TimeSpan.FromSeconds(0.)
      Timeout = TimeSpan.FromSeconds(5.)
      Active = true
      Finished = false
    }, []

  let update msg model =
    let model, cmd, extMsg = update msg model
    extMsg |> Option.iter extDispatch
    model, cmd

  let store, d = Store.makeElmish init update (fun _ ->
    disposable.Value.Dispose()) ()
  dispatch := d
  store, view
