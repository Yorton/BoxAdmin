import MatchedBoxModel from './MatchedBoxModel';

export default class {
    id = '';
    name = '';
    pictures: Array<string> = [];
    createdDate = '';
    modifyDate = '';
    boxCount = 0;
    matchingCounts: Array<MatchedBoxModel> = [];
    constructor(id = '', name = '') {
        this.id = id;
        this.name = name;
    }
}
