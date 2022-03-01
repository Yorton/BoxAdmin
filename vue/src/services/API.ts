import { APIClient, _setAuthorization } from './';
import qs from 'qs';
const request = new APIClient();
const get = request.get;
const post = request.post;
const postFormData = request.postFormData;
const version = 1;
const _identityToken = () => {
    const data = {
        email: 'string',
        password: 'string'
    };
    post('/identity/token', data).then(response => {
        const responseData = !!response.data;
        if (responseData) {
            const token = `Bearer ${response.data.data.jwToken}`;
            _setAuthorization(token);
            const obj = { token: token };
            localStorage.setItem('userInfo', JSON.stringify(obj));
        }
    });
};
// 測試用，之後要移到登入
_identityToken();
// 搭配師管理 MatchingMaker
export const FetchMatchingMakerList = () => {
    return get(`/v${version}/matchingmaker/query`, {});
};
export const FetchMatchingMakerDetail = (params: {}) => {
    return get(`/v${version}/matchingmaker/get`, { params: params });
};
export const UpdateMatchingMakerImage = (id: string, data: {}) => {
    return postFormData(`/v${version}/matchingmaker/${id}/image`, data);
};
export const UpdateMatchingMaker = (data: {}) => {
    return post(`/v${version}/matchingmaker/submit`, data);
};
// StyleBook管理 StyleBook
export const FetchStyleBookList = (params: {}) => {
    return get(`/v${version}/stylebook/query`, {
        params: params,
        paramsSerializer: (params: {}) => {
            return qs.stringify(params, {
                arrayFormat: 'comma',
                encode: false
            });
        }
    });
};
export const FetchStyleBookDetail = (id: string) => {
    return get(`/v${version}/stylebook/${id}/info`, {});
};
export const FetchStyleBookOptionStyle = () => {
    return get(`/v${version}/stylebook/style-list`, {});
};
export const FetchStyleBookOptionOccasion = () => {
    return get(`/v${version}/stylebook/occasion-list`, {});
};
export const UpdateStyleBookImage = (id: string, data: {}) => {
    return postFormData(`/v${version}/stylebook/${id}/image`, data);
};
export const UpdateStyleBook = (data: {}) => {
    return post(`/v${version}/stylebook/submit`, data);
};
export const FetchStyleBookColorImage = (id: string) => {
    return get(`/v${version}/product/series/${id}/info`, {});
};
