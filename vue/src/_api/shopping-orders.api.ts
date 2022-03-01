import request from '@/_utils/request';
import OrderListParamsModel from '@/models/box-management/shopping-orders/OrderListParamsModel';

const version = process.env.VUE_APP_API_VERSION;

export const GetOrderStateList = () => {
    return request({
        url: `/api/${version}/order/getorderstates`,
        method: 'get'
    });
};

export const GetOrderList = (obj: OrderListParamsModel) => {
    return request({
        url: `/api/${version}/order/getorders`,
        method: 'get',
        params: obj
    });
};

export const GetOrderInfo = (transactionNo: string) => {
    return request({
        url: `/api/${version}/order/${transactionNo}/detail`,
        method: 'get'
    });
};
