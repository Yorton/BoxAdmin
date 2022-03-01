export default class {
    sku = '';
    position = 1;
    source = 0;
    constructor(sku = '', source = 0, position = 1) {
        this.sku = sku;
        this.source = source;
        this.position = position;
    }
}
