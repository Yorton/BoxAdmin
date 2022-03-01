<template lang="pug">
div(style="padding: 0px")
    el-card(class="box-card" shadow="never")
        template(#header)
            div(class="card-header")
                span 服務訂單管理-明細
        div(style="margin-bottom: 20px")
            el-form
                el-row(style="margin-bottom: 2%;")
                    el-col(:span="10")
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 服務訂單編號
                            el-col(:span="16")                                        
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.subscribeNo}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 會員ID 
                            el-col(:span="16")   
                                span &emsp;  
                                el-link(@click="onMember($event)") {{ `${state.subscribeDetail.mainSubscribeData.customerId}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 會員姓名 
                            el-col(:span="16")      
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.customerName}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 申請暫停 
                            el-col(:span="16")    
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.suspendName}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 成立方式
                            el-col(:span="18")    
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.createdMethodName}` }} 
                                span {{ `${state.openParenthesis}` }}
                                el-link(@click="onTransactionNo($event)") {{`${state.sourceTransactionNo}`}}
                                span {{ `${state.closeParenthesis}` }}
                               
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 成立時間
                            el-col(:span="16")  
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.createdMethodTime}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 付款方式
                            el-col(:span="16")
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.paymentWay}` }}
                        el-row(style="margin-bottom: 1%;")
                            el-col(:span="6" style="text-align: right")
                                span 發票開立
                            el-col(:span="16")
                                span &emsp; {{ `${state.subscribeDetail.mainSubscribeData.invoicing}` }}
                    el-col(:span="1")
                    el-col(:span="8")
                         el-button(size="mini" type="primary" @click="onSurveyAnswerA") 查看問卷A
                         el-row
                            el-col
                                table.survey-table(border style="margin-top: 1%;")
                                    tbody.survey-table__body
                                        tr
                                            td(colspan="2").survey-table__td 訂閱方案
                                            td.survey-table__td 價格
                                        tr
                                            td(colspan="2").survey-table__td 季卡
                                            td.survey-table__td {{ `${state.subscribeDetail.subscribeInfoData.planPrice}` }}
                                        tr
                                            td.survey-table__td 
                                            td(style="width: 35%").survey-table__td 折價券
                                            td(style="width: 35%").survey-table__td {{ `${state.subscribeDetail.subscribeInfoData.discountQuantity}` }}
                                        tr
                                            td.survey-table__td 
                                            td(style="width: 35%").survey-table__td 加盒券
                                            td(style="width: 35%").survey-table__td {{ `${state.subscribeDetail.subscribeInfoData.boxAddedQuantity}` }}
                                        tr
                                            td.survey-table__td 
                                            td(style="width: 35%").survey-table__td 付款金額
                                            td(style="width: 35%").survey-table__td {{ `${state.subscribeDetail.subscribeInfoData.paymentAmount}` }}
                el-row(style="margin-bottom: 2%;")
                    el-col
                        el-table(:data="state.subscribeDetail.boxReservationData" small border stripe class="table__wrapper border-light" style="box-shadow: none" :cell-style="tableCellStyle")
                            el-table-column(prop="boxNo" label="BOX編號")
                                template(#default="{row}")
                                    el-link(@click="onBoxNo(row, $event)") {{row.boxNo}}
                                
                            el-table-column(prop="reservationDueTime" label="預約完成時間")
                            el-table-column(prop="status" label="狀態")  
                el-row(style="margin-bottom: 2%;")
                    el-col(style="text-align: center") 
                        el-button(size="mini" type="primary" @click="onBack") 返回列表

</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { useRoute, useRouter } from 'vue-router';

import { GetSubscribeDetailById } from '@/_api/box-service.api';
import SubscribeDetailResultModel from '@/models/box-management/box-service/SubscribeDetailResultModel';
import BoxReservationModel from '@/models/box-management/box-service/BoxReservationModel';

export default defineComponent({
    name: 'BoxServiceDetail',
    components: {},
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            openParenthesis: '',
            closeParenthesis: '',
            sourceTransactionNo: '',

            subscribeId:'',
            customerId: '',

            subscribeDetail: new SubscribeDetailResultModel()
        });

        const getSubscribeDetailData = async (id: string) => {
            const { data } = await GetSubscribeDetailById(id);
            state.subscribeDetail = data.data;

            if (
                state.subscribeDetail.mainSubscribeData.sourceTransactionNo !=
                    '' &&
                state.subscribeDetail.mainSubscribeData.createdMethodName ==
                    '自動續約'
            ) {
                state.sourceTransactionNo =
                    state.subscribeDetail.mainSubscribeData.sourceTransactionNo;
                state.openParenthesis = '(';
                state.closeParenthesis = ')';
            }
        };

        onMounted(() => {
            const subscribeId = route.query.detailSubscribeId?.toString();
            if (subscribeId) {
                state.subscribeId = subscribeId;
                getSubscribeDetailData(subscribeId);
            }

            const customerId = route.query.customerId?.toString();
            if (customerId) {
                state.customerId = customerId;
            }
        });

        const onMember = (e: MouseEvent) => {
            // alert("box客戶資料查詢");

            e.preventDefault();
        };

        const onBack = () => {
            router.push({
                path: '/orders-management/box-service'
            });
        };

        const onBoxNo = (item: BoxReservationModel, e: MouseEvent) => {
            e.preventDefault();
        };

        const onTransactionNo = (e: MouseEvent) => {
            e.preventDefault();
        };

         const surveyAnswer = (type: string) => {

            const params = {
                customerId: state.customerId,
                subscribeId: state.subscribeId,
                surveyAnswerType: type
            };

            router.push({
                path: '/orders-management/box-service/surveyanswer',
                query: params
            });
        };

        const onSurveyAnswerA = () =>{
            surveyAnswer('A');
        };

        return {
            state,
            onMember,
            onBack,
            onBoxNo,
            onTransactionNo,
            onSurveyAnswerA
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
    /*text-align: left;*/
    &__head {
        background: #ccc;
    }
    &__th,
    &__td {
        text-align: center;
        padding: 5px;
    }
}
</style>
