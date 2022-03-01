import ProductItemModel from '@/models/components/common/ProductItemModel';

export default class {
    groupId = '';
    product1: ProductItemModel = new ProductItemModel();
    product2: ProductItemModel = new ProductItemModel();
    text = '';
    constructor(
        groupId = '',
        product1 = new ProductItemModel(),
        product2 = new ProductItemModel(),
        text = ''
    ) {
        this.groupId = groupId;
        this.product1 = product1;
        this.product2 = product2;
        this.text = text;
    }
}
