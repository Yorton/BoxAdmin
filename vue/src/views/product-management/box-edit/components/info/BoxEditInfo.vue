<template lang="pug">
.box-edit-info
    el-scrollbar
        h3 本次BOX需求 
        el-row
            el-col
                el-link(type='primary') BOX ID：{{boxData.boxNo}}
                .box-edit-info__survey.ob-mt-1
                    span.box-edit-info__survey-title 配送地區：
                    span.box-edit-info__survey-answer {{boxData.recipient.city}} {{boxData.recipient.region}}
                .box-edit-info__survey.ob-mt-1(v-for="(item, index) in boxData.surveys" :key="`survey-${index}`")
                    span.box-edit-info__survey-title {{item.title}}：
                    span.box-edit-info__survey-answer {{item.answer}}
        el-divider.ob-mt-1.ob-mb-1
        el-row.ob-mb-2
            el-col
                h3.ob-mt-1.ob-mb-1 會員資訊
                .ob-align-center.ob-mb-1
                    el-button(size="mini" type="primary") 訂單查詢
                    el-button(size="mini" type="primary") 客服紀錄
                    el-button(size="mini" type="primary") 折價劵
                .box-edit-info__member-picture
                    swiper(
                        :slides-per-view='1' 
                        @swiper="onSwiper"
                        @slideChange="onSlideChange"
                    )
                        swiper-slide 
                            image-box(src="https://picsum.photos/250/300?random=1")
                        swiper-slide 
                            image-box(src="https://picsum.photos/250/300?random=2")
                        swiper-slide 
                            image-box(src="https://picsum.photos/250/300?random=3")
        el-row
            el-col
                survey-table(
                    v-for="(item, index) in infoArr"
                    :key="`survey-table-${index}`" 
                    :table-data="item"
                )
</template>
<script lang="ts">
import { defineComponent, inject, ref, watch } from 'vue';
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper.scss';
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import CustomerModel from '@/models/customer/CustomerModel';
import SurveyGroupMode from '@/models/customer/SurveyGroupMode';
import BoxEditSurveyModel from '@/models/box-management/box-edit/BoxEditSurveyModel';
import ImageBox from '@/components/common/image-box/Index.vue';
import SurveyTable from '@/components/common/survey-table/Index.vue';
export default defineComponent({
    name: 'BoxEditInfo',
    components: {
        Swiper,
        SwiperSlide,
        ImageBox,
        SurveyTable
    },
    setup() {
        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const customerData = inject('customerData', ref(new CustomerModel()));
        const infoArr = ref(new Array<SurveyGroupMode>());
        const onSwiper = (swiper: unknown) => {
            console.log(swiper);
        };
        const onSlideChange = () => {
            console.log('slide change');
        };

        watch(customerData, () => {
            console.log('BoxEditInfo');
            if (!customerData.value.id) {
                return;
            }
            const age =
                new Date().getFullYear() -
                new Date(customerData.value.birthday).getFullYear();
            const surveyData1 = new SurveyGroupMode();
            surveyData1.groupName = '個人';
            surveyData1.items.push(
                new BoxEditSurveyModel(
                    '生日',
                    customerData.value.birthday.split('T')[0]
                )
            );
            surveyData1.items.push(new BoxEditSurveyModel('年齡', String(age)));
            surveyData1.items.push(
                new BoxEditSurveyModel(
                    '工作類型',
                    '產業：金融<br>職能：財會<br>管理職：否'
                )
            );
            surveyData1.items.push(new BoxEditSurveyModel('婚姻狀態', '未婚'));
            surveyData1.items.push(new BoxEditSurveyModel('小孩', '無'));
            infoArr.value.push(surveyData1);
        });
        return {
            boxData,
            infoArr,
            onSwiper,
            onSlideChange
        };
    }
});
</script>
<style lang="scss">
.box-edit-info {
    position: relative;
    height: 100%;
    border-right: 1px solid #eee;
    &__survey {
        font-size: 12px;
        display: flex;
        align-items: stretch;
        &-title {
            white-space: nowrap;
        }
    }
    &__member-picture {
        position: relative;
        width: 250px;
        margin: 0 auto;
    }
}
</style>
