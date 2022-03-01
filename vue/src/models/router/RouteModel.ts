import RouteMetaModel from './RouteMetaModel';

export default class RouteModel {
    // 網址
    path = '';
    // 選單名稱
    name = '';
    meta: RouteMetaModel = new RouteMetaModel();
    children: RouteModel[] = [];
}
