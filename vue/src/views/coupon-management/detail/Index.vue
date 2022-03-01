<template lang="pug">


.coupon-detail.ob-container
    el-row
        <el-form class="coupon-detail__search-bar">
            <el-form-item label="">
                <el-row>
                    <el-col> 
                        <el-button size="medium" type="primary" @click="backToHome">回列表頁</el-button>
                    </el-col>
                </el-row>
            </el-form-item> 
            <el-form-item label="">
                <el-row>
                    <el-col :span="2">
                        span.coupon-detail__span_bold Coupon ID
                    </el-col>
                    <el-col :span="3"><el-input v-model="state.paramsObj.Id" style="margin-left: -10%"></el-input></el-col>
                    <el-col :span="2">
                        span &emsp;
                        span.coupon-detail__span_bold Coupon 名稱
                    </el-col>
                    <el-col :span="4"><el-input v-model="state.paramsObj.Name" ></el-input></el-col>
                </el-row>
            </el-form-item>
            <el-form-item label="" class="coupon-detail__search-item">
                el-button(size='medium' type='primary' icon='el-icon-search' @click="onQuery") 查詢
            </el-form-item>
        </el-form>
    el-row
        <el-form class="coupon-detail__search-result">
            <el-form-item label="">
                <el-row>
                    <el-col :span="6">
                        span.coupon-detail__span_bold Coupon活動時間
                        span &emsp;{{ `${state.marketingActivityDate}` }} 
                    </el-col>
                    <el-col :span="4">
                        span.coupon-detail__span_bold 產出類型 
                        span &emsp;{{ `${state.outputTypeName}` }}
                    </el-col>
                 
                </el-row>
            </el-form-item>
            <el-form-item label="">
                <el-row>
                    <el-col :span="1"> 
                        span.coupon-detail__span_bold 使用狀態
                    </el-col>
                    <el-col :span="4">
     
                        el-row
                            el-col
                                span 已產生{{ `${state.producedCount}` }}筆
                        el-row
                            el-col
                                span 已領取{{ `${state.receivedCount}` }}筆
                        el-row
                            el-col
                                span 已使用{{ `${state.usedCount}` }}筆
                    </el-col>
                  
                </el-row>
            </el-form-item>
        </el-form>

    el-row
        el-table.coupon-detail__table(:data="state.list" border stripe)
            el-table-column(prop="specialCode" label="Coupon Code")
            el-table-column(prop="customerId" label="會員帳號" sortable)
            el-table-column(prop="receivedDate" label="領取時間" sortable)
            el-table-column(prop="canUseDate" label="可以使用的時間" sortable)
            el-table-column(prop="usedDate" label="實際使用時間" sortable)
            el-table-column(prop="transactionId" label="使用訂單" sortable)
            el-table-column(prop="transactionId" label="來源訂單" sortable)

           
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { ElMessageBox } from 'element-plus';

import { GetCouponDetail } from '@/_api/coupon.api';
import CouponDetailParamsModel from '@/models/coupon/CouponDetailParamsModel';
import CouponDetailListModel from '@/models/coupon/CouponDetailListModel';
import { useRoute, useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';

export default defineComponent({
    name: 'CouponDetail',
    components: {},
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            paramsObj: new CouponDetailParamsModel(),
            list: new Array<CouponDetailListModel>(),
            marketingActivityDate: '',
            outputTypeName: '',
            producedCount: 0,
            receivedCount: 0,
            usedCount: 0
        });

        const execQuery = async () => {
            try {
                SetLoading(true);

                const { data } = await GetCouponDetail(state.paramsObj);

                state.list = [...data.data.couponDetailList];
                state.marketingActivityDate = data.data.marketingActivityDate;
                state.outputTypeName = data.data.outputTypeName;
                state.producedCount = data.data.producedCount;
                state.receivedCount = data.data.receivedCount;
                state.usedCount = data.data.usedCount;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        onMounted(() => {
            const Id = route.query.Id?.toString();
            if (Id) {
                state.paramsObj.Id = Id;
            }

            execQuery();
        });

        const isValid = () => {
            if (state.paramsObj.Id == '' && state.paramsObj.Name == '') {
                ElMessageBox.alert('必需有查詢條件才能進行');
                return false;
            }

            return true;
        };

        const onQuery = () => {
            if (!isValid()) return;

            execQuery();
        };

        const backToHome = () => {
            router.push({
                path: '/coupon-management/query'
            });
        };

        return {
            state,
            onQuery,
            backToHome
        };
    }
});
</script>

<style lang="scss">
@import '@/styles/element-variables.scss';
.coupon-detail {
    &__search-bar {
        width: 100%;
        border: $--table-border;
        padding: 10px 5px;
    }
    &__search-item {
        float: right;
        margin-bottom: 0;
    }
    &__table {
        margin-top: 30px;
    }
    &__search-result {
        width: 100%;
    }
    &__span_bold {
        font-weight: bold;
    }
}
</style>
