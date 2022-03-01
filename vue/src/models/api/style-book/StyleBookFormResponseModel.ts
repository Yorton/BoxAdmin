import MatchMasterModel from '../matching-maker/MatchMasterModel';
import StyleBookMatchingProductModel from './StyleBookMatchingProductModel';

export default class {
    id = '';
    state = 0;
    imageUrl = '';
    styleId = '';
    occasionId = '';
    createdAt = '';
    createdBy = '';
    modifyDate = '';
    modifier = '';
    items: StyleBookMatchingProductModel[] = [];
    matchmaker: MatchMasterModel = new MatchMasterModel();
}
