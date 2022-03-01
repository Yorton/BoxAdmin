export default class {
    series = '';
    sku = '';
    image = '';
    name = '';
    color = '';
    size = '';
    price = 0;
    preStock = 0;
    stock = 0;
    weight = 0;
    constructor(
        series = '',
        sku = '',
        image = '',
        name = '',
        color = '',
        size = '',
        price = 0,
        preStock = 0,
        stock = 0,
        weight = 0
    ) {
        this.series = series;
        this.sku = sku;
        this.image = image;
        this.name = name;
        this.color = color;
        this.size = size;
        this.price = price;
        this.preStock = preStock;
        this.stock = stock;
        this.weight = weight;
    }
}
