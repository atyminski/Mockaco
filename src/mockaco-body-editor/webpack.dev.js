const merge = require('webpack-merge');
const common = require('./webpack.common.js');
const path = require('path');

module.exports = merge(common, {
    mode: 'development',
    devServer: {
        static: path.join(__dirname, "dist"),
        compress: true,
        port: 4000,
      },
});