import request from '@/_utils/request';
import LoginModel from '@/models/account/LoginModel';
export function Login(data: LoginModel) {
    return request({
        url: '/api/identity/token',
        method: 'post',
        data: data
    });
}
