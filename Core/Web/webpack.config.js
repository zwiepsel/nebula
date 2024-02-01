const path = require('path');

const Messages = require('webpack-messages');
const {WebpackManifestPlugin} = require('webpack-manifest-plugin');
const HtmlPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyPlugin = require('copy-webpack-plugin');

const fileName = 'app';
const outputPath = 'wwwroot/dist';

module.exports = (env, argv) => {
    return {
        mode: argv.mode === 'production' ? 'production' : 'development',
        optimization: {
            minimize: argv.mode === 'production'
        },
        entry: {
            'main-js': './assets/js/index.js',
            'theme-dark': './assets/scss/index.dark.scss',
            'theme-default': './assets/scss/index.default.scss',
            'base': './assets/scss/base.scss'
        },
        output: {
            filename: 'js/' + fileName + '_[contenthash].js',
            path: path.resolve(__dirname, outputPath),
            clean: true
        },
        module: {
            rules: [
                {
                    test: /\.s[ac]ss$/i,
                    use: [
                        {
                            loader: MiniCssExtractPlugin.loader,
                            options: {
                                publicPath: '../'
                            }
                        },
                        {
                            loader: 'css-loader',
                            options: {
                                sourceMap: true
                            }
                        },
                        {
                            loader: 'resolve-url-loader',
                            options: {
                                sourceMap: true,
                                publicPath: '../'
                            }
                        },
                        {
                            loader: 'sass-loader',
                            options: {
                                sourceMap: true,
                                additionalData: "$theme: " + env.theme + ";"
                            }
                        }
                    ]
                },
                {
                    test: /\.svg$/,
                    type: 'asset/inline'
                },
                {
                    test: /\.(woff|woff2|eot|ttf|otf)$/i,
                    type: 'asset/resource',
                    generator: {
                        filename: 'fonts/[name][ext]'
                    }
                }
            ]
        },
        plugins: [
            new Messages({
                name: 'nebula',
                logger: str => console.log(` >> ${str}`),
            }),
            new WebpackManifestPlugin(),
            new HtmlPlugin({inject: false, template: 'assets/index.html', filename: '../index.html'}),
            new MiniCssExtractPlugin({
                filename: 'css/[name]_[contenthash].css',
                chunkFilename: 'css/[id]_[contenthash].css'
            }),
            new CopyPlugin({patterns: [{from: "assets/img", to: "img"}]})
        ]
    };
};