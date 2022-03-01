import CardGroupItemModel from './CardGroupItemModel';
import CardModel from './CardModel';

export default class extends CardModel {
    groups: CardGroupItemModel[] = [];
    constructor(id = '', template = 0, intro = '', signatureUrl = '') {
        super(id, template, intro, signatureUrl);
    }
}
