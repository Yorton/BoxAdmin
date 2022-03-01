import request from '@/_utils/request';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/matchingmaker`;
/**
 * 取的搭配師清單
 */
export const GetMatchingMakerList = () => {
    return request({
        url: `${baseUrl}/query`,
        method: 'get'
    });
};
/**
 * 取得搭配師資訊
 * @param id
 */
export const GetMatchingMakerDetail = (id: string) => {
    return request({
        url: `${baseUrl}/get`,
        method: 'get',
        params: { id }
    });
};
/**
 * 上傳搭配師圖片
 * @param id
 * @param data
 */
export const UpdateMatchingMakerImage = (id: string, data: {}) => {
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
 * 更新搭配師資訊
 * @param data
 */
export const UpdateMatchingMaker = (data: {}) => {
    return request({
        url: `${baseUrl}/submit`,
        method: 'post',
        data: data
    });
};
