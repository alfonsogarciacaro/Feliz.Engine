namespace Feliz

open System

type HtmlHelper<'El, 'Prop> =
    abstract MakeEl: string * 'Prop seq -> 'El
    abstract ChildrenToProp: 'El seq -> 'Prop
    abstract StringToEl: string -> 'El
    abstract IntToEl: int -> 'El
    abstract FloatToEl: float -> 'El
    abstract BoolToEl: bool -> 'El
    abstract EmptyEl: 'El

module internal HtmlHelperExtensions =
    type HtmlHelper<'El, 'Prop> with
        member this.MakeElWithChildren(tag, children) =
            this.MakeEl(tag, [this.ChildrenToProp children])
        member this.MakeElWithChild(tag, child) =
            this.MakeElWithChildren(tag, [child])
        member this.MakeElWithChild(tag, v) =
            this.MakeElWithChildren(tag, [this.StringToEl v])
        member this.MakeElWithChild(tag, v) =
            this.MakeElWithChildren(tag, [this.IntToEl v])
        member this.MakeElWithChild(tag, v) =
            this.MakeElWithChildren(tag, [this.FloatToEl v])
        member this.MakeElWithChild(tag, v) =
            this.MakeElWithChildren(tag, [this.BoolToEl v])

open HtmlHelperExtensions

type HtmlEngine<'El, 'Prop>(h: HtmlHelper<'El, 'Prop>) =
    member _.a xs = h.MakeEl("a", xs)
    member _.a (children: seq<'El>) = h.MakeElWithChildren("a", children)

    member _.abbr xs = h.MakeEl("abbr", xs)
    member _.abbr (value: float) = h.MakeElWithChild("abbr", value)
    member _.abbr (value: int) = h.MakeElWithChild("abbr", value)
    member _.abbr (value: 'El) = h.MakeElWithChild("abbr", value)
    member _.abbr (value: string) = h.MakeElWithChild("abbr", value)
    member _.abbr (children: seq<'El>) = h.MakeElWithChildren("abbr", children)

    member _.address xs = h.MakeEl("address", xs)
    member _.address (value: float) = h.MakeElWithChild("address", value)
    member _.address (value: int) = h.MakeElWithChild("address", value)
    member _.address (value: 'El) = h.MakeElWithChild("address", value)
    member _.address (value: string) = h.MakeElWithChild("address", value)
    member _.address (children: seq<'El>) = h.MakeElWithChildren("address", children)

    member _.anchor xs = h.MakeEl("a", xs)
    member _.anchor (children: seq<'El>) = h.MakeElWithChildren("a", children)

    member _.animate xs = h.MakeEl("animate", xs)

    member _.animateMotion xs = h.MakeEl("animateMotion", xs)
    member _.animateMotion (children: seq<'El>) = h.MakeElWithChildren("animateMotion", children)

    member _.animateTransform xs = h.MakeEl("animateTransform", xs)
    member _.animateTransform (children: seq<'El>) = h.MakeElWithChildren("animateTransform", children)

    member _.area xs = h.MakeEl("area", xs)

    member _.article xs = h.MakeEl("article", xs)
    member _.article (children: seq<'El>) = h.MakeElWithChildren("article", children)

    member _.aside xs = h.MakeEl("aside", xs)
    member _.aside (children: seq<'El>) = h.MakeElWithChildren("aside", children)

    member _.audio xs = h.MakeEl("audio", xs)
    member _.audio (children: seq<'El>) = h.MakeElWithChildren("audio", children)

    member _.b xs = h.MakeEl("b", xs)
    member _.b (value: float) = h.MakeElWithChild("b", value)
    member _.b (value: int) = h.MakeElWithChild("b", value)
    member _.b (value: 'El) = h.MakeElWithChild("b", value)
    member _.b (value: string) = h.MakeElWithChild("b", value)
    member _.b (children: seq<'El>) = h.MakeElWithChildren("b", children)

    member _.base' xs = h.MakeEl("base", xs)

    member _.bdi xs = h.MakeEl("bdi", xs)
    member _.bdi (value: float) = h.MakeElWithChild("bdi", value)
    member _.bdi (value: int) = h.MakeElWithChild("bdi", value)
    member _.bdi (value: 'El) = h.MakeElWithChild("bdi", value)
    member _.bdi (value: string) = h.MakeElWithChild("bdi", value)
    member _.bdi (children: seq<'El>) = h.MakeElWithChildren("bdi", children)

    member _.bdo xs = h.MakeEl("bdo", xs)
    member _.bdo (value: float) = h.MakeElWithChild("bdo", value)
    member _.bdo (value: int) = h.MakeElWithChild("bdo", value)
    member _.bdo (value: 'El) = h.MakeElWithChild("bdo", value)
    member _.bdo (value: string) = h.MakeElWithChild("bdo", value)
    member _.bdo (children: seq<'El>) = h.MakeElWithChildren("bdo", children)

    member _.blockquote xs = h.MakeEl("blockquote", xs)
    member _.blockquote (value: float) = h.MakeElWithChild("blockquote", value)
    member _.blockquote (value: int) = h.MakeElWithChild("blockquote", value)
    member _.blockquote (value: 'El) = h.MakeElWithChild("blockquote", value)
    member _.blockquote (value: string) = h.MakeElWithChild("blockquote", value)
    member _.blockquote (children: seq<'El>) = h.MakeElWithChildren("blockquote", children)

    member _.body xs = h.MakeEl("body", xs)
    member _.body (value: float) = h.MakeElWithChild("body", value)
    member _.body (value: int) = h.MakeElWithChild("body", value)
    member _.body (value: 'El) = h.MakeElWithChild("body", value)
    member _.body (value: string) = h.MakeElWithChild("body", value)
    member _.body (children: seq<'El>) = h.MakeElWithChildren("body", children)

    member _.br xs = h.MakeEl("br", xs)

    member _.button xs = h.MakeEl("button", xs)
    member _.button (children: seq<'El>) = h.MakeElWithChildren("button", children)

    member _.canvas xs = h.MakeEl("canvas", xs)

    member _.caption xs = h.MakeEl("caption", xs)
    member _.caption (value: float) = h.MakeElWithChild("caption", value)
    member _.caption (value: int) = h.MakeElWithChild("caption", value)
    member _.caption (value: 'El) = h.MakeElWithChild("caption", value)
    member _.caption (value: string) = h.MakeElWithChild("caption", value)
    member _.caption (children: seq<'El>) = h.MakeElWithChildren("caption", children)

    member _.cite xs = h.MakeEl("cite", xs)
    member _.cite (value: float) = h.MakeElWithChild("cite", value)
    member _.cite (value: int) = h.MakeElWithChild("cite", value)
    member _.cite (value: 'El) = h.MakeElWithChild("cite", value)
    member _.cite (value: string) = h.MakeElWithChild("cite", value)
    member _.cite (children: seq<'El>) = h.MakeElWithChildren("cite", children)
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    member _.circle xs = h.MakeEl("circle", xs)
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    member _.circle (children: seq<'El>) = h.MakeElWithChildren("circle", children)
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    member _.clipPath xs = h.MakeEl("clipPath", xs)
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    member _.clipPath (children: seq<'El>) = h.MakeElWithChildren("clipPath", children)

    member _.code xs = h.MakeEl("code", xs)
    member _.code (value: bool) = h.MakeElWithChild("code", value)
    member _.code (value: float) = h.MakeElWithChild("code", value)
    member _.code (value: int) = h.MakeElWithChild("code", value)
    member _.code (value: 'El) = h.MakeElWithChild("code", value)
    member _.code (value: string) = h.MakeElWithChild("code", value)
    member _.code (children: seq<'El>) = h.MakeElWithChildren("code", children)

    member _.col xs = h.MakeEl("col", xs)

    member _.colgroup xs = h.MakeEl("colgroup", xs)
    member _.colgroup (children: seq<'El>) = h.MakeElWithChildren("colgroup", children)

    member _.data xs = h.MakeEl("data", xs)
    member _.data (value: float) = h.MakeElWithChild("data", value)
    member _.data (value: int) = h.MakeElWithChild("data", value)
    member _.data (value: 'El) = h.MakeElWithChild("data", value)
    member _.data (value: string) = h.MakeElWithChild("data", value)
    member _.data (children: seq<'El>) = h.MakeElWithChildren("data", children)

    member _.datalist xs = h.MakeEl("datalist", xs)
    member _.datalist (value: float) = h.MakeElWithChild("datalist", value)
    member _.datalist (value: int) = h.MakeElWithChild("datalist", value)
    member _.datalist (value: 'El) = h.MakeElWithChild("datalist", value)
    member _.datalist (value: string) = h.MakeElWithChild("datalist", value)
    member _.datalist (children: seq<'El>) = h.MakeElWithChildren("datalist", children)

    member _.dd xs = h.MakeEl("dd", xs)
    member _.dd (value: float) = h.MakeElWithChild("dd", value)
    member _.dd (value: int) = h.MakeElWithChild("dd", value)
    member _.dd (value: 'El) = h.MakeElWithChild("dd", value)
    member _.dd (value: string) = h.MakeElWithChild("dd", value)
    member _.dd (children: seq<'El>) = h.MakeElWithChildren("dd", children)
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    member _.defs xs = h.MakeEl("defs", xs)
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    member _.defs (children: seq<'El>) = h.MakeElWithChildren("defs", children)
    member _.del xs = h.MakeEl("del", xs)
    member _.del (value: float) = h.MakeElWithChild("del", value)
    member _.del (value: int) = h.MakeElWithChild("del", value)
    member _.del (value: 'El) = h.MakeElWithChild("del", value)
    member _.del (value: string) = h.MakeElWithChild("del", value)
    member _.del (children: seq<'El>) = h.MakeElWithChildren("del", children)

    member _.details xs = h.MakeEl("details", xs)
    member _.details (children: seq<'El>) = h.MakeElWithChildren("details", children)

    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc xs = h.MakeEl("desc", xs)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: float) = h.MakeElWithChild("desc", value)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: int) = h.MakeElWithChild("desc", value)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: string) = h.MakeElWithChild("desc", value)

    member _.dfn xs = h.MakeEl("ins", xs)
    member _.dfn (value: float) = h.MakeElWithChild("dfn", value)
    member _.dfn (value: int) = h.MakeElWithChild("dfn", value)
    member _.dfn (value: 'El) = h.MakeElWithChild("dfn", value)
    member _.dfn (value: string) = h.MakeElWithChild("dfn", value)
    member _.dfn (children: seq<'El>) = h.MakeElWithChildren("dfn", children)

    member _.dialog xs = h.MakeEl("dialog", xs)
    member _.dialog (value: float) = h.MakeElWithChild("dialog", value)
    member _.dialog (value: int) = h.MakeElWithChild("dialog", value)
    member _.dialog (value: 'El) = h.MakeElWithChild("dialog", value)
    member _.dialog (value: string) = h.MakeElWithChild("dialog", value)
    member _.dialog (children: seq<'El>) = h.MakeElWithChildren("dialog", children)

    /// The `<div>` tag defines a division or a section in an HTML document
    member _.div xs = h.MakeEl("div", xs)
    member _.div (value: float) = h.MakeElWithChild("div", value)
    member _.div (value: int) = h.MakeElWithChild("div", value)
    member _.div (value: 'El) = h.MakeElWithChild("div", value)
    member _.div (value: string) = h.MakeElWithChild("div", value)
    member _.div (children: seq<'El>) = h.MakeElWithChildren("div", children)

    member _.dl xs = h.MakeEl("dl", xs)
    member _.dl (children: seq<'El>) = h.MakeElWithChildren("dl", children)

    member _.dt xs = h.MakeEl("dt", xs)
    member _.dt (value: float) = h.MakeElWithChild("dt", value)
    member _.dt (value: int) = h.MakeElWithChild("dt", value)
    member _.dt (value: 'El) = h.MakeElWithChild("dt", value)
    member _.dt (value: string) = h.MakeElWithChild("dt", value)
    member _.dt (children: seq<'El>) = h.MakeElWithChildren("dt", children)

    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    member _.ellipse xs = h.MakeEl("ellipse", xs)
    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    member _.ellipse (children: seq<'El>) = h.MakeElWithChildren("ellipse", children)

    member _.em xs = h.MakeEl("em", xs)
    member _.em (value: float) = h.MakeElWithChild("em", value)
    member _.em (value: int) = h.MakeElWithChild("em", value)
    member _.em (value: 'El) = h.MakeElWithChild("em", value)
    member _.em (value: string) = h.MakeElWithChild("em", value)
    member _.em (children: seq<'El>) = h.MakeElWithChildren("em", children)

    member _.embed xs = h.MakeEl("embed", xs)
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    member _.feBlend xs = h.MakeEl("feBlend", xs)
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    member _.feBlend (children: seq<'El>) = h.MakeElWithChildren("feBlend", children)
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    member _.feColorMatrix xs = h.MakeEl("feColorMatrix", xs)
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    member _.feColorMatrix (children: seq<'El>) = h.MakeElWithChildren("feColorMatrix", children)
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    member _.feComponentTransfer xs = h.MakeEl("feComponentTransfer", xs)
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    member _.feComponentTransfer (children: seq<'El>) = h.MakeElWithChildren("feComponentTransfer", children)
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    member _.feComposite xs = h.MakeEl("feComposite", xs)
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    member _.feComposite (children: seq<'El>) = h.MakeElWithChildren("feComposite", children)
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    member _.feConvolveMatrix xs = h.MakeEl("feConvolveMatrix", xs)
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    member _.feConvolveMatrix (children: seq<'El>) = h.MakeElWithChildren("feConvolveMatrix", children)
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    member _.feDiffuseLighting xs = h.MakeEl("feDiffuseLighting", xs)
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    member _.feDiffuseLighting (children: seq<'El>) = h.MakeElWithChildren("feDiffuseLighting", children)
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    member _.feDisplacementMap xs = h.MakeEl("feDisplacementMap", xs)
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    member _.feDisplacementMap (children: seq<'El>) = h.MakeElWithChildren("feDisplacementMap", children)
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    member _.feDistantLight xs = h.MakeEl("feDistantLight", xs)
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    member _.feDistantLight (children: seq<'El>) = h.MakeElWithChildren("feDistantLight", children)
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    member _.feDropShadow xs = h.MakeEl("feDropShadow", xs)
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    member _.feDropShadow (children: seq<'El>) = h.MakeElWithChildren("feDropShadow", children)
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    member _.feFlood xs = h.MakeEl("feFlood", xs)
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    member _.feFlood (children: seq<'El>) = h.MakeElWithChildren("feFlood", children)
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    member _.feFuncA xs = h.MakeEl("feFuncA", xs)
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    member _.feFuncA (children: seq<'El>) = h.MakeElWithChildren("feFuncA", children)
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    member _.feFuncB xs = h.MakeEl("feFuncB", xs)
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    member _.feFuncB (children: seq<'El>) = h.MakeElWithChildren("feFuncB", children)
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    member _.feFuncG xs = h.MakeEl("feFuncG", xs)
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    member _.feFuncG (children: seq<'El>) = h.MakeElWithChildren("feFuncG", children)
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    member _.feFuncR xs = h.MakeEl("feFuncR", xs)
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    member _.feFuncR (children: seq<'El>) = h.MakeElWithChildren("feFuncR", children)
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    member _.feGaussianBlur xs = h.MakeEl("feGaussianBlur", xs)
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    member _.feGaussianBlur (children: seq<'El>) = h.MakeElWithChildren("feGaussianBlur", children)
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    member _.feImage xs = h.MakeEl("feImage", xs)
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    member _.feImage (children: seq<'El>) = h.MakeElWithChildren("feImage", children)
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    member _.feMerge xs = h.MakeEl("feMerge", xs)
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    member _.feMerge (children: seq<'El>) = h.MakeElWithChildren("feMerge", children)
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    member _.feMergeNode xs = h.MakeEl("feMergeNode", xs)
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    member _.feMergeNode (children: seq<'El>) = h.MakeElWithChildren("feMergeNode", children)
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    member _.feMorphology xs = h.MakeEl("feMorphology", xs)
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    member _.feMorphology (children: seq<'El>) = h.MakeElWithChildren("feMorphology", children)
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    member _.feOffset xs = h.MakeEl("feOffset", xs)
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    member _.feOffset (children: seq<'El>) = h.MakeElWithChildren("feOffset", children)
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    member _.fePointLight xs = h.MakeEl("fePointLight", xs)
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    member _.fePointLight (children: seq<'El>) = h.MakeElWithChildren("fePointLight", children)
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    member _.feSpecularLighting xs = h.MakeEl("feSpecularLighting", xs)
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    member _.feSpecularLighting (children: seq<'El>) = h.MakeElWithChildren("feSpecularLighting", children)
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    member _.feSpotLight xs = h.MakeEl("feSpotLight", xs)
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    member _.feSpotLight (children: seq<'El>) = h.MakeElWithChildren("feSpotLight", children)
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    member _.feTile xs = h.MakeEl("feTile", xs)
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    member _.feTile (children: seq<'El>) = h.MakeElWithChildren("feTile", children)
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    member _.feTurbulence xs = h.MakeEl("feTurbulence", xs)
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    member _.feTurbulence (children: seq<'El>) = h.MakeElWithChildren("feTurbulence", children)
    member _.fieldSet xs = h.MakeEl("fieldset", xs)
    member _.fieldSet (children: seq<'El>) = h.MakeElWithChildren("fieldset", children)

    member _.figcaption xs = h.MakeEl("figcaption", xs)
    member _.figcaption (children: seq<'El>) = h.MakeElWithChildren("figcaption", children)

    member _.figure xs = h.MakeEl("figure", xs)
    member _.figure (children: seq<'El>) = h.MakeElWithChildren("figure", children)
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    member _.filter xs = h.MakeEl("filter", xs)
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    member _.filter (children: seq<'El>) = h.MakeElWithChildren("filter", children)

    member _.footer xs = h.MakeEl("footer", xs)
    member _.footer (children: seq<'El>) = h.MakeElWithChildren("footer", children)
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    member _.foreignObject xs = h.MakeEl("foreignObject", xs)
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    member _.foreignObject (children: seq<'El>) = h.MakeElWithChildren("foreignObject", children)

    member _.form xs = h.MakeEl("form", xs)
    member _.form (children: seq<'El>) = h.MakeElWithChildren("form", children)

    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    member _.g xs = h.MakeEl("g", xs)
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    member _.g (children: seq<'El>) = h.MakeElWithChildren("g", children)

    member _.h1 xs = h.MakeEl("h1", xs)
    member _.h1 (value: float) = h.MakeElWithChild("h1", value)
    member _.h1 (value: int) = h.MakeElWithChild("h1", value)
    member _.h1 (value: 'El) = h.MakeElWithChild("h1", value)
    member _.h1 (value: string) = h.MakeElWithChild("h1", value)
    member _.h1 (children: seq<'El>) = h.MakeElWithChildren("h1", children)
    member _.h2 xs = h.MakeEl("h2", xs)
    member _.h2 (value: float) =  h.MakeElWithChild("h2", value)
    member _.h2 (value: int) =  h.MakeElWithChild("h2", value)
    member _.h2 (value: 'El) =  h.MakeElWithChild("h2", value)
    member _.h2 (value: string) =  h.MakeElWithChild("h2", value)
    member _.h2 (children: seq<'El>) = h.MakeElWithChildren("h2", children)

    member _.h3 xs = h.MakeEl("h3", xs)
    member _.h3 (value: float) =  h.MakeElWithChild("h3", value)
    member _.h3 (value: int) =  h.MakeElWithChild("h3", value)
    member _.h3 (value: 'El) =  h.MakeElWithChild("h3", value)
    member _.h3 (value: string) =  h.MakeElWithChild("h3", value)
    member _.h3 (children: seq<'El>) = h.MakeElWithChildren("h3", children)

    member _.h4 xs = h.MakeEl("h4", xs)
    member _.h4 (value: float) = h.MakeElWithChild("h4", value)
    member _.h4 (value: int) = h.MakeElWithChild("h4", value)
    member _.h4 (value: 'El) = h.MakeElWithChild("h4", value)
    member _.h4 (value: string) = h.MakeElWithChild("h4", value)
    member _.h4 (children: seq<'El>) = h.MakeElWithChildren("h4", children)

    member _.h5 xs = h.MakeEl("h5", xs)
    member _.h5 (value: float) = h.MakeElWithChild("h5", value)
    member _.h5 (value: int) = h.MakeElWithChild("h5", value)
    member _.h5 (value: 'El) = h.MakeElWithChild("h5", value)
    member _.h5 (value: string) = h.MakeElWithChild("h5", value)
    member _.h5 (children: seq<'El>) = h.MakeElWithChildren("h5", children)

    member _.h6 xs = h.MakeEl("h6", xs)
    member _.h6 (value: float) = h.MakeElWithChild("h6", value)
    member _.h6 (value: int) = h.MakeElWithChild("h6", value)
    member _.h6 (value: 'El) = h.MakeElWithChild("h6", value)
    member _.h6 (value: string) = h.MakeElWithChild("h6", value)
    member _.h6 (children: seq<'El>) = h.MakeElWithChildren("h6", children)

    member _.head xs = h.MakeEl("head", xs)
    member _.head (children: seq<'El>) = h.MakeElWithChildren("head", children)

    member _.header xs = h.MakeEl("header", xs)
    member _.header (children: seq<'El>) = h.MakeElWithChildren("header", children)

    member _.hr xs = h.MakeEl("hr", xs)

    member _.html xs = h.MakeEl("html", xs)
    member _.html (children: seq<'El>) = h.MakeElWithChildren("html", children)

    member _.i xs = h.MakeEl("i", xs)
    member _.i (value: float) = h.MakeElWithChild("i", value)
    member _.i (value: int) = h.MakeElWithChild("i", value)
    member _.i (value: 'El) = h.MakeElWithChild("i", value)
    member _.i (value: string) = h.MakeElWithChild("i", value)
    member _.i (children: seq<'El>) = h.MakeElWithChildren("i", children)

    member _.iframe xs = h.MakeEl("iframe", xs)

    member _.img xs = h.MakeEl("img", xs)
    /// SVG Image element, not to be confused with HTML img alias.
    member _.image xs = h.MakeEl("image", xs)
    /// SVG Image element, not to be confused with HTML img alias.
    member _.image (children: seq<'El>) = h.MakeElWithChildren("image", children)

    member _.input xs = h.MakeEl("input", xs)

    member _.ins xs = h.MakeEl("ins", xs)
    member _.ins (value: float) = h.MakeElWithChild("ins", value)
    member _.ins (value: int) = h.MakeElWithChild("ins", value)
    member _.ins (value: 'El) = h.MakeElWithChild("ins", value)
    member _.ins (value: string) = h.MakeElWithChild("ins", value)
    member _.ins (children: seq<'El>) = h.MakeElWithChildren("ins", children)

    member _.kbd xs = h.MakeEl("kbd", xs)
    member _.kbd (value: float) = h.MakeElWithChild("kbd", value)
    member _.kbd (value: int) = h.MakeElWithChild("kbd", value)
    member _.kbd (value: 'El) = h.MakeElWithChild("kbd", value)
    member _.kbd (value: string) = h.MakeElWithChild("kbd", value)
    member _.kbd (children: seq<'El>) = h.MakeElWithChildren("kbd", children)

    member _.label xs = h.MakeEl("label", xs)
    member _.label (children: seq<'El>) = h.MakeElWithChildren("label", children)

    member _.legend xs = h.MakeEl("legend", xs)
    member _.legend (value: float) = h.MakeElWithChild("legend", value)
    member _.legend (value: int) = h.MakeElWithChild("legend", value)
    member _.legend (value: 'El) = h.MakeElWithChild("legend", value)
    member _.legend (value: string) = h.MakeElWithChild("legend", value)
    member _.legend (children: seq<'El>) = h.MakeElWithChildren("legend", children)

    member _.li xs = h.MakeEl("li", xs)
    member _.li (value: float) = h.MakeElWithChild("li", value)
    member _.li (value: int) = h.MakeElWithChild("li", value)
    member _.li (value: 'El) = h.MakeElWithChild("li", value)
    member _.li (value: string) = h.MakeElWithChild("li", value)
    member _.li (children: seq<'El>) = h.MakeElWithChildren("li", children)
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    member _.line xs = h.MakeEl("line", xs)
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    member _.line (children: seq<'El>) = h.MakeElWithChildren("line", children)
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    member _.linearGradient xs = h.MakeEl("linearGradient", xs)
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    member _.linearGradient (children: seq<'El>) = h.MakeElWithChildren("linearGradient", children)

    member _.link xs = h.MakeEl("link", xs)

    member _.listItem xs = h.MakeEl("li", xs)
    member _.listItem (value: float) = h.MakeElWithChild("li", value)
    member _.listItem (value: int) = h.MakeElWithChild("li", value)
    member _.listItem (value: 'El) = h.MakeElWithChild("li", value)
    member _.listItem (value: string) = h.MakeElWithChild("li", value)
    member _.listItem (children: seq<'El>) = h.MakeElWithChildren("li", children)

    member _.main xs = h.MakeEl("main", xs)
    member _.main (children: seq<'El>) = h.MakeElWithChildren("main", children)

    member _.map xs = h.MakeEl("map", xs)
    member _.map (children: seq<'El>) = h.MakeElWithChildren("map", children)

    member _.mark xs = h.MakeEl("mark", xs)
    member _.mark (value: float) = h.MakeElWithChild("mark", value)
    member _.mark (value: int) = h.MakeElWithChild("mark", value)
    member _.mark (value: 'El) = h.MakeElWithChild("mark", value)
    member _.mark (value: string) = h.MakeElWithChild("mark", value)
    member _.mark (children: seq<'El>) = h.MakeElWithChildren("mark", children)
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    member _.marker xs = h.MakeEl("marker", xs)
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    member _.marker (children: seq<'El>) = h.MakeElWithChildren("marker", children)
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    member _.mask xs = h.MakeEl("mask", xs)
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    member _.mask (children: seq<'El>) = h.MakeElWithChildren("mask", children)

    member _.meta xs = h.MakeEl("meta", xs)

    member _.metadata xs = h.MakeEl("metadata", xs)
    member _.metadata (children: seq<'El>) = h.MakeElWithChildren("metadata", children)

    member _.meter xs = h.MakeEl("meter", xs)
    member _.meter (value: float) = h.MakeElWithChild("meter", value)
    member _.meter (value: int) = h.MakeElWithChild("meter", value)
    member _.meter (value: 'El) = h.MakeElWithChild("meter", value)
    member _.meter (value: string) = h.MakeElWithChild("meter", value)
    member _.meter (children: seq<'El>) = h.MakeElWithChildren("meter", children)
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    member _.mpath xs = h.MakeEl("mpath", xs)
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    member _.mpath (children: seq<'El>) = h.MakeElWithChildren("mpath", children)
    member _.nav xs = h.MakeEl("nav", xs)
    member _.nav (children: seq<'El>) = h.MakeElWithChildren("nav", children)

    /// The empty element, renders nothing on screen
    member _.none : 'El = h.EmptyEl

    member _.noscript xs = h.MakeEl("noscript", xs)
    member _.noscript (children: seq<'El>) = h.MakeElWithChildren("noscript", children)

    member _.object xs = h.MakeEl("object", xs)
    member _.object (children: seq<'El>) = h.MakeElWithChildren("object", children)

    member _.ol xs = h.MakeEl("ol", xs)
    member _.ol (children: seq<'El>) = h.MakeElWithChildren("ol", children)

    member _.option xs = h.MakeEl("option", xs)
    member _.option (value: float) = h.MakeElWithChild("option", value)
    member _.option (value: int) = h.MakeElWithChild("option", value)
    member _.option (value: 'El) = h.MakeElWithChild("option", value)
    member _.option (value: string) = h.MakeElWithChild("option", value)
    member _.option (children: seq<'El>) = h.MakeElWithChildren("option", children)

    member _.optgroup xs = h.MakeEl("optgroup", xs)
    member _.optgroup (children: seq<'El>) = h.MakeElWithChildren("optgroup", children)

    member _.orderedList xs = h.MakeEl("ol", xs)
    member _.orderedList (children: seq<'El>) = h.MakeElWithChildren("ol", children)

    member _.output xs = h.MakeEl("output", xs)
    member _.output (value: float) = h.MakeElWithChild("output", value)
    member _.output (value: int) = h.MakeElWithChild("output", value)
    member _.output (value: 'El) = h.MakeElWithChild("output", value)
    member _.output (value: string) = h.MakeElWithChild("output", value)
    member _.output (children: seq<'El>) = h.MakeElWithChildren("output", children)

    member _.p xs = h.MakeEl("p", xs)
    member _.p (value: float) = h.MakeElWithChild("p", value)
    member _.p (value: int) = h.MakeElWithChild("p", value)
    member _.p (value: 'El) = h.MakeElWithChild("p", value)
    member _.p (value: string) = h.MakeElWithChild("p", value)
    member _.p (children: seq<'El>) = h.MakeElWithChildren("p", children)

    member _.paragraph xs = h.MakeEl("p", xs)
    member _.paragraph (value: float) = h.MakeElWithChild("p", value)
    member _.paragraph (value: int) = h.MakeElWithChild("p", value)
    member _.paragraph (value: 'El) = h.MakeElWithChild("p", value)
    member _.paragraph (value: string) = h.MakeElWithChild("p", value)
    member _.paragraph (children: seq<'El>) = h.MakeElWithChildren("p", children)

    member _.param xs = h.MakeEl("param", xs)
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    member _.path xs = h.MakeEl("path", xs)
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    member _.path (children: seq<'El>) = h.MakeElWithChildren("path", children)
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    member _.pattern xs = h.MakeEl("pattern", xs)
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    member _.pattern (children: seq<'El>) = h.MakeElWithChildren("pattern", children)
    member _.picture xs = h.MakeEl("picture", xs)
    member _.picture (children: seq<'El>) = h.MakeElWithChildren("picture", children)
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    member _.polygon xs = h.MakeEl("polygon", xs)
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    member _.polygon (children: seq<'El>) = h.MakeElWithChildren("polygon", children)
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    member _.polyline xs = h.MakeEl("polyline", xs)
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    member _.polyline (children: seq<'El>) = h.MakeElWithChildren("polyline", children)
    member _.pre xs = h.MakeEl("pre", xs)
    member _.pre (value: bool) = h.MakeElWithChild("pre", value)
    member _.pre (value: float) = h.MakeElWithChild("pre", value)
    member _.pre (value: int) = h.MakeElWithChild("pre", value)
    member _.pre (value: 'El) = h.MakeElWithChild("pre", value)
    member _.pre (value: string) = h.MakeElWithChild("pre", value)
    member _.pre (children: seq<'El>) = h.MakeElWithChildren("pre", children)

    member _.progress xs = h.MakeEl("progress", xs)
    member _.progress (children: seq<'El>) = h.MakeElWithChildren("progress", children)

    member _.q xs = h.MakeEl("q", xs)
    member _.q (children: seq<'El>) = h.MakeElWithChildren("q", children)
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    member _.radialGradient xs = h.MakeEl("radialGradient", xs)
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    member _.radialGradient (children: seq<'El>) = h.MakeElWithChildren("radialGradient", children)

    member _.rb xs = h.MakeEl("rb", xs)
    member _.rb (value: float) = h.MakeElWithChild("rb", value)
    member _.rb (value: int) = h.MakeElWithChild("rb", value)
    member _.rb (value: 'El) = h.MakeElWithChild("rb", value)
    member _.rb (value: string) = h.MakeElWithChild("rb", value)
    member _.rb (children: seq<'El>) = h.MakeElWithChildren("rb", children)
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    member _.rect xs = h.MakeEl("rect", xs)
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    member _.rect (children: seq<'El>) = h.MakeElWithChildren("rect", children)

    member _.rp xs = h.MakeEl("rp", xs)
    member _.rp (value: float) = h.MakeElWithChild("rp", value)
    member _.rp (value: int) = h.MakeElWithChild("rp", value)
    member _.rp (value: 'El) = h.MakeElWithChild("rp", value)
    member _.rp (value: string) = h.MakeElWithChild("rp", value)
    member _.rp (children: seq<'El>) = h.MakeElWithChildren("rp", children)

    member _.rt xs = h.MakeEl("rt", xs)
    member _.rt (value: float) = h.MakeElWithChild("rt", value)
    member _.rt (value: int) = h.MakeElWithChild("rt", value)
    member _.rt (value: 'El) = h.MakeElWithChild("rt", value)
    member _.rt (value: string) = h.MakeElWithChild("rt", value)
    member _.rt (children: seq<'El>) = h.MakeElWithChildren("rt", children)

    member _.rtc xs = h.MakeEl("rtc", xs)
    member _.rtc (value: float) = h.MakeElWithChild("rtc", value)
    member _.rtc (value: int) = h.MakeElWithChild("rtc", value)
    member _.rtc (value: 'El) = h.MakeElWithChild("rtc", value)
    member _.rtc (value: string) = h.MakeElWithChild("rtc", value)
    member _.rtc (children: seq<'El>) = h.MakeElWithChildren("rtc", children)

    member _.ruby xs = h.MakeEl("ruby", xs)
    member _.ruby (value: float) = h.MakeElWithChild("ruby", value)
    member _.ruby (value: int) = h.MakeElWithChild("ruby", value)
    member _.ruby (value: 'El) = h.MakeElWithChild("ruby", value)
    member _.ruby (value: string) = h.MakeElWithChild("ruby", value)
    member _.ruby (children: seq<'El>) = h.MakeElWithChildren("ruby", children)

    member _.s xs = h.MakeEl("s", xs)
    member _.s (value: float) = h.MakeElWithChild("s", value)
    member _.s (value: int) = h.MakeElWithChild("s", value)
    member _.s (value: 'El) = h.MakeElWithChild("s", value)
    member _.s (value: string) = h.MakeElWithChild("s", value)
    member _.s (children: seq<'El>) = h.MakeElWithChildren("s", children)

    member _.samp xs = h.MakeEl("samp", xs)
    member _.samp (value: float) = h.MakeElWithChild("samp", value)
    member _.samp (value: int) = h.MakeElWithChild("samp", value)
    member _.samp (value: 'El) = h.MakeElWithChild("samp", value)
    member _.samp (value: string) = h.MakeElWithChild("samp", value)
    member _.samp (children: seq<'El>) = h.MakeElWithChildren("samp", children)

    member _.script xs = h.MakeEl("script", xs)
    member _.script (children: seq<'El>) = h.MakeElWithChildren("script", children)

    member _.section xs = h.MakeEl("section", xs)
    member _.section (children: seq<'El>) = h.MakeElWithChildren("section", children)

    member _.select xs = h.MakeEl("select", xs)
    member _.select (children: seq<'El>) = h.MakeElWithChildren("select", children)
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    member _.set xs = h.MakeEl("set", xs)
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    member _.set (children: seq<'El>) = h.MakeElWithChildren("set", children)

    member _.small xs = h.MakeEl("small", xs)
    member _.small (value: float) = h.MakeElWithChild("small", value)
    member _.small (value: int) = h.MakeElWithChild("small", value)
    member _.small (value: 'El) = h.MakeElWithChild("small", value)
    member _.small (value: string) = h.MakeElWithChild("small", value)
    member _.small (children: seq<'El>) = h.MakeElWithChildren("small", children)

    member _.source xs = h.MakeEl("source", xs)

    member _.span xs = h.MakeEl("span", xs)
    member _.span (value: float) = h.MakeElWithChild("span", value)
    member _.span (value: int) = h.MakeElWithChild("span", value)
    member _.span (value: 'El) = h.MakeElWithChild("span", value)
    member _.span (value: string) = h.MakeElWithChild("span", value)
    member _.span (children: seq<'El>) = h.MakeElWithChildren("span", children)
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    member _.stop xs = h.MakeEl("stop", xs)
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    member _.stop (children: seq<'El>) = h.MakeElWithChildren("stop", children)

    member _.strong xs = h.MakeEl("strong", xs)
    member _.strong (value: float) = h.MakeElWithChild("strong", value)
    member _.strong (value: int) = h.MakeElWithChild("strong", value)
    member _.strong (value: 'El) = h.MakeElWithChild("strong", value)
    member _.strong (value: string) = h.MakeElWithChild("strong", value)
    member _.strong (children: seq<'El>) = h.MakeElWithChildren("strong", children)

    member _.style xs = h.MakeEl("style", xs)
    member _.style (value: string) = h.MakeElWithChild("style", value)

    member _.sub xs = h.MakeEl("sub", xs)
    member _.sub (value: float) = h.MakeElWithChild("sub", value)
    member _.sub (value: int) = h.MakeElWithChild("sub", value)
    member _.sub (value: 'El) = h.MakeElWithChild("sub", value)
    member _.sub (value: string) = h.MakeElWithChild("sub", value)
    member _.sub (children: seq<'El>) = h.MakeElWithChildren("sub", children)

    member _.summary xs = h.MakeEl("summary", xs)
    member _.summary (value: float) = h.MakeElWithChild("summary", value)
    member _.summary (value: int) = h.MakeElWithChild("summary", value)
    member _.summary (value: 'El) = h.MakeElWithChild("summary", value)
    member _.summary (value: string) = h.MakeElWithChild("summary", value)
    member _.summary (children: seq<'El>) = h.MakeElWithChildren("summary", children)

    member _.sup xs = h.MakeEl("sup", xs)
    member _.sup (value: float) = h.MakeElWithChild("sup", value)
    member _.sup (value: int) = h.MakeElWithChild("sup", value)
    member _.sup (value: 'El) = h.MakeElWithChild("sup", value)
    member _.sup (value: string) = h.MakeElWithChild("sup", value)
    member _.sup (children: seq<'El>) = h.MakeElWithChildren("sup", children)

    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    member _.svg xs = h.MakeEl("svg", xs)
    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    member _.svg (children: seq<'El>) = h.MakeElWithChildren("svg", children)
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    member _.switch xs = h.MakeEl("switch", xs)
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    member _.switch (children: seq<'El>) = h.MakeElWithChildren("switch", children)
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    member _.symbol xs = h.MakeEl("symbol", xs)
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    member _.symbol (children: seq<'El>) = h.MakeElWithChildren("symbol", children)

    member _.table xs = h.MakeEl("table", xs)
    member _.table (children: seq<'El>) = h.MakeElWithChildren("table", children)

    member _.tableBody xs = h.MakeEl("tbody", xs)
    member _.tableBody (children: seq<'El>) = h.MakeElWithChildren("tbody", children)

    member _.tableCell xs = h.MakeEl("td", xs)
    member _.tableCell (children: seq<'El>) = h.MakeElWithChildren("td", children)

    member _.tableHeader xs = h.MakeEl("th", xs)
    member _.tableHeader (children: seq<'El>) = h.MakeElWithChildren("th", children)

    member _.tableRow xs = h.MakeEl("tr", xs)
    member _.tableRow (children: seq<'El>) = h.MakeElWithChildren("tr", children)

    member _.tbody xs = h.MakeEl("tbody", xs)
    member _.tbody (children: seq<'El>) = h.MakeElWithChildren("tbody", children)

    member _.td xs = h.MakeEl("td", xs)
    member _.td (value: float) = h.MakeElWithChild("td", value)
    member _.td (value: int) = h.MakeElWithChild("td", value)
    member _.td (value: 'El) = h.MakeElWithChild("td", value)
    member _.td (value: string) = h.MakeElWithChild("td", value)
    member _.td (children: seq<'El>) = h.MakeElWithChildren("td", children)

    member _.template xs = h.MakeEl("template", xs)
    member _.template (children: seq<'El>) = h.MakeElWithChildren("template", children)

    [<Obsolete "Html.text is obsolete for creating <text> SVG elements. Use Svg.text instead">]
    member _.text xs = h.MakeEl("text", xs)
    member _.text (value: float) : 'El = h.FloatToEl value
    member _.text (value: int) : 'El = h.IntToEl value
    member _.text (value: string) : 'El = h.StringToEl value
    member _.text (value: System.Guid) : 'El = h.StringToEl (string value)

    member this.textf fmt = Printf.kprintf this.text fmt

    member _.textarea xs = h.MakeEl("textarea", xs)
    member _.textarea (children: seq<'El>) = h.MakeElWithChildren("textarea", children)
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    member _.textPath xs = h.MakeEl("textPath", xs)
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    member _.textPath (children: seq<'El>) = h.MakeElWithChildren("textPath", children)

    member _.tfoot xs = h.MakeEl("tfoot", xs)
    member _.tfoot (children: seq<'El>) = h.MakeElWithChildren("tfoot", children)

    member _.th xs = h.MakeEl("th", xs)
    member _.th (value: float) = h.MakeElWithChild("th", value)
    member _.th (value: int) = h.MakeElWithChild("th", value)
    member _.th (value: 'El) = h.MakeElWithChild("th", value)
    member _.th (value: string) = h.MakeElWithChild("th", value)
    member _.th (children: seq<'El>) = h.MakeElWithChildren("th", children)

    member _.thead xs = h.MakeEl("thead", xs)
    member _.thead (children: seq<'El>) = h.MakeElWithChildren("thead", children)

    member _.time xs = h.MakeEl("time", xs)
    member _.time (children: seq<'El>) = h.MakeElWithChildren("time", children)

    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title xs = h.MakeEl("title", xs)
    member _.title (value: float) = h.MakeElWithChild("title", value)
    member _.title (value: int) = h.MakeElWithChild("title", value)
    member _.title (value: 'El) = h.MakeElWithChild("title", value)
    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title (value: string) = h.MakeElWithChild("title", value)
    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title (children: seq<'El>) = h.MakeElWithChildren("title", children)

    member _.tr xs = h.MakeEl("tr", xs)
    member _.tr (children: seq<'El>) = h.MakeElWithChildren("tr", children)

    member _.track xs = h.MakeEl("track", xs)
    [<Obsolete "Html.tspan is obsolete, use Svg.tsapn instead">]
    member _.tspan xs = h.MakeEl("tspan", xs)
    [<Obsolete "Html.tspan is obsolete, use Svg.tsapn instead">]
    member _.tspan (children: seq<'El>) = h.MakeElWithChildren("tspan", children)

    member _.u xs = h.MakeEl("u", xs)
    member _.u (value: float) = h.MakeElWithChild("u", value)
    member _.u (value: int) = h.MakeElWithChild("u", value)
    member _.u (value: 'El) = h.MakeElWithChild("u", value)
    member _.u (value: string) = h.MakeElWithChild("u", value)
    member _.u (children: seq<'El>) = h.MakeElWithChildren("u", children)

    member _.ul xs = h.MakeEl("ul", xs)
    member _.ul (children: seq<'El>) = h.MakeElWithChildren("ul", children)

    member _.unorderedList xs = h.MakeEl("ul", xs)
    member _.unorderedList (children: seq<'El>) = h.MakeElWithChildren("ul", children)
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    member _.use' xs = h.MakeEl("use", xs)
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    member _.use' (children: seq<'El>) = h.MakeElWithChildren("use", children)
    member _.var xs = h.MakeEl("var", xs)
    member _.var (value: float) = h.MakeElWithChild("var", value)
    member _.var (value: int) = h.MakeElWithChild("var", value)
    member _.var (value: 'El) = h.MakeElWithChild("var", value)
    member _.var (value: string) = h.MakeElWithChild("var", value)
    member _.var (children: seq<'El>) = h.MakeElWithChildren("var", children)

    member _.video xs = h.MakeEl("video", xs)
    member _.video (children: seq<'El>) = h.MakeElWithChildren("video", children)
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    member _.view xs = h.MakeEl("view", xs)
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    member _.view (children: seq<'El>) = h.MakeElWithChildren("view", children)

    member _.wbr xs = h.MakeEl("wbr", xs)