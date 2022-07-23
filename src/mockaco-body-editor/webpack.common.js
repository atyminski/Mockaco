const path = require('path');
const HtmlWebPackPlugin = require( 'html-webpack-plugin' );
const MonacoWebpackPlugin = require('monaco-editor-webpack-plugin');

module.exports = {
  entry: {
    app: "./src/index.ts"
  },
  resolve: {
    extensions: [".ts", ".js"]
  },
  output: {
    globalObject: "self",
    path: path.resolve(__dirname, 'dist')
  },
  module: {
    rules: [
    {
        test: /\.ts?$/,
        use: "ts-loader",
        exclude: /node_modules/
    },
    {
      test: /\.css$/,
      use: ['style-loader', 'css-loader']
    }, 
    {
      test: /\.ttf$/,
      loader: 'file-loader'
    }]
  },
  plugins: [
    new HtmlWebPackPlugin(),
    new MonacoWebpackPlugin({ languages: []})
  ]
};