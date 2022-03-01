<template lang="pug">
.box-orders-detail
    el-scrollbar
        el-row
            el-col(:span="8")
                el-button(size="mini" type="primary" @click="onSurveyAnswerA") 查看問卷A
                el-button(size="mini" type="primary" @click="onSurveyAnswerB") 查看問卷B
                el-button(size="mini" type="primary" @click="onSurveyAnswerC") 查看問卷C
                el-row
                    el-col
                        table.survey-table(border style="margin-top: 1%;")
                            tbody.survey-table__body
                                tr
                                    td.survey-table__td BOX編號
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.boxNo}` }}
                                tr
                                    td.survey-table__td 購物訂單編號
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.transactionNo}` }}
                                tr
                                    td.survey-table__td BOX退貨單號
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.returnNo}` }}
                                tr
                                    td.survey-table__td 會員ID
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.customerId}` }}
                                tr
                                    td.survey-table__td 會員姓名
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.customerName}` }}
                                tr
                                    td.survey-table__td 手機號碼
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.mobile}` }}
                                tr
                                    td.survey-table__td 搭配師
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.matchmakerName}` }}
                                tr
                                    td.survey-table__td 期望配送時間
                                    td.survey-table__td {{ `${state.detailResultObj.mainReservationData.deliveryExpected}` }}
            el-col(:span="1")
            el-col(:span="8")
                 table.survey-table(border style="margin-top: 1%;")
                            tbody.survey-table__body
                                tr
                                    td.survey-table__td BOX啟用(預約完成)時間
                                    td.survey-table__td BOX啟用(預約完成)時間
                                tr
                                    td.survey-table__td 待預覽期限
                                    td.survey-table__td {{ `${state.detailResultObj.timeRecordsData.previewDueDate}` }}
                                tr
                                    td.survey-table__td 表態完成時間
                                    td.survey-table__td 表態完成時間
                                tr
                                    td.survey-table__td 出貨時間
                                    td.survey-table__td {{ `${state.detailResultObj.timeRecordsData.shipDate}` }}
                                tr
                                    td.survey-table__td 配達時間
                                    td.survey-table__td 配達時間
                                tr
                                    td.survey-table__td 試穿期限
                                    td.survey-table__td {{ `${state.detailResultObj.timeRecordsData.tryonExpire }` }}
                                tr
                                    td.survey-table__td 選購付款時間
                                    td.survey-table__td {{ `${state.detailResultObj.timeRecordsData.orderDateTime }` }}
                                tr
                                    td.survey-table__td 申請退回時間
                                    td.survey-table__td {{ `${state.detailResultObj.timeRecordsData.returnTime }` }}
                                tr
                                    td.survey-table__td 退回檢視完成時間
                                    td.survey-table__td 退回檢視完成時間
        el-row
            el-col
                <el-collapse v-model="state.productContent" style="margin-top: 1%;" accordion>
                    <el-collapse-item title="預覽商品內容" name="1">
                        el-table(:data="state.detailResultObj.productsPreviewData" small border stripe class="table__wrapper border-light" style="box-shadow: none" :cell-style="tableCellStyle")
                            el-table-column(label="商品圖")
                                template(#default="{row}")
                                    el-image(v-if="row.picture!=''" :src="row.picture" style="width: 120px;")
                            el-table-column(prop="sku" label="商品編號")
                            el-table-column(prop="productName" label="商品名稱")
                            el-table-column(prop="productSpec" label="商品規格")
                            el-table-column(prop="productNoted" label="商品註記")
                    </el-collapse-item>
                    <el-collapse-item title="出貨商品內容" name="2">
                         el-table(:data="state.detailResultObj.productsShipmentData" small border stripe class="table__wrapper border-light" style="box-shadow: none" :cell-style="tableCellStyle")
                            el-table-column(label="商品圖")
                                template(#default="{row}")
                                    el-image(v-if="row.picture!=''" :src="row.picture" style="width: 120px;")
                            el-table-column(prop="sku" label="商品編號")
                            el-table-column(prop="productName" label="商品名稱")
                            el-table-column(prop="productSpec" label="商品規格")
                            el-table-column(prop="price" label="價格")
                            el-table-column(label="購買/退回")
                                template(#default="{row}")
                                    span(:style="{'color': row.refundNoted=='退回' ? 'red' : 'black'}") {{ `${row.refundNoted }` }}
                    </el-collapse-item>
                </el-collapse>   
        el-row
            el-col(style="text-align: center;")
                 el-button(size="mini" type="primary" @click="onBack") 返回列表
          
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';

import { GetBoxDetailById } from '@/_api/box-orders.api';
import BoxDetailResultModel from '@/models/box-management/box-orders/BoxDetailResultModel';

//import { Swiper, SwiperSlide } from 'swiper/vue';
//import 'swiper/swiper.scss';

export default defineComponent({
    name: 'BoxOrdersDetail',
    components: {
        //Swiper,
        //SwiperSlide
    },
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            
            productContent: '1',

            customerId: '',
            reservationId: '',

            //資料
            detailResultObj: new BoxDetailResultModel()
        });

        const getDetailData = async (id: string) => {
            SetLoading(true);

            const [detailData] = await Promise.all([GetBoxDetailById(id)]);

            SetLoading();

            state.detailResultObj = detailData.data.data;
        };

        onMounted(() => {
            const reservationId = route.query.reservationId?.toString();
            if (reservationId) {
                state.reservationId = reservationId;
                getDetailData(reservationId);
            }

            const customerId = route.query.customerId?.toString();
            if (customerId) {
                state.customerId = customerId;
            }
        });

        const onBack = () => {
            router.push({
                path: '/orders-management/box-orders'
            });
        };

        const surveyAnswer = (type: string) => {

            const params = {
                reservationId: state.reservationId,
                customerId: state.customerId,
                surveyAnswerType: type
            };

            router.push({
                path: '/orders-management/box-orders/surveyanswer',
                query: params
            });
        };

        const onSurveyAnswerA = () =>{
            surveyAnswer('A');
        };

        const onSurveyAnswerB = () =>{
            surveyAnswer('B');
        };

        const onSurveyAnswerC = () =>{
            surveyAnswer('C');
        };

        const tableCellStyle = () => 'padding: 5px 0';

        return {
            state,
            onBack,
            onSurveyAnswerA,
            onSurveyAnswerB,
            onSurveyAnswerC,
            tableCellStyle
        };
    }
});
</script>

<style lang="scss">
.box-orders-detail {
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

.survey-table {
    border-collapse: collapse;
    width: 100%;
    font-size: 14px;
    line-height: 20px;
    text-align: left;
    &__head {
        background: #ccc;
    }
    &__th,
    &__td {
        padding: 5px;
    }
}
</style>
