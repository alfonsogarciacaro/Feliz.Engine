namespace Feliz

open System

// Use Func to avoid Fable checking the arity at runtime because of the returning generic

type HtmlEngine<'Node>(makeNode: Func<string, 'Node seq, 'Node>,
                       stringToNode: Func<string, 'Node>,
                       emptyNode: Func<'Node>) =

    let makeNode key children = makeNode.Invoke(key, children)
    let stringToNode s = stringToNode.Invoke(s)

    /// Create a custom element
    ///
    /// You generally shouldn't need to use this, if you notice an element missing please submit an issue.
    member _.custom (key: string, children: seq<'Node>) = makeNode  key children
    /// The empty element, renders nothing on screen
    member _.none : 'Node = emptyNode.Invoke()

    member _.a (children: seq<'Node>) = makeNode  "a" children

    member _.abbr (value: float) = makeNode  "abbr" [Util.asString value |> stringToNode]
    member _.abbr (value: int) = makeNode  "abbr" [Util.asString value |> stringToNode]
    member _.abbr (value: 'Node) = makeNode  "abbr" [value]
    member _.abbr (value: string) = makeNode  "abbr" [stringToNode value]
    member _.abbr (children: seq<'Node>) = makeNode  "abbr" children

    member _.address (value: float) = makeNode  "address" [Util.asString value |> stringToNode]
    member _.address (value: int) = makeNode  "address" [Util.asString value |> stringToNode]
    member _.address (value: 'Node) = makeNode  "address" [value]
    member _.address (value: string) = makeNode  "address" [stringToNode value]
    member _.address (children: seq<'Node>) = makeNode  "address" children

    member _.anchor (children: seq<'Node>) = makeNode  "a" children

    member _.area (children: seq<'Node>) = makeNode  "area" children

    member _.article (children: seq<'Node>) = makeNode  "article" children

    member _.aside (children: seq<'Node>) = makeNode  "aside" children

    member _.audio (children: seq<'Node>) = makeNode  "audio" children

    member _.b (value: float) = makeNode  "b" [Util.asString value |> stringToNode]
    member _.b (value: int) = makeNode  "b" [Util.asString value |> stringToNode]
    member _.b (value: 'Node) = makeNode  "b" [value]
    member _.b (value: string) = makeNode  "b" [stringToNode value]
    member _.b (children: seq<'Node>) = makeNode  "b" children

    member _.base' (children: seq<'Node>) = makeNode  "base" children

    member _.bdi (value: float) = makeNode  "bdi" [Util.asString value |> stringToNode]
    member _.bdi (value: int) = makeNode  "bdi" [Util.asString value |> stringToNode]
    member _.bdi (value: 'Node) = makeNode  "bdi" [value]
    member _.bdi (value: string) = makeNode  "bdi" [stringToNode value]
    member _.bdi (children: seq<'Node>) = makeNode  "bdi" children

    member _.bdo (value: float) = makeNode  "bdo" [Util.asString value |> stringToNode]
    member _.bdo (value: int) = makeNode  "bdo" [Util.asString value |> stringToNode]
    member _.bdo (value: 'Node) = makeNode  "bdo" [value]
    member _.bdo (value: string) = makeNode  "bdo" [stringToNode value]
    member _.bdo (children: seq<'Node>) = makeNode  "bdo" children

    member _.blockquote (value: float) = makeNode  "blockquote" [Util.asString value |> stringToNode]
    member _.blockquote (value: int) = makeNode  "blockquote" [Util.asString value |> stringToNode]
    member _.blockquote (value: 'Node) = makeNode  "blockquote" [value]
    member _.blockquote (value: string) = makeNode  "blockquote" [stringToNode value]
    member _.blockquote (children: seq<'Node>) = makeNode  "blockquote" children

    member _.body (value: float) = makeNode  "body" [Util.asString value |> stringToNode]
    member _.body (value: int) = makeNode  "body" [Util.asString value |> stringToNode]
    member _.body (value: 'Node) = makeNode  "body" [value]
    member _.body (value: string) = makeNode  "body" [stringToNode value]
    member _.body (children: seq<'Node>) = makeNode  "body" children

    member _.br (children: seq<'Node>) = makeNode  "br" children

    member _.button (children: seq<'Node>) = makeNode  "button" children

    member _.canvas (children: seq<'Node>) = makeNode  "canvas" children

    member _.caption (value: float) = makeNode  "caption" [Util.asString value |> stringToNode]
    member _.caption (value: int) = makeNode  "caption" [Util.asString value |> stringToNode]
    member _.caption (value: 'Node) = makeNode  "caption" [value]
    member _.caption (value: string) = makeNode  "caption" [stringToNode value]
    member _.caption (children: seq<'Node>) = makeNode  "caption" children

    member _.cite (value: float) = makeNode  "cite" [Util.asString value |> stringToNode]
    member _.cite (value: int) = makeNode  "cite" [Util.asString value |> stringToNode]
    member _.cite (value: 'Node) = makeNode  "cite" [value]
    member _.cite (value: string) = makeNode  "cite" [stringToNode value]
    member _.cite (children: seq<'Node>) = makeNode  "cite" children

    // member _.code (value: bool) = makeNode  "code" value
    member _.code (value: float) = makeNode  "code" [Util.asString value |> stringToNode]
    member _.code (value: int) = makeNode  "code" [Util.asString value |> stringToNode]
    member _.code (value: 'Node) = makeNode  "code" [value]
    member _.code (value: string) = makeNode  "code" [stringToNode value]
    member _.code (children: seq<'Node>) = makeNode  "code" children

    member _.col (children: seq<'Node>) = makeNode  "col" children

    member _.colgroup (children: seq<'Node>) = makeNode  "colgroup" children

    member _.data (value: float) = makeNode  "data" [Util.asString value |> stringToNode]
    member _.data (value: int) = makeNode  "data" [Util.asString value |> stringToNode]
    member _.data (value: 'Node) = makeNode  "data" [value]
    member _.data (value: string) = makeNode  "data" [stringToNode value]
    member _.data (children: seq<'Node>) = makeNode  "data" children

    member _.datalist (value: float) = makeNode  "datalist" [Util.asString value |> stringToNode]
    member _.datalist (value: int) = makeNode  "datalist" [Util.asString value |> stringToNode]
    member _.datalist (value: 'Node) = makeNode  "datalist" [value]
    member _.datalist (value: string) = makeNode  "datalist" [stringToNode value]
    member _.datalist (children: seq<'Node>) = makeNode  "datalist" children

    member _.dd (value: float) = makeNode  "dd" [Util.asString value |> stringToNode]
    member _.dd (value: int) = makeNode  "dd" [Util.asString value |> stringToNode]
    member _.dd (value: 'Node) = makeNode  "dd" [value]
    member _.dd (value: string) = makeNode  "dd" [stringToNode value]
    member _.dd (children: seq<'Node>) = makeNode  "dd" children

    member _.del (value: float) = makeNode  "del" [Util.asString value |> stringToNode]
    member _.del (value: int) = makeNode  "del" [Util.asString value |> stringToNode]
    member _.del (value: 'Node) = makeNode  "del" [value]
    member _.del (value: string) = makeNode  "del" [stringToNode value]
    member _.del (children: seq<'Node>) = makeNode  "del" children

    member _.details (children: seq<'Node>) = makeNode  "details" children

    member _.dfn (value: float) = makeNode  "dfn" [Util.asString value |> stringToNode]
    member _.dfn (value: int) = makeNode  "dfn" [Util.asString value |> stringToNode]
    member _.dfn (value: 'Node) = makeNode  "dfn" [value]
    member _.dfn (value: string) = makeNode  "dfn" [stringToNode value]
    member _.dfn (children: seq<'Node>) = makeNode  "dfn" children

    member _.dialog (value: float) = makeNode  "dialog" [Util.asString value |> stringToNode]
    member _.dialog (value: int) = makeNode  "dialog" [Util.asString value |> stringToNode]
    member _.dialog (value: 'Node) = makeNode  "dialog" [value]
    member _.dialog (value: string) = makeNode  "dialog" [stringToNode value]
    member _.dialog (children: seq<'Node>) = makeNode  "dialog" children

    member _.div (value: float) = makeNode  "div" [Util.asString value |> stringToNode]
    member _.div (value: int) = makeNode  "div" [Util.asString value |> stringToNode]
    member _.div (value: 'Node) = makeNode  "div" [value]
    member _.div (value: string) = makeNode  "div" [stringToNode value]
    /// The `<div>` tag defines a division or a section in an HTML document
    member _.div (children: seq<'Node>) = makeNode  "div" children

    member _.dl (children: seq<'Node>) = makeNode  "dl" children

    member _.dt (value: float) = makeNode  "dt" [Util.asString value |> stringToNode]
    member _.dt (value: int) = makeNode  "dt" [Util.asString value |> stringToNode]
    member _.dt (value: 'Node) = makeNode  "dt" [value]
    member _.dt (value: string) = makeNode  "dt" [stringToNode value]
    member _.dt (children: seq<'Node>) = makeNode  "dt" children

    member _.em (value: float) = makeNode  "em" [Util.asString value |> stringToNode]
    member _.em (value: int) = makeNode  "em" [Util.asString value |> stringToNode]
    member _.em (value: 'Node) = makeNode  "em" [value]
    member _.em (value: string) = makeNode  "em" [stringToNode value]
    member _.em (children: seq<'Node>) = makeNode  "em" children

    member _.fieldSet (children: seq<'Node>) = makeNode  "fieldset" children

    member _.figcaption (children: seq<'Node>) = makeNode  "figcaption" children

    member _.figure (children: seq<'Node>) = makeNode  "figure" children

    member _.footer (children: seq<'Node>) = makeNode  "footer" children

    member _.form (children: seq<'Node>) = makeNode  "form" children

    member _.h1 (value: float) = makeNode  "h1" [Util.asString value |> stringToNode]
    member _.h1 (value: int) = makeNode  "h1" [Util.asString value |> stringToNode]
    member _.h1 (value: 'Node) = makeNode  "h1" [value]
    member _.h1 (value: string) = makeNode  "h1" [stringToNode value]
    member _.h1 (children: seq<'Node>) = makeNode  "h1" children
    member _.h2 (value: float) = makeNode "h2" [Util.asString value |> stringToNode]
    member _.h2 (value: int) = makeNode "h2" [Util.asString value |> stringToNode]
    member _.h2 (value: 'Node) = makeNode "h2" [value]
    member _.h2 (value: string) = makeNode "h2" [stringToNode value]
    member _.h2 (children: seq<'Node>) = makeNode  "h2" children

    member _.h3 (value: float) = makeNode "h3" [Util.asString value |> stringToNode]
    member _.h3 (value: int) = makeNode "h3" [Util.asString value |> stringToNode]
    member _.h3 (value: 'Node) = makeNode "h3" [value]
    member _.h3 (value: string) = makeNode "h3" [stringToNode value]
    member _.h3 (children: seq<'Node>) = makeNode  "h3" children

    member _.h4 (value: float) = makeNode  "h4" [Util.asString value |> stringToNode]
    member _.h4 (value: int) = makeNode  "h4" [Util.asString value |> stringToNode]
    member _.h4 (value: 'Node) = makeNode  "h4" [value]
    member _.h4 (value: string) = makeNode  "h4" [stringToNode value]
    member _.h4 (children: seq<'Node>) = makeNode  "h4" children

    member _.h5 (value: float) = makeNode  "h5" [Util.asString value |> stringToNode]
    member _.h5 (value: int) = makeNode  "h5" [Util.asString value |> stringToNode]
    member _.h5 (value: 'Node) = makeNode  "h5" [value]
    member _.h5 (value: string) = makeNode  "h5" [stringToNode value]
    member _.h5 (children: seq<'Node>) = makeNode  "h5" children

    member _.h6 (value: float) = makeNode  "h6" [Util.asString value |> stringToNode]
    member _.h6 (value: int) = makeNode  "h6" [Util.asString value |> stringToNode]
    member _.h6 (value: 'Node) = makeNode  "h6" [value]
    member _.h6 (value: string) = makeNode  "h6" [stringToNode value]
    member _.h6 (children: seq<'Node>) = makeNode  "h6" children

    member _.head (children: seq<'Node>) = makeNode  "head" children

    member _.header (children: seq<'Node>) = makeNode  "header" children

    member _.hr (children: seq<'Node>) = makeNode  "hr" children

    member _.html (children: seq<'Node>) = makeNode  "html" children

    member _.i (value: float) = makeNode  "i" [Util.asString value |> stringToNode]
    member _.i (value: int) = makeNode  "i" [Util.asString value |> stringToNode]
    member _.i (value: 'Node) = makeNode  "i" [value]
    member _.i (value: string) = makeNode  "i" [stringToNode value]
    member _.i (children: seq<'Node>) = makeNode  "i" children

    member _.iframe (children: seq<'Node>) = makeNode  "iframe" children

    member _.img (children: seq<'Node>) = makeNode  "img" children

    member _.input (children: seq<'Node>) = makeNode  "input" children

    member _.ins (value: float) = makeNode  "ins" [Util.asString value |> stringToNode]
    member _.ins (value: int) = makeNode  "ins" [Util.asString value |> stringToNode]
    member _.ins (value: 'Node) = makeNode  "ins" [value]
    member _.ins (value: string) = makeNode  "ins" [stringToNode value]
    member _.ins (children: seq<'Node>) = makeNode  "ins" children

    member _.kbd (value: float) = makeNode  "kbd" [Util.asString value |> stringToNode]
    member _.kbd (value: int) = makeNode  "kbd" [Util.asString value |> stringToNode]
    member _.kbd (value: 'Node) = makeNode  "kbd" [value]
    member _.kbd (value: string) = makeNode  "kbd" [stringToNode value]
    member _.kbd (children: seq<'Node>) = makeNode  "kbd" children

    member _.label (children: seq<'Node>) = makeNode  "label" children

    member _.legend (value: float) = makeNode  "legend" [Util.asString value |> stringToNode]
    member _.legend (value: int) = makeNode  "legend" [Util.asString value |> stringToNode]
    member _.legend (value: 'Node) = makeNode  "legend" [value]
    member _.legend (value: string) = makeNode  "legend" [stringToNode value]
    member _.legend (children: seq<'Node>) = makeNode  "legend" children

    member _.li (value: float) = makeNode  "li" [Util.asString value |> stringToNode]
    member _.li (value: int) = makeNode  "li" [Util.asString value |> stringToNode]
    member _.li (value: 'Node) = makeNode  "li" [value]
    member _.li (value: string) = makeNode  "li" [stringToNode value]
    member _.li (children: seq<'Node>) = makeNode  "li" children

    member _.listItem (value: float) = makeNode  "li" [Util.asString value |> stringToNode]
    member _.listItem (value: int) = makeNode  "li" [Util.asString value |> stringToNode]
    member _.listItem (value: 'Node) = makeNode  "li" [value]
    member _.listItem (value: string) = makeNode  "li" [stringToNode value]
    member _.listItem (children: seq<'Node>) = makeNode  "li" children

    member _.main (children: seq<'Node>) = makeNode  "main" children

    member _.map (children: seq<'Node>) = makeNode  "map" children

    member _.mark (value: float) = makeNode  "mark" [Util.asString value |> stringToNode]
    member _.mark (value: int) = makeNode  "mark" [Util.asString value |> stringToNode]
    member _.mark (value: 'Node) = makeNode  "mark" [value]
    member _.mark (value: string) = makeNode  "mark" [stringToNode value]
    member _.mark (children: seq<'Node>) = makeNode  "mark" children

    member _.metadata (children: seq<'Node>) = makeNode  "metadata" children

    member _.meter (value: float) = makeNode  "meter" [Util.asString value |> stringToNode]
    member _.meter (value: int) = makeNode  "meter" [Util.asString value |> stringToNode]
    member _.meter (value: 'Node) = makeNode  "meter" [value]
    member _.meter (value: string) = makeNode  "meter" [stringToNode value]
    member _.meter (children: seq<'Node>) = makeNode  "meter" children

    member _.nav (children: seq<'Node>) = makeNode  "nav" children

    member _.noscript (children: seq<'Node>) = makeNode  "noscript" children

    member _.object (children: seq<'Node>) = makeNode  "object" children

    member _.ol (children: seq<'Node>) = makeNode  "ol" children

    member _.option (value: float) = makeNode  "option" [Util.asString value |> stringToNode]
    member _.option (value: int) = makeNode  "option" [Util.asString value |> stringToNode]
    member _.option (value: 'Node) = makeNode  "option" [value]
    member _.option (value: string) = makeNode  "option" [stringToNode value]
    member _.option (children: seq<'Node>) = makeNode  "option" children

    member _.optgroup (children: seq<'Node>) = makeNode  "optgroup" children

    member _.orderedList (children: seq<'Node>) = makeNode  "ol" children

    member _.output (value: float) = makeNode  "output" [Util.asString value |> stringToNode]
    member _.output (value: int) = makeNode  "output" [Util.asString value |> stringToNode]
    member _.output (value: 'Node) = makeNode  "output" [value]
    member _.output (value: string) = makeNode  "output" [stringToNode value]
    member _.output (children: seq<'Node>) = makeNode  "output" children

    member _.p (value: float) = makeNode  "p" [Util.asString value |> stringToNode]
    member _.p (value: int) = makeNode  "p" [Util.asString value |> stringToNode]
    member _.p (value: 'Node) = makeNode  "p" [value]
    member _.p (value: string) = makeNode  "p" [stringToNode value]
    member _.p (children: seq<'Node>) = makeNode  "p" children

    member _.paragraph (value: float) = makeNode  "p" [Util.asString value |> stringToNode]
    member _.paragraph (value: int) = makeNode  "p" [Util.asString value |> stringToNode]
    member _.paragraph (value: 'Node) = makeNode  "p" [value]
    member _.paragraph (value: string) = makeNode  "p" [stringToNode value]
    member _.paragraph (children: seq<'Node>) = makeNode  "p" children

    member _.picture (children: seq<'Node>) = makeNode  "picture" children

    // member _.pre (value: bool) = makeNode  "pre" value
    member _.pre (value: float) = makeNode  "pre" [Util.asString value |> stringToNode]
    member _.pre (value: int) = makeNode  "pre" [Util.asString value |> stringToNode]
    member _.pre (value: 'Node) = makeNode  "pre" [value]
    member _.pre (value: string) = makeNode  "pre" [stringToNode value]
    member _.pre (children: seq<'Node>) = makeNode  "pre" children

    member _.progress (children: seq<'Node>) = makeNode  "progress" children

    member _.q (children: seq<'Node>) = makeNode  "q" children

    member _.rb (value: float) = makeNode  "rb" [Util.asString value |> stringToNode]
    member _.rb (value: int) = makeNode  "rb" [Util.asString value |> stringToNode]
    member _.rb (value: 'Node) = makeNode  "rb" [value]
    member _.rb (value: string) = makeNode  "rb" [stringToNode value]
    member _.rb (children: seq<'Node>) = makeNode  "rb" children

    member _.rp (value: float) = makeNode  "rp" [Util.asString value |> stringToNode]
    member _.rp (value: int) = makeNode  "rp" [Util.asString value |> stringToNode]
    member _.rp (value: 'Node) = makeNode  "rp" [value]
    member _.rp (value: string) = makeNode  "rp" [stringToNode value]
    member _.rp (children: seq<'Node>) = makeNode  "rp" children

    member _.rt (value: float) = makeNode  "rt" [Util.asString value |> stringToNode]
    member _.rt (value: int) = makeNode  "rt" [Util.asString value |> stringToNode]
    member _.rt (value: 'Node) = makeNode  "rt" [value]
    member _.rt (value: string) = makeNode  "rt" [stringToNode value]
    member _.rt (children: seq<'Node>) = makeNode  "rt" children

    member _.rtc (value: float) = makeNode  "rtc" [Util.asString value |> stringToNode]
    member _.rtc (value: int) = makeNode  "rtc" [Util.asString value |> stringToNode]
    member _.rtc (value: 'Node) = makeNode  "rtc" [value]
    member _.rtc (value: string) = makeNode  "rtc" [stringToNode value]
    member _.rtc (children: seq<'Node>) = makeNode  "rtc" children

    member _.ruby (value: float) = makeNode  "ruby" [Util.asString value |> stringToNode]
    member _.ruby (value: int) = makeNode  "ruby" [Util.asString value |> stringToNode]
    member _.ruby (value: 'Node) = makeNode  "ruby" [value]
    member _.ruby (value: string) = makeNode  "ruby" [stringToNode value]
    member _.ruby (children: seq<'Node>) = makeNode  "ruby" children

    member _.s (value: float) = makeNode  "s" [Util.asString value |> stringToNode]
    member _.s (value: int) = makeNode  "s" [Util.asString value |> stringToNode]
    member _.s (value: 'Node) = makeNode  "s" [value]
    member _.s (value: string) = makeNode  "s" [stringToNode value]
    member _.s (children: seq<'Node>) = makeNode  "s" children

    member _.samp (value: float) = makeNode  "samp" [Util.asString value |> stringToNode]
    member _.samp (value: int) = makeNode  "samp" [Util.asString value |> stringToNode]
    member _.samp (value: 'Node) = makeNode  "samp" [value]
    member _.samp (value: string) = makeNode  "samp" [stringToNode value]
    member _.samp (children: seq<'Node>) = makeNode  "samp" children

    member _.script (children: seq<'Node>) = makeNode  "script" children

    member _.section (children: seq<'Node>) = makeNode  "section" children

    member _.select (children: seq<'Node>) = makeNode  "select" children
    member _.small (value: float) = makeNode  "small" [Util.asString value |> stringToNode]
    member _.small (value: int) = makeNode  "small" [Util.asString value |> stringToNode]
    member _.small (value: 'Node) = makeNode  "small" [value]
    member _.small (value: string) = makeNode  "small" [stringToNode value]
    member _.small (children: seq<'Node>) = makeNode  "small" children

    member _.source (children: seq<'Node>) = makeNode  "source" children

    member _.span (value: float) = makeNode  "span" [Util.asString value |> stringToNode]
    member _.span (value: int) = makeNode  "span" [Util.asString value |> stringToNode]
    member _.span (value: 'Node) = makeNode  "span" [value]
    member _.span (value: string) = makeNode  "span" [stringToNode value]
    member _.span (children: seq<'Node>) = makeNode  "span" children

    member _.strong (value: float) = makeNode  "strong" [Util.asString value |> stringToNode]
    member _.strong (value: int) = makeNode  "strong" [Util.asString value |> stringToNode]
    member _.strong (value: 'Node) = makeNode  "strong" [value]
    member _.strong (value: string) = makeNode  "strong" [stringToNode value]
    member _.strong (children: seq<'Node>) = makeNode  "strong" children

    member _.style (value: string) = makeNode  "style" [stringToNode value]

    member _.sub (value: float) = makeNode  "sub" [Util.asString value |> stringToNode]
    member _.sub (value: int) = makeNode  "sub" [Util.asString value |> stringToNode]
    member _.sub (value: 'Node) = makeNode  "sub" [value]
    member _.sub (value: string) = makeNode  "sub" [stringToNode value]
    member _.sub (children: seq<'Node>) = makeNode  "sub" children

    member _.summary (value: float) = makeNode  "summary" [Util.asString value |> stringToNode]
    member _.summary (value: int) = makeNode  "summary" [Util.asString value |> stringToNode]
    member _.summary (value: 'Node) = makeNode  "summary" [value]
    member _.summary (value: string) = makeNode  "summary" [stringToNode value]
    member _.summary (children: seq<'Node>) = makeNode  "summary" children

    member _.sup (value: float) = makeNode  "sup" [Util.asString value |> stringToNode]
    member _.sup (value: int) = makeNode  "sup" [Util.asString value |> stringToNode]
    member _.sup (value: 'Node) = makeNode  "sup" [value]
    member _.sup (value: string) = makeNode  "sup" [stringToNode value]
    member _.sup (children: seq<'Node>) = makeNode  "sup" children

    member _.table (children: seq<'Node>) = makeNode  "table" children

    member _.tableBody (children: seq<'Node>) = makeNode  "tbody" children

    member _.tableCell (children: seq<'Node>) = makeNode  "td" children

    member _.tableHeader (children: seq<'Node>) = makeNode  "th" children

    member _.tableRow (children: seq<'Node>) = makeNode  "tr" children

    member _.tbody (children: seq<'Node>) = makeNode  "tbody" children

    member _.td (value: float) = makeNode  "td" [Util.asString value |> stringToNode]
    member _.td (value: int) = makeNode  "td" [Util.asString value |> stringToNode]
    member _.td (value: 'Node) = makeNode  "td" [value]
    member _.td (value: string) = makeNode  "td" [stringToNode value]
    member _.td (children: seq<'Node>) = makeNode  "td" children

    member _.template (children: seq<'Node>) = makeNode  "template" children

    member _.text (value: float) : 'Node = Util.asString value |> stringToNode
    member _.text (value: int) : 'Node = Util.asString value |> stringToNode
    member _.text (value: string) : 'Node = stringToNode value
    member _.text (value: System.Guid) : 'Node = Util.asString value |> stringToNode

    member this.textf fmt = Printf.kprintf this.text fmt

    member _.textarea (children: seq<'Node>) = makeNode  "textarea" children

    member _.tfoot (children: seq<'Node>) = makeNode  "tfoot" children

    member _.th (value: float) = makeNode  "th" [Util.asString value |> stringToNode]
    member _.th (value: int) = makeNode  "th" [Util.asString value |> stringToNode]
    member _.th (value: 'Node) = makeNode  "th" [value]
    member _.th (value: string) = makeNode  "th" [stringToNode value]
    member _.th (children: seq<'Node>) = makeNode  "th" children

    member _.thead (children: seq<'Node>) = makeNode  "thead" children

    member _.time (children: seq<'Node>) = makeNode  "time" children

    member _.tr (children: seq<'Node>) = makeNode  "tr" children

    member _.track (children: seq<'Node>) = makeNode  "track" children

    member _.u (value: float) = makeNode  "u" [Util.asString value |> stringToNode]
    member _.u (value: int) = makeNode  "u" [Util.asString value |> stringToNode]
    member _.u (value: 'Node) = makeNode  "u" [value]
    member _.u (value: string) = makeNode  "u" [stringToNode value]
    member _.u (children: seq<'Node>) = makeNode  "u" children

    member _.ul (children: seq<'Node>) = makeNode  "ul" children

    member _.unorderedList (children: seq<'Node>) = makeNode  "ul" children

    member _.var (value: float) = makeNode  "var" [Util.asString value |> stringToNode]
    member _.var (value: int) = makeNode  "var" [Util.asString value |> stringToNode]
    member _.var (value: 'Node) = makeNode  "var" [value]
    member _.var (value: string) = makeNode  "var" [stringToNode value]
    member _.var (children: seq<'Node>) = makeNode  "var" children

    member _.video (children: seq<'Node>) = makeNode  "video" children

    member _.wbr (children: seq<'Node>) = makeNode  "wbr" children
