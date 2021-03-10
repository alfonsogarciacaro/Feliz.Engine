namespace Feliz

open System
open Browser.Types

module internal Util =
#if FABLE_COMPILER
    let inline cast<'Ev when 'Ev :> Event> (f: 'Ev -> unit): Event -> unit = unbox f
#else
    let cast<'Ev when 'Ev :> Event> (f: 'Ev -> unit): Event -> unit = fun (ev: Event) -> f (ev :?> 'Ev)
#endif

// Use Func to avoid Fable checking the arity at runtime because of the returning generic

type EventEngine<'Node>(makeEvent: Func<string, (Event -> unit), 'Node>) =

    let makeEvent key handler = makeEvent.Invoke(key, handler)

    /// Fires when a media event is aborted.
    member _.onAbort (handler: Event -> unit) = makeEvent "abort" handler

    /// Fires when animation is aborted.
    member _.onAnimationCancel (handler: AnimationEvent -> unit) = makeEvent "animationCancel" (Util.cast handler)

    /// Fires when animation ends.
    member _.onAnimationEnd (handler: AnimationEvent -> unit) = makeEvent "animationEnd" (Util.cast handler)

    /// Fires when animation iterates.
    member _.onAnimationIteration (handler: AnimationEvent -> unit) = makeEvent "animationIteration" (Util.cast handler)

    /// Fires when animation starts.
    member _.onAnimationStart (handler: AnimationEvent -> unit) = makeEvent "animationStart" (Util.cast handler)

    /// Fires the moment that the element loses focus.
    member _.onBlur (handler: FocusEvent -> unit) = makeEvent "blur" (Util.cast handler)

    /// Fires when a user dismisses the current open dialog
    member _.onCancel (handler: Event -> unit) = makeEvent "cancel" handler

    /// Fires when a file is ready to start playing (when it has buffered enough to begin).
    member _.onCanPlay (handler: Event -> unit) = makeEvent "canPlay" handler

    /// Fires when a file can be played all the way to the end without pausing for buffering
    member _.onCanPlayThrough (handler: Event -> unit) = makeEvent "canPlayThrough" handler

    /// Fires the moment when the value of the element is changed
    member _.onChange (handler: Event -> unit) = makeEvent "change"  handler

    /// Same as `onChange` that takes an event as input but instead let's you deal with the `checked` value changed from the `input` element
    /// directly when it is defined as a checkbox with attribute `inputType.checkbox`.
    member _.onChange (handler: bool -> unit) =
        let handler (ev: Event) =
            let el = ev.target :?> HTMLInputElement
            handler el.``checked``
        makeEvent "change" handler

    /// Same as `onChange` that takes an event as input but instead lets you deal with the selected file directly from the `input` element when it is defined as a checkbox with `prop.type'.file`.
    member _.onChange (handler: File -> unit) =
        let fileHandler (ev: Event) : unit =
            let el = ev.target :?> HTMLInputElement
            let files : FileList = el.files
            if not (isNull files) && files.length > 0 then handler (files.item 0)
        makeEvent "change" fileHandler

    /// Same as `onChange` that takes an event as input but instead lets you deal with the selected files directly from the `input` element when it is defined as a checkbox with `prop.type'.file` and `prop.multiple true`.
    member _.onChange (handler: File list -> unit) =
        let fileHandler (ev: Event) : unit =
            let el = ev.target :?> HTMLInputElement
            let fileList : FileList = el.files
            if not (isNull fileList) then handler [ for i in 0 .. fileList.length - 1 -> fileList.item i ]
        makeEvent "change" fileHandler

    /// Same as `onChange` that takes an event as input but instead let's you deal with the text changed from the `input` element directly
    /// instead of extracting it from the event arguments.
    member _.onChange (handler: string -> unit) =
        let handler (ev: Event) =
            let el = ev.target :?> HTMLInputElement
            handler el.value
        makeEvent "change" handler

    /// Same as `onChange` but let's you deal with the `checked` value that has changed from the `input` element directly instead of extracting it from the event arguments.
    member _.onCheckedChange (handler: bool -> unit) =
        let handler (ev: Event) =
            let el = ev.target :?> HTMLInputElement
            handler el.``checked``
        makeEvent "change" handler

    /// Fires on a mouse click on the element.
    member _.onClick (handler: MouseEvent -> unit) = makeEvent "click" (Util.cast handler)

    /// Fires when composition ends.
    member _.onCompositionEnd (handler: CompositionEvent -> unit) = makeEvent "compositionEnd" (Util.cast handler)

    /// Fires when composition starts.
    member _.onCompositionStart (handler: CompositionEvent -> unit) = makeEvent "compositionStart" (Util.cast handler)

    /// Fires when composition changes.
    member _.onCompositionUpdate (handler: CompositionEvent -> unit) = makeEvent "compositionUpdate" (Util.cast handler)

    /// Fires when a context menu is triggered.
    member _.onContextMenu (handler: MouseEvent -> unit) = makeEvent "contextMenu" (Util.cast handler)

    /// Fires when a TextTrack has changed the currently displaying cues.
    member _.onCueChange (handler: Event -> unit) = makeEvent "cueChange" handler

        /// Fires when the user copies the content of an element.
    member _.onCopy (handler: ClipboardEvent -> unit) = makeEvent "copy" (Util.cast handler)

    /// Fires when the user cuts the content of an element.
    member _.onCut (handler: ClipboardEvent -> unit) = makeEvent "cut" (Util.cast handler)

    /// Fires when a mouse is double clicked on the element.
    member _.onDblClick (handler: MouseEvent -> unit) = makeEvent "dblClick" (Util.cast handler)

    /// Fires when an element is dragged.
    member _.onDrag (handler: DragEvent -> unit) = makeEvent "drag" (Util.cast handler)

    /// Fires when the a drag operation has ended.
    member _.onDragEnd (handler: DragEvent -> unit) = makeEvent "dragEnd" (Util.cast handler)

    /// Fires when an element has been dragged to a valid drop target.
    member _.onDragEnter (handler: DragEvent -> unit) = makeEvent "dragEnter" (Util.cast handler)

    member _.onDragExit (handler: DragEvent -> unit) = makeEvent "dragExit" (Util.cast handler)

    /// Fires when an element leaves a valid drop target.
    member _.onDragLeave (handler: DragEvent -> unit) = makeEvent "dragLeave" (Util.cast handler)

    /// Fires when an element is being dragged over a valid drop target.
    member _.onDragOver (handler: DragEvent -> unit) = makeEvent "dragOver" (Util.cast handler)

    /// Fires when the a drag operation has begun.
    member _.onDragStart (handler: DragEvent -> unit) = makeEvent "dragStart" (Util.cast handler)

    /// Fires when dragged element is being dropped.
    member _.onDrop (handler: DragEvent -> unit) = makeEvent "drop" (Util.cast handler)

    /// Fires when the length of the media changes.
    member _.onDurationChange (handler: Event -> unit) = makeEvent "durationChange" handler

    /// Fires when something bad happens and the file is suddenly unavailable (like unexpectedly disconnects).
    member _.onEmptied (handler: Event -> unit) = makeEvent "emptied" handler

    member _.onEncrypted (handler: Event -> unit) = makeEvent "encrypted" handler

    /// Fires when the media has reached the end (a useful event for messages like "thanks for listening").
    member _.onEnded (handler: Event -> unit) = makeEvent "ended" handler

    /// Fires when an error occurs.
    member _.onError (handler: Event -> unit) = makeEvent "error" handler

    /// Fires when an error occurs.
    member _.onError (handler: UIEvent -> unit) = makeEvent "error" (Util.cast handler)

    /// Fires the moment when the element gets focus.
    member _.onFocus (handler: FocusEvent -> unit) = makeEvent "focus" (Util.cast handler)

    /// Fires when an element captures a pointer.
    member _.onGotPointerCapture (handler: PointerEvent -> unit) = makeEvent "gotPointerCapture" (Util.cast handler)

    /// Fires when an element gets user input.
    member _.onInput (handler: Event -> unit) = makeEvent "input" handler

    /// Fires when a submittable element has been checked for validaty and doesn't satisfy its constraints.
    member _.onInvalid (handler: Event -> unit) = makeEvent "invalid" handler

    /// Fires when a user presses a key.
    member _.onKeyDown (handler: KeyboardEvent -> unit) = makeEvent "keyDown" (Util.cast handler)

    /// Fires when a user presses a key.
    // member _.onKeyDown (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
    //     PropHelpers.createOnKey(key, handler)
    //     |> h.MakeEvent("keyDown",)

    /// Fires when a user presses a key.
    member _.onKeyPress (handler: KeyboardEvent -> unit) = makeEvent "keyPress" (Util.cast handler)

    // /// Fires when a user presses a key.
    // member _.onKeyPress (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
    //     PropHelpers.createOnKey(key, handler)
    //     |> h.MakeEvent("keyPress",)

    /// Fires when a user releases a key.
    member _.onKeyUp (handler: KeyboardEvent -> unit) = makeEvent "keyUp" (Util.cast handler)

    // /// Fires when a user releases a key.
    // member _.onKeyUp (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
    //     PropHelpers.createOnKey(key, handler)
    //     |> h.MakeEvent("keyUp",)

    /// Fires after the page is finished loading.
    member _.onLoad (handler: Event -> unit) = makeEvent "load" handler

    /// Fires when media data is loaded.
    member _.onLoadedData (handler: Event -> unit) = makeEvent "loadedData" handler

    /// Fires when meta data (like dimensions and duration) are loaded.
    member _.onLoadedMetadata (handler: Event -> unit) = makeEvent "loadedMetadata" handler

    /// Fires when a request has completed, irrespective of its success.
    member _.onLoadEnd (handler: Event -> unit) = makeEvent "loadEnd" handler

    /// Fires when the file begins to load before anything is actually loaded.
    member _.onLoadStart (handler: Event -> unit) = makeEvent "loadStart" handler

    /// Fires when a captured pointer is released.
    member _.onLostPointerCapture (handler: PointerEvent -> unit) = makeEvent "lostPointerCapture" (Util.cast handler)

    /// Fires when a mouse button is pressed down on an element.
    member _.onMouseDown (handler: MouseEvent -> unit) = makeEvent "mouseDown" (Util.cast handler)

    /// Fires when a pointer enters an element.
    member _.onMouseEnter (handler: MouseEvent -> unit) = makeEvent "mouseEnter" (Util.cast handler)

    /// Fires when a pointer leaves an element.
    member _.onMouseLeave (handler: MouseEvent -> unit) = makeEvent "mouseLeave" (Util.cast handler)

    /// Fires when the mouse pointer is moving while it is over an element.
    member _.onMouseMove (handler: MouseEvent -> unit) = makeEvent "mouseMove" (Util.cast handler)

    /// Fires when the mouse pointer moves out of an element.
    member _.onMouseOut (handler: MouseEvent -> unit) = makeEvent "mouseOut" (Util.cast handler)

    /// Fires when the mouse pointer moves over an element.
    member _.onMouseOver (handler: MouseEvent -> unit) = makeEvent "mouseOver" (Util.cast handler)

    /// Fires when a mouse button is released while it is over an element.
    member _.onMouseUp (handler: MouseEvent -> unit) = makeEvent "mouseUp" (Util.cast handler)

    /// Fires when the user pastes some content in an element.
    member _.onPaste (handler: ClipboardEvent -> unit) = makeEvent "paste" (Util.cast handler)

    /// Fires when the media is paused either by the user or programmatically.
    member _.onPause (handler: Event -> unit) = makeEvent "pause" handler

    /// Fires when the media is ready to start playing.
    member _.onPlay (handler: Event -> unit) = makeEvent "play" handler

    /// Fires when the media actually has started playing
    member _.onPlaying (handler: Event -> unit) = makeEvent "playing" handler

    /// Fires when there are no more pointer events.
    member _.onPointerCancel (handler: PointerEvent -> unit) = makeEvent "pointerCancel" (Util.cast handler)

    /// Fires when a pointer becomes active.
    member _.onPointerDown (handler: PointerEvent -> unit) = makeEvent "pointerDown" (Util.cast handler)

    /// Fires when a pointer is moved into an elements boundaries or one of its descendants.
    member _.onPointerEnter (handler: PointerEvent -> unit) = makeEvent "pointerEnter" (Util.cast handler)

    /// Fires when a pointer is moved out of an elements boundaries.
    member _.onPointerLeave (handler: PointerEvent -> unit) = makeEvent "pointerLeave" (Util.cast handler)

    /// Fires when a pointer moves.
    member _.onPointerMove (handler: PointerEvent -> unit) = makeEvent "pointerMove" (Util.cast handler)

    /// Fires when a pointer is no longer in an elements boundaries, such as moving it, or after a `pointerUp` or `pointerCancel` event.
    member _.onPointerOut (handler: PointerEvent -> unit) = makeEvent "pointerOut" (Util.cast handler)

    /// Fires when a pointer is moved into an elements boundaries.
    member _.onPointerOver (handler: PointerEvent -> unit) = makeEvent "pointerOver" (Util.cast handler)

    /// Fires when a pointer is no longer active.
    member _.onPointerUp (handler: PointerEvent -> unit) = makeEvent "pointerUp" (Util.cast handler)

    /// Fires when the browser is in the process of getting the media data.
    member _.onProgress (handler: Event -> unit) = makeEvent "progress" handler

    /// Fires when the playback rate changes (like when a user switches to a slow motion or fast forward mode).
    member _.onRateChange (handler: Event -> unit) = makeEvent "rateChange" handler

    /// Fires when the Reset button in a form is clicked.
    member _.onReset (handler: Event -> unit) = makeEvent "reset" handler

    /// Fires when the window has been resized.
    member _.onResize (handler: UIEvent -> unit) = makeEvent "resize" (Util.cast handler)

    /// Fires when an element's scrollbar is being scrolled.
    member _.onScroll (handler: Event -> unit) = makeEvent "scroll" handler

    /// Fires when the seeking attribute is set to false indicating that seeking has ended.
    member _.onSeeked (handler: Event -> unit) = makeEvent "seeked" handler

    /// Fires when the seeking attribute is set to true indicating that seeking is active.
    member _.onSeeking (handler: Event -> unit) = makeEvent "seeking" handler

    /// Fires after some text has been selected in an element.
    member _.onSelect (handler: Event -> unit) = makeEvent "select" handler

    /// Fires after some text has been selected in the user interface.
    member _.onSelect (handler: UIEvent -> unit) = makeEvent "select" (Util.cast handler)

    /// Fires when the browser is unable to fetch the media data for whatever reason.
    member _.onStalled (handler: Event -> unit) = makeEvent "stalled" handler

    /// Fires when fetching the media data is stopped before it is completely loaded for whatever reason.
    member _.onSuspend (handler: Event -> unit) = makeEvent "suspend" handler

    /// Fires when a form is submitted.
    member _.onSubmit (handler: Event -> unit) = makeEvent "submit" handler

    /// Same as `onChange` but let's you deal with the text changed from the `input` element directly
    /// instead of extracting it from the event arguments.
    member _.onTextChange (handler: string -> unit) =
        let handler (ev: Event) =
            let el = ev.target :?> HTMLInputElement
            handler el.value
        makeEvent "change" handler

    /// Same as `onInput` but let's you deal with the text changed from the `input` element directly
    /// instead of extracting it from the event arguments.
    member _.onTextInput (handler: string -> unit) =
        let handler (ev: Event) =
            let el = ev.target :?> HTMLInputElement
            handler el.value
        makeEvent "input" handler

    /// Fires when the playing position has changed (like when the user fast forwards to a different point in the media).
    member _.onTimeUpdate (handler: Event -> unit) = makeEvent "timeUpdate" handler

    member _.onTouchCancel (handler: TouchEvent -> unit) = makeEvent "touchCancel" (Util.cast handler)

    member _.onTouchEnd (handler: TouchEvent -> unit) = makeEvent "touchEnd" (Util.cast handler)

    member _.onTouchMove (handler: TouchEvent -> unit) = makeEvent "touchMove" (Util.cast handler)

    member _.onTouchStart (handler: TouchEvent -> unit) = makeEvent "touchStart" (Util.cast handler)

    member _.onTransitionEnd (handler: TransitionEvent -> unit) = makeEvent "transitionEnd" (Util.cast handler)

    /// Fires when the volume is changed which (includes setting the volume to "mute").
    member _.onVolumeChange (handler: Event -> unit) = makeEvent "volumeChange" handler

    /// Fires when the media has paused but is expected to resume (like when the media pauses to buffer more data).
    member _.onWaiting (handler: Event -> unit) = makeEvent "waiting" handler

    /// Fires when the mouse wheel rolls up or down over an element.
    member _.onWheel (handler: WheelEvent -> unit) = makeEvent "wheel" (Util.cast handler)
