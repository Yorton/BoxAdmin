module.exports = {
    outputDir: process.env.OUTPUT_DIR,
    chainWebpack: config => {
        config.plugin('html').tap(args => {
            args[0].title = '訂閱盒後台管理系統';
            return args;
        });
    }
};
