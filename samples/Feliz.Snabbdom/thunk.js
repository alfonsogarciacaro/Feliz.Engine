// Adapted to remove equality check on the function argument
// https://github.com/snabbdom/snabbdom/blob/master/src/package/thunk.ts

import { h } from "snabbdom/h";

function copyToThunk(vnode, thunk) {
    (vnode.data).fn = (thunk.data).fn;
    (vnode.data).args = (thunk.data).args
    thunk.data = vnode.data
    thunk.children = vnode.children
    thunk.text = vnode.text
    thunk.elm = vnode.elm
}

export function thunk(sel, key, fn, args) {
    return h(sel, {
        key: key,
        hook: {
            init(thunk) {
                const cur = thunk.data
                const vnode = (cur.fn).apply(undefined, cur.args)
                copyToThunk(vnode, thunk)
            },
            prepatch(oldVnode, thunk) {
                const old = oldVnode.data
                const cur = thunk.data
                const oldArgs = old.args
                const args = cur.args
                // if (old.fn !== cur.fn || (oldArgs).length !== (args).length) {
                //   copyToThunk((cur.fn).apply(undefined, args), thunk)
                //   return
                // }
                for (let i = 0; i < (args).length; ++i) {
                    if ((oldArgs)[i] !== (args)[i]) {
                        copyToThunk((cur.fn).apply(undefined, args), thunk)
                        return
                    }
                }
                copyToThunk(oldVnode, thunk)
            }
        },
        fn: fn,
        args: args
    })
}