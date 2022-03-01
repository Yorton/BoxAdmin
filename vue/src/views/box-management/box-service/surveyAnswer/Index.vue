<template lang="pug">
div
    el-card(class="box-card")
        el-row
            el-col(style="text-align: right")
                 el-button(size="mini" type="primary" @click="onDetail") 返回明細
        <br/>        
        el-row
            el-col
                table.survey-table(border style="width: 100%;")
                    thead(style="text-align: center").survey-table__head
                        tr
                            th.survey-table__th 題目項
                            th.survey-table__th 題目項顯示
                            th.survey-table__th 子項顯示
                            th.survey-table__th 答案顯示
                    tbody.survey-table__body
                        <tr v-for="(item, key) in state.surveyAnswerList" :key="key">
                            <td>{{ item.no }}</td>
                            <td>{{ item.noName }}</td>
                            <td>{{ item.subNoName }}</td>
                            <td>{{ item.answer }}</td>
                        </tr>
                      
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';

import { GetSubscribeSurveyAnswer } from '@/_api/box-service.api';
import SurveyAnswerParamsModel from '@/models/box-management/box-service/SurveyAnswerParamsModel';
import SurveyAnswerResultModel from '@/models/box-management/box-service/SurveyAnswerResultModel';


export default defineComponent({
    name: 'BoxServiceSurveyAnswer',
    components: {},
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({

            reservationId: '',
            customerId: '',
            subscribeId: '',
            surveyAnswerType: '',

            surveyAnswerParamsObj: new SurveyAnswerParamsModel(),
            surveyAnswerList: new Array<SurveyAnswerResultModel>(),
        });

         const execQuery = async () => {
            try {
                 SetLoading(true);

                 state.surveyAnswerParamsObj.CustomerId = state.customerId;
                 state.surveyAnswerParamsObj.ReservationId = state.reservationId;
                 state.surveyAnswerParamsObj.SurveyAnswerType = state.surveyAnswerType;

                 const { data } = await GetSubscribeSurveyAnswer(state.surveyAnswerParamsObj);
                 state.surveyAnswerList = [...data.data];

            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        onMounted(() => {

            const customerId = route.query.customerId?.toString();
            if (customerId) {
                state.customerId = customerId;
            }

            const subscribeId = route.query.subscribeId?.toString();
            if (subscribeId) {
                state.subscribeId = subscribeId;
            }
    
            const surveyAnswerType = route.query.surveyAnswerType?.toString();
            if (surveyAnswerType) {
                state.surveyAnswerType = surveyAnswerType;
            }

            execQuery();
        });

        const onDetail = ()=>{

            const params = {
                detailSubscribeId: state.subscribeId,
                customerId: state.customerId
            };

            router.push({
                path: '/orders-management/box-service/detail',
                query: params
            });
        };

        return {
            state,
            onDetail
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