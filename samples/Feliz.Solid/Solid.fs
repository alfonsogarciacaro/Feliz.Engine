namespace global

open Fable.Core

type SolidElement =
    interface end

type Solid =
    [<ImportDefault("solid-js/h")>]
    static member h(tag: string, attrs: obj, [<ParamSeq>] children: SolidElement seq): SolidElement = jsNative
    
    static member inline text(text: string): SolidElement = unbox text
    static member inline fragment(els: SolidElement[]): SolidElement = unbox els
    
    [<ImportMember("solid-js/web")>]
    static member render(f: unit -> SolidElement, el: Browser.Types.Element): unit = jsNative

    [<ImportMember("solid-js")>]
    static member createSignal(value: 'T): (unit -> 'T) * ('T -> unit) = jsNative
