<template lang="pug">
.box-orders-member-info
    el-scrollbar
        h2.box-orders-member-info__title 會員資訊
        el-row
            el-col
                el-button(size="mini" type="primary" @click="onBack") 返回列表
        el-row.ob-mb-1.ob-mt-1
            .box-orders-member-info__item.ob-mr-1
                span.box-orders-member-info__item-label 會員帳號：
                span.box-orders-member-info__item-value 123564
            .box-orders-member-info__item.ob-mr-1
                span.box-orders-member-info__item-label 會員姓名：
                span.box-orders-member-info__item-value {{customerData.name}}
            .box-orders-member-info__item
                span.box-orders-member-info__item-label 暱稱：
                span.box-orders-member-info__item-value 美美
        el-row
            .box-orders-member-info__item.ob-mr-1
                span.box-orders-member-info__item-label 方案別：
                span.box-orders-member-info__item-value 
                    |季卡(
                    el-link(type="primary") 20201118001
                    |)
            .box-orders-member-info__item.ob-mr-1
                span.box-orders-member-info__item-label 訂閱效期：
                span.box-orders-member-info__item-value 2020/11/18~2021/02/18
            .box-orders-member-info__item
                span.box-orders-member-info__item-label BOX使用次數：
                span.box-orders-member-info__item-value 2/3
        el-row.ob-mt-1
            el-col.ob-mt-1(v-for="(item, index) in infoArr" :md="24" :lg="12" :key="`survey-${index}`")
                survey-table(:table-data="item")
</template>
<script lang="ts">
import { defineComponent, onMounted, reactive, inject, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

import { GetCustomer } from '@/_api/customer.api';
import CustomerModel from '@/models/customer/CustomerModel';

import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import BoxEditSurveyModel from '@/models/box-management/box-edit/BoxEditSurveyModel';
import SurveyGroupMode from '@/models/customer/SurveyGroupMode';
import SurveyTable from '@/components/common/survey-table/Index.vue';
export default defineComponent({
    name: 'BoxOrdersMembers',
    components: {
        SurveyTable
    },
    setup() {
        const route = useRoute();
        const router = useRouter();

        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const customerData = inject('customerData', ref(new CustomerModel()));
        const infoArr = ref(new Array<SurveyGroupMode>());

        const state = reactive({});

        // watch(
        //     customerData,
        //     async () => {

        //     },
        //     {
        //         immediate: true
        //     }
        // );

        const generateData = async () => {
            const qryCustomerId = route.query.qryCustomerId?.toString();
            if (qryCustomerId) {
                const { data } = await GetCustomer(qryCustomerId);
                customerData.value = data.data as CustomerModel;
            }

            console.log('BoxEditMemberInfo');
            if (!customerData.value.id) {
                return;
            }
            const surveyData1 = new SurveyGroupMode();
            surveyData1.groupName = '風格';
            surveyData1.items.push(new BoxEditSurveyModel('率性休閒', '喜歡'));
            surveyData1.items.push(new BoxEditSurveyModel('簡約質感', '普通'));
            surveyData1.items.push(
                new BoxEditSurveyModel(
                    '清新甜美',
                    '測試1：******<br>測試2：******<br>測試3：******'
                )
            );
            surveyData1.items.push(
                new BoxEditSurveyModel('平常購買品牌', 'SHIEIN、OB嚴選')
            );
            surveyData1.items.push(
                new BoxEditSurveyModel('喜歡穿什麼色系', '冷色系、大地色系')
            );

            const surveyData2 = new SurveyGroupMode();
            surveyData2.groupName = '風格';
            surveyData2.items.push(new BoxEditSurveyModel('率性休閒', '喜歡'));
            surveyData2.items.push(new BoxEditSurveyModel('簡約質感', '普通'));
            surveyData2.items.push(
                new BoxEditSurveyModel(
                    '清新甜美',
                    '測試1：******<br>測試2：******<br>測試3：******'
                )
            );
            surveyData2.items.push(
                new BoxEditSurveyModel('平常購買品牌', 'SHIEIN、OB嚴選')
            );
            surveyData2.items.push(
                new BoxEditSurveyModel('喜歡穿什麼色系', '冷色系、大地色系')
            );
            surveyData2.items.push(
                new BoxEditSurveyModel('喜歡穿什麼色系', '冷色系、大地色系')
            );
            surveyData2.items.push(
                new BoxEditSurveyModel('喜歡穿什麼色系', '冷色系、大地色系')
            );
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData2);
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData2);
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData2);
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData1);
            infoArr.value.push(surveyData1);
        };

        onMounted(() => {
            generateData();
        });

        const onBack = () => {
            router.push({
                path: '/orders-management/box-orders'
            });
        };

        return {
            state,
            onBack,
            boxData,
            customerData,
            infoArr
        };
    }
});
</script>
<style lang="scss">
.box-orders-member-info {
    position: relative;
    height: 94%;
    &__title {
        margin: 0;
    }
    &__item {
    }
    &__item-label {
    }
    &__item-value {
        color: blue;
    }
    &__col {
    }
}
</style>
