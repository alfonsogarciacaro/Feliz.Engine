namespace Feliz.Styles

type IBorderStyle = interface end
type ITextAlignment = interface end
type ITextDecoration = interface end
type ITextDecorationLine = interface end
type IVisibility = interface end
type IPosition = interface end
type IAlignContent = interface end
type IAlignItems = interface end
type IAlignSelf = interface end
type IDisplay = interface end
type IFontStyle = interface end
type IFontVariant = interface end
type IFontWeight = interface end
type IFontStretch = interface end
type IFontKerning = interface end
type IOverflow = interface end
type IWordWrap = interface end
type IBackgroundRepeat = interface end
type IBackgroundClip = interface end
type ICssUnit = interface end
type ITransitionProperty = interface end
type ITransformProperty = interface end
type IGridSpan = interface end
type IGridTemplateItem = interface end

[<AutoOpen>]
module Units =
    type Units =
        | Em of float
        | Px of float
        | Pct of float
        | Pt of float
        with
            override this.ToString() =
                match this with
                |Em  n -> $"{n}em"
                |Px  n -> $"{n}px"
                |Pct n -> $"{n}%%"
                |Pt  n -> $"{n}pt"
            interface ICssUnit

namespace Feliz

open System
open Feliz.Styles

type CssHelper<'Style> =
    // TODO: Should the value be string too?
    abstract MakeStyle: key: string * value: obj -> 'Style

type CssEngine<'Style>(h: CssHelper<'Style>) =
    member _.all (value: string) = h.MakeStyle("all", value)

    /// The zIndex property sets or returns the stack order of a positioned element.
    ///
    /// An element with greater stack order (1) is always in front of another element with lower stack order (0).
    ///
    /// **Tip**: A positioned element is an element with the position property set to: relative, absolute, or fixed.
    ///
    /// **Tip**: This property is useful if you want to create overlapping elements.
    member _.zIndex(value: int) = h.MakeStyle("z-index", value)
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    member _.margin(value: int) = h.MakeStyle("margin", value)
    /// Sets the margin area on two sides of an element. It is a shorthand for margin-top and margin-right.
    member _.margin(top: int, right: int) =
        h.MakeStyle("margin",
            (string top) + "px " +
            (string right) + "px"
        )
    /// Sets the margin area on two sides of an element. It is a shorthand for margin-top and margin-right.
    member _.margin(top: ICssUnit, right: int) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + "px"
        )
    /// Sets the margin area on two sides of an element. It is a shorthand for margin-top and margin-right.
    member _.margin(top: ICssUnit, right: ICssUnit) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    member _.margin(top: ICssUnit, right: int, bottom: int) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + "px " +
            (string bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    member _.margin(top: ICssUnit, right: ICssUnit, bottom: int) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + " " +
            (string bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    member _.margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + " " +
            (string bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    member _.margin(top: ICssUnit, right: int, bottom: ICssUnit) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + "px " +
            (string bottom)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    member _.margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + " " +
            (string bottom) + " " +
            (string left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    member _.margin(top: ICssUnit, right: int, bottom: int, left: int) =
        h.MakeStyle("margin",
            (string top) + " " +
            (string right) + "px " +
            (string bottom) + "px " +
            (string left) + "px"
        )
    /// Sets the margin area on two sides of an element. It is a shorthand for margin-top and margin-right.
    member _.margin(top: int, right: ICssUnit) =
        h.MakeStyle("margin",
            (string top) + "px " +
            (string right)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    member _.margin(top: int, right: int, bottom: int) =
        h.MakeStyle("margin",
            (string top) + "px " +
            (string right) + "px " +
            (string bottom) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    member _.margin(top: int, right: int, bottom: int, left: int) =
        h.MakeStyle("margin",
            (string top) + "px " +
            (string right) + "px " +
            (string bottom) + "px " +
            (string left) + "px")
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    member _.margin(value: ICssUnit) = h.MakeStyle("margin", value)
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginLeft(value: int) = h.MakeStyle("margin-left", value)
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginLeft(value: ICssUnit) = h.MakeStyle("margin-left", value)
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginRight(value: int) = h.MakeStyle("margin-right", value)
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginRight(value: ICssUnit) = h.MakeStyle("margin-right", value)
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginTop(value: int) = h.MakeStyle("margin-top", value)
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginTop(value: ICssUnit) = h.MakeStyle("margin-top", value)
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginBottom(value: int) = h.MakeStyle("margin-bottom", value)
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    member _.marginBottom(value: ICssUnit) = h.MakeStyle("margin-bottom", value)
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(vertical: ICssUnit, horizontal: int) =
        h.MakeStyle("padding",
            (string vertical) + " " +
            (string horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, horizontal: int, bottom: int) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string horizontal) + "px " +
            (string bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, horizontal: ICssUnit, bottom: int) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string horizontal) + " " +
            (string bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, horizontal: ICssUnit, bottom: ICssUnit) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string horizontal) + " " +
            (string bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, horizontal: int, bottom: ICssUnit) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string horizontal) + "px " +
            (string bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string right) + " " +
            (string bottom) + " " +
            (string left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: ICssUnit, right: int, bottom: int, left: int) =
        h.MakeStyle("padding",
            (string top) + " " +
            (string right) + "px " +
            (string bottom) + "px " +
            (string left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(vertical: int, horizontal: ICssUnit) =
        h.MakeStyle("padding",
            (string vertical) + "px " +
            (string horizontal)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(value: int) = h.MakeStyle("padding", value)
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(vertical: int, horizontal: int) =
        h.MakeStyle("padding",
            (string vertical) + "px " +
            (string horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: int, horizontal: int, bottom: int) =
        h.MakeStyle("padding",
            (string top) + "px " +
            (string horizontal) + "px " +
            (string bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(top: int, right: int, bottom: int, left: int) =
        h.MakeStyle("padding",
            (string top) + "px " +
            (string right) + "px " +
            (string bottom) + "px " +
            (string left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    member _.padding(value: ICssUnit) = h.MakeStyle("padding", value)
    /// Sets the height of the padding area on the bottom of an element.
    member _.paddingBottom(value: int) = h.MakeStyle("padding-bottom", value)
    /// Sets the height of the padding area on the bottom of an element.
    member _.paddingBottom(value: ICssUnit) = h.MakeStyle("padding-bottom", value)
    /// Sets the width of the padding area to the left of an element.
    member _.paddingLeft(value: int) = h.MakeStyle("padding-left", value)
    /// Sets the width of the padding area to the left of an element.
    member _.paddingLeft(value: ICssUnit) = h.MakeStyle("padding-left", value)
    /// Sets the width of the padding area on the right of an element.
    member _.paddingRight(value: int) = h.MakeStyle("padding-right", value)
    /// Sets the width of the padding area on the right of an element.
    member _.paddingRight(value: ICssUnit) = h.MakeStyle("padding-right", value)
    /// Sets the height of the padding area on the top of an element.
    member _.paddingTop(value: int) = h.MakeStyle("padding-top", value)
    /// Sets the height of the padding area on the top of an element.
    member _.paddingTop(value: ICssUnit) = h.MakeStyle("padding-top", value)
    /// Sets the flex shrink factor of a flex item. If the size of all flex items is larger than
    /// the flex container, items shrink to fit according to flex-shrink.
    member _.flexShrink(value: int) = h.MakeStyle("flex-shrink", value)
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    member _.flexBasis (value: int) = h.MakeStyle("flex-basis", value)
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    member _.flexBasis (value: float) = h.MakeStyle("flex-basis", value)
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    member _.flexBasis (value: ICssUnit) = h.MakeStyle("flex-basis", value)
    /// Sets the flex grow factor of a flex item main size. It specifies how much of the remaining
    /// space in the flex container should be assigned to the item (the flex grow factor).
    member _.flexGrow (value: int) = h.MakeStyle("flex-grow", value)
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 199.5px 99.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [199.5;99.5;99.5]
    /// ```
    member _.gridTemplateColumns(value: float list) =
        let addPixels = fun x -> x + "px"
        h.MakeStyle("grid-template-columns", (List.map addPixels >> String.concat " ") (List.map string value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 199.5px 99.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|199.5;99.5;99.5|]
    /// ```
    member _.gridTemplateColumns(value: float[]) =
        let addPixels = fun x -> x + "px"
        h.MakeStyle("grid-template-columns", (Array.map addPixels >> String.concat " ") (Array.map string value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [100; 200; 100]
    /// ```
    member _.gridTemplateColumns(value: int list) =
        let addPixels = fun x -> x + "px"
        h.MakeStyle("grid-template-columns", (List.map addPixels >> String.concat " ") (List.map string value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|100; 200; 100|]
    /// ```
    member _.gridTemplateColumns(value: int[]) =
        let addPixels = fun x -> x + "px"
        h.MakeStyle("grid-template-columns", (Array.map addPixels >> String.concat " ") (Array.map string value))
    /// Sets the width of each individual grid column.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 1fr 1fr 2fr;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [length.fr 1; length.fr 1; length.fr 2]
    /// ```
    member _.gridTemplateColumns(value: ICssUnit list) =
        h.MakeStyle("grid-template-columns", String.concat " " (List.map string value))
    /// Sets the width of each individual grid column.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 1fr 1fr 2fr;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|length.fr 1; length.fr 1; length.fr 2|]
    /// ```
    member _.gridTemplateColumns(value: ICssUnit[]) =
        h.MakeStyle("grid-template-columns", String.concat " " (Array.map string value))
    /// Sets the width of each individual grid column. It can also name the lines between them
    /// There can be multiple names for the same line
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: [first-line] auto [first-line-end second-line-start] 100px [second-line-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns [
    ///     grid.namedLine "first-line"
    ///     grid.templateWidth length.auto
    ///     grid.namedLines ["first-line-end second-line-start"]
    ///     grid.templateWidth 100
    ///     grid.namedLine "second-line-end"
    /// ]
    /// ```
    member _.gridTemplateColumns(value: IGridTemplateItem list) =
        h.MakeStyle("gridTemplateColumns", String.concat " " (List.map string value))
    /// Sets the width of each individual grid column. It can also name the lines between them
    /// There can be multiple names for the same line
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: [first-line] auto [first-line-end second-line-start] 100px [second-line-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns [|
    ///     grid.namedLine "first-line"
    ///     grid.templateWidth length.auto
    ///     grid.namedLines [|"first-line-end second-line-start"|]
    ///     grid.templateWidth 100
    ///     grid.namedLine "second-line-end"
    /// |]
    /// ```
    member _.gridTemplateColumns(value: IGridTemplateItem[]) =
        h.MakeStyle("gridTemplateColumns", String.concat " " (Array.map string value))
    /// Sets the width of a number of grid columns to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 99.5px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 99.5)
    /// ```
    member _.gridTemplateColumns(count: int, size: float) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + "px)"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 100px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 100)
    /// ```
    member _.gridTemplateColumns(count: int, size: int) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + "px)"
        )
    /// Sets the width of a number of grid columns to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1fr);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, length.fr 1)
    /// ```
    member _.gridTemplateColumns(count: int, size: ICssUnit) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + ")"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1.5px [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 1.5, "col-start")
    /// ```
    member _.gridTemplateColumns(count: int, size: float, areaName: string) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 10px [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 10, "col-start")
    /// ```
    member _.gridTemplateColumns(count: int, size: int, areaName: string) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid columns to the defined width, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1fr [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, length.fr 1, "col-start")
    /// ```
    member _.gridTemplateColumns(count: int, size: ICssUnit, areaName: string) =
        h.MakeStyle("gridTemplateColumns",
            "repeat(" +
            (string count) + ", " +
            (string size) + " [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 99.5px 199.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [99.5; 199.5; 99.5]
    /// ```
    member _.gridTemplateRows(value: float list) =
        let addPixels = (fun x -> x + "px")
        h.MakeStyle("gridTemplateRows", (List.map addPixels >> String.concat " ") (List.map string value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 99.5px 199.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|99.5; 199.5; 99.5|]
    /// ```
    member _.gridTemplateRows(value: float[]) =
        let addPixels = (fun x -> x + "px")
        h.MakeStyle("gridTemplateRows", (Array.map addPixels >> String.concat " ") (Array.map string value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [100, 200, 100]
    /// ```
    member _.gridTemplateRows(value: int list) =
        let addPixels = (fun x -> x + "px")
        h.MakeStyle("gridTemplateRows", (List.map addPixels >> String.concat " ") (List.map string value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|100; 200; 100|]
    /// ```
    member _.gridTemplateRows(value: int[]) =
        let addPixels = (fun x -> x + "px")
        h.MakeStyle("gridTemplateRows", (Array.map addPixels >> String.concat " ") (Array.map string value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 1fr 10% 250px auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [length.fr 1; length.percent 10; length.px 250; length.auto]
    /// ```
    member _.gridTemplateRows(value: ICssUnit list) =
        h.MakeStyle("gridTemplateRows", String.concat " " (List.map string value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 1fr 10% 250px auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|length.fr 1; length.percent 10; length.px 250; length.auto|]
    /// ```
    member _.gridTemplateRows(value: ICssUnit[]) =
        h.MakeStyle("gridTemplateRows", String.concat " " (Array.map string value))
    /// Sets the width of a number of grid rows to the defined width as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: [row-1-start] 1fr [row-1-end row-2-start] 1fr [row-2-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [
    ///     grid.namedLine "row-1-start"
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLines ["row-1-end"; "row-2-start"]
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLine "row-2-end"
    /// ]
    /// ```
    member _.gridTemplateRows(value: IGridTemplateItem list) =
        h.MakeStyle("gridTemplateRows", String.concat " " (List.map string value))
    /// Sets the width of a number of grid rows to the defined width as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: [row-1-start] 1fr [row-1-end row-2-start] 1fr [row-2-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|
    ///     grid.namedLine "row-1-start"
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLines [|"row-1-end"; "row-2-start"|]
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLine "row-2-end"
    /// |]
    /// ```
    member _.gridTemplateRows(value: IGridTemplateItem[]) =
        h.MakeStyle("gridTemplateRows", String.concat " " (Array.map string value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 199.5);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 199.5)
    /// ```
    member _.gridTemplateRows(count: int, size: float) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + "px)"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 100px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 100)
    /// ```
    member _.gridTemplateRows(count: int, size: int) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + "px)"
        )
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 10%);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, length.percent 10)
    /// ```
    member _.gridTemplateRows(count: int, size: ICssUnit) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + ")"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 75.5, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 75.5, "row")
    /// ```
    member _.gridTemplateRows(count: int, size: float, areaName: string) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 100px, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 100, "row")
    /// ```
    member _.gridTemplateRows(count: int, size: int, areaName: string) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 10%, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, length.percent 10, "row")
    /// ```
    member _.gridTemplateRows(count: int, size: ICssUnit, areaName: string) =
        h.MakeStyle("gridTemplateRows",
            "repeat("+
            (string count) + ", " +
            (string size) + " [" +
            areaName + "])"
        )
    /// 2D representation of grid layout as blocks with names
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas:
    ///     'header header header header'
    ///     'nav nav . sidebar'
    ///     'footer footer footer footer';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [
    ///     ["header"; "header"; "header"; "header" ]
    ///     ["nav"   ; "nav"   ; "."     ; "sidebar"]
    ///     ["footer"; "footer"; "footer"; "footer" ]
    /// ]
    /// ```
    member _.gridTemplateAreas(value: string list list) =
        let wrapLine = (fun x -> "'" + x + "'")
        let lines = List.map (String.concat " " >> wrapLine) value
        let block = String.concat "\n" lines
        h.MakeStyle("gridTemplateAreas", block)
    /// 2D representation of grid layout as blocks with names
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas:
    ///     'header header header header'
    ///     'nav nav . sidebar'
    ///     'footer footer footer footer';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [|
    ///     [|"header"; "header"; "header"; "header" |]
    ///     [|"nav"   ; "nav"   ; "."     ; "sidebar"|]
    ///     [|"footer"; "footer"; "footer"; "footer" |]
    /// |]
    /// ```
    member _.gridTemplateAreas(value: string[][]) =
        let wrapLine = (fun x -> "'" + x + "'")
        let lines = Array.map (String.concat " " >> wrapLine) value
        let block = String.concat "\n" lines
        h.MakeStyle("gridTemplateAreas", block)
    /// One-dimensional alternative to the nested list. For column-based layouts
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas: 'first second third fourth';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas ["first"; "second"; "third"; "fourth"]
    /// ```
    member _.gridTemplateAreas(value: string list) =
        let block = (String.concat " ") value
        h.MakeStyle("gridTemplateAreas", "'" + block + "'")
    /// One-dimensional alternative to the nested list. For column-based layouts
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas: 'first second third fourth';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [|"first"; "second"; "third"; "fourth"|]
    /// ```
    member _.gridTemplateAreas(value: string[]) =
        let block = (String.concat " ") value
        h.MakeStyle("gridTemplateAreas", "'" + block + "'")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap 1.5
    /// ```
    member _.columnGap(value: float) =
        h.MakeStyle("columnGap", string value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap 10
    /// ```
    member _.columnGap(value: int) =
        h.MakeStyle("columnGap", string value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap (length.em 1)
    /// ```
    member _.columnGap(value: ICssUnit) =
        h.MakeStyle("columnGap", value)
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 2.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap 2.5
    /// ```
    member _.rowGap(value: float) =
        h.MakeStyle("rowGap", string value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap 10
    /// ```
    member _.rowGap(value: int) =
        h.MakeStyle("rowGap", string value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap (length.em 1)
    /// ```
    member _.rowGap(value: ICssUnit) =
        h.MakeStyle("rowGap", value)
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 2em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, length.em 2)
    /// ```
    member _.gap(rowGap: ICssUnit, columnGap: ICssUnit) =
        h.MakeStyle("gap",
            (string rowGap) + " " +
            (string columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 3.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, 3.5)
    /// ```
    member _.gap(rowGap: ICssUnit, columnGap: float) =
        h.MakeStyle("gap",
            (string rowGap) + " " +
            (string columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, 10)
    /// ```
    member _.gap(rowGap: ICssUnit, columnGap: int) =
        h.MakeStyle("gap",
            (string rowGap) + " " +
            (string columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, length.em 1)
    /// ```
    member _.gap(rowGap: int, columnGap: ICssUnit) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, 1.5)
    /// ```
    member _.gap(rowGap: int, columnGap: float) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 15px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, 15)
    /// ```
    member _.gap(rowGap: int, columnGap: int) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 2.5px 15%;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (2.5, length.percent 15)
    /// ```
    member _.gap(rowGap: float, columnGap: ICssUnit) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1.5px 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (1.5, 1.5)
    /// ```
    member _.gap(rowGap: float, columnGap: float) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1.5px 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (1.5, 10)
    /// ```
    member _.gap(rowGap: float, columnGap: int) =
        h.MakeStyle("gap",
            (string rowGap) + "px " +
            (string columnGap) + "px"
        )
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: col2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart "col2"
    /// ```
    member _.gridColumnStart(value: string) = h.MakeStyle("gridColumnStart", value)
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// When there are multiple named lines with the same name, you can specify which one by count
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart ("col", 2)
    /// ```
    member _.gridColumnStart(value: string, count: int) =
        h.MakeStyle("gridColumnStart", value + " " + (string count))
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart 2
    /// ```
    member _.gridColumnStart(value: int) = h.MakeStyle("gridColumnStart", value)
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart (gridColumn.span "odd-col")
    /// ```
    member _.gridColumnStart(value: IGridSpan) = h.MakeStyle("gridColumnStart", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: col-2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd "col-2"
    /// ```
    member _.gridColumnEnd(value: string) = h.MakeStyle("gridColumnEnd", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd ("odd-col", 2)
    /// ```
    member _.gridColumnEnd(value: string, count: int) =
        h.MakeStyle("gridColumnEnd", value + " " + (string count))
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd 2
    /// ```
    member _.gridColumnEnd(value: int) = h.MakeStyle("gridColumnEnd", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd (gridColumn.span 2)
    /// ```
    member _.gridColumnEnd(value: IGridSpan) = h.MakeStyle("gridColumnEnd", value)
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: col2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart "col2"
    /// ```
    member _.gridRowStart(value: string) = h.MakeStyle("gridRowStart", value)
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart ("col", 2)
    /// ```
    member _.gridRowStart(value: string, count: int) =
        h.MakeStyle("gridRowStart", value + " " + (string count))
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart 2
    /// ```
    member _.gridRowStart(value: int) = h.MakeStyle("gridRowStart", value)
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart (gridRow.span "odd-col")
    /// ```
    member _.gridRowStart(value: IGridSpan) = h.MakeStyle("gridRowStart", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: col-2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd "col-2"
    /// ```
    member _.gridRowEnd(value: string) = h.MakeStyle("gridRowEnd", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd ("odd-col", 2)
    /// ```
    member _.gridRowEnd(value: string, count: int) =
        h.MakeStyle("gridRowEnd", value + " " + (string count))
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd 2
    /// ```
    member _.gridRowEnd(value: int) = h.MakeStyle("gridRowEnd", value)
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd (gridRow.span 2)
    /// ```
    member _.gridRowEnd(value: IGridSpan) = h.MakeStyle("gridRowEnd", value)
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / col-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", "col-4")
    /// ```
    member _.gridColumn(start: string, end': string) =
        h.MakeStyle("gridColumn", start + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", 4)
    /// ```
    member _.gridColumn(start: string, end': int) =
        h.MakeStyle("gridColumn", start + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", gridColumn.span 2)
    /// ```
    member _.gridColumn(start: string, end': IGridSpan) =
        h.MakeStyle("gridColumn", start + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1/ col-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, "col-4")
    /// ```
    member _.gridColumn(start: int, end': string) =
        h.MakeStyle("gridColumn", (string start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, 3)
    /// ```
    member _.gridColumn(start: int, end': int) =
        h.MakeStyle("gridColumn", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, gridColumn.span 2)
    /// ```
    member _.gridColumn(start: int, end': IGridSpan) =
        h.MakeStyle("gridColumn", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / col-3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, "col-3")
    /// ```
    member _.gridColumn(start: IGridSpan, end': string) =
        h.MakeStyle("gridColumn", (string start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, 4)
    /// ```
    member _.gridColumn(start: IGridSpan, end': int) =
        h.MakeStyle("gridColumn", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, gridColumn.span 3)
    /// ```
    member _.gridColumn(start: IGridSpan, end': IGridSpan) =
        h.MakeStyle("gridColumn", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / row-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", "row-4")
    /// ```
    member _.gridRow(start: string, end': string) =
        h.MakeStyle("gridRow", start + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", 4)
    /// ```
    member _.gridRow(start: string, end': int) =
        h.MakeStyle("gridRow", start + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / span "odd-row";
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", gridRow.span 2)
    /// ```
    member _.gridRow(start: string, end': IGridSpan) =
        h.MakeStyle("gridRow", start + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / row-3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, "row-3")
    /// ```
    member _.gridRow(start: int, end': string) =
        h.MakeStyle("gridRow", (string start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, 4)
    /// ```
    member _.gridRow(start: int, end': int) =
        h.MakeStyle("gridRow", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, gridRow.span 3)
    /// ```
    member _.gridRow(start: int, end': IGridSpan) =
        h.MakeStyle("gridRow", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / "row-4";
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, "row-4")
    /// ```
    member _.gridRow(start: IGridSpan, end': string) =
        h.MakeStyle("gridRow", (string start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, 3)
    /// ```
    member _.gridRow(start: IGridSpan, end': int) =
        h.MakeStyle("gridRow", (string start) + " / " + (string end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, gridRow.span 3)
    /// ```
    member _.gridRow(start: IGridSpan, end': IGridSpan) =
        h.MakeStyle("gridRow", (string start) + " / " + (string end'))
    /// Sets the named grid area the item is placed in
    ///
    /// **CSS**
    /// ```css
    /// grid-area: header;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridArea "header"
    /// ```
    member _.gridArea(value: string) =
        h.MakeStyle("gridArea", value)
    /// Shorthand for `grid-template-areas`, `grid-template-columns` and `grid-template-rows`.
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template
    ///
    /// **CSS**
    /// ```css
    /// grid-template:  [header-top] 'a a a'      [header-bottom]
    ///                   [main-top] 'b b b' 1fr  [main-bottom]
    ///                              / auto 1fr auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplate "[header-top] 'a a a'      [header-bottom] " +
    ///                      main-top-b-b-b-1fr-main-bottom +
    ///                                "/ auto 1fr auto"
    /// ```
    member _.gridTemplate(value: string) =
        h.MakeStyle("gridTemplate", value)
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    member _.transitionDuration(timespan: TimeSpan) =
        h.MakeStyle("transitionDuration", string timespan.TotalMilliseconds + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    member _.transitionDurationSeconds(n: float) =
        h.MakeStyle("transitionDuration", (string n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    member _.transitionDurationMilliseconds(n: float) =
        h.MakeStyle("transitionDuration", (string n) + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    member _.transitionDurationSeconds(n: int) =
        h.MakeStyle("transitionDuration", (string n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    member _.transitionDurationMilliseconds(n: int) =
        h.MakeStyle("transitionDuration", (string n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    member _.transitionDelay(timespan: TimeSpan) =
        h.MakeStyle("transitionDelay", string timespan.TotalMilliseconds + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    member _.transitionDelaySeconds(n: float) =
        h.MakeStyle("transitionDelay", (string n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    member _.transitionDelayMilliseconds(n: float) =
        h.MakeStyle("transitionDelay", (string n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    member _.transitionDelaySeconds(n: int) =
        h.MakeStyle("transitionDelay", (string n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    member _.transitionDelayMilliseconds(n: int) =
        h.MakeStyle("transitionDelay", (string n) + "ms")
    /// Sets the CSS properties to which a transition effect should be applied.
    member _.transitionProperty ([<ParamArray>] properties: ITransitionProperty[]) =
        h.MakeStyle("transitionProperty", String.concat "," (Array.map string properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    member _.transitionProperty (properties: ITransitionProperty list) =
        h.MakeStyle("transitionProperty", String.concat "," (List.map string properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    member _.transitionProperty (property: ITransitionProperty) =
        h.MakeStyle("transitionProperty", property)
    /// Sets the CSS properties to which a transition effect should be applied.
    member _.transitionProperty (property: string) =
        h.MakeStyle("transitionProperty", property)

    member _.transform(transformation: ITransformProperty) =
        h.MakeStyle("transform", transformation)

    member _.transform(transformations: ITransformProperty list) =
        h.MakeStyle("transform", String.concat " " (List.map string transformations))

    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    member _.fontSize(size: int) = h.MakeStyle("font-size", string size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    member _.fontSize(size: float) = h.MakeStyle("font-size", string size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    member _.fontSize(size: ICssUnit) = h.MakeStyle("font-size", size)
    /// Specifies the height of a text lines.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    member _.lineHeight(size: int) = h.MakeStyle("line-height", string size + "px")
    /// Specifies the height of a text lines.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    member _.lineHeight(size: float) = h.MakeStyle("line-height", string size + "px")
    /// Specifies the height of a text lines.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    member _.lineHeight(size: ICssUnit) = h.MakeStyle("line-height", size)
    /// Sets the background color of an element.
    member _.backgroundColor (color: string) = h.MakeStyle("background-color", color)
    /// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
    ///
    /// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
    /// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
    /// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    member _.caretColor (color: string) = h.MakeStyle("caret-color", color)
    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    member _.color (color: string) = h.MakeStyle("color", color)
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    member _.top(value: int) = h.MakeStyle("top", value)
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    member _.top(value: ICssUnit) = h.MakeStyle("top", value)
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    member _.bottom(value: int) = h.MakeStyle("bottom", value)
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    member _.bottom(value: ICssUnit) = h.MakeStyle("bottom", value)
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    member _.left(value: int) = h.MakeStyle("left", value)
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    member _.left(value: ICssUnit) = h.MakeStyle("left", value)
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    member _.right(value: int) = h.MakeStyle("right", value)
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    member _.right(value: ICssUnit) = h.MakeStyle("right", value)
    /// Define a custom attribute of via key value pair
    member _.custom(key: string, value: obj) = h.MakeStyle(key, value)
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    member _.borderBottom(width: int, style: IBorderStyle, color: string) =
        h.MakeStyle("borderBottom",
            (string width) + "px " +
            (string style) + " " +
            color
        )
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    member _.borderBottom(width: ICssUnit, style: IBorderStyle, color: string) =
        h.MakeStyle("borderBottom",
            (string width) + " " +
            (string style) + " " +
            color
        )

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    member _.outlineWidth(width: int) =
        h.MakeStyle("outlineWidth", (string width) + "px")

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    member _.outlineWidth(width: ICssUnit) =
        h.MakeStyle("outlineWidth", width)

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    member _.outlineOffset (offset:int) =
        h.MakeStyle("outlineWidth", (string offset) + "px")

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    member _.outlineOffset (offset:ICssUnit) =
        h.MakeStyle("outlineWidth", offset)

    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    ///
    /// The `outline-color` property specifies the color of an outline.

    /// **Note**: Always declare the outline-style property before the outline-color property. An element must have an outline before you change the color of it.
    member _.outlineColor (color: string) =
        h.MakeStyle("outlineColor", color)
    /// Set an element's left border.
    member _.borderLeft(width: int, style: IBorderStyle, color: string) =
        h.MakeStyle("borderLeft",
            (string width) + "px " +
            (string style) + " " +
            color
        )
    /// Set an element's left border.
    member _.borderLeft(width: ICssUnit, style: IBorderStyle, color: string) =
        h.MakeStyle("borderBottom",
            (string width) + " " +
            (string style) + " " +
            color
        )
    /// Set an element's right border.
    member _.borderRight(width: int, style: IBorderStyle, color: string) =
        h.MakeStyle("borderRight",
            (string width) + "px " +
            (string style) + " " +
            color
        )
    /// Set an element's right border.
    member _.borderRight(width: ICssUnit, style: IBorderStyle, color: string) =
        h.MakeStyle("borderRight",
            (string width) + " " +
            (string style) + " " +
            color
        )
    /// Set an element's top border.
    member _.borderTop(width: int, style: IBorderStyle, color: string) =
        h.MakeStyle("borderTop",
            (string width) + "px " +
            (string style) + " " +
            color
        )
    /// Set an element's top border.
    member _.borderTop(width: ICssUnit, style: IBorderStyle, color: string) =
        h.MakeStyle("borderTop",
            (string width) + " " +
            (string style) + " " +
            color
        )
    /// Sets the line style of an element's bottom border.
    member _.borderBottomStyle(style: IBorderStyle) = h.MakeStyle("borderBottomStyle", string style)
    /// Sets the width of the bottom border of an element.
    member _.borderBottomWidth (width: int) = h.MakeStyle("borderBottomWidth", string width + "px")
    /// Sets the width of the bottom border of an element.
    member _.borderBottomWidth (width: ICssUnit) = h.MakeStyle("borderBottomWidth", string width)
    /// Sets the color of an element's bottom border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    member _.borderBottomColor (color: string) = h.MakeStyle("borderBottomColor", color)
    /// Sets the line style of an element's top border.
    member _.borderTopStyle(style: IBorderStyle) = h.MakeStyle("borderTopStyle", string style)
    /// Sets the width of the top border of an element.
    member _.borderTopWidth (width: int) = h.MakeStyle("borderTopWidth", string width + "px")
    /// Sets the width of the top border of an element.
    member _.borderTopWidth (width: ICssUnit) = h.MakeStyle("borderTopWidth", string width)
    /// Sets the color of an element's top border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    member _.borderTopColor (color: string) = h.MakeStyle("borderTopColor", color)
    /// /// Sets the line style of an element's right border.
    member _.borderRightStyle(style: IBorderStyle) = h.MakeStyle("borderRightStyle", string style)
    /// Sets the width of the right border of an element.
    member _.borderRightWidth (width: int) = h.MakeStyle("borderRightWidth", string width + "px")
    /// Sets the width of the right border of an element.
    member _.borderRightWidth (width: ICssUnit) = h.MakeStyle("borderRightWidth", string width)
    /// Sets the color of an element's right border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    member _.borderRightColor (color: string) = h.MakeStyle("borderRightColor", color)
    /// Sets the line style of an element's left border.
    member _.borderLeftStyle(style: IBorderStyle) = h.MakeStyle("borderLeftStyle", string style)
    /// Sets the width of the left border of an element.
    member _.borderLeftWidth (width: int) = h.MakeStyle("borderLeftWidth", string width + "px")
    /// Sets the width of the left border of an element.
    member _.borderLeftWidth (width: ICssUnit) = h.MakeStyle("borderLeftWidth", string width)
    /// Sets the color of an element's left border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    member _.borderLeftColor (color: string) = h.MakeStyle("borderLeftColor", color)
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    member _.border(width: int, style: IBorderStyle, color: string) =
        h.MakeStyle("border",
            (string width) + "px " +
            (string style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    member _.border(width: ICssUnit, style: IBorderStyle, color: string) =
        h.MakeStyle("border",
            (string width) + " " +
            (string style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    member _.border(width: string, style: IBorderStyle, color: string) =
        h.MakeStyle("border",
            (string width) + " " +
            (string style) + " " +
            color
        )
    /// Sets the line style for all four sides of an element's border.
    member _.borderStyle (style: IBorderStyle) = h.MakeStyle("borderStyle", style)
    /// Sets the line style for all four sides of an element's border.
    member _.borderStyle(top: IBorderStyle, right: IBorderStyle)  =
        h.MakeStyle("borderStyle", (string top) + " " + (string right))
    /// Sets the line style for all four sides of an element's border.
    member _.borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle) =
        h.MakeStyle("borderStyle", (string top) + " " + (string right) + " " +  (string bottom))
    /// Sets the line style for all four sides of an element's border.
    member _.borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle, left: IBorderStyle) =
        h.MakeStyle("borderStyle", (string top) + " " + (string right) + " " + (string bottom) + " " +  (string left))
    /// Sets the color of an element's border.
    member _.borderColor (color: string) = h.MakeStyle("borderColor", color)
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    member _.borderRadius (radius: int) = h.MakeStyle("borderRadius", radius)
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    member _.borderRadius (radius: ICssUnit) = h.MakeStyle("borderRadius", radius)
    /// Sets the width of an element's border.
    member _.borderWidth (top: int, right: int) =
        h.MakeStyle("borderWidth",
            (string top) + "px " +
            (string right) + "px"
        )
    /// Sets the width of an element's border.
    member _.borderWidth (width: int) = h.MakeStyle("borderWidth", width)
    /// Sets the width of an element's border.
    member _.borderWidth (top: int, right: int, bottom: int) =
        h.MakeStyle("borderWidth",
            (string top) + "px " +
            (string right) + "px " +
            (string bottom) + "px"
        )
    /// Sets the width of an element's border.
    member _.borderWidth (top: int, right: int, bottom: int, left: int) =
        h.MakeStyle("borderWidth",
            (string top) + "px " +
            (string right) + "px " +
            (string bottom) + "px " +
            (string left) + "px"
        )
    /// Sets one or more animations to apply to an element. Each name is an @keyframes at-rule that
    /// sets the property values for the animation sequence.
    member _.animationName(keyframeName: string) = h.MakeStyle("animationName", keyframeName)
    /// Sets the length of time that an animation takes to complete one cycle.
    member _.animationDuration(timespan: TimeSpan) = h.MakeStyle("animationDuration", (string timespan.TotalMilliseconds) + "ms")
    /// Sets the length of time that an animation takes to complete one cycle.
    member _.animationDuration(seconds: int) = h.MakeStyle("animationDuration", (string seconds) + "s")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    member _.animationDelay(timespan: TimeSpan) = h.MakeStyle("animationDelay", (string timespan.TotalMilliseconds) + "ms")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
     /// The number of times the animation runs.
    member _.animationDurationCount(count: int) = h.MakeStyle("animationDurationCount", count)
    /// Sets the font family for the font specified in a @font-face rule.
    member _.fontFamily (family: string) = h.MakeStyle("font-family", family)
    /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold.
    /// Possible values are [100, 200, 300, 400, 500, 600, 700, 800, 900]
    member _.fontWeight (weight: int) = h.MakeStyle("fontWeight", weight)
    /// Sets the color of decorations added to text by text-decoration-line.
    member _.textDecorationColor(color: string) = h.MakeStyle("textDecorationColor", color)
    /// Sets the kind of decoration that is used on text in an element, such as an underline or overline.
    member _.textDecorationLine(line: ITextDecorationLine) = h.MakeStyle("textDecorationLine", line)
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    member _.textDecoration(line: ITextDecorationLine) = h.MakeStyle("textDecoration", line)
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    member _.textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine) =
        h.MakeStyle("textDecoration", (string bottom) + " " + (string top))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    member _.textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration) =
        h.MakeStyle("textDecoration", (string bottom) + " " + (string top) + " " + (string style))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    member _.textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration, color: string) =
        h.MakeStyle("textDecoration", (string bottom) + " " + (string top) + " " + (string style) + " " + color)
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    member _.textIndent(value: int) = h.MakeStyle("textIndent", value)
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    member _.textIndent(value: string) = h.MakeStyle("textIndent", value)
    /// Sets the opacity of an element.
    ///
    /// Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
    member _.opacity(value: double) = h.MakeStyle("opacity", value)
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    member _.minWidth (value: int) = h.MakeStyle("minWidth", value)
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    member _.minWidth (value: ICssUnit) = h.MakeStyle("minWidth", value)
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    member _.minWidth (value: string) = h.MakeStyle("minWidth", value)
    /// Sets the initial position for each background image.
    ///
    /// The position is relative to the position layer set by background-origin.
    member _.backgroundPosition  (position: string) = h.MakeStyle("backgroundPosition", position)
    /// Sets the type of cursor, if any, to show when the mouse pointer is over an element.
    member _.cursor (value: string) = h.MakeStyle("cursor", value)
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    member _.minHeight (value: int) = h.MakeStyle("minHeight", value)
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    member _.minHeight (value: ICssUnit) = h.MakeStyle("minHeight", value)
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    member _.maxWidth (value: int) = h.MakeStyle("maxWidth", value)
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    member _.maxWidth (value: ICssUnit) = h.MakeStyle("maxWidth", value)
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    member _.maxHeight (value: int) = h.MakeStyle("maxHeight", value)
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    member _.maxHeight (value: ICssUnit) = h.MakeStyle("maxHeight", value)
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    member _.height (value: int) = h.MakeStyle("height", value)
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    member _.height (value: ICssUnit) = h.MakeStyle("height", value)
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    member _.width (value: int) = h.MakeStyle("width", value)
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    member _.width (value: ICssUnit) = h.MakeStyle("width", value)
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    member _.backgroundSize (value: string) = h.MakeStyle("backgroundSize", value)
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    member _.backgroundSize (value: ICssUnit) = h.MakeStyle("backgroundSize", value)
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    member _.backgroundSize (width: ICssUnit, height: ICssUnit) =
        h.MakeStyle("backgroundSize",
            string width
            + " " +
            string height
        )

    /// Sets one or more background images on an element.
    member _.backgroundImage (value: string) = h.MakeStyle("backgroundImage", value)
    /// Short-hand for `style.backgroundImage(sprintf "url('%s')" value)` to set the backround image using a url.
    member _.backgroundImageUrl (value: string) = h.MakeStyle("backgroundImage", "url('" + value + "')")
    /// Sets how background images are repeated.
    ///
    /// A background image can be repeated along the horizontal and vertical axes, or not repeated at all.
    member _.backgroundRepeat (repeat: IBackgroundRepeat) = h.MakeStyle("backgroundRepeat", repeat)
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    member _.boxShadow(horizontalOffset: int, verticalOffset: int, color: string) =
        h.MakeStyle("boxShadow",
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    member _.boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
        h.MakeStyle("boxShadow",
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            (string blur) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    member _.boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int, color: string) =
        h.MakeStyle("boxShadow",
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            (string blur) + "px " +
            (string spread) + "px " +
            color
        )

    /// Sets the color of an SVG shape.
    member _.fill (color: string) = h.MakeStyle("fill", color)

    member _.boxShadow_none = h.MakeStyle("boxShadow", "none")
    /// Inherits this property from its parent element.
    member _.boxShadow_inheritFromParent = h.MakeStyle("boxShadow", "inherit")


    /// Inherits this property from its parent element.
    member _.height_inheritFromParent = h.MakeStyle("height", "inherit")
    /// Sets this property to its default value.
    member _.height_initial = h.MakeStyle("height", "initial")
    /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
    member _.height_unset = h.MakeStyle("height", "unset")

    /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.height_fitContent = h.MakeStyle("height", "fit-content")

    /// The intrinsic preferred height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.height_maxContent = h.MakeStyle("height", "max-content")

    /// The intrinsic minimum height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.height_minContent = h.MakeStyle("height", "min-content")

    /// Inherits this property from its parent element.
    member _.minHeight_inheritFromParent = h.MakeStyle("min-height", "inherit")
    /// Sets this property to its default value.
    member _.minHeight_initial = h.MakeStyle("min-height", "initial")
    /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
    member _.minHeight_unset = h.MakeStyle("min-height", "unset")

    /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.minHeight_fitContent = h.MakeStyle("min-height", "fit-content")

    /// The intrinsic preferred height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.minHeight_maxContent = h.MakeStyle("min-height", "max-content")

    /// The intrinsic minimum height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.minHeight_minContent = h.MakeStyle("min-height", "min-content")

    /// Inherits this property from its parent element.
    member _.maxHeight_inheritFromParent = h.MakeStyle("max-height", "inherit")
    /// Sets this property to its default value.
    member _.maxHeight_initial = h.MakeStyle("max-height", "initial")
    /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
    member _.maxHeight_unset = h.MakeStyle("max-height", "unset")

    /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.maxHeight_fitContent = h.MakeStyle("max-height", "fit-content")

    /// The intrinsic preferred height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.maxHeight_maxContent = h.MakeStyle("max-height", "max-content")

    /// The intrinsic minimum height.
    [<Experimental("This is an experimental API that should not be used in production code.")>]
    member _.maxHeight_minContent = h.MakeStyle("max-height", "min-content")

    /// The browser determines the justification algorithm
    member _.textJustify_auto = h.MakeStyle("textJustify", "auto")
    /// Increases/Decreases the space between words
    member _.textJustify_interWord = h.MakeStyle("textJustify", "inter-word")
    /// Increases/Decreases the space between characters
    member _.textJustify_interCharacter = h.MakeStyle("textJustify", "inter-character")
    /// Disables justification methods
    member _.textJustify_none = h.MakeStyle("textJustify", "none")
    member _.textJustify_initial = h.MakeStyle("textJustify", "initial")
    /// Inherits this property from its parent element.
    member _.textJustify_inheritFromParent = h.MakeStyle("textJustify", "inherit")

    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default.
    member _.whitespace_normal = h.MakeStyle("whiteSpace", "normal")
    /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line.
    /// The text continues on the same line until a `<br> ` tag is encountered.
    member _.whitespace_nowrap = h.MakeStyle("whiteSpace", "nowrap")
    /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the <pre> tag in HTML.
    member _.whitespace_pre = h.MakeStyle("whiteSpace", "pre")
    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
    member _.whitespace_preline = h.MakeStyle("whiteSpace", "pre-line")
    /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
    member _.whitespace_prewrap = h.MakeStyle("whiteSpace", "pre-wrap")
    /// Sets this property to its default value.
    member _.whitespace_initial = h.MakeStyle("whiteSpace", "initial")
    /// Inherits this property from its parent element.
    member _.whitespace_inheritFromParent = h.MakeStyle("whiteSpace", "inherit")

    /// Default value. Uses default line break rules.
    member _.wordBreak_normal = h.MakeStyle("wordBreak", "normal")
    /// To prevent overflow, word may be broken at any character
    member _.wordBreak_breakAll = h.MakeStyle("wordBreak", "break-all")
    /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text. Non-CJK text behavior is the same as value "normal"
    member _.wordBreak_keepAll = h.MakeStyle("wordBreak", "keep-all")
    /// To prevent overflow, word may be broken at arbitrary points.
    member _.wordBreak_breakWord = h.MakeStyle("wordBreak", "break-word")
    /// Sets this property to its default value.
    member _.wordBreak_initial = h.MakeStyle("wordBreak", "initial")
    /// Inherits this property from its parent element.
    member _.wordBreak_inheritFromParent = h.MakeStyle("wordBreak", "inherit")

    /// Allows a straight jump "scroll effect" between elements within the scrolling box. This is default
    member _.scrollBehavior_auto = h.MakeStyle("scrollBehavior", "auto")
    /// Allows a smooth animated "scroll effect" between elements within the scrolling box.
    member _.scrollBehavior_smooth = h.MakeStyle("scrollBehavior", "smooth")
    /// Sets this property to its default value.
    member _.scrollBehavior_initial = h.MakeStyle("scrollBehavior", "initial")
    /// Inherits this property from its parent element.
    member _.scrollBehavior_inheritFromParent = h.MakeStyle("scrollBehavior", "inherit")

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    member _.overflow_visible = h.MakeStyle("overflow", "visibile")
    /// The content is clipped - and no scrolling mechanism is provided.
    member _.overflow_hidden = h.MakeStyle("overflow", "hidden")
    /// The content is clipped and a scrolling mechanism is provided.
    member _.overflow_scroll = h.MakeStyle("overflow", "scroll")
    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    member _.overflow_auto = h.MakeStyle("overflow", "auto")
    /// Sets this property to its default value.
    member _.overflow_initial = h.MakeStyle("overflow", "initial")
    /// Inherits this property from its parent element.
    member _.overflow_inheritFromParent = h.MakeStyle("overflow", "inherit")

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    member _.overflowX_visible = h.MakeStyle("overflowX", "visibile")
    /// The content is clipped - and no scrolling mechanism is provided.
    member _.overflowX_hidden = h.MakeStyle("overflowX", "hidden")
    /// The content is clipped and a scrolling mechanism is provided.
    member _.overflowX_scroll = h.MakeStyle("overflowX", "scroll")
    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    member _.overflowX_auto = h.MakeStyle("overflowX", "auto")
    /// Sets this property to its default value.
    member _.overflowX_initial = h.MakeStyle("overflowX", "initial")
    /// Inherits this property from its parent element.
    member _.overflowX_inheritFromParent = h.MakeStyle("overflowX", "inherit")

    /// The element is hidden (but still takes up space).
    member _.visibility_hidden = h.MakeStyle("visibility", "hidden")
    /// Default value. The element is visible.
    member _.visibility_visible = h.MakeStyle("visibility", "visible")
    /// Only for table rows (`<tr> `), row groups (`<tbody> `), columns (`<col> `), column groups
    /// (`<colgroup> `). This value removes a row or column, but it does not affect the table layout.
    /// The space taken up by the row or column will be available for other content.
    ///
    /// If collapse is used on other elements, it renders as "hidden"
    member _.visibility_collapse = h.MakeStyle("visibility", "collapse")
    /// Sets this property to its default value.
    member _.visibility_initial = h.MakeStyle("visibility", "initial")
    /// Inherits this property from its parent element.
    member _.visibility_inheritFromParent = h.MakeStyle("visibility", "inherit")

    /// Default value. The length is equal to the length of the flexible item. If the item has
    /// no length specified, the length will be according to its content.
    member _.flexBasis_auto = h.MakeStyle("flexBasis", "auto")
    /// Sets this property to its default value.
    member _.flexBasis_initial = h.MakeStyle("flexBasis", "initial")
    /// Inherits this property from its parent element.
    member _.flexBasis_inheritFromParent = h.MakeStyle("flexBasis", "inherit")

    /// Default value. The flexible items are displayed horizontally, as a row
    member _.flexDirection_row = h.MakeStyle("flexDirection", "row")
    /// Same as row, but in reverse order.
    member _.flexDirection_rowReverse = h.MakeStyle("flexDirection", "row-reverse")
    /// The flexible items are displayed vertically, as a column
    member _.flexDirection_column = h.MakeStyle("flexDirection", "column")
    /// Same as column, but in reverse order
    member _.flexDirection_columnReverse = h.MakeStyle("flexDirection", "column-reverse")
    /// Sets this property to its default value.
    member _.flexDirection_initial = h.MakeStyle("flexBasis", "initial")
    /// Inherits this property from its parent element.
    member _.flexDirection_inheritFromParent = h.MakeStyle("flexBasis", "inherit")

    /// Default value. Specifies that the flexible items will not wrap.
    member _.flexWrap_nowrap = h.MakeStyle("flexWrap", "nowrap")
    /// Specifies that the flexible items will wrap if necessary
    member _.flexWrap_wrap = h.MakeStyle("flexWrap", "wrap")
    /// Specifies that the flexible items will wrap, if necessary, in reverse order
    member _.flexWrap_wrapReverse = h.MakeStyle("flexWrap", "wrap-reverse")
    /// Sets this property to its default value.
    member _.flexWrap_initial = h.MakeStyle("flexWrap", "initial")
    /// Inherits this property from its parent element.
    member _.flexWrap_inheritFromParent = h.MakeStyle("flexWrap", "inherit")

/// Places an element on the left or right side of its container, allowing text and
/// inline elements to wrap around it. The element is removed from the normal flow
/// of the page, though still remaining a part of the flow (in contrast to absolute
/// positioning).
    /// The element must float on the left side of its containing block.
    member _.float_left = h.MakeStyle("float", "left")
    /// The element must float on the right side of its containing block.
    member _.float_right = h.MakeStyle("float", "right")
    /// The element must not float.
    member _.float_none = h.MakeStyle("float", "none")

/// Determines how a font face is displayed based on whether and when it is downloaded and ready to use.
    /// The font display strategy is defined by the user agent.
    ///
    /// Default value
    member _.fontDisplay_auto = h.MakeStyle("fontDisplay", "auto")
    /// Gives the font face a short block period and an infinite swap period.
    member _.fontDisplay_block = h.MakeStyle("fontDisplay", "block")
    /// Gives the font face an extremely small block period and an infinite swap period.
    member _.fontDisplay_swap = h.MakeStyle("fontDisplay", "swap")
    /// Gives the font face an extremely small block period and a short swap period.
    member _.fontDisplay_fallback = h.MakeStyle("fontDisplay", "fallback")
    /// Gives the font face an extremely small block period and no swap period.
    member _.fontDisplay_optional = h.MakeStyle("fontDisplay", "optional")

    /// Default. The browser determines whether font kerning should be applied or not
    member _.fontKerning_auto = h.MakeStyle("fontKerning", "auto")
    /// Specifies that font kerning is applied
    member _.fontKerning_normal = h.MakeStyle("fontKerning", "normal")
    /// Specifies that font kerning is not applied
    member _.fontKerning_none = h.MakeStyle("fontKerning", "none")

/// The font-weight property sets how thick or thin characters in text should be displayed.
    /// Defines normal characters. This is default.
    member _.fontWeight_normal = h.MakeStyle("fontWeight", "normal")
    /// Defines thick characters.
    member _.fontWeight_bold = h.MakeStyle("fontWeight", "bold")
    /// Defines thicker characters
    member _.fontWeight_bolder = h.MakeStyle("fontWeight", "bolder")
    /// Defines lighter characters.
    member _.fontWeight_lighter = h.MakeStyle("fontWeight", "lighter")
    /// Sets this property to its default value.
    member _.fontWeight_initial = h.MakeStyle("fontWeight", "initial")
    /// Inherits this property from its parent element.
    member _.fontWeight_inheritFromParent = h.MakeStyle("fontWeight", "inherit")

    /// The browser displays a normal font style. This is defaut.
    member _.fontStyle_normal = h.MakeStyle("fontStyle", "normal")
    /// The browser displays an italic font style.
    member _.fontStyle_italic = h.MakeStyle("fontStyle", "italic")
    /// The browser displays an oblique font style.
    member _.fontStyle_oblique = h.MakeStyle("fontStyle", "oblique")
    /// Sets this property to its default value.
    member _.fontStyle_initial = h.MakeStyle("fontStyle", "initial")
    /// Inherits this property from its parent element.
    member _.fontStyle_inheritFromParent = h.MakeStyle("fontStyle", "inherit")

    /// The browser displays a normal font. This is default
    member _.fontVariant_normal = h.MakeStyle("fontVariant", "normal")
    /// The browser displays a small-caps font
    member _.fontVariant_smallCaps = h.MakeStyle("fontVariant", "small-caps")
    /// Sets this property to its default value.
    member _.fontVariant_initial = h.MakeStyle("fontVariant", "initial")
    /// Inherits this property from its parent element.
    member _.fontVariant_inheritFromParent = h.MakeStyle("fontVariant", "inherit")

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    member _.overflowY_visible = h.MakeStyle("overflowY", "visibile")
    /// The content is clipped - and no scrolling mechanism is provided.
    member _.overflowY_hidden = h.MakeStyle("overflowY", "hidden")
    /// The content is clipped and a scrolling mechanism is provided.
    member _.overflowY_scroll = h.MakeStyle("overflowY", "scroll")
    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    member _.overflowY_auto = h.MakeStyle("overflowY", "auto")
    /// Sets this property to its default value.
    member _.overflowY_initial = h.MakeStyle("overflowY", "initial")
    /// Inherits this property from its parent element.
    member _.overflowY_inheritFromParent = h.MakeStyle("overflowY", "inherit")

    /// Break words only at allowed break points
    member _.wordWrap_normal = h.MakeStyle("wordWrap", "normal")
    /// Allows unbreakable words to be broken
    member _.wordWrap_breakWord = h.MakeStyle("wordWrap", "break-word")
    /// Sets this property to its default value.
    member _.wordWrap_initial = h.MakeStyle("wordWrap", "initial")
    /// Inherits this property from its parent element.
    member _.wordWrap_inheritFromParent = h.MakeStyle("wordWrap", "inherit")

    /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container.
    member _.alignSelf_auto = h.MakeStyle("alignSelf", "auto")
    /// The element is positioned to fit the container
    member _.alignSelf_stretch = h.MakeStyle("alignSelf", "stretch")
    /// The element is positioned at the center of the container
    member _.alignSelf_center = h.MakeStyle("alignSelf", "center")
    /// The element is positioned at the beginning of the container
    member _.alignSelf_flexStart = h.MakeStyle("alignSelf", "flex-start")
    /// The element is positioned at the end of the container
    member _.alignSelf_flexEnd = h.MakeStyle("alignSelf", "flex-end")
    /// The element is positioned at the baseline of the container
    member _.alignSelf_baseline = h.MakeStyle("alignSelf", "baseline")
    /// Sets this property to its default value
    member _.alignSelf_initial = h.MakeStyle("alignSelf", "initial")
    /// Inherits this property from its parent element
    member _.alignSelf_inheritFromParent = h.MakeStyle("alignSelf", "inherit")

    /// Default. Items are stretched to fit the container
    member _.alignItems_stretch = h.MakeStyle("alignItems", "stretch")
    /// Items are positioned at the center of the container
    member _.alignItems_center = h.MakeStyle("alignItems", "center")
    /// Items are positioned at the beginning of the container
    member _.alignItems_flexStart = h.MakeStyle("alignItems", "flex-start")
    /// Items are positioned at the end of the container
    member _.alignItems_flexEnd = h.MakeStyle("alignItems", "flex-end")
    /// Items are positioned at the baseline of the container
    member _.alignItems_baseline = h.MakeStyle("alignItems", "baseline")
    /// Sets this property to its default value
    member _.alignItems_initial = h.MakeStyle("alignItems", "initial")
    /// Inherits this property from its parent element
    member _.alignItems_inheritFromParent = h.MakeStyle("alignItems", "inherit")

/// The `align-content` property modifies the behavior of the `flex-wrap` property.
/// It is similar to align-items, but instead of aligning flex items, it aligns flex lines.
///
/// **Note**: There must be multiple lines of items for this property to have any effect!
///
/// **Tip**: Use the justify-content property to align the items on the main-axis (horizontally).
    /// Default value. Lines stretch to take up the remaining space.
    member _.alignContent_stretch = h.MakeStyle("alignContent", "stretch")
    /// Lines are packed toward the center of the flex container.
    member _.alignContent_center = h.MakeStyle("alignContent", "center")
    /// Lines are packed toward the start of the flex container.
    member _.alignContent_flexStart = h.MakeStyle("alignContent", "flex-start")
    /// Lines are packed toward the end of the flex container.
    member _.alignContent_flexEnd = h.MakeStyle("alignContent", "flex-end")
    /// Lines are evenly distributed in the flex container.
    member _.alignContent_spaceBetween = h.MakeStyle("alignContent", "space-between")
    /// Lines are evenly distributed in the flex container, with half-size spaces on either end.
    member _.alignContent_spaceAround = h.MakeStyle("alignContent", "space-around")
    member _.alignContent_initial = h.MakeStyle("alignContent", "initial")
    member _.alignContent_inheritFromParent = h.MakeStyle("alignContent", "inherit")

/// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
///
/// See https://www.w3schools.com/cssref/css3_pr_justify-content.asp for reference.
///
/// **Tip**: Use the align-items property to align the items vertically.
    /// Default value. Items are positioned at the beginning of the container.
    member _.justifyContent_flexStart = h.MakeStyle("justifyContent", "flex-start")
    /// Items are positioned at the end of the container.
    member _.justifyContent_flexEnd = h.MakeStyle("justifyContent", "flex-end")
    /// Items are positioned at the center of the container
    member _.justifyContent_center = h.MakeStyle("justifyContent", "center")
    /// Items are positioned with space between the lines
    member _.justifyContent_spaceBetween = h.MakeStyle("justifyContent", "space-between")
    /// Items are positioned with space before, between, and after the lines.
    member _.justifyContent_spaceAround = h.MakeStyle("justifyContent", "space-around")
    /// Sets this property to its default value.
    member _.justifyContent_initial = h.MakeStyle("justifyContent", "initial")
    /// Inherits this property from its parent element.
    member _.justifyContent_inheritFromParent = h.MakeStyle("justifyContent", "inherit")

/// An outline is a line around an element.
/// It is displayed around the margin of the element. However, it is different from the border property.
/// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    /// Specifies a medium outline. This is default.
    member _.outlineWidth_medium = h.MakeStyle("outlineWidth", "medium")
    /// Specifies a thin outline.
    member _.outlineWidth_thin = h.MakeStyle("outlineWidth", "thin")
    /// Specifies a thick outline.
    member _.outlineWidth_thick = h.MakeStyle("outlineWidth", "thick")
    /// Sets this property to its default value
    member _.outlineWidth_initial = h.MakeStyle("outlineWidth", "initial")
    /// Inherits this property from its parent element
    member _.outlineWidth_inheritFromParent = h.MakeStyle("outlineWidth", "inherit")

    /// Default value. The marker is a filled circle
    member _.listStyleType_disc = h.MakeStyle("listStyleType", "disc")
    /// The marker is traditional Armenian numbering
    member _.listStyleType_armenian = h.MakeStyle("listStyleType", "armenian")
    /// The marker is a circle
    member _.listStyleType_circle = h.MakeStyle("listStyleType", "circle")
    /// The marker is plain ideographic numbers
    member _.listStyleType_cjkIdeographic = h.MakeStyle("listStyleType", "cjk-ideographic")
    /// The marker is a number
    member _.listStyleType_decimal = h.MakeStyle("listStyleType", "decimal")
    /// The marker is a number with leading zeros (01, 02, 03, etc.)
    member _.listStyleType_decimalLeadingZero = h.MakeStyle("listStyleType", "decimal-leading-zero")
    /// The marker is traditional Georgian numbering
    member _.listStyleType_georgian = h.MakeStyle("listStyleType", "georgian")
    /// The marker is traditional Hebrew numbering
    member _.listStyleType_hebrew = h.MakeStyle("listStyleType", "hebrew")
    /// The marker is traditional Hiragana numbering
    member _.listStyleType_hiragana = h.MakeStyle("listStyleType", "hiragana")
    /// The marker is traditional Hiragana iroha numbering
    member _.listStyleType_hiraganaIroha = h.MakeStyle("listStyleType", "hiragana-iroha")
    /// The marker is traditional Katakana numbering
    member _.listStyleType_katakana = h.MakeStyle("listStyleType", "katakana")
    /// The marker is traditional Katakana iroha numbering
    member _.listStyleType_katakanaIroha = h.MakeStyle("listStyleType", "katakana-iroha")
    /// The marker is lower-alpha (a, b, c, d, e, etc.)
    member _.listStyleType_lowerAlpha = h.MakeStyle("listStyleType", "lower-alpha")
    /// The marker is lower-greek
    member _.listStyleType_lowerGreek = h.MakeStyle("listStyleType", "lower-greek")
    /// The marker is lower-latin (a, b, c, d, e, etc.)
    member _.listStyleType_lowerLatin = h.MakeStyle("listStyleType", "lower-latin")
    /// The marker is lower-roman (i, ii, iii, iv, v, etc.)
    member _.listStyleType_lowerRoman = h.MakeStyle("listStyleType", "lower-roman")
    /// No marker is shown
    member _.listStyleType_none = h.MakeStyle("listStyleType", "none")
    /// The marker is a square
    member _.listStyleType_square = h.MakeStyle("listStyleType", "square")
    /// The marker is upper-alpha (A, B, C, D, E, etc.)
    member _.listStyleType_upperAlpha = h.MakeStyle("listStyleType", "upper-alpha")
    /// The marker is upper-greek
    member _.listStyleType_upperGreek = h.MakeStyle("listStyleType", "upper-greek")
    /// The marker is upper-latin (A, B, C, D, E, etc.)
    member _.listStyleType_upperLatin = h.MakeStyle("listStyleType", "upper-latin")
    /// The marker is upper-roman (I, II, III, IV, V, etc.)
    member _.listStyleType_upperRoman = h.MakeStyle("listStyleType", "upper-roman")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.listStyleType_initial = h.MakeStyle("listStyleType", "initial")
    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.listStyleType_inheritFromParent = h.MakeStyle("listStyleType", "inherit")

    member _.property_none = h.MakeStyle("listStyleImage", "none")
    /// The path to the image to be used as a list-item marker
    member _.property_url (path: string) = h.MakeStyle("listStyleImage", "url('" + path + "')")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.property_initial = h.MakeStyle("listStyleImage", "initial")
    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.property_inheritFromParent = h.MakeStyle("listStyleImage", "inherit")

    /// The bullet points will be inside the list item
    member _.listStylePosition_inside = h.MakeStyle("listStylePosition", "inside")
    /// The bullet points will be outside the list item. This is default
    member _.listStylePosition_outside = h.MakeStyle("listStylePosition", "outside")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.listStylePosition_initial = h.MakeStyle("listStylePosition", "initial")
    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.listStylePosition_inheritFromParent = h.MakeStyle("listStylePosition", "inherit")

    /// Aligns the text to the left.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align
    member _.textAlign_left = h.MakeStyle("textAlign", "left")
    /// Aligns the text to the right.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=right
    member _.textAlign_right = h.MakeStyle("textAlign", "right")
    /// Centers the text.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=center
    member _.textAlign_center = h.MakeStyle("textAlign", "center")
    /// Stretches the lines so that each line has equal width (like in newspapers and magazines).
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=justify
    member _.textAlign_justify = h.MakeStyle("textAlign", "justify")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.textAlign_initial = h.MakeStyle("textAlign", "initial")
    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    member _.textAlign_inheritFromParent = h.MakeStyle("textAlign", "inherit")

    member _.textDecorationLine_none = h.MakeStyle("textDecorationLine", "none")
    member _.textDecorationLine_underline = h.MakeStyle("textDecorationLine", "underline")
    member _.textDecorationLine_overline = h.MakeStyle("textDecorationLine", "overline")
    member _.textDecorationLine_lineThrough = h.MakeStyle("textDecorationLine", "line-through")
    member _.textDecorationLine_initial = h.MakeStyle("textDecorationLine", "initial")
    /// Inherits this property from its parent element.
    member _.textDecorationLine_inheritFromParent = h.MakeStyle("textDecorationLine", "inherit")

    member _.textDecoration_none = h.MakeStyle("textDecoration", "none")
    member _.textDecoration_underline = h.MakeStyle("textDecoration", "underline")
    member _.textDecoration_overline = h.MakeStyle("textDecoration", "overline")
    member _.textDecoration_lineThrough = h.MakeStyle("textDecoration", "line-through")
    member _.textDecoration_initial = h.MakeStyle("textDecoration", "initial")
    /// Inherits this property from its parent element.
    member _.textDecoration_inheritFromParent = h.MakeStyle("textDecoration", "inherit")

/// The `transform-style` property specifies how nested elements are rendered in 3D space.
    /// Specifies that child elements will NOT preserve its 3D position. This is default.
    member _.transformStyle_flat = h.MakeStyle("transformStyle", "flat")
    /// Specifies that child elements will preserve its 3D position
    member _.transformStyle_preserve3D = h.MakeStyle("transformStyle", "preserve-3d")
    member _.transformStyle_initial = h.MakeStyle("transformStyle", "initial")
    /// Inherits this property from its parent element.
    member _.transformStyle_inheritFromParent = h.MakeStyle("transformStyle", "inherit")

    /// No capitalization. The text renders as it is. This is default.
    member _.textTransform_none = h.MakeStyle("textTransform", "none")
    /// Transforms the first character of each word to uppercase.
    member _.textTransform_capitalize = h.MakeStyle("textTransform", "capitalize")
    /// Transforms all characters to uppercase.
    member _.textTransform_uppercase = h.MakeStyle("textTransform", "uppercase")
    /// Transforms all characters to lowercase.
    member _.textTransform_lowercase = h.MakeStyle("textTransform", "lowercase")
    member _.textTransform_initial = h.MakeStyle("textTransform", "initial")
    /// Inherits this property from its parent element.
    member _.textTransform_inheritFromParent = h.MakeStyle("textTransform", "inherit")

    /// Default value. The text is clipped and not accessible.
    member _.textOverflow_clip = h.MakeStyle("textOverflow", "clip")
    /// Render an ellipsis ("...") to represent the clipped text.
    member _.textOverflow_ellipsis = h.MakeStyle("textOverflow", "ellipsis")
    /// Render the given string to represent the clipped text.
    member _.textOverflow_custom(value: string) = h.MakeStyle("textOverflow", value)
    member _.textOverflow_initial = h.MakeStyle("textOverflow", "initial")
    /// Inherits this property from its parent element.
    member _.textOverflow_inheritFromParent = h.MakeStyle("textOverflow", "inherit")

/// Defines visual effects like blur and saturation to an element.
    /// Default value. Specifies no effects.
    member _.filter_none = h.MakeStyle("filter", "none")
    /// Applies a blur effect to the elemeen. A larger value will create more blur.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_blur(value: int) = h.MakeStyle("filter", "blur(" + (string value) + "%)")
    /// Applies a blur effect to the elemeen. A larger value will create more blur.
    ///
    /// This overload takes a floating number that goes from 0 to 1,
    member _.filter_blur(value: double) = h.MakeStyle("filter", "blur(" + (string value) + ")")
    /// Adjusts the brightness of the elemeen
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    ///
    /// Values over 100% will provide brighter results.
    member _.filter_brightness(value: int) = h.MakeStyle("filter", "brightness(" + (string value) + "%)")
    /// Adjusts the brightness of the elemeen. A larger value will create more blur.
    ///
    /// This overload takes a floating number that goes from 0 to 1,
    member _.filter_brightness(value: double) = h.MakeStyle("filter", "brightness(" + (string value) + ")")
    /// Adjusts the contrast of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_contrast(value: int) = h.MakeStyle("filter", "contrast(" + (string value) + "%)")
    /// Adjusts the contrast of the element. A larger value will create more contrast.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_contrast(value: double) = h.MakeStyle("filter", "contrast(" + (string value) + ")")
    /// Applies a drop shadow effect.
    member _.filter_dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int,  color: string) =
        h.MakeStyle("filter",
            "drop-shadow(" +
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            (string blur) + "px " +
            (string spread) + "px " +
            color +
            ")"
        )

    /// Applies a drop shadow effect.
    member _.filter_dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
        h.MakeStyle("filter",
            "drop-shadow(" +
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            (string blur) + "px " +
            color +
            ")"
        )

    /// Applies a drop shadow effect.
    member _.filter_dropShadow(horizontalOffset: int, verticalOffset: int, color: string) =
        h.MakeStyle("filter",
            "drop-shadow(" +
            (string horizontalOffset) + "px " +
            (string verticalOffset) + "px " +
            color +
            ")"
        )

    /// Converts the image to grayscale
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_grayscale(value: int) = h.MakeStyle("filter", "grayscale(" + (string value) + "%)")
    /// Converts the image to grayscale
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_grayscale(value: double) = h.MakeStyle("filter", "grayscale(" + (string value) + ")")
    /// Applies a hue rotation on the image. The value defines the number of degrees around the color circle the image
    /// samples will be adjusted. 0deg is default, and represents the original image.
    ///
    /// **Note**: Maximum value is 360
    member _.filter_hueRotate(degrees: int) = h.MakeStyle("filter", "hue-rotate(" + (string degrees) + "deg)")
    /// Inverts the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_invert(value: int) = h.MakeStyle("filter", "invert(" + (string value) + "%)")
    /// Inverts the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_invert(value: double) = h.MakeStyle("filter", "invert(" + (string value) + ")")
    /// Sets the opacity of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_opacity(value: int) = h.MakeStyle("filter", "opacity(" + (string value) + "%)")
    /// Sets the opacity of the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_opacity(value: double) = h.MakeStyle("filter", "opacity(" + (string value) + ")")
    /// Sets the saturation of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_saturate(value: int) = h.MakeStyle("filter", "saturate(" + (string value) + "%)")
    /// Sets the saturation of the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_saturate(value: double) = h.MakeStyle("filter", "saturate(" + (string value) + ")")
    /// Applies Sepia filter to the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    member _.filter_sepia(value: int) = h.MakeStyle("filter", "sepia(" + (string value) + "%)")
    /// Applies Sepia filter to the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    member _.filter_sepia(value: double) = h.MakeStyle("filter", "sepia(" + (string value) + ")")
    /// The url() function takes the location of an XML file that specifies an SVG filter, and may include an anchor to a specific filter element.
    ///
    /// Example: `filter: url(svg-url#element-id)`
    member _.filter_url(value: string) = h.MakeStyle("filter", "url(" + value + ")")
    /// Sets this property to its default value.
    member _.filter_initial = h.MakeStyle("filter", "initial")
    /// Inherits this property from its parent element.
    member _.filter_inheritFromParent = h.MakeStyle("filter", "inherit")

/// Sets whether table borders should collapse into a single border or be separated as in standard HTML.
    /// Borders are separated; each cell will display its own borders. This is default.
    member _.borderCollapse_separate = h.MakeStyle("borderCollapse", "separate")
    /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect)
    member _.borderCollapse_collapse = h.MakeStyle("borderCollapse", "collapse")
    /// Sets this property to its default value
    member _.borderCollapse_initial = h.MakeStyle("borderCollapse", "initial")
    /// Inherits this property from its parent element.
    member _.borderCollapse_inheritFromParent = h.MakeStyle("borderCollapse", "inherit")

/// Specifies the size of the background images
    /// Default value. The background image is displayed in its original size
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=auto)
    member _.backgroundSize_auto = h.MakeStyle("backgroundSize", "auto")
    /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges.
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=cover)
    member _.backgroundSize_cover = h.MakeStyle("backgroundSize", "cover")
    /// Resize the background image to make sure the image is fully visible
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=contain)
    member _.backgroundSize_contain = h.MakeStyle("backgroundSize", "contain")
    /// Sets this property to its default value.
    member _.backgroundSize_initial = h.MakeStyle("backgroundSize", "initial")
    /// Inherits this property from its parent element.
    member _.backgroundSize_inheritFromParent = h.MakeStyle("backgroundSize", "inherit")

    /// Default value. The line will display as a single line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=solid
    member _.textDecorationStyle_solid = h.MakeStyle("textDecorationStyle", "solid")
    /// The line will display as a double line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=double
    member _.textDecorationStyle_double = h.MakeStyle("textDecorationStyle", "double")
    /// The line will display as a dotted line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dotted
    member _.textDecorationStyle_dotted = h.MakeStyle("textDecorationStyle", "dotted")
    /// The line will display as a dashed line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dashed
    member _.textDecorationStyle_dashed = h.MakeStyle("textDecorationStyle", "dashed")
    /// The line will display as a wavy line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=wavy
    member _.textDecorationStyle_wavy = h.MakeStyle("textDecorationStyle", "wavy")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=initial
    member _.textDecorationStyle_initial = h.MakeStyle("textDecorationStyle", "initial")
    /// Inherits this property from its parent element.
    member _.textDecorationStyle_inheritFromParent = h.MakeStyle("textDecorationStyle", "inherit")

    /// Makes the text as narrow as it gets.
    member _.fontStretch_ultraCondensed = h.MakeStyle("fontStretch", "ultra-condensed")
    /// Makes the text narrower than condensed, but not as narrow as ultra-condensed
    member _.fontStretch_extraCondensed = h.MakeStyle("fontStretch", "extra-condensed")
    /// Makes the text narrower than semi-condensed, but not as narrow as extra-condensed.
    member _.fontStretch_condensed = h.MakeStyle("fontStretch", "condensed")
    /// Makes the text narrower than normal, but not as narrow as condensed.
    member _.fontStretch_semiCondensed = h.MakeStyle("fontStretch", "semi-condensed")
    /// Default value. No font stretching
    member _.fontStretch_normal = h.MakeStyle("fontStretch", "normal")
    /// Makes the text wider than normal, but not as wide as expanded
    member _.fontStretch_semiExpanded = h.MakeStyle("fontStretch", "semi-expanded")
    /// Makes the text wider than semi-expanded, but not as wide as extra-expanded
    member _.fontStretch_expanded = h.MakeStyle("fontStretch", "expanded")
    /// Makes the text wider than expanded, but not as wide as ultra-expanded
    member _.fontStretch_extraExpanded = h.MakeStyle("fontStretch", "extra-expanded")
    /// Makes the text as wide as it gets.
    member _.fontStretch_ultraExpanded = h.MakeStyle("fontStretch", "ultra-expanded")
    /// Sets this property to its default value.
    member _.fontStretch_initial = h.MakeStyle("fontStretch", "initial")
    /// Inherits this property from its parent element.
    member _.fontStretch_inheritFromParent = h.MakeStyle("fontStretch", "inherit")

/// Specifies how an element should float.
///
/// **Note**: Absolutely positioned elements ignores the float property!
    /// The element does not float, (will be displayed just where it occurs in the text). This is default
    member _.floatStyle_none = h.MakeStyle("float", "none")
    member _.floatStyle_left = h.MakeStyle("float", "left")
    member _.floatStyle_right = h.MakeStyle("float", "right")
    /// Sets this property to its default value.
    member _.floatStyle_initial = h.MakeStyle("float", "initial")
    /// Inherits this property from its parent element.
    member _.floatStyle_inheritFromParent = h.MakeStyle("float", "inherit")

    /// The element is aligned with the baseline of the parent. This is default.
    member _.verticalAlign_baseline = h.MakeStyle("verticalAlign", "baseline")
    /// The element is aligned with the subscript baseline of the parent
    member _.verticalAlign_sub = h.MakeStyle("verticalAlign", "sup")
    /// The element is aligned with the superscript baseline of the parent.
    member _.verticalAlign_super = h.MakeStyle("verticalAlign", "super")
    /// The element is aligned with the top of the tallest element on the line.
    member _.verticalAlign_top = h.MakeStyle("verticalAlign", "top")
    /// The element is aligned with the top of the parent element's font.
    member _.verticalAlign_textTop = h.MakeStyle("verticalAlign", "text-top")
    /// The element is placed in the middle of the parent element.
    member _.verticalAlign_middle = h.MakeStyle("verticalAlign", "middle")
    /// The element is aligned with the lowest element on the line.
    member _.verticalAlign_bottom = h.MakeStyle("verticalAlign", "bottom")
    /// The element is aligned with the bottom of the parent element's font
    member _.verticalAlign_textBottom = h.MakeStyle("verticalAlign", "text-bottom")
    /// Sets this property to its default value.
    member _.verticalAlign_initial = h.MakeStyle("verticalAlign", "initial")
    /// Inherits this property from its parent element.
    member _.verticalAlign_inheritFromParent = h.MakeStyle("verticalAlign", "inherit")

/// Specifies whether lines of text are laid out horizontally or vertically.
    /// Let the content flow horizontally from left to right, vertically from top to bottom
    member _.writingMode_horizontalTopBottom = h.MakeStyle("writingMode", "horizontal-tb")
    /// Let the content flow vertically from top to bottom, horizontally from right to left
    member _.writingMode_verticalRightLeft = h.MakeStyle("writingMode", "vertical-rl")
    /// Let the content flow vertically from top to bottom, horizontally from left to right
    member _.writingMode_verticalLeftRight = h.MakeStyle("writingMode", "vertical-lr")
    /// Sets this property to its default value.
    member _.writingMode_initial = h.MakeStyle("writingMode", "initial")
    /// Inherits this property from its parent element.
    member _.writingMode_inheritFromParent = h.MakeStyle("writingMode", "inherit")

    /// Default value. Specifies a animation effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
    member _.animationTimingFunction_ease = h.MakeStyle("animationTimingFunction", "ease")
    /// Specifies a animation effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
    member _.animationTimingFunction_linear = h.MakeStyle("animationTimingFunction", "linear")
    /// Specifies a animation effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
    member _.animationTimingFunction_easeIn = h.MakeStyle("animationTimingFunction", "ease-in")
    /// Specifies a animation effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
    member _.animationTimingFunction_easeOut = h.MakeStyle("animationTimingFunction", "ease-out")
    /// Specifies a animation effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
    member _.animationTimingFunction_easeInOut = h.MakeStyle("animationTimingFunction", "ease-in-out")
    /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
    member _.animationTimingFunction_cubicBezier(n1: float, n2: float, n3: float, n4: float) =
        h.MakeStyle("animationTimingFunction",
            "cubic-bezier(" + (string n1) + "," +
            (string n2) + "," +
            (string n3) + "," +
            (string n4) + ")"
        )
    /// Sets this property to its default value
    member _.animationTimingFunction_initial = h.MakeStyle("animationTimingFunction", "initial")
    /// Inherits this property from its parent element.
    member _.animationTimingFunction_inheritFromParent = h.MakeStyle("animationTimingFunction", "inherit")

    /// Default value. Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
    member _.transitionTimingFunction_ease = h.MakeStyle("transitionTimingFunction", "ease")
    /// Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
    member _.transitionTimingFunction_linear = h.MakeStyle("transitionTimingFunction", "linear")
    /// Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
    member _.transitionTimingFunction_easeIn = h.MakeStyle("transitionTimingFunction", "ease-in")
    /// Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
    member _.transitionTimingFunction_easeOut = h.MakeStyle("transitionTimingFunction", "ease-out")
    /// Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
    member _.transitionTimingFunction_easeInOut = h.MakeStyle("transitionTimingFunction", "ease-in-out")
    /// Equivalent to steps(1, start)
    member _.transitionTimingFunction_stepStart = h.MakeStyle("transitionTimingFunction", "step-start")
    /// Equivalent to steps(1, end)
    member _.transitionTimingFunction_stepEnd = h.MakeStyle("transitionTimingFunction", "step-end")
    member _.transitionTimingFunction_stepsToEnd(steps: int) =
        h.MakeStyle("transitionTimingFunction", "steps(" + (string steps) + ", end)")
    member _.transitionTimingFunction_stepsToStart(steps: int) =
        h.MakeStyle("transitionTimingFunction", "steps(" + (string steps) + ", start)")
    /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
    member _.transitionTimingFunction_cubicBezier(n1: float, n2: float, n3: float, n4: float) =
        h.MakeStyle("transitionTimingFunction",
            "cubic-bezier(" + (string n1) + "," +
            (string n2) + "," +
            (string n3) + "," +
            (string n4) + ")"
        )
    /// Sets this property to its default value
    member _.transitionTimingFunction_initial = h.MakeStyle("transitionTimingFunction", "initial")
    /// Inherits this property from its parent element.
    member _.transitionTimingFunction_inheritFromParent = h.MakeStyle("transitionTimingFunction", "inherit")

    /// Default. Text can be selected if the browser allows it.
    member _.userSelect_auto = h.MakeStyle("userSelect", "auto")
    /// Prevents text selection.
    member _.userSelect_none = h.MakeStyle("userSelect", "none")
    /// The text can be selected by the user.
    member _.userSelect_text = h.MakeStyle("userSelect", "text")
    /// Text selection is made with one click instead of a double-click.
    member _.userSelect_all = h.MakeStyle("userSelect", "all")
    /// Sets this property to its default value.
    member _.userSelect_initial = h.MakeStyle("userSelect", "initial")
    /// Inherits this property from its parent element.
    member _.userSelect_inheritFromParent = h.MakeStyle("userSelect", "inherit")

    /// Specifies a dotted border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_dotted = h.MakeStyle("borderStyle", "dotted")
    /// Specifies a dashed border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_dashed = h.MakeStyle("borderStyle", "dashed")
    /// Specifies a solid border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_solid = h.MakeStyle("borderStyle", "solid")
    /// Specifies a double border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_double = h.MakeStyle("borderStyle", "double")
    /// Specifies a 3D grooved border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_groove = h.MakeStyle("borderStyle", "groove")
    /// Specifies a 3D ridged border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_ridge = h.MakeStyle("borderStyle", "ridge")
    /// Specifies a 3D inset border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_inset = h.MakeStyle("borderStyle", "inset")
    /// Specifies a 3D outset border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_outset = h.MakeStyle("borderStyle", "outset")
    /// Default value. Specifies no border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    member _.borderStyle_none = h.MakeStyle("borderStyle", "none")
    /// The same as "none", except in border conflict resolution for table elements.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    member _.borderStyle_hidden = h.MakeStyle("borderStyle", "hidden")
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    ///
    /// Read about initial value https://www.w3schools.com/cssref/css_initial.asp
    member _.borderStyle_initial = h.MakeStyle("borderStyle", "initial")
    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    ///
    /// Read about inherit https://www.w3schools.com/cssref/css_inherit.asp
    member _.borderStyle_inheritFromParent = h.MakeStyle("borderStyle", "inherit")

/// Defines the algorithm used to lay out table cells, rows, and columns.
///
/// **Tip:** The main benefit of table-layout: fixed; is that the table renders much faster. On large tables,
/// users will not see any part of the table until the browser has rendered the whole table. So, if you use
/// table-layout: fixed, users will see the top of the table while the browser loads and renders rest of the
/// table. This gives the impression that the page loads a lot quicker!
    /// Browsers use an automatic table layout algorithm. The column width is set by the widest unbreakable
    /// content in the cells. The content will dictate the layout
    member _.tableLayout_auto = h.MakeStyle("tableLayout", "auto")
    /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col
    /// or by the width of the first row of cells. Cells in other rows do not affect column widths. If no widths
    /// are present on the first row, the column widths are divided equally across the table, regardless of content
    /// inside the cells
    member _.tableLayout_fixed' = h.MakeStyle("tableLayout", "fixed")
    /// Sets this property to its default value.
    member _.tableLayout_initial = h.MakeStyle("tableLayout", "initial")
    /// Inherits this property from its parent element.
    member _.tableLayout_inheritFromParent = h.MakeStyle("tableLayout", "inherit")

    /// Displays an element as an inline element (like `<span> `). Any height and width properties will have no effect.
    member _.display_inlineElement = h.MakeStyle("display", "inline")
    /// Displays an element as a block element (like `<p> `). It starts on a new line, and takes up the whole width.
    member _.display_block = h.MakeStyle("display", "block")
    /// Makes the container disappear, making the child elements children of the element the next level up in the DOM.
    member _.display_contents = h.MakeStyle("display", "contents")
    /// Displays an element as a block-level flex container.
    member _.display_flex = h.MakeStyle("display", "flex")
    /// Displays an element as a block container box, and lays out its contents using flow layout.
    ///
    /// It always establishes a new block formatting context for its contents.
    member _.display_flowRoot = h.MakeStyle("display", "flow-root")
    /// Displays an element as a block-level grid container.
    member _.display_grid = h.MakeStyle("display", "grid")
    /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values.
    member _.display_inlineBlock = h.MakeStyle("display", "inline-block")
    /// Displays an element as an inline-level flex container.
    member _.display_inlineFlex = h.MakeStyle("display", "inline-flex")
    /// Displays an element as an inline-level grid container
    member _.display_inlineGrid = h.MakeStyle("display", "inline-grid")
    /// The element is displayed as an inline-level table.
    member _.display_inlineTable = h.MakeStyle("display", "inline-table")
    /// Let the element behave like a `<li> ` element
    member _.display_listItem = h.MakeStyle("display", "list-item")
    /// Displays an element as either block or inline, depending on context.
    member _.display_runIn = h.MakeStyle("display", "run-in")
    /// Let the element behave like a `<table> ` element.
    member _.display_table = h.MakeStyle("display", "table")
    /// Let the element behave like a <caption> element.
    member _.display_tableCaption = h.MakeStyle("display", "table-caption")
    /// Let the element behave like a <colgroup> element.
    member _.display_tableColumnGroup = h.MakeStyle("display", "table-column-group")
    /// Let the element behave like a <thead> element.
    member _.display_tableHeaderGroup = h.MakeStyle("display", "table-header-group")
    /// Let the element behave like a <tfoot> element.
    member _.display_tableFooterGroup = h.MakeStyle("display", "table-footer-group")
    /// Let the element behave like a <tbody> element.
    member _.display_tableRowGroup = h.MakeStyle("display", "table-row-group")
    /// Let the element behave like a <td> element.
    member _.display_tableCell = h.MakeStyle("display", "table-cell")
    /// Let the element behave like a <col> element.
    member _.display_tableColumn = h.MakeStyle("display", "table-column")
    /// Let the element behave like a <tr> element.
    member _.display_tableRow = h.MakeStyle("display", "table-row")
    /// The element is completely removed.
    member _.display_none = h.MakeStyle("display", "none")
    /// Sets this property to its default value.
    member _.display_initial = h.MakeStyle("display", "initial")
    /// Inherits this property from its parent element.
    member _.display_inheritFromParent = h.MakeStyle("display", "inherit")

/// See documentation at https://developer.mozilla.org/en-US/docs/Web/CSS/cursor
    /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
    member _.cursor_auto = h.MakeStyle("cursor", "auto")
    /// The cursor indicates an alias of something is to be created
    member _.cursor_alias = h.MakeStyle("cursor", "alias")
    /// The platform-dependent default cursor. Typically an arrow.
    member _.cursor_defaultCursor = h.MakeStyle("cursor", "default")
    /// No cursor is rendered.
    member _.cursor_none = h.MakeStyle("cursor", "none")
    /// A context menu is available.
    member _.cursor_contextMenu = h.MakeStyle("cursor", "context-menu")
    /// Help information is available.
    member _.cursor_help = h.MakeStyle("cursor", "help")
    /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
    member _.cursor_pointer = h.MakeStyle("cursor", "pointer")
    /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
    member _.cursor_progress = h.MakeStyle("cursor", "progress")
    /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
    member _.cursor_wait = h.MakeStyle("cursor", "wait")
    /// The table cell or set of cells can be selected.
    member _.cursor_cell = h.MakeStyle("cursor", "cell")
    /// Cross cursor, often used to indicate selection in a bitmap.
    member _.cursor_crosshair = h.MakeStyle("cursor", "crosshair")
    /// The text can be selected. Typically the shape of an I-beam.
    member _.cursor_text = h.MakeStyle("cursor", "text")
    /// The vertical text can be selected. Typically the shape of a sideways I-beam.
    member _.cursor_verticalText = h.MakeStyle("cursor", "vertical-text")
    /// Something is to be copied.
    member _.cursor_copy = h.MakeStyle("cursor", "copy")
    /// Something is to be moved.
    member _.cursor_move = h.MakeStyle("cursor", "move")
    /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
    member _.cursor_noDrop = h.MakeStyle("cursor", "no-drop")
    /// The requested action will not be carried out.
    member _.cursor_notAllowed = h.MakeStyle("cursor", "not-allowed")
    /// Something can be grabbed (dragged to be moved).
    member _.cursor_grab = h.MakeStyle("cursor", "grab")
    /// Something is being grabbed (dragged to be moved).
    member _.cursor_grabbing = h.MakeStyle("cursor", "grabbing")
    /// Something can be scrolled in any direction (panned).
    member _.cursor_allScroll = h.MakeStyle("cursor", "all-scroll")
    /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
    member _.cursor_columnResize = h.MakeStyle("cursor", "col-resize")
    /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
    member _.cursor_rowResize = h.MakeStyle("cursor", "row-resize")
    /// Directional resize arrow
    member _.cursor_northResize = h.MakeStyle("cursor", "n-resize")
    /// Directional resize arrow
    member _.cursor_eastResize = h.MakeStyle("cursor", "e-resize")
    /// Directional resize arrow
    member _.cursor_southResize = h.MakeStyle("cursor", "s-resize")
    /// Directional resize arrow
    member _.cursor_westResize = h.MakeStyle("cursor", "w-resize")
    /// Directional resize arrow
    member _.cursor_northEastResize = h.MakeStyle("cursor", "ne-resize")
    /// Directional resize arrow
    member _.cursor_northWestResize = h.MakeStyle("cursor", "nw-resize")
    /// Directional resize arrow
    member _.cursor_southEastResize = h.MakeStyle("cursor", "se-resize")
    /// Directional resize arrow
    member _.cursor_southWestResize = h.MakeStyle("cursor", "sw-resize")
    /// Directional resize arrow
    member _.cursor_eastWestResize = h.MakeStyle("cursor", "ew-resize")
    /// Directional resize arrow
    member _.cursor_northSouthResize = h.MakeStyle("cursor", "ns-resize")
    /// Directional resize arrow
    member _.cursor_northEastSouthWestResize = h.MakeStyle("cursor", "nesw-resize")
    /// Directional resize arrow
    member _.cursor_northWestSouthEastResize = h.MakeStyle("cursor", "nwse-resize")
    /// Something can be zoomed (magnified) in
    member _.cursor_zoomIn = h.MakeStyle("cursor", "zoom-in")
    /// Something can be zoomed out
    member _.cursor_zoomOut = h.MakeStyle("cursor", "zoom-out")

/// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
///
/// The outline-style property specifies the style of an outline.
///
/// An outline is a line around an element. It is displayed around the margin of the element. However, it is different from the border property.
///
/// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    /// Permits the user agent to render a custom outline style.
    member _.outlineStyle_auto = h.MakeStyle("outlineStyle", "auto")
    /// Specifies no outline. This is default.
    member _.outlineStyle_none = h.MakeStyle("outlineStyle", "none")
    /// Specifies a hidden outline
    member _.outlineStyle_hidden = h.MakeStyle("outlineStyle", "hidden")
    /// Specifies a dotted outline
    member _.outlineStyle_dotted = h.MakeStyle("outlineStyle", "dotted")
    /// Specifies a dashed outline
    member _.outlineStyle_dashed = h.MakeStyle("outlineStyle", "dashed")
    /// Specifies a solid outline
    member _.outlineStyle_solid = h.MakeStyle("outlineStyle", "solid")
    /// Specifies a double outliner
    member _.outlineStyle_double = h.MakeStyle("outlineStyle", "double")
    /// Specifies a 3D grooved outline. The effect depends on the outline-color value
    member _.outlineStyle_groove = h.MakeStyle("outlineStyle", "groove")
    /// Specifies a 3D ridged outline. The effect depends on the outline-color value
    member _.outlineStyle_ridge = h.MakeStyle("outlineStyle", "ridge")
    /// Specifies a 3D inset  outline. The effect depends on the outline-color value
    member _.outlineStyle_inset = h.MakeStyle("outlineStyle", "inset")
    /// Specifies a 3D outset outline. The effect depends on the outline-color value
    member _.outlineStyle_outset = h.MakeStyle("outlineStyle", "outset")
    /// Sets this property to its default value
    member _.outlineStyle_initial = h.MakeStyle("outlineStyle", "initial")
    /// Inherits this property from its parent element
    member _.outlineStyle_inheritFromParent = h.MakeStyle("outlineStyle", "inherit")
    /// Resets to its inherited value if the property naturally inherits from its parent,
    /// and to its initial value if not.
    member _.outlineStyle_unset = h.MakeStyle("outlineStyle", "unset")

    /// The background image will scroll with the page. This is default.
    member _.backgroundPosition_scroll = h.MakeStyle("backgroundPosition", "scroll")
    /// The background image will not scroll with the page.
    member _.backgroundPosition_fixedNoScroll = h.MakeStyle("backgroundPosition", "fixed")
    /// The background image will scroll with the element's contents.
    member _.backgroundPosition_local = h.MakeStyle("backgroundPosition", "local")
    /// Sets this property to its default value.
    member _.backgroundPosition_initial = h.MakeStyle("backgroundPosition", "initial")
    /// Inherits this property from its parent element.
    member _.backgroundPosition_inheritFromParent = h.MakeStyle("backgroundPosition", "inherit")

/// This property defines the blending mode of each background layer (color and/or image).
    /// This is default. Sets the blending mode to normal.
    member _.backgroundBlendMode_normal = h.MakeStyle("backgroundBlendMode", "normal")
    /// Sets the blending mode to screen
    member _.backgroundBlendMode_screen = h.MakeStyle("backgroundBlendMode", "screen")
    /// Sets the blending mode to overlay
    member _.backgroundBlendMode_overlay = h.MakeStyle("backgroundBlendMode", "overlay")
    /// Sets the blending mode to darken
    member _.backgroundBlendMode_darken = h.MakeStyle("backgroundBlendMode", "darken")
    /// Sets the blending mode to multiply
    member _.backgroundBlendMode_lighten = h.MakeStyle("backgroundBlendMode", "lighten")
    /// Sets the blending mode to color-dodge
    member _.backgroundBlendMode_collorDodge = h.MakeStyle("backgroundBlendMode", "color-dodge")
    /// Sets the blending mode to saturation
    member _.backgroundBlendMode_saturation = h.MakeStyle("backgroundBlendMode", "saturation")
    /// Sets the blending mode to color
    member _.backgroundBlendMode_color = h.MakeStyle("backgroundBlendMode", "color")
    /// Sets the blending mode to luminosity
    member _.backgroundBlendMode_luminosity = h.MakeStyle("backgroundBlendMode", "luminosity")

/// Defines how far the background (color or image) should extend within an element.
    /// Default value. The background extends behind the border.
    member _.backgroundClip_borderBox = h.MakeStyle("backgroundClip", "border-box")
    /// The background extends to the inside edge of the border.
    member _.backgroundClip_paddingBox = h.MakeStyle("backgroundClip", "padding-box")
    /// The background extends to the edge of the content box.
    member _.backgroundClip_contentBox = h.MakeStyle("backgroundClip", "content-box")
    /// Sets this property to its default value.
    member _.backgroundClip_initial = h.MakeStyle("backgroundClip", "initial")
    /// Inherits this property from its parent element.
    member _.backgroundClip_inheritFromParent = h.MakeStyle("backgroundClip", "inherit")

    /// Defines that there should be no transformation.
    member _.transform_none = h.MakeStyle("transform", "none")
    /// Defines a 2D transformation, using a matrix of six values.
    member _.transform_matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
        h.MakeStyle("transform",
            "matrix(" +
            (string x1) + "," +
            (string y1) + "," +
            (string z1) + "," +
            (string x2) + "," +
            (string y2) + "," +
            (string z2) + ")"
        )

    /// Defines a 2D translation.
    member _.transform_translate(x: int, y: int) =
        h.MakeStyle("transform",
            "translate(" + (string x) + "px," + (string y) + "px)"
        )
    /// Defines a 2D translation.
    member _.transform_translate(x: ICssUnit, y: ICssUnit) =
        h.MakeStyle("transform",
            "translate(" + (string x) + "," + (string y) + ")"
        )

    /// Defines a 3D translation.
    member _.transform_translate3D(x: int, y: int, z: int) =
        h.MakeStyle("transform",
            "translate3d(" + (string x) + "px," + (string y) + "px," + (string z) + "px)"
        )
    /// Defines a 3D translation.
    member _.transform_translate3D(x: ICssUnit, y: ICssUnit, z: ICssUnit) =
        h.MakeStyle("transform",
            "translate3d(" + (string x) + "," + (string y) + "," + (string z) + ")"
        )

    /// Defines a translation, using only the value for the X-axis.
    member _.transform_translateX(x: int) =
        h.MakeStyle("transform", "translateX(" + (string x) + "px)")
    /// Defines a translation, using only the value for the X-axis.
    member _.transform_translateX(x: ICssUnit) =
        h.MakeStyle("transform", "translateX(" + (string x) + ")")
    /// Defines a translation, using only the value for the Y-axis
    member _.transform_translateY(y: int) =
        h.MakeStyle("transform", "translateY(" + (string y) + "px)")
    /// Defines a translation, using only the value for the Y-axis
    member _.transform_translateY(y: ICssUnit) =
        h.MakeStyle("transform", "translateY(" + (string y) + ")")
    /// Defines a 3D translation, using only the value for the Z-axis
    member _.transform_translateZ(z: int) =
        h.MakeStyle("transform", "translateZ(" + (string z) + "px)")
    /// Defines a 3D translation, using only the value for the Z-axis
    member _.transform_translateZ(z: ICssUnit) =
        h.MakeStyle("transform", "translateZ(" + (string z) + ")")

    /// Defines a 2D scale transformation.
    member _.transform_scale(x: int, y: int) =
        h.MakeStyle("transform",
            "scale(" + (string x) + "," + (string y) + ")"
        )
    /// Defines a scale transformation.
    member _.transform_scale(n: int) =
        h.MakeStyle("transform",
            "scale(" + (string n) + ")"
        )

    /// Defines a scale transformation.
    member _.transform_scale(n: float) =
        h.MakeStyle("transform",
            "scale(" + (string n) + ")"
        )

    /// Defines a 3D scale transformation
    member _.transform_scale3D(x: int, y: int, z: int) =
        h.MakeStyle("transform",
            "scale3d(" + (string x) + "," + (string y) + "," + (string z) + ")"
        )

    /// Defines a scale transformation by giving a value for the X-axis.
    member _.transform_scaleX(x: int) =
        h.MakeStyle("transform", "scaleX(" + (string x) + ")")

    /// Defines a scale transformation by giving a value for the Y-axis.
    member _.transform_scaleY(y: int) =
        h.MakeStyle("transform", "scaleY(" + (string y) + ")")
    /// Defines a 3D translation, using only the value for the Z-axis
    member _.transform_scaleZ(z: int) =
        h.MakeStyle("transform", "scaleZ(" + (string z) + ")")
    /// Defines a 2D rotation, the angle is specified in the parameter.
    member _.transform_rotate(deg: int) =
        h.MakeStyle("transform", "rotate(" + (string deg) + "deg)")
    /// Defines a 2D rotation, the angle is specified in the parameter.
    member _.transform_rotate(deg: float) =
        h.MakeStyle("transform", "rotate(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the X-axis.
    member _.transform_rotateX(deg: float) =
        h.MakeStyle("transform", "rotateX(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the X-axis.
    member _.transform_rotateX(deg: int) =
        h.MakeStyle("transform", "rotateX(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the Y-axis
    member _.transform_rotateY(deg: float) =
        h.MakeStyle("transform", "rotateY(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the Y-axis
    member _.transform_rotateY(deg: int) =
        h.MakeStyle("transform", "rotateY(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the Z-axis
    member _.transform_rotateZ(deg: float) =
        h.MakeStyle("transform", "rotateZ(" + (string deg) + "deg)")
    /// Defines a 3D rotation along the Z-axis
    member _.transform_rotateZ(deg: int) =
        h.MakeStyle("transform", "rotateZ(" + (string deg) + "deg)")
    /// Defines a 2D skew transformation along the X- and the Y-axis.
    member _.transform_skew(xAngle: int, yAngle: int) =
        h.MakeStyle("transform", "skew(" + (string xAngle) + "deg," + (string yAngle) + "deg)")
    /// Defines a 2D skew transformation along the X- and the Y-axis.
    member _.transform_skew(xAngle: float, yAngle: float) =
        h.MakeStyle("transform", "skew(" + (string xAngle) + "deg," + (string yAngle) + "deg)")
    /// Defines a 2D skew transformation along the X-axis
    member _.transform_skewX(xAngle: int) =
        h.MakeStyle("transform", "skewX(" + (string xAngle) + "deg)")
    /// Defines a 2D skew transformation along the X-axis
    member _.transform_skewX(xAngle: float) =
        h.MakeStyle("transform", "skewX(" + (string xAngle) + "deg)")
    /// Defines a 2D skew transformation along the Y-axis
    member _.transform_skewY(xAngle: int) =
        h.MakeStyle("transform", "skewY(" + (string xAngle) + "deg)")
    /// Defines a 2D skew transformation along the Y-axis
    member _.transform_skewY(xAngle: float) =
        h.MakeStyle("transform", "skewY(" + (string xAngle) + "deg)")
    /// Defines a perspective view for a 3D transformed element
    member _.transform_perspective(n: int) =
        h.MakeStyle("transform", "perspective(" + (string n) + ")")
    /// Sets this property to its default value.
    member _.transform_initial = h.MakeStyle("transform", "initial")
    /// Inherits this property from its parent element.
    member _.transform_inheritFromParent = h.MakeStyle("transform", "inherit")

    member _.margin_auto = h.MakeStyle("margin", "auto")

/// The direction property specifies the text direction/writing direction within a block-level element.
    /// Text direction goes from right-to-left
    member _.direction_rightToLeft = h.MakeStyle("direction", "rtl")
    /// Text direction goes from left-to-right. This is default
    member _.direction_leftToRight = h.MakeStyle("direction", "ltr")
    /// Sets this property to its default value.
    member _.direction_initial = h.MakeStyle("direction", "initial")
    /// Inherits this property from its parent element.
    member _.direction_inheritFromParent = h.MakeStyle("direction", "inherit")

/// Sets whether or not to display borders on empty cells in a table.
    /// Display borders on empty cells. This is default
    member _.emptyCells_show = h.MakeStyle("emptyCells", "show")
    /// Hide borders on empty cells
    member _.emptyCells_hide = h.MakeStyle("emptyCells", "hide")
    /// Sets this property to its default value
    member _.emptyCells_initial = h.MakeStyle("emptyCells", "initial")
    /// Inherits this property from its parent element
    member _.emptyCells_inheritFromParent = h.MakeStyle("emptyCells", "inherit")


/// Sets whether or not the animation should play in reverse on alternate cycles.
    /// Default value. The animation should be played as normal
    member _.animationDirection_normal = h.MakeStyle("animationDirection", "normal")
    /// The animation should play in reverse direction
    member _.animationDirection_reverse = h.MakeStyle("animationDirection", "reverse")
    /// The animation will be played as normal every odd time (1, 3, 5, etc..) and in reverse direction every even time (2, 4, 6, etc...).
    member _.animationDirection_alternate = h.MakeStyle("animationDirection", "alternate")
    /// The animation will be played in reverse direction every odd time (1, 3, 5, etc..) and in a normal direction every even time (2,4,6,etc...)
    member _.animationDirection_alternateReverse = h.MakeStyle("animationDirection", "alternate-reverse")
    /// Sets this property to its default value
    member _.animationDirection_initial = h.MakeStyle("animationDirection", "initial")
    /// Inherits this property from its parent element.
    member _.animationDirection_inheritFromParent = h.MakeStyle("animationDirection", "inherit")

    /// Default value. Specifies that the animation is running.
    member _.animationPlayState_running = h.MakeStyle("animationPlayState", "running")
    /// Specifies that the animation is paused
    member _.animationPlayState_paused = h.MakeStyle("animationPlayState", "paused")
    /// Sets this property to its default value
    member _.animationPlayState_initial = h.MakeStyle("animationPlayState", "initial")
    /// Inherits this property from its parent element.
    member _.animationPlayState_inheritFromParent = h.MakeStyle("animationPlayState", "inherit")

    /// Specifies that the animation should be played infinite times (forever)
    member _.animationIterationCount_infinite = h.MakeStyle("animationIterationCount", "infinite")
    /// Sets this property to its default value
    member _.animationIterationCount_initial = h.MakeStyle("animationIterationCount", "initial")
    /// Inherits this property from its parent element.
    member _.animationIterationCount_inheritFromParent = h.MakeStyle("animationIterationCount", "inherit")

/// Specifies a style for the element when the animation is not playing (before it starts, after it ends, or both).
    /// Default value. Animation will not apply any styles to the element before or after it is executing
    member _.animationFillMode_none = h.MakeStyle("animationFillMode", "none")
    /// The element will retain the style values that is set by the last keyframe (depends on animation-direction and animation-iteration-count).
    member _.animationFillMode_forwards = h.MakeStyle("animationFillMode", "forwards")
    /// The element will get the style values that is set by the first keyframe (depends on animation-direction), and retain this during the animation-delay period
    member _.animationFillMode_backwards = h.MakeStyle("animationFillMode", "backwards")
    /// The animation will follow the rules for both forwards and backwards, extending the animation properties in both directions
    member _.animationFillMode_both = h.MakeStyle("animationFillMode", "both")
    /// Sets this property to its default value
    member _.animationFillMode_initial = h.MakeStyle("animationFillMode", "initial")
    /// Inherits this property from its parent element
    member _.animationFillMode_inheritFromParent = h.MakeStyle("animationFillMode", "inherit")

    /// The background image is repeated both vertically and horizontally. This is default.
    member _.backgroundRepeat_repeat = h.MakeStyle("backgroundRepeat", "repeat")
    /// The background image is only repeated horizontally.
    member _.backgroundRepeat_repeatX = h.MakeStyle("backgroundRepeat", "repeat-x")
    /// The background image is only repeated vertically.
    member _.backgroundRepeat_repeatY = h.MakeStyle("backgroundRepeat", "repeat-y")
    /// The background-image is not repeated.
    member _.backgroundRepeat_noRepeat = h.MakeStyle("backgroundRepeat", "no-repeat")
    /// Sets this property to its default value.
    member _.backgroundRepeat_initial = h.MakeStyle("backgroundRepeat", "initial")
    /// Inherits this property from its parent element.
    member _.backgroundRepeat_inheritFromParent = h.MakeStyle("backgroundRepeat", "inherit")

    /// Default value. Elements render in order, as they appear in the document flow.
    member _.position_defaultStatic = h.MakeStyle("position", "static")
    /// The element is positioned relative to its first positioned (not static) ancestor element.
    member _.position_absolute = h.MakeStyle("position", "absolute")
    /// The element is positioned relative to the browser window
    member _.position_fixedRelativeToWindow = h.MakeStyle("position", "fixed")
    /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position.
    member _.position_relative = h.MakeStyle("position", "relative")
    /// The element is positioned based on the user's scroll position
    ///
    /// A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed).
    ///
    /// Note: Not supported in IE/Edge 15 or earlier. Supported in Safari from version 6.1 with a -webkit- prefix.
    member _.position_sticky = h.MakeStyle("position", "sticky")
    member _.position_initial = h.MakeStyle("position", "initial")
    /// Inherits this property from its parent element.
    member _.position_inheritFromParent = h.MakeStyle("position", "inherit")

/// Sets how the total width and height of an element is calculated.
    /// Default value. The width and height properties include the content, but does not include the padding, border, or margin.
    member _.boxSizing_contentBox = h.MakeStyle("boxSizing", "content-box")
    /// The width and height properties include the content, padding, and border, but do not include the margin. Note that padding and border will be inside of the box.
    member _.boxSizing_borderBox = h.MakeStyle("boxSizing", "border-box")
    /// Sets this property to its default value.
    member _.boxSizing_initial = h.MakeStyle("boxSizing", "initial")
    /// Inherits this property from its parent element.
    member _.boxSizing_inheritFromParent = h.MakeStyle("boxSizing", "inherit")

/// Sets whether an element is resizable, and if so, in which directions.
    /// Default value. The element offers no user-controllable method for resizing it.
    member _.resize_none = h.MakeStyle("resize", "none")
    /// The element displays a mechanism for allowing the user to resize it, which may be resized both horizontally and vertically.
    member _.resize_both = h.MakeStyle("resize", "both")
    /// The element displays a mechanism for allowing the user to resize it in the horizontal direction.
    member _.resize_horizontal = h.MakeStyle("resize", "horizontal")
    /// The element displays a mechanism for allowing the user to resize it in the vertical direction.
    member _.resize_vertical = h.MakeStyle("resize", "vertical")
    /// The element displays a mechanism for allowing the user to resize it in the block direction (either horizontally or vertically, depending on the writing-mode and direction value).
    member _.resize_block = h.MakeStyle("resize", "block")
    /// The element displays a mechanism for allowing the user to resize it in the inline direction (either horizontally or vertically, depending on the writing-mode and direction value).
    member _.resize_inline' = h.MakeStyle("resize", "inline")
    /// Sets this property to its default value.
    member _.resize_initial = h.MakeStyle("resize", "initial")
    /// Inherits this property from its parent element.
    member _.resize_inheritFromParent = h.MakeStyle("resize", "inherit")

/// Sets the background color of an element.
    member _.backgroundColor_indianRed = h.MakeStyle("backgroundColor", "#CD5C5C")
    member _.backgroundColor_lightCoral = h.MakeStyle("backgroundColor", "#F08080")
    member _.backgroundColor_salmon = h.MakeStyle("backgroundColor", "#FA8072")
    member _.backgroundColor_darkSalmon = h.MakeStyle("backgroundColor", "#E9967A")
    member _.backgroundColor_lightSalmon = h.MakeStyle("backgroundColor", "#FFA07A")
    member _.backgroundColor_crimson = h.MakeStyle("backgroundColor", "#DC143C")
    member _.backgroundColor_red = h.MakeStyle("backgroundColor", "#FF0000")
    member _.backgroundColor_fireBrick = h.MakeStyle("backgroundColor", "#B22222")
    member _.backgroundColor_darkred = h.MakeStyle("backgroundColor", "#8B0000")
    member _.backgroundColor_pink = h.MakeStyle("backgroundColor", "#FFC0CB")
    member _.backgroundColor_lightPink = h.MakeStyle("backgroundColor", "#FFB6C1")
    member _.backgroundColor_hotPink = h.MakeStyle("backgroundColor", "#FF69B4")
    member _.backgroundColor_deepPink = h.MakeStyle("backgroundColor", "#FF1493")
    member _.backgroundColor_mediumVioletRed = h.MakeStyle("backgroundColor", "#C71585")
    member _.backgroundColor_paleVioletRed = h.MakeStyle("backgroundColor", "#DB7093")
    member _.backgroundColor_coral = h.MakeStyle("backgroundColor", "#FF7F50")
    member _.backgroundColor_tomato = h.MakeStyle("backgroundColor", "#FF6347")
    member _.backgroundColor_orangeRed = h.MakeStyle("backgroundColor", "#FF4500")
    member _.backgroundColor_darkOrange = h.MakeStyle("backgroundColor", "#FF8C00")
    member _.backgroundColor_orange = h.MakeStyle("backgroundColor", "#FFA500")
    member _.backgroundColor_gold = h.MakeStyle("backgroundColor", "#FFD700")
    member _.backgroundColor_yellow = h.MakeStyle("backgroundColor", "#FFFF00")
    member _.backgroundColor_lightYellow = h.MakeStyle("backgroundColor", "#FFFFE0")
    member _.backgroundColor_limonChiffon = h.MakeStyle("backgroundColor", "#FFFACD")
    member _.backgroundColor_lightGoldenRodYellow = h.MakeStyle("backgroundColor", "#FAFAD2")
    member _.backgroundColor_papayaWhip = h.MakeStyle("backgroundColor", "#FFEFD5")
    member _.backgroundColor_moccasin = h.MakeStyle("backgroundColor", "#FFE4B5")
    member _.backgroundColor_peachPuff = h.MakeStyle("backgroundColor", "#FFDAB9")
    member _.backgroundColor_paleGoldenRod = h.MakeStyle("backgroundColor", "#EEE8AA")
    member _.backgroundColor_khaki = h.MakeStyle("backgroundColor", "#F0E68C")
    member _.backgroundColor_darkKhaki = h.MakeStyle("backgroundColor", "#BDB76B")
    member _.backgroundColor_lavender = h.MakeStyle("backgroundColor", "#E6E6FA")
    member _.backgroundColor_thistle = h.MakeStyle("backgroundColor", "#D8BFD8")
    member _.backgroundColor_plum = h.MakeStyle("backgroundColor", "#DDA0DD")
    member _.backgroundColor_violet = h.MakeStyle("backgroundColor", "#EE82EE")
    member _.backgroundColor_orchid = h.MakeStyle("backgroundColor", "#DA70D6")
    member _.backgroundColor_fuchsia = h.MakeStyle("backgroundColor", "#FF00FF")
    member _.backgroundColor_magenta = h.MakeStyle("backgroundColor", "#FF00FF")
    member _.backgroundColor_mediumOrchid = h.MakeStyle("backgroundColor", "#BA55D3")
    member _.backgroundColor_mediumPurple = h.MakeStyle("backgroundColor", "#9370DB")
    member _.backgroundColor_rebeccaPurple = h.MakeStyle("backgroundColor", "#663399")
    member _.backgroundColor_blueViolet = h.MakeStyle("backgroundColor", "#8A2BE2")
    member _.backgroundColor_darkViolet = h.MakeStyle("backgroundColor", "#9400D3")
    member _.backgroundColor_darkOrchid = h.MakeStyle("backgroundColor", "#9932CC")
    member _.backgroundColor_darkMagenta = h.MakeStyle("backgroundColor", "#8B008B")
    member _.backgroundColor_purple = h.MakeStyle("backgroundColor", "#800080")
    member _.backgroundColor_indigo = h.MakeStyle("backgroundColor", "#4B0082")
    member _.backgroundColor_slateBlue = h.MakeStyle("backgroundColor", "#6A5ACD")
    member _.backgroundColor_darkSlateBlue = h.MakeStyle("backgroundColor", "#483D8B")
    member _.backgroundColor_mediumSlateBlue = h.MakeStyle("backgroundColor", "#7B68EE")
    member _.backgroundColor_greenYellow = h.MakeStyle("backgroundColor", "#ADFF2F")
    member _.backgroundColor_chartreuse = h.MakeStyle("backgroundColor", "#7FFF00")
    member _.backgroundColor_lawnGreen = h.MakeStyle("backgroundColor", "#7CFC00")
    member _.backgroundColor_lime = h.MakeStyle("backgroundColor", "#00FF00")
    member _.backgroundColor_limeGreen = h.MakeStyle("backgroundColor", "#32CD32")
    member _.backgroundColor_paleGreen = h.MakeStyle("backgroundColor", "#98FB98")
    member _.backgroundColor_lightGreen = h.MakeStyle("backgroundColor", "#90EE90")
    member _.backgroundColor_mediumSpringGreen = h.MakeStyle("backgroundColor", "#00FA9A")
    member _.backgroundColor_springGreen = h.MakeStyle("backgroundColor", "#00FF7F")
    member _.backgroundColor_mediumSeaGreen = h.MakeStyle("backgroundColor", "#3CB371")
    member _.backgroundColor_seaGreen = h.MakeStyle("backgroundColor", "#2E8B57")
    member _.backgroundColor_forestGreen = h.MakeStyle("backgroundColor", "#228B22")
    member _.backgroundColor_green = h.MakeStyle("backgroundColor", "#008000")
    member _.backgroundColor_darkGreen = h.MakeStyle("backgroundColor", "#006400")
    member _.backgroundColor_yellowGreen = h.MakeStyle("backgroundColor", "#9ACD32")
    member _.backgroundColor_oliveDrab = h.MakeStyle("backgroundColor", "#6B8E23")
    member _.backgroundColor_olive = h.MakeStyle("backgroundColor", "#808000")
    member _.backgroundColor_darkOliveGreen = h.MakeStyle("backgroundColor", "#556B2F")
    member _.backgroundColor_mediumAquamarine = h.MakeStyle("backgroundColor", "#66CDAA")
    member _.backgroundColor_darkSeaGreen = h.MakeStyle("backgroundColor", "#8FBC8B")
    member _.backgroundColor_lightSeaGreen = h.MakeStyle("backgroundColor", "#20B2AA")
    member _.backgroundColor_darkCyan = h.MakeStyle("backgroundColor", "#008B8B")
    member _.backgroundColor_teal = h.MakeStyle("backgroundColor", "#008080")
    member _.backgroundColor_aqua = h.MakeStyle("backgroundColor", "#00FFFF")
    member _.backgroundColor_cyan = h.MakeStyle("backgroundColor", "#00FFFF")
    member _.backgroundColor_lightCyan = h.MakeStyle("backgroundColor", "#E0FFFF")
    member _.backgroundColor_paleTurqouise = h.MakeStyle("backgroundColor", "#AFEEEE")
    member _.backgroundColor_aquaMarine = h.MakeStyle("backgroundColor", "#7FFFD4")
    member _.backgroundColor_turqouise = h.MakeStyle("backgroundColor", "#AFEEEE")
    member _.backgroundColor_mediumTurqouise = h.MakeStyle("backgroundColor", "#48D1CC")
    member _.backgroundColor_darkTurqouise = h.MakeStyle("backgroundColor", "#00CED1")
    member _.backgroundColor_cadetBlue = h.MakeStyle("backgroundColor", "#5F9EA0")
    member _.backgroundColor_steelBlue = h.MakeStyle("backgroundColor", "#4682B4")
    member _.backgroundColor_lightSteelBlue = h.MakeStyle("backgroundColor", "#B0C4DE")
    member _.backgroundColor_powederBlue = h.MakeStyle("backgroundColor", "#B0E0E6")
    member _.backgroundColor_lightBlue = h.MakeStyle("backgroundColor", "#ADD8E6")
    member _.backgroundColor_skyBlue = h.MakeStyle("backgroundColor", "#87CEEB")
    member _.backgroundColor_lightSkyBlue = h.MakeStyle("backgroundColor", "#87CEFA")
    member _.backgroundColor_deepSkyBlue = h.MakeStyle("backgroundColor", "#00BFFF")
    member _.backgroundColor_dodgerBlue = h.MakeStyle("backgroundColor", "#1E90FF")
    member _.backgroundColor_cornFlowerBlue = h.MakeStyle("backgroundColor", "#6495ED")
    member _.backgroundColor_royalBlue = h.MakeStyle("backgroundColor", "#4169E1")
    member _.backgroundColor_blue = h.MakeStyle("backgroundColor", "#0000FF")
    member _.backgroundColor_mediumBlue = h.MakeStyle("backgroundColor", "#0000CD")
    member _.backgroundColor_darkBlue = h.MakeStyle("backgroundColor", "#00008B")
    member _.backgroundColor_navy = h.MakeStyle("backgroundColor", "#000080")
    member _.backgroundColor_midnightBlue = h.MakeStyle("backgroundColor", "#191970")
    member _.backgroundColor_cornSilk = h.MakeStyle("backgroundColor", "#FFF8DC")
    member _.backgroundColor_blanchedAlmond = h.MakeStyle("backgroundColor", "#FFEBCD")
    member _.backgroundColor_bisque = h.MakeStyle("backgroundColor", "#FFE4C4")
    member _.backgroundColor_navajoWhite = h.MakeStyle("backgroundColor", "#FFDEAD")
    member _.backgroundColor_wheat = h.MakeStyle("backgroundColor", "#F5DEB3")
    member _.backgroundColor_burlyWood = h.MakeStyle("backgroundColor", "#DEB887")
    member _.backgroundColor_tan = h.MakeStyle("backgroundColor", "#D2B48C")
    member _.backgroundColor_rosyBrown = h.MakeStyle("backgroundColor", "#BC8F8F")
    member _.backgroundColor_sandyBrown = h.MakeStyle("backgroundColor", "#F4A460")
    member _.backgroundColor_goldenRod = h.MakeStyle("backgroundColor", "#DAA520")
    member _.backgroundColor_darkGoldenRod = h.MakeStyle("backgroundColor", "#B8860B")
    member _.backgroundColor_peru = h.MakeStyle("backgroundColor", "#CD853F")
    member _.backgroundColor_chocolate = h.MakeStyle("backgroundColor", "#D2691E")
    member _.backgroundColor_saddleBrown = h.MakeStyle("backgroundColor", "#8B4513")
    member _.backgroundColor_sienna = h.MakeStyle("backgroundColor", "#A0522D")
    member _.backgroundColor_brown = h.MakeStyle("backgroundColor", "#A52A2A")
    member _.backgroundColor_maroon = h.MakeStyle("backgroundColor", "#A52A2A")
    member _.backgroundColor_white = h.MakeStyle("backgroundColor", "#FFFFFF")
    member _.backgroundColor_snow = h.MakeStyle("backgroundColor", "#FFFAFA")
    member _.backgroundColor_honeyDew = h.MakeStyle("backgroundColor", "#F0FFF0")
    member _.backgroundColor_mintCream = h.MakeStyle("backgroundColor", "#F5FFFA")
    member _.backgroundColor_azure = h.MakeStyle("backgroundColor", "#F0FFFF")
    member _.backgroundColor_aliceBlue = h.MakeStyle("backgroundColor", "#F0F8FF")
    member _.backgroundColor_ghostWhite = h.MakeStyle("backgroundColor", "#F8F8FF")
    member _.backgroundColor_whiteSmoke = h.MakeStyle("backgroundColor", "#F5F5F5")
    member _.backgroundColor_seaShell = h.MakeStyle("backgroundColor", "#FFF5EE")
    member _.backgroundColor_beige = h.MakeStyle("backgroundColor", "#F5F5DC")
    member _.backgroundColor_oldLace = h.MakeStyle("backgroundColor", "#FDF5E6")
    member _.backgroundColor_floralWhite = h.MakeStyle("backgroundColor", "#FFFAF0")
    member _.backgroundColor_ivory = h.MakeStyle("backgroundColor", "#FFFFF0")
    member _.backgroundColor_antiqueWhite = h.MakeStyle("backgroundColor", "#FAEBD7")
    member _.backgroundColor_linen = h.MakeStyle("backgroundColor", "#FAF0E6")
    member _.backgroundColor_lavenderBlush = h.MakeStyle("backgroundColor", "#FFF0F5")
    member _.backgroundColor_mistyRose = h.MakeStyle("backgroundColor", "#FFE4E1")
    member _.backgroundColor_gainsBoro = h.MakeStyle("backgroundColor", "#DCDCDC")
    member _.backgroundColor_lightGray = h.MakeStyle("backgroundColor", "#D3D3D3")
    member _.backgroundColor_silver = h.MakeStyle("backgroundColor", "#C0C0C0")
    member _.backgroundColor_darkGray = h.MakeStyle("backgroundColor", "#A9A9A9")
    member _.backgroundColor_gray = h.MakeStyle("backgroundColor", "#808080")
    member _.backgroundColor_dimGray = h.MakeStyle("backgroundColor", "#696969")
    member _.backgroundColor_lightSlateGray = h.MakeStyle("backgroundColor", "#778899")
    member _.backgroundColor_slateGray = h.MakeStyle("backgroundColor", "#708090")
    member _.backgroundColor_darkSlateGray = h.MakeStyle("backgroundColor", "#2F4F4F")
    member _.backgroundColor_black = h.MakeStyle("backgroundColor", "#000000")
    member _.backgroundColor_transparent = h.MakeStyle("backgroundColor", "transparent")

/// Sets the color of an element's border.
    member _.borderColor_indianRed = h.MakeStyle("borderColor", "#CD5C5C")
    member _.borderColor_lightCoral = h.MakeStyle("borderColor", "#F08080")
    member _.borderColor_salmon = h.MakeStyle("borderColor", "#FA8072")
    member _.borderColor_darkSalmon = h.MakeStyle("borderColor", "#E9967A")
    member _.borderColor_lightSalmon = h.MakeStyle("borderColor", "#FFA07A")
    member _.borderColor_crimson = h.MakeStyle("borderColor", "#DC143C")
    member _.borderColor_red = h.MakeStyle("borderColor", "#FF0000")
    member _.borderColor_fireBrick = h.MakeStyle("borderColor", "#B22222")
    member _.borderColor_darkred = h.MakeStyle("borderColor", "#8B0000")
    member _.borderColor_pink = h.MakeStyle("borderColor", "#FFC0CB")
    member _.borderColor_lightPink = h.MakeStyle("borderColor", "#FFB6C1")
    member _.borderColor_hotPink = h.MakeStyle("borderColor", "#FF69B4")
    member _.borderColor_deepPink = h.MakeStyle("borderColor", "#FF1493")
    member _.borderColor_mediumVioletRed = h.MakeStyle("borderColor", "#C71585")
    member _.borderColor_paleVioletRed = h.MakeStyle("borderColor", "#DB7093")
    member _.borderColor_coral = h.MakeStyle("borderColor", "#FF7F50")
    member _.borderColor_tomato = h.MakeStyle("borderColor", "#FF6347")
    member _.borderColor_orangeRed = h.MakeStyle("borderColor", "#FF4500")
    member _.borderColor_darkOrange = h.MakeStyle("borderColor", "#FF8C00")
    member _.borderColor_orange = h.MakeStyle("borderColor", "#FFA500")
    member _.borderColor_gold = h.MakeStyle("borderColor", "#FFD700")
    member _.borderColor_yellow = h.MakeStyle("borderColor", "#FFFF00")
    member _.borderColor_lightYellow = h.MakeStyle("borderColor", "#FFFFE0")
    member _.borderColor_limonChiffon = h.MakeStyle("borderColor", "#FFFACD")
    member _.borderColor_lightGoldenRodYellow = h.MakeStyle("borderColor", "#FAFAD2")
    member _.borderColor_papayaWhip = h.MakeStyle("borderColor", "#FFEFD5")
    member _.borderColor_moccasin = h.MakeStyle("borderColor", "#FFE4B5")
    member _.borderColor_peachPuff = h.MakeStyle("borderColor", "#FFDAB9")
    member _.borderColor_paleGoldenRod = h.MakeStyle("borderColor", "#EEE8AA")
    member _.borderColor_khaki = h.MakeStyle("borderColor", "#F0E68C")
    member _.borderColor_darkKhaki = h.MakeStyle("borderColor", "#BDB76B")
    member _.borderColor_lavender = h.MakeStyle("borderColor", "#E6E6FA")
    member _.borderColor_thistle = h.MakeStyle("borderColor", "#D8BFD8")
    member _.borderColor_plum = h.MakeStyle("borderColor", "#DDA0DD")
    member _.borderColor_violet = h.MakeStyle("borderColor", "#EE82EE")
    member _.borderColor_orchid = h.MakeStyle("borderColor", "#DA70D6")
    member _.borderColor_fuchsia = h.MakeStyle("borderColor", "#FF00FF")
    member _.borderColor_magenta = h.MakeStyle("borderColor", "#FF00FF")
    member _.borderColor_mediumOrchid = h.MakeStyle("borderColor", "#BA55D3")
    member _.borderColor_mediumPurple = h.MakeStyle("borderColor", "#9370DB")
    member _.borderColor_rebeccaPurple = h.MakeStyle("borderColor", "#663399")
    member _.borderColor_blueViolet = h.MakeStyle("borderColor", "#8A2BE2")
    member _.borderColor_darkViolet = h.MakeStyle("borderColor", "#9400D3")
    member _.borderColor_darkOrchid = h.MakeStyle("borderColor", "#9932CC")
    member _.borderColor_darkMagenta = h.MakeStyle("borderColor", "#8B008B")
    member _.borderColor_purple = h.MakeStyle("borderColor", "#800080")
    member _.borderColor_indigo = h.MakeStyle("borderColor", "#4B0082")
    member _.borderColor_slateBlue = h.MakeStyle("borderColor", "#6A5ACD")
    member _.borderColor_darkSlateBlue = h.MakeStyle("borderColor", "#483D8B")
    member _.borderColor_mediumSlateBlue = h.MakeStyle("borderColor", "#7B68EE")
    member _.borderColor_greenYellow = h.MakeStyle("borderColor", "#ADFF2F")
    member _.borderColor_chartreuse = h.MakeStyle("borderColor", "#7FFF00")
    member _.borderColor_lawnGreen = h.MakeStyle("borderColor", "#7CFC00")
    member _.borderColor_lime = h.MakeStyle("borderColor", "#00FF00")
    member _.borderColor_limeGreen = h.MakeStyle("borderColor", "#32CD32")
    member _.borderColor_paleGreen = h.MakeStyle("borderColor", "#98FB98")
    member _.borderColor_lightGreen = h.MakeStyle("borderColor", "#90EE90")
    member _.borderColor_mediumSpringGreen = h.MakeStyle("borderColor", "#00FA9A")
    member _.borderColor_springGreen = h.MakeStyle("borderColor", "#00FF7F")
    member _.borderColor_mediumSeaGreen = h.MakeStyle("borderColor", "#3CB371")
    member _.borderColor_seaGreen = h.MakeStyle("borderColor", "#2E8B57")
    member _.borderColor_forestGreen = h.MakeStyle("borderColor", "#228B22")
    member _.borderColor_green = h.MakeStyle("borderColor", "#008000")
    member _.borderColor_darkGreen = h.MakeStyle("borderColor", "#006400")
    member _.borderColor_yellowGreen = h.MakeStyle("borderColor", "#9ACD32")
    member _.borderColor_oliveDrab = h.MakeStyle("borderColor", "#6B8E23")
    member _.borderColor_olive = h.MakeStyle("borderColor", "#808000")
    member _.borderColor_darkOliveGreen = h.MakeStyle("borderColor", "#556B2F")
    member _.borderColor_mediumAquamarine = h.MakeStyle("borderColor", "#66CDAA")
    member _.borderColor_darkSeaGreen = h.MakeStyle("borderColor", "#8FBC8B")
    member _.borderColor_lightSeaGreen = h.MakeStyle("borderColor", "#20B2AA")
    member _.borderColor_darkCyan = h.MakeStyle("borderColor", "#008B8B")
    member _.borderColor_teal = h.MakeStyle("borderColor", "#008080")
    member _.borderColor_aqua = h.MakeStyle("borderColor", "#00FFFF")
    member _.borderColor_cyan = h.MakeStyle("borderColor", "#00FFFF")
    member _.borderColor_lightCyan = h.MakeStyle("borderColor", "#E0FFFF")
    member _.borderColor_paleTurqouise = h.MakeStyle("borderColor", "#AFEEEE")
    member _.borderColor_aquaMarine = h.MakeStyle("borderColor", "#7FFFD4")
    member _.borderColor_turqouise = h.MakeStyle("borderColor", "#AFEEEE")
    member _.borderColor_mediumTurqouise = h.MakeStyle("borderColor", "#48D1CC")
    member _.borderColor_darkTurqouise = h.MakeStyle("borderColor", "#00CED1")
    member _.borderColor_cadetBlue = h.MakeStyle("borderColor", "#5F9EA0")
    member _.borderColor_steelBlue = h.MakeStyle("borderColor", "#4682B4")
    member _.borderColor_lightSteelBlue = h.MakeStyle("borderColor", "#B0C4DE")
    member _.borderColor_powederBlue = h.MakeStyle("borderColor", "#B0E0E6")
    member _.borderColor_lightBlue = h.MakeStyle("borderColor", "#ADD8E6")
    member _.borderColor_skyBlue = h.MakeStyle("borderColor", "#87CEEB")
    member _.borderColor_lightSkyBlue = h.MakeStyle("borderColor", "#87CEFA")
    member _.borderColor_deepSkyBlue = h.MakeStyle("borderColor", "#00BFFF")
    member _.borderColor_dodgerBlue = h.MakeStyle("borderColor", "#1E90FF")
    member _.borderColor_cornFlowerBlue = h.MakeStyle("borderColor", "#6495ED")
    member _.borderColor_royalBlue = h.MakeStyle("borderColor", "#4169E1")
    member _.borderColor_blue = h.MakeStyle("borderColor", "#0000FF")
    member _.borderColor_mediumBlue = h.MakeStyle("borderColor", "#0000CD")
    member _.borderColor_darkBlue = h.MakeStyle("borderColor", "#00008B")
    member _.borderColor_navy = h.MakeStyle("borderColor", "#000080")
    member _.borderColor_midnightBlue = h.MakeStyle("borderColor", "#191970")
    member _.borderColor_cornSilk = h.MakeStyle("borderColor", "#FFF8DC")
    member _.borderColor_blanchedAlmond = h.MakeStyle("borderColor", "#FFEBCD")
    member _.borderColor_bisque = h.MakeStyle("borderColor", "#FFE4C4")
    member _.borderColor_navajoWhite = h.MakeStyle("borderColor", "#FFDEAD")
    member _.borderColor_wheat = h.MakeStyle("borderColor", "#F5DEB3")
    member _.borderColor_burlyWood = h.MakeStyle("borderColor", "#DEB887")
    member _.borderColor_tan = h.MakeStyle("borderColor", "#D2B48C")
    member _.borderColor_rosyBrown = h.MakeStyle("borderColor", "#BC8F8F")
    member _.borderColor_sandyBrown = h.MakeStyle("borderColor", "#F4A460")
    member _.borderColor_goldenRod = h.MakeStyle("borderColor", "#DAA520")
    member _.borderColor_darkGoldenRod = h.MakeStyle("borderColor", "#B8860B")
    member _.borderColor_peru = h.MakeStyle("borderColor", "#CD853F")
    member _.borderColor_chocolate = h.MakeStyle("borderColor", "#D2691E")
    member _.borderColor_saddleBrown = h.MakeStyle("borderColor", "#8B4513")
    member _.borderColor_sienna = h.MakeStyle("borderColor", "#A0522D")
    member _.borderColor_brown = h.MakeStyle("borderColor", "#A52A2A")
    member _.borderColor_maroon = h.MakeStyle("borderColor", "#A52A2A")
    member _.borderColor_white = h.MakeStyle("borderColor", "#FFFFFF")
    member _.borderColor_snow = h.MakeStyle("borderColor", "#FFFAFA")
    member _.borderColor_honeyDew = h.MakeStyle("borderColor", "#F0FFF0")
    member _.borderColor_mintCream = h.MakeStyle("borderColor", "#F5FFFA")
    member _.borderColor_azure = h.MakeStyle("borderColor", "#F0FFFF")
    member _.borderColor_aliceBlue = h.MakeStyle("borderColor", "#F0F8FF")
    member _.borderColor_ghostWhite = h.MakeStyle("borderColor", "#F8F8FF")
    member _.borderColor_whiteSmoke = h.MakeStyle("borderColor", "#F5F5F5")
    member _.borderColor_seaShell = h.MakeStyle("borderColor", "#FFF5EE")
    member _.borderColor_beige = h.MakeStyle("borderColor", "#F5F5DC")
    member _.borderColor_oldLace = h.MakeStyle("borderColor", "#FDF5E6")
    member _.borderColor_floralWhite = h.MakeStyle("borderColor", "#FFFAF0")
    member _.borderColor_ivory = h.MakeStyle("borderColor", "#FFFFF0")
    member _.borderColor_antiqueWhite = h.MakeStyle("borderColor", "#FAEBD7")
    member _.borderColor_linen = h.MakeStyle("borderColor", "#FAF0E6")
    member _.borderColor_lavenderBlush = h.MakeStyle("borderColor", "#FFF0F5")
    member _.borderColor_mistyRose = h.MakeStyle("borderColor", "#FFE4E1")
    member _.borderColor_gainsBoro = h.MakeStyle("borderColor", "#DCDCDC")
    member _.borderColor_lightGray = h.MakeStyle("borderColor", "#D3D3D3")
    member _.borderColor_silver = h.MakeStyle("borderColor", "#C0C0C0")
    member _.borderColor_darkGray = h.MakeStyle("borderColor", "#A9A9A9")
    member _.borderColor_gray = h.MakeStyle("borderColor", "#808080")
    member _.borderColor_dimGray = h.MakeStyle("borderColor", "#696969")
    member _.borderColor_lightSlateGray = h.MakeStyle("borderColor", "#778899")
    member _.borderColor_slateGray = h.MakeStyle("borderColor", "#708090")
    member _.borderColor_darkSlateGray = h.MakeStyle("borderColor", "#2F4F4F")
    member _.borderColor_black = h.MakeStyle("borderColor", "#000000")
    member _.borderColor_transparent = h.MakeStyle("borderColor", "transparent")

/// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
///
/// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
/// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
/// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    /// The user agent selects an appropriate color for the caret.
    ///
    /// This is generally currentcolor, but the user agent may choose a different color to ensure good
    /// visibility and contrast with the surrounding content, taking into account the value of currentcolor,
    /// the background, shadows, and other factors.
    member _.caretColor_auto = h.MakeStyle("caretColor", "auto")
    member _.caretColor_indianRed = h.MakeStyle("caretColor", "#CD5C5C")
    member _.caretColor_lightCoral = h.MakeStyle("caretColor", "#F08080")
    member _.caretColor_salmon = h.MakeStyle("caretColor", "#FA8072")
    member _.caretColor_darkSalmon = h.MakeStyle("caretColor", "#E9967A")
    member _.caretColor_lightSalmon = h.MakeStyle("caretColor", "#FFA07A")
    member _.caretColor_crimson = h.MakeStyle("caretColor", "#DC143C")
    member _.caretColor_red = h.MakeStyle("caretColor", "#FF0000")
    member _.caretColor_fireBrick = h.MakeStyle("caretColor", "#B22222")
    member _.caretColor_darkred = h.MakeStyle("caretColor", "#8B0000")
    member _.caretColor_pink = h.MakeStyle("caretColor", "#FFC0CB")
    member _.caretColor_lightPink = h.MakeStyle("caretColor", "#FFB6C1")
    member _.caretColor_hotPink = h.MakeStyle("caretColor", "#FF69B4")
    member _.caretColor_deepPink = h.MakeStyle("caretColor", "#FF1493")
    member _.caretColor_mediumVioletRed = h.MakeStyle("caretColor", "#C71585")
    member _.caretColor_paleVioletRed = h.MakeStyle("caretColor", "#DB7093")
    member _.caretColor_coral = h.MakeStyle("caretColor", "#FF7F50")
    member _.caretColor_tomato = h.MakeStyle("caretColor", "#FF6347")
    member _.caretColor_orangeRed = h.MakeStyle("caretColor", "#FF4500")
    member _.caretColor_darkOrange = h.MakeStyle("caretColor", "#FF8C00")
    member _.caretColor_orange = h.MakeStyle("caretColor", "#FFA500")
    member _.caretColor_gold = h.MakeStyle("caretColor", "#FFD700")
    member _.caretColor_yellow = h.MakeStyle("caretColor", "#FFFF00")
    member _.caretColor_lightYellow = h.MakeStyle("caretColor", "#FFFFE0")
    member _.caretColor_limonChiffon = h.MakeStyle("caretColor", "#FFFACD")
    member _.caretColor_lightGoldenRodYellow = h.MakeStyle("caretColor", "#FAFAD2")
    member _.caretColor_papayaWhip = h.MakeStyle("caretColor", "#FFEFD5")
    member _.caretColor_moccasin = h.MakeStyle("caretColor", "#FFE4B5")
    member _.caretColor_peachPuff = h.MakeStyle("caretColor", "#FFDAB9")
    member _.caretColor_paleGoldenRod = h.MakeStyle("caretColor", "#EEE8AA")
    member _.caretColor_khaki = h.MakeStyle("caretColor", "#F0E68C")
    member _.caretColor_darkKhaki = h.MakeStyle("caretColor", "#BDB76B")
    member _.caretColor_lavender = h.MakeStyle("caretColor", "#E6E6FA")
    member _.caretColor_thistle = h.MakeStyle("caretColor", "#D8BFD8")
    member _.caretColor_plum = h.MakeStyle("caretColor", "#DDA0DD")
    member _.caretColor_violet = h.MakeStyle("caretColor", "#EE82EE")
    member _.caretColor_orchid = h.MakeStyle("caretColor", "#DA70D6")
    member _.caretColor_fuchsia = h.MakeStyle("caretColor", "#FF00FF")
    member _.caretColor_magenta = h.MakeStyle("caretColor", "#FF00FF")
    member _.caretColor_mediumOrchid = h.MakeStyle("caretColor", "#BA55D3")
    member _.caretColor_mediumPurple = h.MakeStyle("caretColor", "#9370DB")
    member _.caretColor_rebeccaPurple = h.MakeStyle("caretColor", "#663399")
    member _.caretColor_blueViolet = h.MakeStyle("caretColor", "#8A2BE2")
    member _.caretColor_darkViolet = h.MakeStyle("caretColor", "#9400D3")
    member _.caretColor_darkOrchid = h.MakeStyle("caretColor", "#9932CC")
    member _.caretColor_darkMagenta = h.MakeStyle("caretColor", "#8B008B")
    member _.caretColor_purple = h.MakeStyle("caretColor", "#800080")
    member _.caretColor_indigo = h.MakeStyle("caretColor", "#4B0082")
    member _.caretColor_slateBlue = h.MakeStyle("caretColor", "#6A5ACD")
    member _.caretColor_darkSlateBlue = h.MakeStyle("caretColor", "#483D8B")
    member _.caretColor_mediumSlateBlue = h.MakeStyle("caretColor", "#7B68EE")
    member _.caretColor_greenYellow = h.MakeStyle("caretColor", "#ADFF2F")
    member _.caretColor_chartreuse = h.MakeStyle("caretColor", "#7FFF00")
    member _.caretColor_lawnGreen = h.MakeStyle("caretColor", "#7CFC00")
    member _.caretColor_lime = h.MakeStyle("caretColor", "#00FF00")
    member _.caretColor_limeGreen = h.MakeStyle("caretColor", "#32CD32")
    member _.caretColor_paleGreen = h.MakeStyle("caretColor", "#98FB98")
    member _.caretColor_lightGreen = h.MakeStyle("caretColor", "#90EE90")
    member _.caretColor_mediumSpringGreen = h.MakeStyle("caretColor", "#00FA9A")
    member _.caretColor_springGreen = h.MakeStyle("caretColor", "#00FF7F")
    member _.caretColor_mediumSeaGreen = h.MakeStyle("caretColor", "#3CB371")
    member _.caretColor_seaGreen = h.MakeStyle("caretColor", "#2E8B57")
    member _.caretColor_forestGreen = h.MakeStyle("caretColor", "#228B22")
    member _.caretColor_green = h.MakeStyle("caretColor", "#008000")
    member _.caretColor_darkGreen = h.MakeStyle("caretColor", "#006400")
    member _.caretColor_yellowGreen = h.MakeStyle("caretColor", "#9ACD32")
    member _.caretColor_oliveDrab = h.MakeStyle("caretColor", "#6B8E23")
    member _.caretColor_olive = h.MakeStyle("caretColor", "#808000")
    member _.caretColor_darkOliveGreen = h.MakeStyle("caretColor", "#556B2F")
    member _.caretColor_mediumAquamarine = h.MakeStyle("caretColor", "#66CDAA")
    member _.caretColor_darkSeaGreen = h.MakeStyle("caretColor", "#8FBC8B")
    member _.caretColor_lightSeaGreen = h.MakeStyle("caretColor", "#20B2AA")
    member _.caretColor_darkCyan = h.MakeStyle("caretColor", "#008B8B")
    member _.caretColor_teal = h.MakeStyle("caretColor", "#008080")
    member _.caretColor_aqua = h.MakeStyle("caretColor", "#00FFFF")
    member _.caretColor_cyan = h.MakeStyle("caretColor", "#00FFFF")
    member _.caretColor_lightCyan = h.MakeStyle("caretColor", "#E0FFFF")
    member _.caretColor_paleTurqouise = h.MakeStyle("caretColor", "#AFEEEE")
    member _.caretColor_aquaMarine = h.MakeStyle("caretColor", "#7FFFD4")
    member _.caretColor_turqouise = h.MakeStyle("caretColor", "#AFEEEE")
    member _.caretColor_mediumTurqouise = h.MakeStyle("caretColor", "#48D1CC")
    member _.caretColor_darkTurqouise = h.MakeStyle("caretColor", "#00CED1")
    member _.caretColor_cadetBlue = h.MakeStyle("caretColor", "#5F9EA0")
    member _.caretColor_steelBlue = h.MakeStyle("caretColor", "#4682B4")
    member _.caretColor_lightSteelBlue = h.MakeStyle("caretColor", "#B0C4DE")
    member _.caretColor_powederBlue = h.MakeStyle("caretColor", "#B0E0E6")
    member _.caretColor_lightBlue = h.MakeStyle("caretColor", "#ADD8E6")
    member _.caretColor_skyBlue = h.MakeStyle("caretColor", "#87CEEB")
    member _.caretColor_lightSkyBlue = h.MakeStyle("caretColor", "#87CEFA")
    member _.caretColor_deepSkyBlue = h.MakeStyle("caretColor", "#00BFFF")
    member _.caretColor_dodgerBlue = h.MakeStyle("caretColor", "#1E90FF")
    member _.caretColor_cornFlowerBlue = h.MakeStyle("caretColor", "#6495ED")
    member _.caretColor_royalBlue = h.MakeStyle("caretColor", "#4169E1")
    member _.caretColor_blue = h.MakeStyle("caretColor", "#0000FF")
    member _.caretColor_mediumBlue = h.MakeStyle("caretColor", "#0000CD")
    member _.caretColor_darkBlue = h.MakeStyle("caretColor", "#00008B")
    member _.caretColor_navy = h.MakeStyle("caretColor", "#000080")
    member _.caretColor_midnightBlue = h.MakeStyle("caretColor", "#191970")
    member _.caretColor_cornSilk = h.MakeStyle("caretColor", "#FFF8DC")
    member _.caretColor_blanchedAlmond = h.MakeStyle("caretColor", "#FFEBCD")
    member _.caretColor_bisque = h.MakeStyle("caretColor", "#FFE4C4")
    member _.caretColor_navajoWhite = h.MakeStyle("caretColor", "#FFDEAD")
    member _.caretColor_wheat = h.MakeStyle("caretColor", "#F5DEB3")
    member _.caretColor_burlyWood = h.MakeStyle("caretColor", "#DEB887")
    member _.caretColor_tan = h.MakeStyle("caretColor", "#D2B48C")
    member _.caretColor_rosyBrown = h.MakeStyle("caretColor", "#BC8F8F")
    member _.caretColor_sandyBrown = h.MakeStyle("caretColor", "#F4A460")
    member _.caretColor_goldenRod = h.MakeStyle("caretColor", "#DAA520")
    member _.caretColor_darkGoldenRod = h.MakeStyle("caretColor", "#B8860B")
    member _.caretColor_peru = h.MakeStyle("caretColor", "#CD853F")
    member _.caretColor_chocolate = h.MakeStyle("caretColor", "#D2691E")
    member _.caretColor_saddleBrown = h.MakeStyle("caretColor", "#8B4513")
    member _.caretColor_sienna = h.MakeStyle("caretColor", "#A0522D")
    member _.caretColor_brown = h.MakeStyle("caretColor", "#A52A2A")
    member _.caretColor_maroon = h.MakeStyle("caretColor", "#A52A2A")
    member _.caretColor_white = h.MakeStyle("caretColor", "#FFFFFF")
    member _.caretColor_snow = h.MakeStyle("caretColor", "#FFFAFA")
    member _.caretColor_honeyDew = h.MakeStyle("caretColor", "#F0FFF0")
    member _.caretColor_mintCream = h.MakeStyle("caretColor", "#F5FFFA")
    member _.caretColor_azure = h.MakeStyle("caretColor", "#F0FFFF")
    member _.caretColor_aliceBlue = h.MakeStyle("caretColor", "#F0F8FF")
    member _.caretColor_ghostWhite = h.MakeStyle("caretColor", "#F8F8FF")
    member _.caretColor_whiteSmoke = h.MakeStyle("caretColor", "#F5F5F5")
    member _.caretColor_seaShell = h.MakeStyle("caretColor", "#FFF5EE")
    member _.caretColor_beige = h.MakeStyle("caretColor", "#F5F5DC")
    member _.caretColor_oldLace = h.MakeStyle("caretColor", "#FDF5E6")
    member _.caretColor_floralWhite = h.MakeStyle("caretColor", "#FFFAF0")
    member _.caretColor_ivory = h.MakeStyle("caretColor", "#FFFFF0")
    member _.caretColor_antiqueWhite = h.MakeStyle("caretColor", "#FAEBD7")
    member _.caretColor_linen = h.MakeStyle("caretColor", "#FAF0E6")
    member _.caretColor_lavenderBlush = h.MakeStyle("caretColor", "#FFF0F5")
    member _.caretColor_mistyRose = h.MakeStyle("caretColor", "#FFE4E1")
    member _.caretColor_gainsBoro = h.MakeStyle("caretColor", "#DCDCDC")
    member _.caretColor_lightGray = h.MakeStyle("caretColor", "#D3D3D3")
    member _.caretColor_silver = h.MakeStyle("caretColor", "#C0C0C0")
    member _.caretColor_darkGray = h.MakeStyle("caretColor", "#A9A9A9")
    member _.caretColor_gray = h.MakeStyle("caretColor", "#808080")
    member _.caretColor_dimGray = h.MakeStyle("caretColor", "#696969")
    member _.caretColor_lightSlateGray = h.MakeStyle("caretColor", "#778899")
    member _.caretColor_slateGray = h.MakeStyle("caretColor", "#708090")
    member _.caretColor_darkSlateGray = h.MakeStyle("caretColor", "#2F4F4F")
    member _.caretColor_black = h.MakeStyle("caretColor", "#000000")
    member _.caretColor_transparent = h.MakeStyle("caretColor", "transparent")

/// Sets the foreground color value of an element's text and text decorations, and sets the
/// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
/// and is the default for other color properties, such as border-color.
    member _.color_indianRed = h.MakeStyle("color", "#CD5C5C")
    member _.color_lightCoral = h.MakeStyle("color", "#F08080")
    member _.color_salmon = h.MakeStyle("color", "#FA8072")
    member _.color_darkSalmon = h.MakeStyle("color", "#E9967A")
    member _.color_lightSalmon = h.MakeStyle("color", "#FFA07A")
    member _.color_crimson = h.MakeStyle("color", "#DC143C")
    member _.color_red = h.MakeStyle("color", "#FF0000")
    member _.color_fireBrick = h.MakeStyle("color", "#B22222")
    member _.color_darkred = h.MakeStyle("color", "#8B0000")
    member _.color_pink = h.MakeStyle("color", "#FFC0CB")
    member _.color_lightPink = h.MakeStyle("color", "#FFB6C1")
    member _.color_hotPink = h.MakeStyle("color", "#FF69B4")
    member _.color_deepPink = h.MakeStyle("color", "#FF1493")
    member _.color_mediumVioletRed = h.MakeStyle("color", "#C71585")
    member _.color_paleVioletRed = h.MakeStyle("color", "#DB7093")
    member _.color_coral = h.MakeStyle("color", "#FF7F50")
    member _.color_tomato = h.MakeStyle("color", "#FF6347")
    member _.color_orangeRed = h.MakeStyle("color", "#FF4500")
    member _.color_darkOrange = h.MakeStyle("color", "#FF8C00")
    member _.color_orange = h.MakeStyle("color", "#FFA500")
    member _.color_gold = h.MakeStyle("color", "#FFD700")
    member _.color_yellow = h.MakeStyle("color", "#FFFF00")
    member _.color_lightYellow = h.MakeStyle("color", "#FFFFE0")
    member _.color_limonChiffon = h.MakeStyle("color", "#FFFACD")
    member _.color_lightGoldenRodYellow = h.MakeStyle("color", "#FAFAD2")
    member _.color_papayaWhip = h.MakeStyle("color", "#FFEFD5")
    member _.color_moccasin = h.MakeStyle("color", "#FFE4B5")
    member _.color_peachPuff = h.MakeStyle("color", "#FFDAB9")
    member _.color_paleGoldenRod = h.MakeStyle("color", "#EEE8AA")
    member _.color_khaki = h.MakeStyle("color", "#F0E68C")
    member _.color_darkKhaki = h.MakeStyle("color", "#BDB76B")
    member _.color_lavender = h.MakeStyle("color", "#E6E6FA")
    member _.color_thistle = h.MakeStyle("color", "#D8BFD8")
    member _.color_plum = h.MakeStyle("color", "#DDA0DD")
    member _.color_violet = h.MakeStyle("color", "#EE82EE")
    member _.color_orchid = h.MakeStyle("color", "#DA70D6")
    member _.color_fuchsia = h.MakeStyle("color", "#FF00FF")
    member _.color_magenta = h.MakeStyle("color", "#FF00FF")
    member _.color_mediumOrchid = h.MakeStyle("color", "#BA55D3")
    member _.color_mediumPurple = h.MakeStyle("color", "#9370DB")
    member _.color_rebeccaPurple = h.MakeStyle("color", "#663399")
    member _.color_blueViolet = h.MakeStyle("color", "#8A2BE2")
    member _.color_darkViolet = h.MakeStyle("color", "#9400D3")
    member _.color_darkOrchid = h.MakeStyle("color", "#9932CC")
    member _.color_darkMagenta = h.MakeStyle("color", "#8B008B")
    member _.color_purple = h.MakeStyle("color", "#800080")
    member _.color_indigo = h.MakeStyle("color", "#4B0082")
    member _.color_slateBlue = h.MakeStyle("color", "#6A5ACD")
    member _.color_darkSlateBlue = h.MakeStyle("color", "#483D8B")
    member _.color_mediumSlateBlue = h.MakeStyle("color", "#7B68EE")
    member _.color_greenYellow = h.MakeStyle("color", "#ADFF2F")
    member _.color_chartreuse = h.MakeStyle("color", "#7FFF00")
    member _.color_lawnGreen = h.MakeStyle("color", "#7CFC00")
    member _.color_lime = h.MakeStyle("color", "#00FF00")
    member _.color_limeGreen = h.MakeStyle("color", "#32CD32")
    member _.color_paleGreen = h.MakeStyle("color", "#98FB98")
    member _.color_lightGreen = h.MakeStyle("color", "#90EE90")
    member _.color_mediumSpringGreen = h.MakeStyle("color", "#00FA9A")
    member _.color_springGreen = h.MakeStyle("color", "#00FF7F")
    member _.color_mediumSeaGreen = h.MakeStyle("color", "#3CB371")
    member _.color_seaGreen = h.MakeStyle("color", "#2E8B57")
    member _.color_forestGreen = h.MakeStyle("color", "#228B22")
    member _.color_green = h.MakeStyle("color", "#008000")
    member _.color_darkGreen = h.MakeStyle("color", "#006400")
    member _.color_yellowGreen = h.MakeStyle("color", "#9ACD32")
    member _.color_oliveDrab = h.MakeStyle("color", "#6B8E23")
    member _.color_olive = h.MakeStyle("color", "#808000")
    member _.color_darkOliveGreen = h.MakeStyle("color", "#556B2F")
    member _.color_mediumAquamarine = h.MakeStyle("color", "#66CDAA")
    member _.color_darkSeaGreen = h.MakeStyle("color", "#8FBC8B")
    member _.color_lightSeaGreen = h.MakeStyle("color", "#20B2AA")
    member _.color_darkCyan = h.MakeStyle("color", "#008B8B")
    member _.color_teal = h.MakeStyle("color", "#008080")
    member _.color_aqua = h.MakeStyle("color", "#00FFFF")
    member _.color_cyan = h.MakeStyle("color", "#00FFFF")
    member _.color_lightCyan = h.MakeStyle("color", "#E0FFFF")
    member _.color_paleTurqouise = h.MakeStyle("color", "#AFEEEE")
    member _.color_aquaMarine = h.MakeStyle("color", "#7FFFD4")
    member _.color_turqouise = h.MakeStyle("color", "#AFEEEE")
    member _.color_mediumTurqouise = h.MakeStyle("color", "#48D1CC")
    member _.color_darkTurqouise = h.MakeStyle("color", "#00CED1")
    member _.color_cadetBlue = h.MakeStyle("color", "#5F9EA0")
    member _.color_steelBlue = h.MakeStyle("color", "#4682B4")
    member _.color_lightSteelBlue = h.MakeStyle("color", "#B0C4DE")
    member _.color_powederBlue = h.MakeStyle("color", "#B0E0E6")
    member _.color_lightBlue = h.MakeStyle("color", "#ADD8E6")
    member _.color_skyBlue = h.MakeStyle("color", "#87CEEB")
    member _.color_lightSkyBlue = h.MakeStyle("color", "#87CEFA")
    member _.color_deepSkyBlue = h.MakeStyle("color", "#00BFFF")
    member _.color_dodgerBlue = h.MakeStyle("color", "#1E90FF")
    member _.color_cornFlowerBlue = h.MakeStyle("color", "#6495ED")
    member _.color_royalBlue = h.MakeStyle("color", "#4169E1")
    member _.color_blue = h.MakeStyle("color", "#0000FF")
    member _.color_mediumBlue = h.MakeStyle("color", "#0000CD")
    member _.color_darkBlue = h.MakeStyle("color", "#00008B")
    member _.color_navy = h.MakeStyle("color", "#000080")
    member _.color_midnightBlue = h.MakeStyle("color", "#191970")
    member _.color_cornSilk = h.MakeStyle("color", "#FFF8DC")
    member _.color_blanchedAlmond = h.MakeStyle("color", "#FFEBCD")
    member _.color_bisque = h.MakeStyle("color", "#FFE4C4")
    member _.color_navajoWhite = h.MakeStyle("color", "#FFDEAD")
    member _.color_wheat = h.MakeStyle("color", "#F5DEB3")
    member _.color_burlyWood = h.MakeStyle("color", "#DEB887")
    member _.color_tan = h.MakeStyle("color", "#D2B48C")
    member _.color_rosyBrown = h.MakeStyle("color", "#BC8F8F")
    member _.color_sandyBrown = h.MakeStyle("color", "#F4A460")
    member _.color_goldenRod = h.MakeStyle("color", "#DAA520")
    member _.color_darkGoldenRod = h.MakeStyle("color", "#B8860B")
    member _.color_peru = h.MakeStyle("color", "#CD853F")
    member _.color_chocolate = h.MakeStyle("color", "#D2691E")
    member _.color_saddleBrown = h.MakeStyle("color", "#8B4513")
    member _.color_sienna = h.MakeStyle("color", "#A0522D")
    member _.color_brown = h.MakeStyle("color", "#A52A2A")
    member _.color_maroon = h.MakeStyle("color", "#A52A2A")
    member _.color_white = h.MakeStyle("color", "#FFFFFF")
    member _.color_snow = h.MakeStyle("color", "#FFFAFA")
    member _.color_honeyDew = h.MakeStyle("color", "#F0FFF0")
    member _.color_mintCream = h.MakeStyle("color", "#F5FFFA")
    member _.color_azure = h.MakeStyle("color", "#F0FFFF")
    member _.color_aliceBlue = h.MakeStyle("color", "#F0F8FF")
    member _.color_ghostWhite = h.MakeStyle("color", "#F8F8FF")
    member _.color_whiteSmoke = h.MakeStyle("color", "#F5F5F5")
    member _.color_seaShell = h.MakeStyle("color", "#FFF5EE")
    member _.color_beige = h.MakeStyle("color", "#F5F5DC")
    member _.color_oldLace = h.MakeStyle("color", "#FDF5E6")
    member _.color_floralWhite = h.MakeStyle("color", "#FFFAF0")
    member _.color_ivory = h.MakeStyle("color", "#FFFFF0")
    member _.color_antiqueWhite = h.MakeStyle("color", "#FAEBD7")
    member _.color_linen = h.MakeStyle("color", "#FAF0E6")
    member _.color_lavenderBlush = h.MakeStyle("color", "#FFF0F5")
    member _.color_mistyRose = h.MakeStyle("color", "#FFE4E1")
    member _.color_gainsBoro = h.MakeStyle("color", "#DCDCDC")
    member _.color_lightGray = h.MakeStyle("color", "#D3D3D3")
    member _.color_silver = h.MakeStyle("color", "#C0C0C0")
    member _.color_darkGray = h.MakeStyle("color", "#A9A9A9")
    member _.color_gray = h.MakeStyle("color", "#808080")
    member _.color_dimGray = h.MakeStyle("color", "#696969")
    member _.color_lightSlateGray = h.MakeStyle("color", "#778899")
    member _.color_slateGray = h.MakeStyle("color", "#708090")
    member _.color_darkSlateGray = h.MakeStyle("color", "#2F4F4F")
    member _.color_black = h.MakeStyle("color", "#000000")
    member _.color_transparent = h.MakeStyle("color", "transparent")

/// Sets the color of decorations added to text by text-decoration-line.
    member _.textDecorationColor_indianRed = h.MakeStyle("textDecorationColor", "#CD5C5C")
    member _.textDecorationColor_lightCoral = h.MakeStyle("textDecorationColor", "#F08080")
    member _.textDecorationColor_salmon = h.MakeStyle("textDecorationColor", "#FA8072")
    member _.textDecorationColor_darkSalmon = h.MakeStyle("textDecorationColor", "#E9967A")
    member _.textDecorationColor_lightSalmon = h.MakeStyle("textDecorationColor", "#FFA07A")
    member _.textDecorationColor_crimson = h.MakeStyle("textDecorationColor", "#DC143C")
    member _.textDecorationColor_red = h.MakeStyle("textDecorationColor", "#FF0000")
    member _.textDecorationColor_fireBrick = h.MakeStyle("textDecorationColor", "#B22222")
    member _.textDecorationColor_darkred = h.MakeStyle("textDecorationColor", "#8B0000")
    member _.textDecorationColor_pink = h.MakeStyle("textDecorationColor", "#FFC0CB")
    member _.textDecorationColor_lightPink = h.MakeStyle("textDecorationColor", "#FFB6C1")
    member _.textDecorationColor_hotPink = h.MakeStyle("textDecorationColor", "#FF69B4")
    member _.textDecorationColor_deepPink = h.MakeStyle("textDecorationColor", "#FF1493")
    member _.textDecorationColor_mediumVioletRed = h.MakeStyle("textDecorationColor", "#C71585")
    member _.textDecorationColor_paleVioletRed = h.MakeStyle("textDecorationColor", "#DB7093")
    member _.textDecorationColor_coral = h.MakeStyle("textDecorationColor", "#FF7F50")
    member _.textDecorationColor_tomato = h.MakeStyle("textDecorationColor", "#FF6347")
    member _.textDecorationColor_orangeRed = h.MakeStyle("textDecorationColor", "#FF4500")
    member _.textDecorationColor_darkOrange = h.MakeStyle("textDecorationColor", "#FF8C00")
    member _.textDecorationColor_orange = h.MakeStyle("textDecorationColor", "#FFA500")
    member _.textDecorationColor_gold = h.MakeStyle("textDecorationColor", "#FFD700")
    member _.textDecorationColor_yellow = h.MakeStyle("textDecorationColor", "#FFFF00")
    member _.textDecorationColor_lightYellow = h.MakeStyle("textDecorationColor", "#FFFFE0")
    member _.textDecorationColor_limonChiffon = h.MakeStyle("textDecorationColor", "#FFFACD")
    member _.textDecorationColor_lightGoldenRodYellow = h.MakeStyle("textDecorationColor", "#FAFAD2")
    member _.textDecorationColor_papayaWhip = h.MakeStyle("textDecorationColor", "#FFEFD5")
    member _.textDecorationColor_moccasin = h.MakeStyle("textDecorationColor", "#FFE4B5")
    member _.textDecorationColor_peachPuff = h.MakeStyle("textDecorationColor", "#FFDAB9")
    member _.textDecorationColor_paleGoldenRod = h.MakeStyle("textDecorationColor", "#EEE8AA")
    member _.textDecorationColor_khaki = h.MakeStyle("textDecorationColor", "#F0E68C")
    member _.textDecorationColor_darkKhaki = h.MakeStyle("textDecorationColor", "#BDB76B")
    member _.textDecorationColor_lavender = h.MakeStyle("textDecorationColor", "#E6E6FA")
    member _.textDecorationColor_thistle = h.MakeStyle("textDecorationColor", "#D8BFD8")
    member _.textDecorationColor_plum = h.MakeStyle("textDecorationColor", "#DDA0DD")
    member _.textDecorationColor_violet = h.MakeStyle("textDecorationColor", "#EE82EE")
    member _.textDecorationColor_orchid = h.MakeStyle("textDecorationColor", "#DA70D6")
    member _.textDecorationColor_fuchsia = h.MakeStyle("textDecorationColor", "#FF00FF")
    member _.textDecorationColor_magenta = h.MakeStyle("textDecorationColor", "#FF00FF")
    member _.textDecorationColor_mediumOrchid = h.MakeStyle("textDecorationColor", "#BA55D3")
    member _.textDecorationColor_mediumPurple = h.MakeStyle("textDecorationColor", "#9370DB")
    member _.textDecorationColor_rebeccaPurple = h.MakeStyle("textDecorationColor", "#663399")
    member _.textDecorationColor_blueViolet = h.MakeStyle("textDecorationColor", "#8A2BE2")
    member _.textDecorationColor_darkViolet = h.MakeStyle("textDecorationColor", "#9400D3")
    member _.textDecorationColor_darkOrchid = h.MakeStyle("textDecorationColor", "#9932CC")
    member _.textDecorationColor_darkMagenta = h.MakeStyle("textDecorationColor", "#8B008B")
    member _.textDecorationColor_purple = h.MakeStyle("textDecorationColor", "#800080")
    member _.textDecorationColor_indigo = h.MakeStyle("textDecorationColor", "#4B0082")
    member _.textDecorationColor_slateBlue = h.MakeStyle("textDecorationColor", "#6A5ACD")
    member _.textDecorationColor_darkSlateBlue = h.MakeStyle("textDecorationColor", "#483D8B")
    member _.textDecorationColor_mediumSlateBlue = h.MakeStyle("textDecorationColor", "#7B68EE")
    member _.textDecorationColor_greenYellow = h.MakeStyle("textDecorationColor", "#ADFF2F")
    member _.textDecorationColor_chartreuse = h.MakeStyle("textDecorationColor", "#7FFF00")
    member _.textDecorationColor_lawnGreen = h.MakeStyle("textDecorationColor", "#7CFC00")
    member _.textDecorationColor_lime = h.MakeStyle("textDecorationColor", "#00FF00")
    member _.textDecorationColor_limeGreen = h.MakeStyle("textDecorationColor", "#32CD32")
    member _.textDecorationColor_paleGreen = h.MakeStyle("textDecorationColor", "#98FB98")
    member _.textDecorationColor_lightGreen = h.MakeStyle("textDecorationColor", "#90EE90")
    member _.textDecorationColor_mediumSpringGreen = h.MakeStyle("textDecorationColor", "#00FA9A")
    member _.textDecorationColor_springGreen = h.MakeStyle("textDecorationColor", "#00FF7F")
    member _.textDecorationColor_mediumSeaGreen = h.MakeStyle("textDecorationColor", "#3CB371")
    member _.textDecorationColor_seaGreen = h.MakeStyle("textDecorationColor", "#2E8B57")
    member _.textDecorationColor_forestGreen = h.MakeStyle("textDecorationColor", "#228B22")
    member _.textDecorationColor_green = h.MakeStyle("textDecorationColor", "#008000")
    member _.textDecorationColor_darkGreen = h.MakeStyle("textDecorationColor", "#006400")
    member _.textDecorationColor_yellowGreen = h.MakeStyle("textDecorationColor", "#9ACD32")
    member _.textDecorationColor_oliveDrab = h.MakeStyle("textDecorationColor", "#6B8E23")
    member _.textDecorationColor_olive = h.MakeStyle("textDecorationColor", "#808000")
    member _.textDecorationColor_darkOliveGreen = h.MakeStyle("textDecorationColor", "#556B2F")
    member _.textDecorationColor_mediumAquamarine = h.MakeStyle("textDecorationColor", "#66CDAA")
    member _.textDecorationColor_darkSeaGreen = h.MakeStyle("textDecorationColor", "#8FBC8B")
    member _.textDecorationColor_lightSeaGreen = h.MakeStyle("textDecorationColor", "#20B2AA")
    member _.textDecorationColor_darkCyan = h.MakeStyle("textDecorationColor", "#008B8B")
    member _.textDecorationColor_teal = h.MakeStyle("textDecorationColor", "#008080")
    member _.textDecorationColor_aqua = h.MakeStyle("textDecorationColor", "#00FFFF")
    member _.textDecorationColor_cyan = h.MakeStyle("textDecorationColor", "#00FFFF")
    member _.textDecorationColor_lightCyan = h.MakeStyle("textDecorationColor", "#E0FFFF")
    member _.textDecorationColor_paleTurqouise = h.MakeStyle("textDecorationColor", "#AFEEEE")
    member _.textDecorationColor_aquaMarine = h.MakeStyle("textDecorationColor", "#7FFFD4")
    member _.textDecorationColor_turqouise = h.MakeStyle("textDecorationColor", "#AFEEEE")
    member _.textDecorationColor_mediumTurqouise = h.MakeStyle("textDecorationColor", "#48D1CC")
    member _.textDecorationColor_darkTurqouise = h.MakeStyle("textDecorationColor", "#00CED1")
    member _.textDecorationColor_cadetBlue = h.MakeStyle("textDecorationColor", "#5F9EA0")
    member _.textDecorationColor_steelBlue = h.MakeStyle("textDecorationColor", "#4682B4")
    member _.textDecorationColor_lightSteelBlue = h.MakeStyle("textDecorationColor", "#B0C4DE")
    member _.textDecorationColor_powederBlue = h.MakeStyle("textDecorationColor", "#B0E0E6")
    member _.textDecorationColor_lightBlue = h.MakeStyle("textDecorationColor", "#ADD8E6")
    member _.textDecorationColor_skyBlue = h.MakeStyle("textDecorationColor", "#87CEEB")
    member _.textDecorationColor_lightSkyBlue = h.MakeStyle("textDecorationColor", "#87CEFA")
    member _.textDecorationColor_deepSkyBlue = h.MakeStyle("textDecorationColor", "#00BFFF")
    member _.textDecorationColor_dodgerBlue = h.MakeStyle("textDecorationColor", "#1E90FF")
    member _.textDecorationColor_cornFlowerBlue = h.MakeStyle("textDecorationColor", "#6495ED")
    member _.textDecorationColor_royalBlue = h.MakeStyle("textDecorationColor", "#4169E1")
    member _.textDecorationColor_blue = h.MakeStyle("textDecorationColor", "#0000FF")
    member _.textDecorationColor_mediumBlue = h.MakeStyle("textDecorationColor", "#0000CD")
    member _.textDecorationColor_darkBlue = h.MakeStyle("textDecorationColor", "#00008B")
    member _.textDecorationColor_navy = h.MakeStyle("textDecorationColor", "#000080")
    member _.textDecorationColor_midnightBlue = h.MakeStyle("textDecorationColor", "#191970")
    member _.textDecorationColor_cornSilk = h.MakeStyle("textDecorationColor", "#FFF8DC")
    member _.textDecorationColor_blanchedAlmond = h.MakeStyle("textDecorationColor", "#FFEBCD")
    member _.textDecorationColor_bisque = h.MakeStyle("textDecorationColor", "#FFE4C4")
    member _.textDecorationColor_navajoWhite = h.MakeStyle("textDecorationColor", "#FFDEAD")
    member _.textDecorationColor_wheat = h.MakeStyle("textDecorationColor", "#F5DEB3")
    member _.textDecorationColor_burlyWood = h.MakeStyle("textDecorationColor", "#DEB887")
    member _.textDecorationColor_tan = h.MakeStyle("textDecorationColor", "#D2B48C")
    member _.textDecorationColor_rosyBrown = h.MakeStyle("textDecorationColor", "#BC8F8F")
    member _.textDecorationColor_sandyBrown = h.MakeStyle("textDecorationColor", "#F4A460")
    member _.textDecorationColor_goldenRod = h.MakeStyle("textDecorationColor", "#DAA520")
    member _.textDecorationColor_darkGoldenRod = h.MakeStyle("textDecorationColor", "#B8860B")
    member _.textDecorationColor_peru = h.MakeStyle("textDecorationColor", "#CD853F")
    member _.textDecorationColor_chocolate = h.MakeStyle("textDecorationColor", "#D2691E")
    member _.textDecorationColor_saddleBrown = h.MakeStyle("textDecorationColor", "#8B4513")
    member _.textDecorationColor_sienna = h.MakeStyle("textDecorationColor", "#A0522D")
    member _.textDecorationColor_brown = h.MakeStyle("textDecorationColor", "#A52A2A")
    member _.textDecorationColor_maroon = h.MakeStyle("textDecorationColor", "#A52A2A")
    member _.textDecorationColor_white = h.MakeStyle("textDecorationColor", "#FFFFFF")
    member _.textDecorationColor_snow = h.MakeStyle("textDecorationColor", "#FFFAFA")
    member _.textDecorationColor_honeyDew = h.MakeStyle("textDecorationColor", "#F0FFF0")
    member _.textDecorationColor_mintCream = h.MakeStyle("textDecorationColor", "#F5FFFA")
    member _.textDecorationColor_azure = h.MakeStyle("textDecorationColor", "#F0FFFF")
    member _.textDecorationColor_aliceBlue = h.MakeStyle("textDecorationColor", "#F0F8FF")
    member _.textDecorationColor_ghostWhite = h.MakeStyle("textDecorationColor", "#F8F8FF")
    member _.textDecorationColor_whiteSmoke = h.MakeStyle("textDecorationColor", "#F5F5F5")
    member _.textDecorationColor_seaShell = h.MakeStyle("textDecorationColor", "#FFF5EE")
    member _.textDecorationColor_beige = h.MakeStyle("textDecorationColor", "#F5F5DC")
    member _.textDecorationColor_oldLace = h.MakeStyle("textDecorationColor", "#FDF5E6")
    member _.textDecorationColor_floralWhite = h.MakeStyle("textDecorationColor", "#FFFAF0")
    member _.textDecorationColor_ivory = h.MakeStyle("textDecorationColor", "#FFFFF0")
    member _.textDecorationColor_antiqueWhite = h.MakeStyle("textDecorationColor", "#FAEBD7")
    member _.textDecorationColor_linen = h.MakeStyle("textDecorationColor", "#FAF0E6")
    member _.textDecorationColor_lavenderBlush = h.MakeStyle("textDecorationColor", "#FFF0F5")
    member _.textDecorationColor_mistyRose = h.MakeStyle("textDecorationColor", "#FFE4E1")
    member _.textDecorationColor_gainsBoro = h.MakeStyle("textDecorationColor", "#DCDCDC")
    member _.textDecorationColor_lightGray = h.MakeStyle("textDecorationColor", "#D3D3D3")
    member _.textDecorationColor_silver = h.MakeStyle("textDecorationColor", "#C0C0C0")
    member _.textDecorationColor_darkGray = h.MakeStyle("textDecorationColor", "#A9A9A9")
    member _.textDecorationColor_gray = h.MakeStyle("textDecorationColor", "#808080")
    member _.textDecorationColor_dimGray = h.MakeStyle("textDecorationColor", "#696969")
    member _.textDecorationColor_lightSlateGray = h.MakeStyle("textDecorationColor", "#778899")
    member _.textDecorationColor_slateGray = h.MakeStyle("textDecorationColor", "#708090")
    member _.textDecorationColor_darkSlateGray = h.MakeStyle("textDecorationColor", "#2F4F4F")
    member _.textDecorationColor_black = h.MakeStyle("textDecorationColor", "#000000")
    member _.textDecorationColor_transparent = h.MakeStyle("textDecorationColor", "transparent")
