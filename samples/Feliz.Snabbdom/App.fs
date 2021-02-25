module App

open System

type Todo = {
  Id : Guid
  Description : string
  Completed : bool
}

type TodoBeingEdited = {
  Id: Guid
  Description: string
}

type State = {
  TodoList: Todo list
  NewTodo : string
  TodoBeingEdited : TodoBeingEdited option
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
    { Id = Guid.NewGuid(); Description = "Learn F#"; Completed = false }
    { Id = Guid.NewGuid(); Description = "Learn Elmish"; Completed = true }
  ]
  NewTodo = ""
  TodoBeingEdited = None
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
          Completed = false }

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
      let nextEditModel =
        state.TodoList
        |> List.tryFind (fun todo -> todo.Id = todoId)
        |> Option.map (fun todo -> { Id = todoId; Description = todo.Description })

      { state with TodoBeingEdited = nextEditModel }

  | CancelEdit ->
      { state with TodoBeingEdited = None }

  | ApplyEdit ->
      match state.TodoBeingEdited with
      | None -> state
      | Some todoBeingEdited when todoBeingEdited.Description = "" -> state
      | Some todoBeingEdited ->
          let nextTodoList =
            state.TodoList
            |> List.map (fun todo ->
                if todo.Id = todoBeingEdited.Id
                then { todo with Description = todoBeingEdited.Description }
                else todo)

          { state with TodoList = nextTodoList; TodoBeingEdited = None }

  | SetEditedDescription newText ->
      let nextEditModel =
        state.TodoBeingEdited
        |> Option.map (fun todoBeingEdited -> { todoBeingEdited with Description = newText })

      { state with TodoBeingEdited = nextEditModel }

open Feliz
open Feliz.Snabbdom

// Helper function to easily construct div with only classes and children
let div (classes: string list) (children: Node list) =
    Html.div((Attr.classes classes)::children)

let appTitle =
    Html.p [
      Attr.className "title"
      Html.text "Elmish To-Do List"
    ]

let inputField (state: State) (dispatch: Msg -> unit) =
  div [ "field"; "has-addons" ] [
   div [ "control"; "is-expanded" ] [
      Html.input [
        Attr.classes [ "input"; "is-medium" ]
        Attr.value state.NewTodo
        Ev.onTextChange (SetNewTodo >> dispatch)
        Ev.onKeyUp (fun ev ->
          let el = ev.target :?> Browser.Types.HTMLInputElement
          match ev.key with
          | "Enter" ->
            dispatch AddNewTodo
            el.value <- ""
          | "Escape" ->
            SetNewTodo "" |> dispatch
            el.value <- ""
            el.blur()
          | _ -> ())
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

let renderTodo (todo: Todo) (dispatch: Msg -> unit) =
  Html.li [
    key todo.Id
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

    div [ "columns"; "is-mobile"; "is-vcentered" ] [
        div [ "column"; "subtitle"] [
            Html.p [
              Attr.className "subtitle"
              Html.text todo.Description
              Ev.onDblClick (fun _ -> dispatch (StartEditingTodo todo.Id))
            ]
        ]

        div [ "column"; "is-narrow" ] [
            div [ "buttons" ] [
                Html.button [
                    Attr.classes  [ true, "button"; todo.Completed, "is-success"]
                    Ev.onClick (fun _ -> dispatch (ToggleCompleted todo.Id))
                    Html.i [ Attr.classes [ "fa"; "fa-check" ] ]
                ]
            ]

            Html.button [
                Css.marginRight (length.px 5)
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


let renderEditForm (todoBeingEdited: TodoBeingEdited) (dispatch: Msg -> unit) =
  div [ "box" ] [
    div [ "field is-grouped" ] [
      div [ "control is-expanded" ] [
        Html.input [
          Attr.classes [ "input"; "is-medium" ]
          Attr.value todoBeingEdited.Description
          Ev.onTextChange (SetEditedDescription >> dispatch)
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
  ]

let todoList (state: State) (dispatch: Msg -> unit) =
  Html.ul [
      for todo in state.TodoList ->
        match state.TodoBeingEdited with
        | Some todoBeingEdited when todoBeingEdited.Id = todo.Id ->
            renderEditForm todoBeingEdited dispatch
        | _otherwise ->
            renderTodo todo dispatch
  ]

let view (state: State) (dispatch: Msg -> unit) =
  Html.div [
    Css.margin(length.zero, length.auto)
    Css.maxWidth 800
    Css.padding 20
    appTitle
    inputField state dispatch
    todoList state dispatch
  ]

Elmish.app "app-container" init update view
