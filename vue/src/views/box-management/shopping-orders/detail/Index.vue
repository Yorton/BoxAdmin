<template lang="pug">
div
    el-card(class="box-card")
        template(#header)
            div(class="card-header")
                span 購物訂單管理-明細  
        el-row
            el-col(:span="8")
                table.survey-table(border style="width: 80%;")
                    tbody.survey-table__body
                        tr
                            td.survey-table__td 購物訂單編號
                            td.survey-table__td {{ `${state.orderInfo.transactionNo}` }}
                        tr
                            td.survey-table__td Box編號
                            td.survey-table__td {{ `${state.orderInfo.boxNo}` }}
                        tr
                            td.survey-table__td 會員ID
                            td.survey-table__td {{ `${state.orderInfo.customerId}` }}
                        tr
                            td.survey-table__td 會員姓名
                            td.survey-table__td {{ `${state.orderInfo.customerName}` }}
                        tr
                            td.survey-table__td 手機號碼
                            td.survey-table__td {{ `${state.orderInfo.mobile}` }}
                        tr
                            td.survey-table__td 付款方式
                            td.survey-table__td {{ `${state.orderInfo.payTypeName}` }}
                        tr
                            td.survey-table__td 發票開立
                            td.survey-table__td {{ `${state.orderInfo.invDeviceCode}` }} ({{ `${state.orderInfo.invDeviceName}` }})
            el-col(:span="8")
                table.survey-table(style="width: 80%;")
                    tr
                        td(:colspan="2" style="text-aligen: left;").survey-table__td 
                            div(style="border-width:3px;border-style:solid;padding:5px;width: 90px;") 收件人資訊
                    tr
                        td.survey-table__td 姓名
                        td.survey-table__td {{ `${state.orderInfo.ordererName}` }}
                    tr
                        td.survey-table__td 電話
                        td.survey-table__td {{ `${state.orderInfo.ordererMobile}` }}
                    tr
                        td.survey-table__td 地址
                        td.survey-table__td {{ `${state.orderInfo.zip}${state.orderInfo.city}${state.orderInfo.region}${state.orderInfo.address}` }}
                    tr(v-if="state.orderInfo.isReturn")
                        td(:colspan="2" style="text-aligen: left;").survey-table__td 
                            div(style="border-width:3px;border-style:solid;padding:5px;width: 100px;") Box退貨資訊
                    tr(v-if="state.orderInfo.isReturn")
                        td.survey-table__td BOX退貨單號
                        td.survey-table__td {{ `${state.orderInfo.rtnNo}` }}
                    tr(v-if="state.orderInfo.isReturn")
                        td.survey-table__td 鑑賞退貨單號
                        td.survey-table__td
            el-col(:span="8")  
                table.survey-table(border style="width: 80%;")
                    tr
                        td.survey-table__td 成立時間
                        td.survey-table__td {{ `${state.orderInfo.createTime}` }}
                    tr
                        td.survey-table__td 預覽截止時間
                        td.survey-table__td {{ `${state.orderInfo.previewDueDate}` }}
                    tr
                        td.survey-table__td 出貨時間
                        td.survey-table__td {{ `${state.orderInfo.shipDate}` }}
                    tr
                        td.survey-table__td 到貨時間
                        td.survey-table__td {{ `${state.orderInfo.devileryTime}` }}
                    tr
                        td.survey-table__td 付款時間
                        td.survey-table__td {{ `${state.orderInfo.orderTime}` }}
                    tr
                        td.survey-table__td 鑑賞期
                        td.survey-table__td {{ `${state.orderInfo.appreciationTime}` }}
                    tr(v-if="state.orderInfo.isReturn")
                        td.survey-table__td 退貨申請時間
                        td.survey-table__td {{ `${state.orderInfo.returnApplyTime}` }}
                    tr(v-if="state.orderInfo.isReturn")
                        td.survey-table__td 退貨完成時間
                        td.survey-table__td {{ `${state.orderInfo.rtnDate}` }}
    el-card(class="box-card")
        el-table(:data="state.orderInfo.details" small border stripe class="table__wrapper border-light" style="box-shadow: none")
            el-table-column(prop="" label="商品圖")
                template(#default="{row}")
                    Image(:path="row.imagePath")
            el-table-column(prop="sku" label="商品編號")
            el-table-column(prop="skuName" label="商品名稱")
            el-table-column(prop="" label="商品規格")
                template(#default="{row}") {{ `${row.color}.${row.size}` }}
            el-table-column(prop="stateName" label="狀態")
            el-table-column(prop="sellingPrice" label="單價")
        div(class="el-table--fit el-table--striped el-table--border el-table--enable-row-hover el-table--enable-row-transition el-table table__wrapper border-light")
            div(class="el-table__footer-wrapper")
                table(class="el-table__footer" cellspacing="0" cellpadding="0" border="0" style="width: 100%;")
                    tr
                        td(colspan="5" style="text-align: right") 
                            div(class="cell") 小計
                        td 
                            div(class="cell") {{ `${state.orderInfo.detailsSum}` }}
                    tr(v-if="state.orderInfo.isReturn")
                        td(colspan="5" style="text-align: right") 
                            div(class="cell") 退貨折讓(商品)
                        td 
                            div(class="cell") 0
                    tr(v-if="state.orderInfo.isReturn")
                        td(colspan="5" style="text-align: right") 
                            div(class="cell") 退貨折讓(Box折抵)
                        td 
                            div(class="cell") 0
                    tr(v-if="state.orderInfo.isReturn")
                        td(colspan="5" style="text-align: right") 
                            div(class="cell") 退貨折讓(折價券)
                        td 
                            div(class="cell") 0
                    tr
                        td(colspan="5" style="text-align: right") 
                            div(class="cell") 總額
                        td 
                            div(class="cell") {{ `${state.orderInfo.totalPrice}` }}
    el-row(style="margin-top: 20px;")
        el-col(style="text-align: center") 
            el-button(size="mini" type="primary" @click="handleBack") 返回列表
</template>
<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import OrderInfoResultModel from '@/models/box-management/shopping-orders/OrderInfoResultModel';
import { GetOrderInfo } from '@/_api/shopping-orders.api';
import { formatDate } from '@/_utils/common';
import Image from '@/components/Image.vue';
export default defineComponent({
    name: 'ShoppingOrderDetail',
    components: { Image },
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            orderInfo: new OrderInfoResultModel()
        });

        const getOrderInfo = async (transactionNo: string) => {
            const { data } = await GetOrderInfo(transactionNo);
            console.log(data);
            state.orderInfo = data.data.orderInfo;
            state.orderInfo.createTime = formatDate(
                state.orderInfo.createTime,
                'YYYY-MM-DD'
            );
            state.orderInfo.previewDueDate = formatDate(
                state.orderInfo.previewDueDate,
                'YYYY-MM-DD'
            );
            state.orderInfo.shipDate = formatDate(
                state.orderInfo.shipDate,
                'YYYY-MM-DD'
            );
            state.orderInfo.devileryTime = formatDate(
                state.orderInfo.devileryTime,
                'YYYY-MM-DD'
            );
            state.orderInfo.orderTime = formatDate(
                state.orderInfo.orderTime,
                'YYYY-MM-DD'
            );
            state.orderInfo.appreciationTime = formatDate(
                state.orderInfo.appreciationTime,
                'YYYY-MM-DD'
            );
            state.orderInfo.returnApplyTime = formatDate(
                state.orderInfo.returnApplyTime,
                'YYYY-MM-DD'
            );
            state.orderInfo.rtnDate = formatDate(
                state.orderInfo.rtnDate,
                'YYYY-MM-DD'
            );
            state.orderInfo.details = data.data.details;

            let sum = 0;
            state.orderInfo.details.map(item => {
                sum += item.sellingPrice;
            });
            state.orderInfo.detailsSum = sum;
        };

        const handleBack = () => {
            router.push({
                path: '/orders-management/shopping-orders'
            });
        };

        onMounted(() => {
            const transactionNo = route.query.transactionNo?.toString();
            if (transactionNo) {
                getOrderInfo(transactionNo);
            }
        });

        return {
            state,
            handleBack
        };
    }
});
</script>
<style lang="scss">
.survey-table {
    border-collapse: collapse;
    width: 100%;
    font-size: 14px;
    line-height: 20px;
    &__head {
        background: #ccc;
    }
    &__th,
    &__td {
        padding: 5px;
    }
}
</style>
