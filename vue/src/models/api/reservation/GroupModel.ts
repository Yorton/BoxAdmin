import GroupProductItemModel from '@/models/api/reservation/GroupProductItemModel';
export default class {
    id = '';
    sortNum = 0;
    items: GroupProductItemModel[] = [];
    constructor(id = '') {
        this.id = id;
    }
}
