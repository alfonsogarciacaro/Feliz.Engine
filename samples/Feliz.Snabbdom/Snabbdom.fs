module Snabbdom

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser.Types

type Module = interface end
type VirtualNode = interface end

type Patch = delegate of HTMLElement * VirtualNode -> unit

[<ImportMember("snabbdom/modules/attributes")>]
let attributesModule: Module = jsNative

[<ImportMember("snabbdom/modules/style")>]
let styleModule: Module = jsNative

[<ImportMember("snabbdom/modules/eventlisteners")>]
let eventListenersModule: Module = jsNative

[<ImportMember("snabbdom/h")>]
let h(tag: string, props: obj, children: ResizeArray<VirtualNode>): VirtualNode = jsNative

[<ImportMember("snabbdom/init")>]
let init(modules: Module[]): Patch = jsNative

type Helper() =
    static let patcher = init [|
        attributesModule
        styleModule
        eventListenersModule
    |]
    static member Empty: VirtualNode = unbox null
    static member Text(str: string): VirtualNode = unbox str
    static member Patch(el, vnode) = patcher.Invoke(el, vnode)
