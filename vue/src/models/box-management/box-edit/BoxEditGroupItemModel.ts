export default class {
    id = '';
    reservationId = '';
    groupId = '';
    series = '';
    sku = '';
    dislikeFeedback = false;
    dislikeReason = 0;
    createdAt = '';
    createdBy = '';
    productName = '';
    imageUrl = '';
    color = '';
    size = '';
    price = 0;
    source = 0;
    position = 1;
    constructor(
        series = '',
        sku = '',
        color = '',
        imageUrl = '',
        productName = '',
        size = '',
        price = 0,
        source = 0
    ) {
        this.series = series;
        this.sku = sku;
        this.color = color;
        this.imageUrl = imageUrl;
        this.productName = productName;
        this.size = size;
        this.price = price;
        this.source = source;
    }
}
