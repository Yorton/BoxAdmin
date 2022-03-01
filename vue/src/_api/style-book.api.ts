import StyleBookQueryModel from '@/models/api/style-book/StyleBookQueryModel';
import request from '@/_utils/request';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/stylebook`;
/**
 * 風格分類
 */
export const GetStyleList = () => {
    return request({
        url: `${baseUrl}/style-list`,
        method: 'get'
    });
};
/**
 * 情境場合
 */
export const GetOccasionList = () => {
    return request({
        url: `${baseUrl}/occasion-list`,
        method: 'get'
    });
};
/**
 * StyleBook清單
 * @param params
 */
export const GetStyleBookList = (obj: StyleBookQueryModel) => {
    return request({
        url: `${baseUrl}/query`,
        method: 'get',
        params: obj
        // paramsSerializer: (params: {}) => {
        //     return qs.stringify(params, {
        //         arrayFormat: 'comma',
        //         encode: false
        //     });
        // }
    });
};
/**
 * StyleBook資料
 * @param id
 */
export const GetStyleBookDetail = (id: string) => {
    return request({
        url: `${baseUrl}/${id}/info`,
        method: 'get'
    });
};
/**
 * 上傳StyleBook圖片
 * @param id
 * @param data
 */
export const UpdateStyleBookImage = (id: string, data: {}) => {
    return request({
        url: `${baseUrl}/${id}/image`,
        method: 'post',
        headers: {
            'Content-Type': 'multipart/form-data'
        },
        data: data
    });
};
/**
 * 新增或更新StyleBook
 * @param data
 */
export const UpdateStyleBook = (data: {}) => {
    return request({
        url: `${baseUrl}/submit`,
        method: 'post',
        data: data
    });
};

/**
 * 移除StyleBook
 * @param id
 */
export const RemoveStyleBook = (id: string) => {
    return request({
        url: `${baseUrl}/${id}/remove`,
        method: 'post'
    });
};
