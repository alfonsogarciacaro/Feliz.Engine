module Snabbdom

open System
open Fable.Core

type Module = interface end

type VNode =
    abstract sel: string
    abstract key: string
    abstract data: obj
    abstract children: VNode[]
    abstract text: string
    abstract elm: Browser.Types.HTMLElement

type Patch = delegate of VNode * VNode -> unit

[<ImportMember("snabbdom/modules/attributes")>]
let attributesModule: Module = jsNative

[<ImportMember("snabbdom/modules/style")>]
let styleModule: Module = jsNative

[<ImportMember("snabbdom/modules/eventlisteners")>]
let eventListenersModule: Module = jsNative

[<ImportMember("snabbdom/h")>]
let h(tag: string, props: obj, children: ResizeArray<VNode>): VNode = jsNative

[<ImportMember("snabbdom/init")>]
let init(modules: Module[]): Patch = jsNative

// [<ImportMember("snabbdom/thunk")>]
[<ImportMember("./thunk")>]
let thunk(sel: string, key: Guid, fn: obj, args: obj[]): VNode = jsNative

type Helper() =
    static let patcher = init [|
        attributesModule
        styleModule
        eventListenersModule
    |]
    static member inline AsNode(el: Browser.Types.HTMLElement) = unbox el
    static member Empty: VNode = unbox null
    static member Text(str: string): VNode = unbox str
    static member Patch(oldNode, newNode) = patcher.Invoke(oldNode, newNode)
    static member Thunk(sel: string, key: Guid, renderFn: obj, stateArgs: obj[]) = thunk(sel, key, renderFn, stateArgs)
