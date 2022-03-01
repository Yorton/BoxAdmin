import GroupModel from '@/models/api/reservation/GroupModel';
export default class {
    id = '';
    groups: GroupModel[] = [];
    constructor(id = '') {
        this.id = id;
    }
}
