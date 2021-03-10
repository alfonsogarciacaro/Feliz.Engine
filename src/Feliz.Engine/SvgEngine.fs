namespace Feliz

open System

// Use Func to avoid Fable checking the arity at runtime because of the returning generic

type SvgEngine<'Node>(makeNode: Func<string, 'Node seq, 'Node>,
                      stringToNode: Func<string, 'Node>,
                      emptyNode: Func<'Node>) =

    let makeNode key children = makeNode.Invoke(key, children)
    let stringToNode s = stringToNode.Invoke(s)

    /// Create a custom element
    ///
    /// You generally shouldn't need to use this, if you notice an element missing please submit an issue.
    member _.custom (key: string, children: seq<'Node>) = makeNode key children
    /// The empty element, renders nothing on screen
    member _.none : 'Node = emptyNode.Invoke()

    /// SVG Image element, not to be confused with HTML img alias.
    member _.image (children: seq<'Node>) = makeNode "image" children
    /// The svg element is a container that defines a new coordinate system and viewport. It is used as the outermost element of SVG documents, but it can also be used to embed an SVG fragment inside an SVG or HTML document.
    member _.svg (children: seq<'Node>) = makeNode "svg" children
    member _.circle (children: seq<'Node>) = makeNode "circle" children
    member _.clipPath (children: seq<'Node>) = makeNode "clipPath" children
    /// The <defs> element is used to store graphical objects that will be used at a later time. Objects created inside a <defs> element are not rendered directly. To display them you have to reference them (with a <use> element for example). https://developer.mozilla.org/en-US/docs/Web/SVG/Element/defs
    member _.defs (children: seq<'Node>) = makeNode "defs" children
    /// The <desc> element provides an accessible, long-text description of any SVG container element or graphics element.
    member _.desc (value: string) = makeNode "desc" [stringToNode value]
    member _.ellipse (children: seq<'Node>) = makeNode "ellipse" children
    member _.feBlend (children: seq<'Node>) = makeNode "feBlend" children
    member _.feColorMatrix (children: seq<'Node>) = makeNode "feColorMatrix" children
    member _.feComponentTransfer (children: seq<'Node>) = makeNode "feComponentTransfer" children
    member _.feComposite (children: seq<'Node>) = makeNode "feComposite" children
    member _.feConvolveMatrix (children: seq<'Node>) = makeNode "feConvolveMatrix" children
    member _.feDiffuseLighting (children: seq<'Node>) = makeNode "feDiffuseLighting" children
    member _.feDisplacementMap (children: seq<'Node>) = makeNode "feDisplacementMap" children
    member _.feDistantLight (children: seq<'Node>) = makeNode "feDistantLight" children
    member _.feDropShadow (children: seq<'Node>) = makeNode "feDropShadow" children
    member _.feFlood (children: seq<'Node>) = makeNode "feFlood" children
    member _.feFuncA (children: seq<'Node>) = makeNode "feFuncA" children
    member _.feFuncB (children: seq<'Node>) = makeNode "feFuncB" children
    member _.feFuncG (children: seq<'Node>) = makeNode "feFuncG" children
    member _.feFuncR (children: seq<'Node>) = makeNode "feFuncR" children
    member _.feGaussianBlur (children: seq<'Node>) = makeNode "feGaussianBlur" children
    member _.feImage (children: seq<'Node>) = makeNode "feImage" children
    member _.feMerge (children: seq<'Node>) = makeNode "feMerge" children
    member _.feMergeNode (children: seq<'Node>) = makeNode "feMergeNode" children
    member _.feMorphology (children: seq<'Node>) = makeNode "feMorphology" children
    member _.feOffset (children: seq<'Node>) = makeNode "feOffset" children
    member _.fePointLight (children: seq<'Node>) = makeNode "fePointLight" children
    member _.feSpecularLighting (children: seq<'Node>) = makeNode "feSpecularLighting" children
    member _.feSpotLight (children: seq<'Node>) = makeNode "feSpotLight" children
    member _.feTile (children: seq<'Node>) = makeNode "feTile" children
    member _.feTurbulence (children: seq<'Node>) = makeNode "feTurbulence" children
    member _.filter (children: seq<'Node>) = makeNode "filter" children
    member _.foreignObject (children: seq<'Node>) = makeNode "foreignObject" children
    /// The <g> SVG element is a container used to group other SVG elements.
    ///
    /// Transformations applied to the <g> element are performed on its child elements, and its attributes are inherited by its children. It can also group multiple elements to be referenced later with the <use> element.
    member _.g (children: seq<'Node>) = makeNode "g" children
    member _.line (children: seq<'Node>) = makeNode "line" children
    member _.linearGradient (children: seq<'Node>) = makeNode "linearGradient" children
    /// The <marker> element defines the graphic that is to be used for drawing arrowheads or polymarkers on a given <path>, <line>, <polyline> or <polygon> element.
    member _.marker (children: seq<'Node>) = makeNode "marker" children
    member _.mask (children: seq<'Node>) = makeNode "marker" children
    member _.mpath (children: seq<'Node>) = makeNode "mpath" children
    member _.path (children: seq<'Node>) = makeNode "path" children
    member _.pattern (children: seq<'Node>) = makeNode "pattern" children
    member _.polygon (children: seq<'Node>) = makeNode "polygon" children
    member _.polyline (children: seq<'Node>) = makeNode "polyline" children
    member _.set (children: seq<'Node>) = makeNode "set" children
    member _.stop (children: seq<'Node>) = makeNode "stop" children
    member _.style (value: string) = makeNode "style" [stringToNode value]
    member _.switch (children: seq<'Node>) = makeNode "switch" children
    member _.symbol (children: seq<'Node>) = makeNode "symbol" children
    member _.text (content: string) = makeNode "text" [stringToNode content]
    member _.title (content: string) = makeNode "title" [stringToNode content]
    member _.textPath (children: seq<'Node>) = makeNode "textPath" children
    member _.tspan (children: seq<'Node>) = makeNode "tspan" children
    member _.use' (children: seq<'Node>) = makeNode "use" children
    member _.radialGradient (children: seq<'Node>) = makeNode "radialGradient" children
    member _.rect (children: seq<'Node>) = makeNode "rect" children
    member _.view (children: seq<'Node>) = makeNode "view" children
