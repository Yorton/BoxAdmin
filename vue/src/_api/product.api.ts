import BoxEditStyleBookFilterModel from '@/models/box-management/box-edit/BoxEditStyleBookFilterModel';
import request from '@/_utils/request';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/product`;
// 收藏清單清單
export function GetFavoritesProductItems(id: string) {
    return request({
        url: `${baseUrl}/items/${id}/favorites`,
        method: 'get'
    });
}
// 猜你喜歡清單
export function GetScoreProductItems(id: string) {
    return request({
        url: `${baseUrl}/items/${id}/score`,
        method: 'get'
    });
}
// 搜尋清單
export function GetSearchProductItemsBySeries(id: string) {
    return request({
        url: `${baseUrl}/items/${id}/byseries`,
        method: 'get'
    });
}
// 搭配品清單
export function GetStyleBookByFilter(obj: BoxEditStyleBookFilterModel) {
    return request({
        url: `${baseUrl}/items/bystylebookfilter`,
        method: 'get',
        params: obj
    });
}

export const GetStyleBookColorImage = (id: string) => {
    return request({
        url: `${baseUrl}/series/${id}/info`,
        method: 'get'
    });
};
