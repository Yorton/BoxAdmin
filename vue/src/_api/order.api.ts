import request from '@/_utils/request';
const version = process.env.VUE_APP_API_VERSION;
const baseUrl = `/api/${version}/order`;
export function GetOrderList() {
    return request({
        url: `${baseUrl}/all`,
        method: 'get'
    });
}
