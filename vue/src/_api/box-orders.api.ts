import request from '@/_utils/request';
import BoxOrdersParamsModel from '@/models/box-management/box-orders/BoxOrdersParamsModel';
import BoxReservationParamsModel from '@/models/box-management/box-orders/BoxReservationParamsModel';
import SurveyAnswerParamsModel from '@/models/box-management/box-orders/SurveyAnswerParamsModel';

const version = process.env.VUE_APP_API_VERSION;

export const GetBoxStatus = () => {
    return request({
        url: `/api/${version}/boxorders/getBoxStatus`,
        method: 'get',
        params: {}
    });
};

export const GetMatchmakers = () => {
    return request({
        url: `/api/${version}/boxorders/getMatchmakers`,
        method: 'get',
        params: {}
    });
};

export const GetBoxOrders = (obj: BoxOrdersParamsModel) => {
    return request({
        url: `/api/${version}/boxorders/getBoxOrders`,
        method: 'get',
        params: obj
    });
};

export const GetBoxReservation = (obj: BoxReservationParamsModel) => {
    return request({
        url: `/api/${version}/boxorders/getBoxReservation`,
        method: 'get',
        params: obj
    });
};

export const GetBoxDetailById = (id: string) => {
    return request({
        url: `/api/${version}/boxorders/${id}/getBoxDetailById`,
        method: 'get'
    });
};

export const GetBoxSurveyAnswer = (obj: SurveyAnswerParamsModel) => {
    return request({
        url: `/api/${version}/boxorders/getBoxSurveyAnswer`,
        method: 'get',
        params: obj
    });
};

