module Snabbdom

open Fable.Core

type Module = interface end
type VirtualNode = interface end

type Patch = delegate of VirtualNode * VirtualNode -> unit

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
    static member inline AsNode(el: Browser.Types.HTMLElement) = unbox el
    static member Empty: VirtualNode = unbox null
    static member Text(str: string): VirtualNode = unbox str
    static member Patch(oldNode, newNode) = patcher.Invoke(oldNode, newNode)
