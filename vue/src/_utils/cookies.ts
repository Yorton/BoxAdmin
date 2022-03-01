import { VueCookieNext } from 'vue-cookie-next';
import LoginResponseModel from '@/models/account/LoginResponseModel';

// 登入資訊
const userCookieName = 'user';
export const SetUser = (obj: LoginResponseModel) => {
    VueCookieNext.setCookie(userCookieName, JSON.stringify(obj), {
        expire: ''
    });
};

export const GetUser = (): LoginResponseModel => {
    return VueCookieNext.getCookie(userCookieName);
};

export const RemoveUser = () => VueCookieNext.removeCookie(userCookieName);
