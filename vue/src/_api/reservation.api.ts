import request from '@/_utils/request';
import BoxListSearchModel from '@/models/box-management/box-list/BoxListSearchModel';
import AddItemModel from '@/models/api/reservation/AddItemModel';
import MessageTemplateModel from '@/models/api/reservation/MessageTemplateModel';
import CardModel from '@/models/api/reservation/CardModel';
import UpdateStyleGroupModel from '@/models/api/reservation/UpdateStyleGroupModel';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/reservation`;
//取得預約單清單
export const GetBoxList = (obj: BoxListSearchModel) => {
    return request({
        url: `${baseUrl}/query`,
        method: 'get',
        params: obj
    });
};
// 取得BOX預約單資訊
export const GetBoxInformation = (id: string) => {
    return request({
        url: `${baseUrl}/${id}/get`,
        method: 'get'
    });
};
// 新增/更新預約單搭配商品
export const SaveMatchItems = (obj: AddItemModel) => {
    return request({
        url: `${baseUrl}/group/additem`,
        method: 'post',
        data: obj
    });
};
// 更新搭配組合資料
export const UpdateStyleGroup = (obj: UpdateStyleGroupModel) => {
    return request({
        url: `${baseUrl}/group`,
        method: 'post',
        data: obj
    });
};
// 取得文案範本
export const GetMessageTemplate = (obj: MessageTemplateModel) => {
    return request({
        url: `${baseUrl}/card/message-template`,
        method: 'get',
        params: obj
    });
};

export const SaveCard = (obj: CardModel) => {
    return request({
        url: `${baseUrl}/card`,
        method: 'post',
        data: obj
    });
};
