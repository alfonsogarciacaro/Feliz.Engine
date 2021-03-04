module.exports = {
    entry: './snabbdom.js',
    mode: "production",
    output: {
        filename: "snabbdom.min.js",
        path: __dirname,
        libraryTarget: 'commonjs',
    },
  };