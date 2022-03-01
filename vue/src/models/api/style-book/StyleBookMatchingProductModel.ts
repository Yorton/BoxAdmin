export default class {
    styleBookId = '';
    series = '';
    color = '';
    imageUrl = '';
    catelogName = '';
    constructor(
        styleBookId = '',
        series = '',
        color = '',
        imageUrl = '',
        catelogName = ''
    ) {
        this.styleBookId = styleBookId;
        this.series = series;
        this.color = color;
        this.imageUrl = imageUrl;
        this.catelogName = catelogName;
    }
}
