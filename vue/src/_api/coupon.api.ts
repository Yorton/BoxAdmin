import request from '@/_utils/request';
import CouponQueryParamsModel from '@/models/coupon/CouponQueryParamsModel';
import CouponSubmitParamsModel from '@/models/coupon/CouponSubmitParamsModel';
import CouponRemoveParamsModel from '@/models/coupon/CouponRemoveParamsModel';
import CouponDetailParamsModel from '@/models/coupon/CouponDetailParamsModel';

const version = process.env.VUE_APP_API_VERSION;
export const GetCoupons = (obj: CouponQueryParamsModel) => {
    return request({
        url: `/api/${version}/coupon/getcoupons`,
        method: 'get',
        params: obj
    });
};

export const GetCouponById = (id: string) => {
    return request({
        url: `/api/${version}/coupon/${id}/getcouponbyid`,
        method: 'get'
    });
};

export const GetCouponByType = (CouponType: number) => {
    return request({
        url: `/api/${version}/coupon/${CouponType}/getcouponbytype`,
        method: 'get'
    });
};

export const CouponSubmit = (submitModel: CouponSubmitParamsModel) => {
    return request({
        url: `/api/${version}/coupon/submit`,
        method: 'post',
        data: submitModel
    });
};

export const CouponRemove = (removeModel: CouponRemoveParamsModel) => {
    return request({
        url: `/api/${version}/coupon/remove`,
        method: 'post',
        data: removeModel
    });
};

export const GetCouponDetail = (obj: CouponDetailParamsModel) => {
    return request({
        url: `/api/${version}/coupon/getcoupondetail`,
        method: 'get',
        params: obj
    });
};

export const UploadMembersList = (data: {}) => {
    return request({
        url: `/api/${version}/coupon/uploadmemberslist`,
        method: 'post',
        data: data
    });
};
