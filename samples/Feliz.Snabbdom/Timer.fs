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
    Disposable: IDisposable option
  }
  interface IDisposable with
    member this.Dispose() = this.Disposable |> Option.iter (fun d -> d.Dispose())

type InMsg =
  | Toggle of bool

type OutMsg =
  | Timeout

type Msg =
  | Tick
  | InMsg of InMsg
  | Subscribed of IDisposable

let init () =
  {
    StartedOrResumed = DateTime.Now
    Elapsed = TimeSpan.FromSeconds(0.)
    Timeout = TimeSpan.FromSeconds(5.)
    Active = true
    Finished = false
    Disposable = None
  }, []

let subscribe (obs: IObservable<InMsg>) _model = Cmd.ofSub <| fun dispatch ->
    let disp = obs.Subscribe(InMsg >> dispatch)
    let intervalId = JS.setInterval (fun _ -> dispatch Tick) 1000
    printfn "Set interval %i" intervalId

    { new IDisposable with
        member _.Dispose() =
          disp.Dispose()
          JS.clearInterval intervalId
          printfn "Clear interval %i" intervalId }
    |> Subscribed
    |> dispatch

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

  | Subscribed d ->
    { model with Disposable = Some d }, [], None

let view (model: Model) _dispatch =
  Html.p [
    Html.text (String.Format("{0:00}:{1:00}",
                floor model.Elapsed.TotalMinutes,
                 (floor model.Elapsed.TotalSeconds |> int) % 60))
  ]

let mkProgram (obs: IObservable<InMsg>) (dispatch: OutMsg -> unit) =
  let update msg model =
    let model, cmd, extMsg = update msg model
    extMsg |> Option.iter dispatch
    model, cmd

  Program.mkProgram init update view
  |> Program.withSubscription (subscribe obs)
