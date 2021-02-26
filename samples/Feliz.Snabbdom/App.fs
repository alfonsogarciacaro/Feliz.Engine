module App

open System

module Clock =
  type Model = { DateTime: DateTime }

  type Msg = Tick

  let init () =
    { DateTime = DateTime.Now }

  let update msg model =
    match msg with
    | Tick -> { DateTime = DateTime.Now }

  open Fable.Core
  open Feliz.Snabbdom

  let view model dispatch =
    Html.p [
      Hook.insert (fun n ->
        let id = JS.setInterval (fun _ -> dispatch Tick) 1000
        n.elm.dataset.["interval"] <- string id)

      Hook.destroy (fun n ->
        n.elm.dataset.["interval"] |> int |> JS.clearInterval)

      Html.text (model.DateTime.ToString("HH:mm:ss"))
    ]

  let mount () =
    Html.div [
      Hook.insert (Elmish.mount init update view)
    ]

type Todo = {
  Id : Guid
  Description : string
  Completed : bool
  Editing : string option
}

type State = {
  TodoList: Todo list
  NewTodo : string
}

type Msg =
  | SetNewTodo of string
  | AddNewTodo
  | DeleteTodo of Guid
  | ToggleCompleted of Guid
  | CancelEdit
  | ApplyEdit
  | StartEditingTodo of Guid
  | SetEditedDescription of string


let init() = {
  TodoList = [
    { Id = Guid.NewGuid(); Description = "Learn F#"; Completed = false; Editing = None }
    { Id = Guid.NewGuid(); Description = "Learn Elmish"; Completed = true; Editing = None }
  ]
  NewTodo = ""
}

let update (msg: Msg) (state: State) =
  match msg with
  | SetNewTodo desc ->
      { state with NewTodo = desc }

  | AddNewTodo when String.IsNullOrWhiteSpace state.NewTodo ->
      state

  | AddNewTodo ->
      let nextTodo =
        { Id = Guid.NewGuid()
          Description = state.NewTodo
          Completed = false
          Editing = None }

      { state with
          NewTodo = ""
          TodoList = nextTodo::state.TodoList }

  | DeleteTodo todoId ->
      let nextTodoList =
        state.TodoList
        |> List.filter (fun todo -> todo.Id <> todoId)

      { state with TodoList = nextTodoList }

  | ToggleCompleted todoId ->
      let nextTodoList =
        state.TodoList
        |> List.map (fun todo ->
           if todo.Id = todoId
           then { todo with Completed = not todo.Completed }
           else todo)

      { state with TodoList = nextTodoList }

  | StartEditingTodo todoId ->
      let todos = state.TodoList |> List.map (fun t ->
        { t with Editing = if t.Id = todoId then Some t.Description else None })
      { state with TodoList = todos }

  | CancelEdit ->
      let todos = state.TodoList |> List.map (fun t -> { t with Editing = None })
      { state with TodoList = todos }

  | ApplyEdit ->
      let todos = state.TodoList |> List.map (fun t ->
        match t.Editing with
        | None -> t
        | Some d -> { t with Description = d; Editing = None })
      { state with TodoList = todos }

  | SetEditedDescription newText ->
      let todos = state.TodoList |> List.map (fun t ->
        { t with Editing = t.Editing |> Option.map (fun _ -> newText) })
      { state with TodoList = todos }

open Browser.Types
open Feliz
open Feliz.Snabbdom

// Helper function to easily construct div with only classes and children
let div (classes: string list) (children: Node list) =
    Html.div((Attr.classes classes)::children)

let onEnterOrEscape dispatch onEnterMsg onEscapeMsg =
    Ev.onKeyUp (fun ev ->
      let el = ev.target :?> HTMLInputElement
      match ev.key with
      | "Enter" ->
        dispatch onEnterMsg
        el.value <- ""
      | "Escape" ->
        dispatch onEscapeMsg
        el.value <- ""
        el.blur()
      | _ -> ())

let appTitle() =
  div ["level"] [
    div ["level-left"] [
      div ["level-item"] [
        Html.p [
          Attr.className "title"
          Html.text "Elmish To-Do List"
        ]
      ]
    ]
    div ["level-right"] [
      div ["level-item"] [
        Clock.mount()
      ]
    ]
  ]

let inputField (state: State) (dispatch: Msg -> unit) =
  div [ "field"; "has-addons" ] [
   div [ "control"; "is-expanded" ] [
      Html.input [
        Attr.classes [ "input"; "is-medium" ]
        Attr.value state.NewTodo
        Ev.onTextChange (SetNewTodo >> dispatch)
        onEnterOrEscape dispatch AddNewTodo (SetNewTodo "")
      ]
    ]

   div [ "control" ] [
      Html.button [
        Attr.classes [ "button"; "is-primary"; "is-medium" ]
        Ev.onClick (fun _ -> dispatch AddNewTodo)
        Html.i [ Attr.classes [ "fa"; "fa-plus" ] ]
      ]
    ]
  ]

let renderTodo dispatch (todo: Todo) =
  printfn $"Rendering todo {todo.Description}"
  Html.li [
    Attr.className "box"
    Css.opacity 0.
    Css.transform.scale 1.5
    // Snabbdom doesn't support `all`, we need to list all the transitioning properties
    Css.transition "opacity 0.5s, transform 0.5s"
    Css.delayed [
      Css.opacity 1.
      Css.transform.scale 1.
    ]
    Css.remove [
      Css.opacity 0.
      Css.transform.scale 0.1
    ]

    match todo.Editing with
    | Some editing ->
      div [ "field is-grouped" ] [
        div [ "control is-expanded" ] [
          Html.input [
            Attr.classes [ "input"; "is-medium" ]
            Attr.value editing
            Ev.onTextChange (SetEditedDescription >> dispatch)
            onEnterOrEscape dispatch ApplyEdit CancelEdit
            Hook.insert (fun vnode ->
              let el = vnode.elm :?> HTMLInputElement
              el.select()
            )
          ]
        ]

        div [ "control"; "buttons" ] [
          Html.button [
            Attr.classes [ "button"; "is-primary"]
            Ev.onClick (fun _ -> dispatch ApplyEdit)
            Html.i [ Attr.classes ["fa"; "fa-save" ] ]
          ]

          Html.button [
            Attr.classes ["button"; "is-warning"]
            Ev.onClick (fun _ -> dispatch CancelEdit)
            Html.i [ Attr.classes ["fa"; "fa-arrow-right"] ]
          ]
        ]
      ]

    | None ->
      div [ "columns"; "is-mobile"; "is-vcentered" ] [
          div [ "column"; "subtitle"] [
              Html.p [
                Css.userSelect.none
                Css.cursor.pointer
                Attr.className "subtitle"
                Html.text todo.Description
                Ev.onDblClick (fun _ -> dispatch (StartEditingTodo todo.Id))
              ]
          ]

          div [ "column"; "is-narrow" ] [
              Html.button [
                  Attr.classes  [ true, "button"; todo.Completed, "is-success"]
                  Ev.onClick (fun _ -> dispatch (ToggleCompleted todo.Id))
                  Html.i [ Attr.classes [ "fa"; "fa-check" ] ]
              ]

              Html.button [
                  Css.margin(length.zero, length.px 5)
                  Attr.classes [ "button"; "is-primary" ]
                  Ev.onClick (fun _ -> dispatch (StartEditingTodo todo.Id))
                  Html.i [ Attr.classes [ "fa"; "fa-edit" ] ]
              ]

              Html.button [
                  Attr.classes [ "button"; "is-danger" ]
                  Ev.onClick (fun _ -> dispatch (DeleteTodo todo.Id))
                  Html.i [ Attr.classes [ "fa"; "fa-times" ] ]
              ]
          ]
      ]
  ]

let todoList (state: State) (dispatch: Msg -> unit) =
  Html.ul (state.TodoList |> List.map (memoize (renderTodo dispatch)))

let view (state: State) (dispatch: Msg -> unit) =
  Html.div [
    Css.margin(length.zero, length.auto)
    Css.maxWidth 800
    Css.padding 20
    appTitle()
    inputField state dispatch
    todoList state dispatch
  ]

Elmish.app "app-container" init update view
