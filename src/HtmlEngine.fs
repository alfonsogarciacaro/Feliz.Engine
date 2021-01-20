namespace Feliz

open System

type IConverter<'El, 'Prop> =
    abstract CreateEl: string * 'Prop seq -> 'El
    abstract ChildrenToProp: 'El seq -> 'Prop
    abstract StringToEl: string -> 'El
    abstract IntToEl: int -> 'El
    abstract FloatToEl: float -> 'El
    abstract BoolToEl: bool -> 'El
    abstract EmptyEl: 'El

module internal ConverterExtensions =
    type IConverter<'El, 'Prop> with
        member this.CreateWithChildren(tag, children) =
            this.CreateEl(tag, [this.ChildrenToProp children])
        member this.CreateWithChild(tag, child) =
            this.CreateWithChildren(tag, [child])
        member this.CreateWithChild(tag, v) =
            this.CreateWithChildren(tag, [this.StringToEl v])
        member this.CreateWithChild(tag, v) =
            this.CreateWithChildren(tag, [this.IntToEl v])
        member this.CreateWithChild(tag, v) =
            this.CreateWithChildren(tag, [this.FloatToEl v])
        member this.CreateWithChild(tag, v) =
            this.CreateWithChildren(tag, [this.BoolToEl v])

open ConverterExtensions

type HtmlEngine<'El, 'Prop>(h: IConverter<'El, 'Prop>) =
    member _.a xs = h.CreateEl("a", xs)
    member _.a (children: seq<'El>) = h.CreateWithChildren("a", children)

    member _.abbr xs = h.CreateEl("abbr", xs)
    member _.abbr (value: float) = h.CreateWithChild("abbr", value)
    member _.abbr (value: int) = h.CreateWithChild("abbr", value)
    member _.abbr (value: 'El) = h.CreateWithChild("abbr", value)
    member _.abbr (value: string) = h.CreateWithChild("abbr", value)
    member _.abbr (children: seq<'El>) = h.CreateWithChildren("abbr", children)

    member _.address xs = h.CreateEl("address", xs)
    member _.address (value: float) = h.CreateWithChild("address", value)
    member _.address (value: int) = h.CreateWithChild("address", value)
    member _.address (value: 'El) = h.CreateWithChild("address", value)
    member _.address (value: string) = h.CreateWithChild("address", value)
    member _.address (children: seq<'El>) = h.CreateWithChildren("address", children)

    member _.anchor xs = h.CreateEl("a", xs)
    member _.anchor (children: seq<'El>) = h.CreateWithChildren("a", children)

    member _.animate xs = h.CreateEl("animate", xs)

    member _.animateMotion xs = h.CreateEl("animateMotion", xs)
    member _.animateMotion (children: seq<'El>) = h.CreateWithChildren("animateMotion", children)

    member _.animateTransform xs = h.CreateEl("animateTransform", xs)
    member _.animateTransform (children: seq<'El>) = h.CreateWithChildren("animateTransform", children)

    member _.area xs = h.CreateEl("area", xs)

    member _.article xs = h.CreateEl("article", xs)
    member _.article (children: seq<'El>) = h.CreateWithChildren("article", children)

    member _.aside xs = h.CreateEl("aside", xs)
    member _.aside (children: seq<'El>) = h.CreateWithChildren("aside", children)

    member _.audio xs = h.CreateEl("audio", xs)
    member _.audio (children: seq<'El>) = h.CreateWithChildren("audio", children)

    member _.b xs = h.CreateEl("b", xs)
    member _.b (value: float) = h.CreateWithChild("b", value)
    member _.b (value: int) = h.CreateWithChild("b", value)
    member _.b (value: 'El) = h.CreateWithChild("b", value)
    member _.b (value: string) = h.CreateWithChild("b", value)
    member _.b (children: seq<'El>) = h.CreateWithChildren("b", children)

    member _.base' xs = h.CreateEl("base", xs)

    member _.bdi xs = h.CreateEl("bdi", xs)
    member _.bdi (value: float) = h.CreateWithChild("bdi", value)
    member _.bdi (value: int) = h.CreateWithChild("bdi", value)
    member _.bdi (value: 'El) = h.CreateWithChild("bdi", value)
    member _.bdi (value: string) = h.CreateWithChild("bdi", value)
    member _.bdi (children: seq<'El>) = h.CreateWithChildren("bdi", children)

    member _.bdo xs = h.CreateEl("bdo", xs)
    member _.bdo (value: float) = h.CreateWithChild("bdo", value)
    member _.bdo (value: int) = h.CreateWithChild("bdo", value)
    member _.bdo (value: 'El) = h.CreateWithChild("bdo", value)
    member _.bdo (value: string) = h.CreateWithChild("bdo", value)
    member _.bdo (children: seq<'El>) = h.CreateWithChildren("bdo", children)

    member _.blockquote xs = h.CreateEl("blockquote", xs)
    member _.blockquote (value: float) = h.CreateWithChild("blockquote", value)
    member _.blockquote (value: int) = h.CreateWithChild("blockquote", value)
    member _.blockquote (value: 'El) = h.CreateWithChild("blockquote", value)
    member _.blockquote (value: string) = h.CreateWithChild("blockquote", value)
    member _.blockquote (children: seq<'El>) = h.CreateWithChildren("blockquote", children)

    member _.body xs = h.CreateEl("body", xs)
    member _.body (value: float) = h.CreateWithChild("body", value)
    member _.body (value: int) = h.CreateWithChild("body", value)
    member _.body (value: 'El) = h.CreateWithChild("body", value)
    member _.body (value: string) = h.CreateWithChild("body", value)
    member _.body (children: seq<'El>) = h.CreateWithChildren("body", children)

    member _.br xs = h.CreateEl("br", xs)

    member _.button xs = h.CreateEl("button", xs)
    member _.button (children: seq<'El>) = h.CreateWithChildren("button", children)

    member _.canvas xs = h.CreateEl("canvas", xs)

    member _.caption xs = h.CreateEl("caption", xs)
    member _.caption (value: float) = h.CreateWithChild("caption", value)
    member _.caption (value: int) = h.CreateWithChild("caption", value)
    member _.caption (value: 'El) = h.CreateWithChild("caption", value)
    member _.caption (value: string) = h.CreateWithChild("caption", value)
    member _.caption (children: seq<'El>) = h.CreateWithChildren("caption", children)

    member _.cite xs = h.CreateEl("cite", xs)
    member _.cite (value: float) = h.CreateWithChild("cite", value)
    member _.cite (value: int) = h.CreateWithChild("cite", value)
    member _.cite (value: 'El) = h.CreateWithChild("cite", value)
    member _.cite (value: string) = h.CreateWithChild("cite", value)
    member _.cite (children: seq<'El>) = h.CreateWithChildren("cite", children)
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    member _.circle xs = h.CreateEl("circle", xs)
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    member _.circle (children: seq<'El>) = h.CreateWithChildren("circle", children)
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    member _.clipPath xs = h.CreateEl("clipPath", xs)
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    member _.clipPath (children: seq<'El>) = h.CreateWithChildren("clipPath", children)

    member _.code xs = h.CreateEl("code", xs)
    member _.code (value: bool) = h.CreateWithChild("code", value)
    member _.code (value: float) = h.CreateWithChild("code", value)
    member _.code (value: int) = h.CreateWithChild("code", value)
    member _.code (value: 'El) = h.CreateWithChild("code", value)
    member _.code (value: string) = h.CreateWithChild("code", value)
    member _.code (children: seq<'El>) = h.CreateWithChildren("code", children)

    member _.col xs = h.CreateEl("col", xs)

    member _.colgroup xs = h.CreateEl("colgroup", xs)
    member _.colgroup (children: seq<'El>) = h.CreateWithChildren("colgroup", children)

    member _.data xs = h.CreateEl("data", xs)
    member _.data (value: float) = h.CreateWithChild("data", value)
    member _.data (value: int) = h.CreateWithChild("data", value)
    member _.data (value: 'El) = h.CreateWithChild("data", value)
    member _.data (value: string) = h.CreateWithChild("data", value)
    member _.data (children: seq<'El>) = h.CreateWithChildren("data", children)

    member _.datalist xs = h.CreateEl("datalist", xs)
    member _.datalist (value: float) = h.CreateWithChild("datalist", value)
    member _.datalist (value: int) = h.CreateWithChild("datalist", value)
    member _.datalist (value: 'El) = h.CreateWithChild("datalist", value)
    member _.datalist (value: string) = h.CreateWithChild("datalist", value)
    member _.datalist (children: seq<'El>) = h.CreateWithChildren("datalist", children)

    member _.dd xs = h.CreateEl("dd", xs)
    member _.dd (value: float) = h.CreateWithChild("dd", value)
    member _.dd (value: int) = h.CreateWithChild("dd", value)
    member _.dd (value: 'El) = h.CreateWithChild("dd", value)
    member _.dd (value: string) = h.CreateWithChild("dd", value)
    member _.dd (children: seq<'El>) = h.CreateWithChildren("dd", children)
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    member _.defs xs = h.CreateEl("defs", xs)
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    member _.defs (children: seq<'El>) = h.CreateWithChildren("defs", children)
    member _.del xs = h.CreateEl("del", xs)
    member _.del (value: float) = h.CreateWithChild("del", value)
    member _.del (value: int) = h.CreateWithChild("del", value)
    member _.del (value: 'El) = h.CreateWithChild("del", value)
    member _.del (value: string) = h.CreateWithChild("del", value)
    member _.del (children: seq<'El>) = h.CreateWithChildren("del", children)

    member _.details xs = h.CreateEl("details", xs)
    member _.details (children: seq<'El>) = h.CreateWithChildren("details", children)

    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc xs = h.CreateEl("desc", xs)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: float) = h.CreateWithChild("desc", value)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: int) = h.CreateWithChild("desc", value)
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    member _.desc (value: string) = h.CreateWithChild("desc", value)

    member _.dfn xs = h.CreateEl("ins", xs)
    member _.dfn (value: float) = h.CreateWithChild("dfn", value)
    member _.dfn (value: int) = h.CreateWithChild("dfn", value)
    member _.dfn (value: 'El) = h.CreateWithChild("dfn", value)
    member _.dfn (value: string) = h.CreateWithChild("dfn", value)
    member _.dfn (children: seq<'El>) = h.CreateWithChildren("dfn", children)

    member _.dialog xs = h.CreateEl("dialog", xs)
    member _.dialog (value: float) = h.CreateWithChild("dialog", value)
    member _.dialog (value: int) = h.CreateWithChild("dialog", value)
    member _.dialog (value: 'El) = h.CreateWithChild("dialog", value)
    member _.dialog (value: string) = h.CreateWithChild("dialog", value)
    member _.dialog (children: seq<'El>) = h.CreateWithChildren("dialog", children)

    /// The `<div>` tag defines a division or a section in an HTML document
    member _.div xs = h.CreateEl("div", xs)
    member _.div (value: float) = h.CreateWithChild("div", value)
    member _.div (value: int) = h.CreateWithChild("div", value)
    member _.div (value: 'El) = h.CreateWithChild("div", value)
    member _.div (value: string) = h.CreateWithChild("div", value)
    member _.div (children: seq<'El>) = h.CreateWithChildren("div", children)

    member _.dl xs = h.CreateEl("dl", xs)
    member _.dl (children: seq<'El>) = h.CreateWithChildren("dl", children)

    member _.dt xs = h.CreateEl("dt", xs)
    member _.dt (value: float) = h.CreateWithChild("dt", value)
    member _.dt (value: int) = h.CreateWithChild("dt", value)
    member _.dt (value: 'El) = h.CreateWithChild("dt", value)
    member _.dt (value: string) = h.CreateWithChild("dt", value)
    member _.dt (children: seq<'El>) = h.CreateWithChildren("dt", children)

    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    member _.ellipse xs = h.CreateEl("ellipse", xs)
    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    member _.ellipse (children: seq<'El>) = h.CreateWithChildren("ellipse", children)

    member _.em xs = h.CreateEl("em", xs)
    member _.em (value: float) = h.CreateWithChild("em", value)
    member _.em (value: int) = h.CreateWithChild("em", value)
    member _.em (value: 'El) = h.CreateWithChild("em", value)
    member _.em (value: string) = h.CreateWithChild("em", value)
    member _.em (children: seq<'El>) = h.CreateWithChildren("em", children)

    member _.embed xs = h.CreateEl("embed", xs)
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    member _.feBlend xs = h.CreateEl("feBlend", xs)
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    member _.feBlend (children: seq<'El>) = h.CreateWithChildren("feBlend", children)
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    member _.feColorMatrix xs = h.CreateEl("feColorMatrix", xs)
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    member _.feColorMatrix (children: seq<'El>) = h.CreateWithChildren("feColorMatrix", children)
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    member _.feComponentTransfer xs = h.CreateEl("feComponentTransfer", xs)
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    member _.feComponentTransfer (children: seq<'El>) = h.CreateWithChildren("feComponentTransfer", children)
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    member _.feComposite xs = h.CreateEl("feComposite", xs)
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    member _.feComposite (children: seq<'El>) = h.CreateWithChildren("feComposite", children)
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    member _.feConvolveMatrix xs = h.CreateEl("feConvolveMatrix", xs)
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    member _.feConvolveMatrix (children: seq<'El>) = h.CreateWithChildren("feConvolveMatrix", children)
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    member _.feDiffuseLighting xs = h.CreateEl("feDiffuseLighting", xs)
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    member _.feDiffuseLighting (children: seq<'El>) = h.CreateWithChildren("feDiffuseLighting", children)
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    member _.feDisplacementMap xs = h.CreateEl("feDisplacementMap", xs)
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    member _.feDisplacementMap (children: seq<'El>) = h.CreateWithChildren("feDisplacementMap", children)
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    member _.feDistantLight xs = h.CreateEl("feDistantLight", xs)
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    member _.feDistantLight (children: seq<'El>) = h.CreateWithChildren("feDistantLight", children)
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    member _.feDropShadow xs = h.CreateEl("feDropShadow", xs)
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    member _.feDropShadow (children: seq<'El>) = h.CreateWithChildren("feDropShadow", children)
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    member _.feFlood xs = h.CreateEl("feFlood", xs)
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    member _.feFlood (children: seq<'El>) = h.CreateWithChildren("feFlood", children)
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    member _.feFuncA xs = h.CreateEl("feFuncA", xs)
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    member _.feFuncA (children: seq<'El>) = h.CreateWithChildren("feFuncA", children)
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    member _.feFuncB xs = h.CreateEl("feFuncB", xs)
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    member _.feFuncB (children: seq<'El>) = h.CreateWithChildren("feFuncB", children)
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    member _.feFuncG xs = h.CreateEl("feFuncG", xs)
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    member _.feFuncG (children: seq<'El>) = h.CreateWithChildren("feFuncG", children)
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    member _.feFuncR xs = h.CreateEl("feFuncR", xs)
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    member _.feFuncR (children: seq<'El>) = h.CreateWithChildren("feFuncR", children)
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    member _.feGaussianBlur xs = h.CreateEl("feGaussianBlur", xs)
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    member _.feGaussianBlur (children: seq<'El>) = h.CreateWithChildren("feGaussianBlur", children)
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    member _.feImage xs = h.CreateEl("feImage", xs)
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    member _.feImage (children: seq<'El>) = h.CreateWithChildren("feImage", children)
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    member _.feMerge xs = h.CreateEl("feMerge", xs)
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    member _.feMerge (children: seq<'El>) = h.CreateWithChildren("feMerge", children)
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    member _.feMergeNode xs = h.CreateEl("feMergeNode", xs)
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    member _.feMergeNode (children: seq<'El>) = h.CreateWithChildren("feMergeNode", children)
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    member _.feMorphology xs = h.CreateEl("feMorphology", xs)
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    member _.feMorphology (children: seq<'El>) = h.CreateWithChildren("feMorphology", children)
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    member _.feOffset xs = h.CreateEl("feOffset", xs)
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    member _.feOffset (children: seq<'El>) = h.CreateWithChildren("feOffset", children)
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    member _.fePointLight xs = h.CreateEl("fePointLight", xs)
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    member _.fePointLight (children: seq<'El>) = h.CreateWithChildren("fePointLight", children)
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    member _.feSpecularLighting xs = h.CreateEl("feSpecularLighting", xs)
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    member _.feSpecularLighting (children: seq<'El>) = h.CreateWithChildren("feSpecularLighting", children)
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    member _.feSpotLight xs = h.CreateEl("feSpotLight", xs)
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    member _.feSpotLight (children: seq<'El>) = h.CreateWithChildren("feSpotLight", children)
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    member _.feTile xs = h.CreateEl("feTile", xs)
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    member _.feTile (children: seq<'El>) = h.CreateWithChildren("feTile", children)
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    member _.feTurbulence xs = h.CreateEl("feTurbulence", xs)
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    member _.feTurbulence (children: seq<'El>) = h.CreateWithChildren("feTurbulence", children)
    member _.fieldSet xs = h.CreateEl("fieldset", xs)
    member _.fieldSet (children: seq<'El>) = h.CreateWithChildren("fieldset", children)

    member _.figcaption xs = h.CreateEl("figcaption", xs)
    member _.figcaption (children: seq<'El>) = h.CreateWithChildren("figcaption", children)

    member _.figure xs = h.CreateEl("figure", xs)
    member _.figure (children: seq<'El>) = h.CreateWithChildren("figure", children)
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    member _.filter xs = h.CreateEl("filter", xs)
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    member _.filter (children: seq<'El>) = h.CreateWithChildren("filter", children)

    member _.footer xs = h.CreateEl("footer", xs)
    member _.footer (children: seq<'El>) = h.CreateWithChildren("footer", children)
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    member _.foreignObject xs = h.CreateEl("foreignObject", xs)
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    member _.foreignObject (children: seq<'El>) = h.CreateWithChildren("foreignObject", children)

    member _.form xs = h.CreateEl("form", xs)
    member _.form (children: seq<'El>) = h.CreateWithChildren("form", children)

    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    member _.g xs = h.CreateEl("g", xs)
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    member _.g (children: seq<'El>) = h.CreateWithChildren("g", children)

    member _.h1 xs = h.CreateEl("h1", xs)
    member _.h1 (value: float) = h.CreateWithChild("h1", value)
    member _.h1 (value: int) = h.CreateWithChild("h1", value)
    member _.h1 (value: 'El) = h.CreateWithChild("h1", value)
    member _.h1 (value: string) = h.CreateWithChild("h1", value)
    member _.h1 (children: seq<'El>) = h.CreateWithChildren("h1", children)
    member _.h2 xs = h.CreateEl("h2", xs)
    member _.h2 (value: float) =  h.CreateWithChild("h2", value)
    member _.h2 (value: int) =  h.CreateWithChild("h2", value)
    member _.h2 (value: 'El) =  h.CreateWithChild("h2", value)
    member _.h2 (value: string) =  h.CreateWithChild("h2", value)
    member _.h2 (children: seq<'El>) = h.CreateWithChildren("h2", children)

    member _.h3 xs = h.CreateEl("h3", xs)
    member _.h3 (value: float) =  h.CreateWithChild("h3", value)
    member _.h3 (value: int) =  h.CreateWithChild("h3", value)
    member _.h3 (value: 'El) =  h.CreateWithChild("h3", value)
    member _.h3 (value: string) =  h.CreateWithChild("h3", value)
    member _.h3 (children: seq<'El>) = h.CreateWithChildren("h3", children)

    member _.h4 xs = h.CreateEl("h4", xs)
    member _.h4 (value: float) = h.CreateWithChild("h4", value)
    member _.h4 (value: int) = h.CreateWithChild("h4", value)
    member _.h4 (value: 'El) = h.CreateWithChild("h4", value)
    member _.h4 (value: string) = h.CreateWithChild("h4", value)
    member _.h4 (children: seq<'El>) = h.CreateWithChildren("h4", children)

    member _.h5 xs = h.CreateEl("h5", xs)
    member _.h5 (value: float) = h.CreateWithChild("h5", value)
    member _.h5 (value: int) = h.CreateWithChild("h5", value)
    member _.h5 (value: 'El) = h.CreateWithChild("h5", value)
    member _.h5 (value: string) = h.CreateWithChild("h5", value)
    member _.h5 (children: seq<'El>) = h.CreateWithChildren("h5", children)

    member _.h6 xs = h.CreateEl("h6", xs)
    member _.h6 (value: float) = h.CreateWithChild("h6", value)
    member _.h6 (value: int) = h.CreateWithChild("h6", value)
    member _.h6 (value: 'El) = h.CreateWithChild("h6", value)
    member _.h6 (value: string) = h.CreateWithChild("h6", value)
    member _.h6 (children: seq<'El>) = h.CreateWithChildren("h6", children)

    member _.head xs = h.CreateEl("head", xs)
    member _.head (children: seq<'El>) = h.CreateWithChildren("head", children)

    member _.header xs = h.CreateEl("header", xs)
    member _.header (children: seq<'El>) = h.CreateWithChildren("header", children)

    member _.hr xs = h.CreateEl("hr", xs)

    member _.html xs = h.CreateEl("html", xs)
    member _.html (children: seq<'El>) = h.CreateWithChildren("html", children)

    member _.i xs = h.CreateEl("i", xs)
    member _.i (value: float) = h.CreateWithChild("i", value)
    member _.i (value: int) = h.CreateWithChild("i", value)
    member _.i (value: 'El) = h.CreateWithChild("i", value)
    member _.i (value: string) = h.CreateWithChild("i", value)
    member _.i (children: seq<'El>) = h.CreateWithChildren("i", children)

    member _.iframe xs = h.CreateEl("iframe", xs)

    member _.img xs = h.CreateEl("img", xs)
    /// SVG Image element, not to be confused with HTML img alias.
    member _.image xs = h.CreateEl("image", xs)
    /// SVG Image element, not to be confused with HTML img alias.
    member _.image (children: seq<'El>) = h.CreateWithChildren("image", children)

    member _.input xs = h.CreateEl("input", xs)

    member _.ins xs = h.CreateEl("ins", xs)
    member _.ins (value: float) = h.CreateWithChild("ins", value)
    member _.ins (value: int) = h.CreateWithChild("ins", value)
    member _.ins (value: 'El) = h.CreateWithChild("ins", value)
    member _.ins (value: string) = h.CreateWithChild("ins", value)
    member _.ins (children: seq<'El>) = h.CreateWithChildren("ins", children)

    member _.kbd xs = h.CreateEl("kbd", xs)
    member _.kbd (value: float) = h.CreateWithChild("kbd", value)
    member _.kbd (value: int) = h.CreateWithChild("kbd", value)
    member _.kbd (value: 'El) = h.CreateWithChild("kbd", value)
    member _.kbd (value: string) = h.CreateWithChild("kbd", value)
    member _.kbd (children: seq<'El>) = h.CreateWithChildren("kbd", children)

    member _.label xs = h.CreateEl("label", xs)
    member _.label (children: seq<'El>) = h.CreateWithChildren("label", children)

    member _.legend xs = h.CreateEl("legend", xs)
    member _.legend (value: float) = h.CreateWithChild("legend", value)
    member _.legend (value: int) = h.CreateWithChild("legend", value)
    member _.legend (value: 'El) = h.CreateWithChild("legend", value)
    member _.legend (value: string) = h.CreateWithChild("legend", value)
    member _.legend (children: seq<'El>) = h.CreateWithChildren("legend", children)

    member _.li xs = h.CreateEl("li", xs)
    member _.li (value: float) = h.CreateWithChild("li", value)
    member _.li (value: int) = h.CreateWithChild("li", value)
    member _.li (value: 'El) = h.CreateWithChild("li", value)
    member _.li (value: string) = h.CreateWithChild("li", value)
    member _.li (children: seq<'El>) = h.CreateWithChildren("li", children)
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    member _.line xs = h.CreateEl("line", xs)
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    member _.line (children: seq<'El>) = h.CreateWithChildren("line", children)
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    member _.linearGradient xs = h.CreateEl("linearGradient", xs)
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    member _.linearGradient (children: seq<'El>) = h.CreateWithChildren("linearGradient", children)

    member _.link xs = h.CreateEl("link", xs)

    member _.listItem xs = h.CreateEl("li", xs)
    member _.listItem (value: float) = h.CreateWithChild("li", value)
    member _.listItem (value: int) = h.CreateWithChild("li", value)
    member _.listItem (value: 'El) = h.CreateWithChild("li", value)
    member _.listItem (value: string) = h.CreateWithChild("li", value)
    member _.listItem (children: seq<'El>) = h.CreateWithChildren("li", children)

    member _.main xs = h.CreateEl("main", xs)
    member _.main (children: seq<'El>) = h.CreateWithChildren("main", children)

    member _.map xs = h.CreateEl("map", xs)
    member _.map (children: seq<'El>) = h.CreateWithChildren("map", children)

    member _.mark xs = h.CreateEl("mark", xs)
    member _.mark (value: float) = h.CreateWithChild("mark", value)
    member _.mark (value: int) = h.CreateWithChild("mark", value)
    member _.mark (value: 'El) = h.CreateWithChild("mark", value)
    member _.mark (value: string) = h.CreateWithChild("mark", value)
    member _.mark (children: seq<'El>) = h.CreateWithChildren("mark", children)
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    member _.marker xs = h.CreateEl("marker", xs)
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    member _.marker (children: seq<'El>) = h.CreateWithChildren("marker", children)
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    member _.mask xs = h.CreateEl("mask", xs)
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    member _.mask (children: seq<'El>) = h.CreateWithChildren("mask", children)

    member _.meta xs = h.CreateEl("meta", xs)

    member _.metadata xs = h.CreateEl("metadata", xs)
    member _.metadata (children: seq<'El>) = h.CreateWithChildren("metadata", children)

    member _.meter xs = h.CreateEl("meter", xs)
    member _.meter (value: float) = h.CreateWithChild("meter", value)
    member _.meter (value: int) = h.CreateWithChild("meter", value)
    member _.meter (value: 'El) = h.CreateWithChild("meter", value)
    member _.meter (value: string) = h.CreateWithChild("meter", value)
    member _.meter (children: seq<'El>) = h.CreateWithChildren("meter", children)
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    member _.mpath xs = h.CreateEl("mpath", xs)
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    member _.mpath (children: seq<'El>) = h.CreateWithChildren("mpath", children)
    member _.nav xs = h.CreateEl("nav", xs)
    member _.nav (children: seq<'El>) = h.CreateWithChildren("nav", children)

    /// The empty element, renders nothing on screen
    member _.none : 'El = h.EmptyEl

    member _.noscript xs = h.CreateEl("noscript", xs)
    member _.noscript (children: seq<'El>) = h.CreateWithChildren("noscript", children)

    member _.object xs = h.CreateEl("object", xs)
    member _.object (children: seq<'El>) = h.CreateWithChildren("object", children)

    member _.ol xs = h.CreateEl("ol", xs)
    member _.ol (children: seq<'El>) = h.CreateWithChildren("ol", children)

    member _.option xs = h.CreateEl("option", xs)
    member _.option (value: float) = h.CreateWithChild("option", value)
    member _.option (value: int) = h.CreateWithChild("option", value)
    member _.option (value: 'El) = h.CreateWithChild("option", value)
    member _.option (value: string) = h.CreateWithChild("option", value)
    member _.option (children: seq<'El>) = h.CreateWithChildren("option", children)

    member _.optgroup xs = h.CreateEl("optgroup", xs)
    member _.optgroup (children: seq<'El>) = h.CreateWithChildren("optgroup", children)

    member _.orderedList xs = h.CreateEl("ol", xs)
    member _.orderedList (children: seq<'El>) = h.CreateWithChildren("ol", children)

    member _.output xs = h.CreateEl("output", xs)
    member _.output (value: float) = h.CreateWithChild("output", value)
    member _.output (value: int) = h.CreateWithChild("output", value)
    member _.output (value: 'El) = h.CreateWithChild("output", value)
    member _.output (value: string) = h.CreateWithChild("output", value)
    member _.output (children: seq<'El>) = h.CreateWithChildren("output", children)

    member _.p xs = h.CreateEl("p", xs)
    member _.p (value: float) = h.CreateWithChild("p", value)
    member _.p (value: int) = h.CreateWithChild("p", value)
    member _.p (value: 'El) = h.CreateWithChild("p", value)
    member _.p (value: string) = h.CreateWithChild("p", value)
    member _.p (children: seq<'El>) = h.CreateWithChildren("p", children)

    member _.paragraph xs = h.CreateEl("p", xs)
    member _.paragraph (value: float) = h.CreateWithChild("p", value)
    member _.paragraph (value: int) = h.CreateWithChild("p", value)
    member _.paragraph (value: 'El) = h.CreateWithChild("p", value)
    member _.paragraph (value: string) = h.CreateWithChild("p", value)
    member _.paragraph (children: seq<'El>) = h.CreateWithChildren("p", children)

    member _.param xs = h.CreateEl("param", xs)
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    member _.path xs = h.CreateEl("path", xs)
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    member _.path (children: seq<'El>) = h.CreateWithChildren("path", children)
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    member _.pattern xs = h.CreateEl("pattern", xs)
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    member _.pattern (children: seq<'El>) = h.CreateWithChildren("pattern", children)
    member _.picture xs = h.CreateEl("picture", xs)
    member _.picture (children: seq<'El>) = h.CreateWithChildren("picture", children)
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    member _.polygon xs = h.CreateEl("polygon", xs)
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    member _.polygon (children: seq<'El>) = h.CreateWithChildren("polygon", children)
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    member _.polyline xs = h.CreateEl("polyline", xs)
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    member _.polyline (children: seq<'El>) = h.CreateWithChildren("polyline", children)
    member _.pre xs = h.CreateEl("pre", xs)
    member _.pre (value: bool) = h.CreateWithChild("pre", value)
    member _.pre (value: float) = h.CreateWithChild("pre", value)
    member _.pre (value: int) = h.CreateWithChild("pre", value)
    member _.pre (value: 'El) = h.CreateWithChild("pre", value)
    member _.pre (value: string) = h.CreateWithChild("pre", value)
    member _.pre (children: seq<'El>) = h.CreateWithChildren("pre", children)

    member _.progress xs = h.CreateEl("progress", xs)
    member _.progress (children: seq<'El>) = h.CreateWithChildren("progress", children)

    member _.q xs = h.CreateEl("q", xs)
    member _.q (children: seq<'El>) = h.CreateWithChildren("q", children)
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    member _.radialGradient xs = h.CreateEl("radialGradient", xs)
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    member _.radialGradient (children: seq<'El>) = h.CreateWithChildren("radialGradient", children)

    member _.rb xs = h.CreateEl("rb", xs)
    member _.rb (value: float) = h.CreateWithChild("rb", value)
    member _.rb (value: int) = h.CreateWithChild("rb", value)
    member _.rb (value: 'El) = h.CreateWithChild("rb", value)
    member _.rb (value: string) = h.CreateWithChild("rb", value)
    member _.rb (children: seq<'El>) = h.CreateWithChildren("rb", children)
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    member _.rect xs = h.CreateEl("rect", xs)
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    member _.rect (children: seq<'El>) = h.CreateWithChildren("rect", children)

    member _.rp xs = h.CreateEl("rp", xs)
    member _.rp (value: float) = h.CreateWithChild("rp", value)
    member _.rp (value: int) = h.CreateWithChild("rp", value)
    member _.rp (value: 'El) = h.CreateWithChild("rp", value)
    member _.rp (value: string) = h.CreateWithChild("rp", value)
    member _.rp (children: seq<'El>) = h.CreateWithChildren("rp", children)

    member _.rt xs = h.CreateEl("rt", xs)
    member _.rt (value: float) = h.CreateWithChild("rt", value)
    member _.rt (value: int) = h.CreateWithChild("rt", value)
    member _.rt (value: 'El) = h.CreateWithChild("rt", value)
    member _.rt (value: string) = h.CreateWithChild("rt", value)
    member _.rt (children: seq<'El>) = h.CreateWithChildren("rt", children)

    member _.rtc xs = h.CreateEl("rtc", xs)
    member _.rtc (value: float) = h.CreateWithChild("rtc", value)
    member _.rtc (value: int) = h.CreateWithChild("rtc", value)
    member _.rtc (value: 'El) = h.CreateWithChild("rtc", value)
    member _.rtc (value: string) = h.CreateWithChild("rtc", value)
    member _.rtc (children: seq<'El>) = h.CreateWithChildren("rtc", children)

    member _.ruby xs = h.CreateEl("ruby", xs)
    member _.ruby (value: float) = h.CreateWithChild("ruby", value)
    member _.ruby (value: int) = h.CreateWithChild("ruby", value)
    member _.ruby (value: 'El) = h.CreateWithChild("ruby", value)
    member _.ruby (value: string) = h.CreateWithChild("ruby", value)
    member _.ruby (children: seq<'El>) = h.CreateWithChildren("ruby", children)

    member _.s xs = h.CreateEl("s", xs)
    member _.s (value: float) = h.CreateWithChild("s", value)
    member _.s (value: int) = h.CreateWithChild("s", value)
    member _.s (value: 'El) = h.CreateWithChild("s", value)
    member _.s (value: string) = h.CreateWithChild("s", value)
    member _.s (children: seq<'El>) = h.CreateWithChildren("s", children)

    member _.samp xs = h.CreateEl("samp", xs)
    member _.samp (value: float) = h.CreateWithChild("samp", value)
    member _.samp (value: int) = h.CreateWithChild("samp", value)
    member _.samp (value: 'El) = h.CreateWithChild("samp", value)
    member _.samp (value: string) = h.CreateWithChild("samp", value)
    member _.samp (children: seq<'El>) = h.CreateWithChildren("samp", children)

    member _.script xs = h.CreateEl("script", xs)
    member _.script (children: seq<'El>) = h.CreateWithChildren("script", children)

    member _.section xs = h.CreateEl("section", xs)
    member _.section (children: seq<'El>) = h.CreateWithChildren("section", children)

    member _.select xs = h.CreateEl("select", xs)
    member _.select (children: seq<'El>) = h.CreateWithChildren("select", children)
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    member _.set xs = h.CreateEl("set", xs)
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    member _.set (children: seq<'El>) = h.CreateWithChildren("set", children)

    member _.small xs = h.CreateEl("small", xs)
    member _.small (value: float) = h.CreateWithChild("small", value)
    member _.small (value: int) = h.CreateWithChild("small", value)
    member _.small (value: 'El) = h.CreateWithChild("small", value)
    member _.small (value: string) = h.CreateWithChild("small", value)
    member _.small (children: seq<'El>) = h.CreateWithChildren("small", children)

    member _.source xs = h.CreateEl("source", xs)

    member _.span xs = h.CreateEl("span", xs)
    member _.span (value: float) = h.CreateWithChild("span", value)
    member _.span (value: int) = h.CreateWithChild("span", value)
    member _.span (value: 'El) = h.CreateWithChild("span", value)
    member _.span (value: string) = h.CreateWithChild("span", value)
    member _.span (children: seq<'El>) = h.CreateWithChildren("span", children)
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    member _.stop xs = h.CreateEl("stop", xs)
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    member _.stop (children: seq<'El>) = h.CreateWithChildren("stop", children)

    member _.strong xs = h.CreateEl("strong", xs)
    member _.strong (value: float) = h.CreateWithChild("strong", value)
    member _.strong (value: int) = h.CreateWithChild("strong", value)
    member _.strong (value: 'El) = h.CreateWithChild("strong", value)
    member _.strong (value: string) = h.CreateWithChild("strong", value)
    member _.strong (children: seq<'El>) = h.CreateWithChildren("strong", children)

    member _.style xs = h.CreateEl("style", xs)
    member _.style (value: string) = h.CreateWithChild("style", value)

    member _.sub xs = h.CreateEl("sub", xs)
    member _.sub (value: float) = h.CreateWithChild("sub", value)
    member _.sub (value: int) = h.CreateWithChild("sub", value)
    member _.sub (value: 'El) = h.CreateWithChild("sub", value)
    member _.sub (value: string) = h.CreateWithChild("sub", value)
    member _.sub (children: seq<'El>) = h.CreateWithChildren("sub", children)

    member _.summary xs = h.CreateEl("summary", xs)
    member _.summary (value: float) = h.CreateWithChild("summary", value)
    member _.summary (value: int) = h.CreateWithChild("summary", value)
    member _.summary (value: 'El) = h.CreateWithChild("summary", value)
    member _.summary (value: string) = h.CreateWithChild("summary", value)
    member _.summary (children: seq<'El>) = h.CreateWithChildren("summary", children)

    member _.sup xs = h.CreateEl("sup", xs)
    member _.sup (value: float) = h.CreateWithChild("sup", value)
    member _.sup (value: int) = h.CreateWithChild("sup", value)
    member _.sup (value: 'El) = h.CreateWithChild("sup", value)
    member _.sup (value: string) = h.CreateWithChild("sup", value)
    member _.sup (children: seq<'El>) = h.CreateWithChildren("sup", children)

    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    member _.svg xs = h.CreateEl("svg", xs)
    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    member _.svg (children: seq<'El>) = h.CreateWithChildren("svg", children)
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    member _.switch xs = h.CreateEl("switch", xs)
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    member _.switch (children: seq<'El>) = h.CreateWithChildren("switch", children)
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    member _.symbol xs = h.CreateEl("symbol", xs)
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    member _.symbol (children: seq<'El>) = h.CreateWithChildren("symbol", children)

    member _.table xs = h.CreateEl("table", xs)
    member _.table (children: seq<'El>) = h.CreateWithChildren("table", children)

    member _.tableBody xs = h.CreateEl("tbody", xs)
    member _.tableBody (children: seq<'El>) = h.CreateWithChildren("tbody", children)

    member _.tableCell xs = h.CreateEl("td", xs)
    member _.tableCell (children: seq<'El>) = h.CreateWithChildren("td", children)

    member _.tableHeader xs = h.CreateEl("th", xs)
    member _.tableHeader (children: seq<'El>) = h.CreateWithChildren("th", children)

    member _.tableRow xs = h.CreateEl("tr", xs)
    member _.tableRow (children: seq<'El>) = h.CreateWithChildren("tr", children)

    member _.tbody xs = h.CreateEl("tbody", xs)
    member _.tbody (children: seq<'El>) = h.CreateWithChildren("tbody", children)

    member _.td xs = h.CreateEl("td", xs)
    member _.td (value: float) = h.CreateWithChild("td", value)
    member _.td (value: int) = h.CreateWithChild("td", value)
    member _.td (value: 'El) = h.CreateWithChild("td", value)
    member _.td (value: string) = h.CreateWithChild("td", value)
    member _.td (children: seq<'El>) = h.CreateWithChildren("td", children)

    member _.template xs = h.CreateEl("template", xs)
    member _.template (children: seq<'El>) = h.CreateWithChildren("template", children)

    [<Obsolete "Html.text is obsolete for creating <text> SVG elements. Use Svg.text instead">]
    member _.text xs = h.CreateEl("text", xs)
    member _.text (value: float) : 'El = h.FloatToEl value
    member _.text (value: int) : 'El = h.IntToEl value
    member _.text (value: string) : 'El = h.StringToEl value
    member _.text (value: System.Guid) : 'El = h.StringToEl (string value)

    member this.textf fmt = Printf.kprintf this.text fmt

    member _.textarea xs = h.CreateEl("textarea", xs)
    member _.textarea (children: seq<'El>) = h.CreateWithChildren("textarea", children)
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    member _.textPath xs = h.CreateEl("textPath", xs)
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    member _.textPath (children: seq<'El>) = h.CreateWithChildren("textPath", children)

    member _.tfoot xs = h.CreateEl("tfoot", xs)
    member _.tfoot (children: seq<'El>) = h.CreateWithChildren("tfoot", children)

    member _.th xs = h.CreateEl("th", xs)
    member _.th (value: float) = h.CreateWithChild("th", value)
    member _.th (value: int) = h.CreateWithChild("th", value)
    member _.th (value: 'El) = h.CreateWithChild("th", value)
    member _.th (value: string) = h.CreateWithChild("th", value)
    member _.th (children: seq<'El>) = h.CreateWithChildren("th", children)

    member _.thead xs = h.CreateEl("thead", xs)
    member _.thead (children: seq<'El>) = h.CreateWithChildren("thead", children)

    member _.time xs = h.CreateEl("time", xs)
    member _.time (children: seq<'El>) = h.CreateWithChildren("time", children)

    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title xs = h.CreateEl("title", xs)
    member _.title (value: float) = h.CreateWithChild("title", value)
    member _.title (value: int) = h.CreateWithChild("title", value)
    member _.title (value: 'El) = h.CreateWithChild("title", value)
    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title (value: string) = h.CreateWithChild("title", value)
    [<Obsolete "Html.title is obsolete for creating <title> SVG elements, use Svg.title instead">]
    member _.title (children: seq<'El>) = h.CreateWithChildren("title", children)

    member _.tr xs = h.CreateEl("tr", xs)
    member _.tr (children: seq<'El>) = h.CreateWithChildren("tr", children)

    member _.track xs = h.CreateEl("track", xs)
    [<Obsolete "Html.tspan is obsolete, use Svg.tsapn instead">]
    member _.tspan xs = h.CreateEl("tspan", xs)
    [<Obsolete "Html.tspan is obsolete, use Svg.tsapn instead">]
    member _.tspan (children: seq<'El>) = h.CreateWithChildren("tspan", children)

    member _.u xs = h.CreateEl("u", xs)
    member _.u (value: float) = h.CreateWithChild("u", value)
    member _.u (value: int) = h.CreateWithChild("u", value)
    member _.u (value: 'El) = h.CreateWithChild("u", value)
    member _.u (value: string) = h.CreateWithChild("u", value)
    member _.u (children: seq<'El>) = h.CreateWithChildren("u", children)

    member _.ul xs = h.CreateEl("ul", xs)
    member _.ul (children: seq<'El>) = h.CreateWithChildren("ul", children)

    member _.unorderedList xs = h.CreateEl("ul", xs)
    member _.unorderedList (children: seq<'El>) = h.CreateWithChildren("ul", children)
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    member _.use' xs = h.CreateEl("use", xs)
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    member _.use' (children: seq<'El>) = h.CreateWithChildren("use", children)
    member _.var xs = h.CreateEl("var", xs)
    member _.var (value: float) = h.CreateWithChild("var", value)
    member _.var (value: int) = h.CreateWithChild("var", value)
    member _.var (value: 'El) = h.CreateWithChild("var", value)
    member _.var (value: string) = h.CreateWithChild("var", value)
    member _.var (children: seq<'El>) = h.CreateWithChildren("var", children)

    member _.video xs = h.CreateEl("video", xs)
    member _.video (children: seq<'El>) = h.CreateWithChildren("video", children)
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    member _.view xs = h.CreateEl("view", xs)
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    member _.view (children: seq<'El>) = h.CreateWithChildren("view", children)

    member _.wbr xs = h.CreateEl("wbr", xs)