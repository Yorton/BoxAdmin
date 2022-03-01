import CardModel from '@/models/api/reservation/CardModel';
import BoxEditCustomerModel from './BoxEditCustomerModel';
import BoxEditGroupModel from './BoxEditGroupModel';
import BoxEditMatchingMakerModel from './BoxEditMatchingMakerModel';
import BoxEditRecipientModel from './BoxEditRecipientModel';
import BoxEditSurveyModel from './BoxEditSurveyModel';
import BoxtEditStateModel from './BoxtEditStateModel';

export default class {
    id = '';
    subscribeId = '';
    customer: BoxEditCustomerModel = new BoxEditCustomerModel();
    customerId = '';
    boxNo = '';
    boxType = 0;
    boxTypeName = '';
    state: BoxtEditStateModel = new BoxtEditStateModel();
    flowState: BoxtEditStateModel = new BoxtEditStateModel();
    matchmakerId = '';
    matchmaker: BoxEditMatchingMakerModel = new BoxEditMatchingMakerModel();
    itemGroups: BoxEditGroupModel[] = [];
    recipient: BoxEditRecipientModel = new BoxEditRecipientModel();
    card: CardModel = new CardModel();
    surveys: BoxEditSurveyModel[] = [];
}
