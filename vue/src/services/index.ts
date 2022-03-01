import axios from 'axios';
import config from './../config';

const request = axios.create();
request.defaults.baseURL = config.APIURL;
request.defaults.headers.post['Content-Type'] = 'application/json';

const _setAuthorization = (apiToken: string) => {
    const token = !!apiToken;
    let authorizationToken;
    if (token) authorizationToken = apiToken;
    else {
        const storageUserInfo = localStorage.getItem('userInfo') || '';
        const booleanStorageUserInfo = !!storageUserInfo;
        authorizationToken = booleanStorageUserInfo
            ? JSON.parse(storageUserInfo).token
            : 'noLogin';
    }
    request.defaults.headers.common['Authorization'] = authorizationToken;
};
_setAuthorization('');
class APIClient {
    get = (url: string, params: object) => {
        return request.get(url, params);
    };
    post = (url: string, data: object) => {
        return request.post(url, data);
    };
    postFormData = (url: string, data: object) => {
        return request.post(url, data, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
    };
}
export { _setAuthorization, APIClient };
