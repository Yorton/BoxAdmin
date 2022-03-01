import request from '@/_utils/request';
import SubcribeListParamsModel from '@/models/box-management/box-service/SubcribeListParamsModel';
import SurveyAnswerParamsModel from '@/models/box-management/box-service/SurveyAnswerParamsModel';

const version = process.env.VUE_APP_API_VERSION;

export const GetSubscribeList = (obj: SubcribeListParamsModel) => {
    return request({
        url: `/api/${version}/boxservice/getSubscribeList`,
        method: 'get',
        params: obj
    });
};

export const GetSubscribeState = () => {
    return request({
        url: `/api/${version}/boxservice/getSubscribeState`,
        method: 'get',
        params: {}
    });
};

export const GetSubscribeDetailById = (id: string) => {
    return request({
        url: `/api/${version}/boxservice/${id}/getSubscribeDetailById`,
        method: 'get'
    });
};

export const GetSubscribeSurveyAnswer = (obj: SurveyAnswerParamsModel) => {
    return request({
        url: `/api/${version}/boxservice/getSubscribeSurveyAnswer`,
        method: 'get',
        params: obj
    });
};
