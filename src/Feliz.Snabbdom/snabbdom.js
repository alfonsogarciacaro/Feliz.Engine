// Snabbdom: https://github.com/snabbdom/snabbdom
// Copyright (c) 2015 Simon Friis Vindum - MIT License

import { h } from "snabbdom/h";

export { attributesModule } from "snabbdom/modules/attributes";
export { styleModule } from "snabbdom/modules/style";
export { eventListenersModule } from "snabbdom/modules/eventlisteners";
export { init } from "snabbdom/init";
export { h } from "snabbdom/h";

export function memo(key, render, arg, equals) {
    equals = equals || ((oldArg, newArg) =>
        Array.isArray(oldArg)
            ? Array.isArray(newArg)
                && oldArg.length === newArg.length
                && oldArg.reduce(((acc, cur, i) => acc && cur === newArg[i]), true)
            : oldArg === newArg);

    return h("memo", {
        key,
        arg,
        hook: {
            init(vnode) {
                Object.assign(vnode, render(arg));
                vnode.data.hook = vnode.data.hook || {};
                // After creating the element, make sure to put back the selector and keys
                // so the node is correctly matched when updating
                vnode.data.hook.create = () => {
                    vnode.sel = "memo";
                    vnode.key = key;
                    vnode.data.arg = arg;
                }
            },
            prepatch(oldVnode, newVnode) {
                if (equals(oldVnode.data.arg, arg)) {
                    Object.assign(newVnode, oldVnode);
                } else {
                    Object.assign(newVnode, render(arg));
                    newVnode.sel = "memo";
                    newVnode.key = key;
                    newVnode.data.arg = arg;
                }
            },
        },
    })
}