module Todos

open System
 open Browser.Types
open Elmish.Snabbdom
open Feliz
open Feliz.Snabbdom

type Todo = {
  Id : Guid
  Description : string
  Timeout : bool
  Completed : bool
}

type State = {
  TodoList: Todo list
  NewTodo : string
  Editing: (Guid * string) option
}

type Msg =
  | Timeout of Guid
  | SetNewTodo of string
  | AddNewTodo
  | DeleteTodo of Guid
  | ToggleCompleted of Guid
  | CancelEdit
  | ApplyEdit
  | StartEditingTodo of Guid
  | SetEditedDescription of string

let init() =
  {
    TodoList = [
      { Id = Guid.NewGuid(); Description = "Learn F#"; Completed = false; Timeout = false }
      { Id = Guid.NewGuid(); Description = "Learn Elmish"; Completed = true; Timeout = false }
    ]
    NewTodo = ""
    Editing = None
  }

let update (msg: Msg) (state: State) =
  match msg with
  | Timeout todoId ->
      state.TodoList |> List.map (fun todo ->
          if todo.Id = todoId
          then { todo with Timeout = true }
          else todo)
      |> fun todos -> { state with TodoList = todos }

  | SetNewTodo desc ->
      printfn "New todo %s" desc
      { state with NewTodo = desc }

  | AddNewTodo when String.IsNullOrWhiteSpace state.NewTodo ->
      state

  | AddNewTodo ->
      let nextTodo =
        { Id = Guid.NewGuid()
          Description = state.NewTodo
          Completed = true
          Timeout = false }

      { state with
          NewTodo = ""
          TodoList = nextTodo::state.TodoList }

  | DeleteTodo todoId ->
      state.TodoList
      |> List.filter (fun todo -> todo.Id <> todoId)
      |> fun todos -> { state with TodoList = todos }

  | ToggleCompleted todoId ->
      state.TodoList
      |> List.map (fun todo -> if todo.Id = todoId then { todo with Completed = not todo.Completed } else todo)
      |> fun todos -> { state with TodoList = todos }

  | StartEditingTodo todoId ->
      state.TodoList
      |> List.tryFind (fun t -> t.Id = todoId)
      |> Option.map (fun t -> t.Id, t.Description)
      |> fun editing -> { state with Editing = editing }

  | CancelEdit ->
      { state with Editing = None }

  | ApplyEdit ->
      match state.Editing with
      | None -> state
      | Some(todoId, desc) ->
        state.TodoList |> List.map (fun todo ->
            if todo.Id = todoId
            then { todo with Description = desc }
            else todo)
        |> fun todos -> { state with Editing = None; TodoList = todos }

  | SetEditedDescription newText ->
      { state with Editing = state.Editing |> Option.map (fun (id,_) -> id, newText) }

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

let level leftItems rightItems =
  div ["level"] [
    div ["level-left"]
      (leftItems |> List.map (fun i -> div ["level-item"] [i]))
    div ["level-right"]
      (rightItems |> List.map (fun i -> div ["level-item"] [i]))
  ]

let appTitle (_: State) _dispatch =
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

let renderTodo dispatch (todo: Todo, editing: string option) =
  printfn $"Rendering todo {todo.Description}, editing: {Option.isSome editing}"
  Html.li [
    Attr.className "box"

    Css.backgroundColor (if todo.Timeout
      then color.red
      else color.transparent)

    Css.opacity 0.
    Css.transformScale 1.5
    // Snabbdom doesn't support `all`, we need to list all the transitioning properties
    Css.transitionProperty(
      transitionProperty.opacity,
      transitionProperty.transform
    )
    Css.transitionDurationSeconds 0.5
    Css.delayed [
      Css.opacity 1.
      Css.transformScale 1.
    ]
    Css.remove [
      Css.opacity 0.
      Css.transformScale 0.1
    ]

    match editing with
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
          div [ "column" ] [
              level [
                Html.p [
                  Css.userSelectNone
                  Css.cursorPointer
                  Attr.className "subtitle"
                  Html.text todo.Description
                  Ev.onDblClick (fun _ -> dispatch (StartEditingTodo todo.Id))
                ]
              ] [
                Timer.mount
                  (fun Timer.Timeout -> Timeout todo.Id |> dispatch)
                  (not todo.Completed) // Timer is only active when item is not completed
              ]
          ]

          div [ "column"; "is-narrow" ] [
              Html.button [
                  Attr.classes [ true, "button"; todo.Completed, "is-success"]
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
  Html.ul (
    state.TodoList
    |> List.map (fun todo ->
      todo,
      state.Editing |> Option.bind (fun (i,e) -> if i = todo.Id then Some e else None))
    |> List.map (memoizeWithId (renderTodo dispatch) (fun (t,_) -> t.Id))
  )

let view (state: State) (dispatch: Msg -> unit) =
  Html.div [
    Css.margin(length.zero, length.auto)
    Css.maxWidth 800
    Css.padding 20

    appTitle state dispatch
    inputField state dispatch
    todoList state dispatch
  ]
