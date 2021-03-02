# Feliz.Engine

Feliz.Engine provides an abstract API based on the great work by Zaid Ajaj and contributors with [Feliz](https://zaid-ajaj.github.io/Feliz/) that can be implemented for different applications using F# to declare HTML interfaces, either with Fable or .NET. See the `samples` directory for some use cases.

The main differences with Feliz are:

- Feliz exposes the API using static types that can be opened with the new `open type` declaration in F# 5. The implementations of Feliz.Engine will expose the API through values, which must be always qualified as in `Html.div` (some specific types like `length` can still be opened).

- Feliz.Engine uses generics for the return types, so they depend on the specific implementations. It's possible that what React understand as props and children are implemented using the same type, for example, so they can appear in the same list as in:

```fsharp
Html.p [
    Attr.className "subtitle"

    Css.userSelectNone
    Css.cursorPointer
    Css.margin(px 8, zero)

    Html.text todo.Description
    Ev.onDblClick (fun _ -> dispatch (StartEditingTodo todo.Id))
]
```

- For styles and attributes that accept specific values, Feliz provides specific types in a clever way that lets you dot into the properties, as in `css.cursor.pointer`. In Feliz.Engine, all the helpers belong to the same type so camelCase is used instead: `Css.cursorPointer`.

- For styles, Feliz provides multiple overloads so you can also fit an `int` or `float` wherever a CSS unit is expected (defaulting to pixels). For easier maintenance, Feliz.Engine removes most of these overloads prefering `ICssUnit` through the `length` helpers.