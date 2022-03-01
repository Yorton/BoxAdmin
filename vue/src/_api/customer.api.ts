import request from '@/_utils/request';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/customer`;
export function GetCustomer(id: string) {
    return request({
        url: `${baseUrl}/${id}/get`,
        method: 'get'
    });
}
