import StyleGroupModel from '../style-book/StyleGroupModel';

export default class {
    items: StyleGroupModel[] = [];
    constructor(items = new Array<StyleGroupModel>()) {
        this.items = items;
    }
}
