import MainSubscribeModel from './MainSubscribeModel';
import SubscribeInfoModel from './SubscribeInfoModel';
import BoxReservationModel from './BoxReservationModel';

export default class {
    mainSubscribeData: MainSubscribeModel = new MainSubscribeModel();
    //問卷
    subscribeInfoData: SubscribeInfoModel = new SubscribeInfoModel();
    boxReservationData: BoxReservationModel[] = [];
}
