// Adapted to remove equality check on the function argument
// https://github.com/snabbdom/snabbdom/blob/master/src/package/thunk.ts

import { h } from "snabbdom/h";

function copyToThunk(vnode, thunk) {
    vnode.data.fn = thunk.data.fn;
    vnode.data.arg = thunk.data.arg;
    vnode.data.equalFn = thunk.data.equalFn;
    thunk.data = vnode.data;
    thunk.children = vnode.children;
    thunk.text = vnode.text;
    thunk.elm = vnode.elm;
}

export function thunk(sel, key, fn, arg, equalFn) {
    equalFn = equalFn || ((oldArg, newArg) =>
        Array.isArray(oldArg)
            ? Array.isArray(newArg)
                && oldArg.length === newArg.length
                && oldArg.reduce(((acc, cur, i) => acc && cur === newArg[i]), true)
            : oldArg === newArg);

    return h(sel, {
        key: key,
        hook: {
            init(thunk) {
                const cur = thunk.data;
                const vnode = cur.fn.call(undefined, cur.arg);
                copyToThunk(vnode, thunk);
            },
            prepatch(oldVnode, thunk) {
                const old = oldVnode.data;
                const cur = thunk.data;
                if (!equalFn(old.arg, cur.arg)) {
                    copyToThunk(cur.fn.call(undefined, cur.arg), thunk);
                } else {
                    copyToThunk(oldVnode, thunk);
                }
            }
        },
        fn: fn,
        arg: arg,
        equalFn: equalFn,
    })
}