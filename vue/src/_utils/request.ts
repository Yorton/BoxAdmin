import axios, { AxiosRequestConfig } from 'axios';
import { useStore } from '@/store';
const request = axios.create({
    baseURL: process.env.VUE_APP_API_URI
});
export default function(obj: AxiosRequestConfig) {
    if (obj.method?.toLocaleLowerCase() === 'get') {
        if (!obj.params) obj.params = {};
        obj.params.rnd =
            new Date().getTime().toString() +
            parseInt((Math.random() * 10000).toString());
    }
    if (useStore().getters.getToken) {
        obj.headers = {
            Authorization: `Bearer ${useStore().getters.getToken}`
        };
    }
    return request(obj);
}
