<template lang="pug">

coupon-type(v-model:visible="state.couponTypeVisible" @on-select="onSelectCouponType")

.coupon-query.ob-container
    el-row
        <el-form class="coupon-query__search-bar">
            <el-form-item label="">
                <el-row>
                    <el-col :span="2">
                        span.coupon-query__span_bold Coupon 名稱
                    </el-col>
                    <el-col :span="3"><el-input v-model="state.paramsObj.CouponName"></el-input></el-col>
                    <el-col :span="3">
                        span &emsp;
                        span.coupon-query__span_bold Coupon 活動時間
                    </el-col>
                    <el-col :span="10">
                        <el-date-picker v-model="state.paramsObj.MarketingActivityStartDate" type="date" value-format="yyyy-MM-dd" style="width:30%;"></el-date-picker>
                        span &nbsp;～&nbsp;
                        <el-date-picker v-model="state.paramsObj.MarketingActivityEndDate" type="date" value-format="yyyy-MM-dd" style="width:30%;"></el-date-picker>
                    </el-col>
                </el-row>
            </el-form-item>
            <el-form-item label="">
                <el-row>
                    <el-col :span="1">
                        span.coupon-query__span_bold 狀態
                    </el-col>
                    <el-col :span="6">
                        <el-radio-group v-model="state.paramsObj.StatusType">
                            el-radio(v-for="(item, index) in state.statusTypeOptions" :label="item.label" :value="item.value" @change="onChange($event)" :key="`statusType-${index}`") 
                        </el-radio-group>
                    </el-col>
                </el-row>
            </el-form-item>
            <el-form-item label="" class="coupon-query__search-item">
                el-button(size='medium' type='primary'  @click="onAdd" ) 新增
                el-button(size='medium' type='primary' icon='el-icon-search' @click="onQuery") 查詢
            </el-form-item>
        </el-form>

    el-row
        
        el-table.coupon-query__table(:data="state.list.slice((state.page-1)*state.pageSize,state.page*state.pageSize)" border stripe)
            el-table-column(prop="id" label="Coupon ID" sortable)
            el-table-column(prop="couponName" label="Coupon 名稱" sortable)
            el-table-column(prop="couponTypeName" label="類型" sortable)
            el-table-column(prop="marketingActivityStartDate" label="活動時間開始日" sortable)
            el-table-column(prop="marketingActivityEndDate" label="活動時間結束日" sortable)
            el-table-column(prop="canUseStartDate" label="可以使用開始日" sortable)
            el-table-column(prop="canUseEndDate" label="可以使用結束日" sortable)
            el-table-column(prop="cartTypeName" label="優惠項目")
            el-table-column(prop="discountContentTypeName" label="優惠內容")
            el-table-column(prop="status" label="狀態")
            el-table-column(prop="" label="功能")
                template(#default="{row}")
                    el-button(size='mini' type="primary" @click="onEdit(row)") 編輯
                    el-button(size='mini' type="primary" @click="onDetail(row)") 明細

        div(style="text-align: center;margin-top: 1%; margin-left: 25%;")
            el-pagination(background layout="prev, pager, next, sizes"  
                            :total="state.total" 
                            :page-sizes="[10, 25, 50]"
                            :page-size="state.pageSize"
                            :current-page="state.page" 
                            @size-change="onSizeChange"
                            @current-change="onCurrentChange")
        

           
</template>

<script lang="ts">
import { defineComponent, onMounted, onBeforeMount, reactive } from 'vue';

import { GetCoupons } from '@/_api/coupon.api';
import CouponQueryParamsModel from '@/models/coupon/CouponQueryParamsModel';
import CouponQueryResultModel from '@/models/coupon/CouponQueryResultModel';
import { useRoute, useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';

import CouponType from '../coupon-type/index.vue';

export default defineComponent({
    name: 'CouponQuery',
    components: {
        CouponType
    },
    setup() {
        const router = useRouter();

        const state = reactive({
            paramsObj: new CouponQueryParamsModel(),
            list: new Array<CouponQueryResultModel>(),
            couponTypeVisible: false,

            statusTypeOptions: [
                {
                    value: '1',
                    label: '尚未開始'
                },
                {
                    value: '2',
                    label: '進行中'
                },
                {
                    value: '3',
                    label: '已結束'
                }
            ],

            total: 0,
            page: 0,
            pageSize: 0
        });

        const formatDate = (marketingActivityDate: string) => {
            const date = new Date(marketingActivityDate);

            return (
                date.getFullYear() +
                '-' +
                (date.getMonth() + 1 >= 10
                    ? date.getMonth() + 1
                    : '0' + (date.getMonth() + 1)) +
                '-' +
                (date.getDate() >= 10 ? date.getDate() : '0' + date.getDate())
            );
        };

        const execQuery = async () => {
            try {
                SetLoading(true);

                if (
                    state.paramsObj.MarketingActivityStartDate != null &&
                    state.paramsObj.MarketingActivityStartDate != ''
                ) {
                    state.paramsObj.MarketingActivityStartDate = formatDate(
                        state.paramsObj.MarketingActivityStartDate
                    );
                }

                if (
                    state.paramsObj.MarketingActivityEndDate != null &&
                    state.paramsObj.MarketingActivityEndDate != ''
                ) {
                    state.paramsObj.MarketingActivityEndDate = formatDate(
                        state.paramsObj.MarketingActivityEndDate
                    );
                }

                //elememt-ui radio label即為值(與正常觀念不同),所以需轉換處理
                const tmpStatusType = state.paramsObj.StatusType;
                if (state.paramsObj.StatusType == '尚未開始')
                    state.paramsObj.StatusType = '1';
                if (state.paramsObj.StatusType == '進行中')
                    state.paramsObj.StatusType = '2';
                if (state.paramsObj.StatusType == '已結束')
                    state.paramsObj.StatusType = '3';

                const { data } = await GetCoupons(state.paramsObj);

                state.paramsObj.StatusType = tmpStatusType;

                state.list = [...data.data];

                //優惠項目-複選值處理
                for (let i = 0; i < state.list.length; i++) {
                    const item = state.list[i];
                    item.cartTypeName = '';

                    if (item.cartType.includes('1')) {
                        item.cartTypeName += '服務訂單(服務方案),';
                    }
                    if (item.cartType.includes('2')) {
                        item.cartTypeName += '商品訂單(盒內商品),';
                    }
                    if (item.cartType.includes('3')) {
                        item.cartTypeName += '商品訂單(直購),';
                    }

                    if (item.cartTypeName != '')
                        item.cartTypeName = item.cartTypeName.substr(
                            0,
                            item.cartTypeName.length - 1
                        );
                }

                state.total = state.list.length;
                state.page = 1;
                state.pageSize = 10;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        const getSearchParams = () => {
            const searchObjJsonStr = sessionStorage.getItem('couponSearchObj');
            if (searchObjJsonStr != null) {
                const searchObj = JSON.parse(searchObjJsonStr || '{}');

                state.paramsObj.CouponName = searchObj.CouponName;
                state.paramsObj.MarketingActivityStartDate =
                    searchObj.MarketingActivityStartDate;
                state.paramsObj.MarketingActivityEndDate =
                    searchObj.MarketingActivityEndDate;
                state.paramsObj.StatusType = searchObj.StatusType;

                sessionStorage.removeItem('couponSearchObj');
            }
        };

        onBeforeMount(() => {
            //取得原來的查詢條件
            getSearchParams();
        });

        onMounted(() => {
            execQuery();
        });

        const onQuery = () => {
            execQuery();
        };

        const onAdd = () => {
            state.couponTypeVisible = true;
        };

        const keepSearchData = () => {
            const searchObj = {
                CouponName: state.paramsObj.CouponName,
                MarketingActivityStartDate:
                    state.paramsObj.MarketingActivityStartDate,
                MarketingActivityEndDate:
                    state.paramsObj.MarketingActivityEndDate,
                StatusType: state.paramsObj.StatusType
            };
            sessionStorage.setItem('couponSearchObj', JSON.stringify(searchObj));
        };

        const onEdit = (item: CouponQueryResultModel) => {
            //紀錄搜尋條件
            keepSearchData();

            const params = { id: item.id, type: '' };

            router.push({
                path: '/coupon-management/edit',
                query: params
            });
        };

        const onDetail = (item: CouponQueryResultModel) => {
            //紀錄搜尋條件
            keepSearchData();

            const params = {
                Id: item.id
            };

            router.push({
                path: '/coupon-management/detail',
                query: params
            });
        };

        const onCurrentChange = (currentPage: number) => {
            state.page = currentPage;
        };

        const onSizeChange = (size: number) => {
            state.pageSize = size;
        };

        const onSelectCouponType = (CouponType = '') => {
            //可接收子視窗傳值處理
            // const params = { id: '',
            //                  type: CouponType
            //                };
            // router.push({
            //     path: '/coupon-management/edit',
            //     query: params
            // });
            console.log(CouponType);
        };

        const onChange = (value: string) => {
            // do nothing.
            console.log(value);
        };

        return {
            state,
            onQuery,
            onAdd,
            onEdit,
            onDetail,
            onCurrentChange,
            onSizeChange,
            onSelectCouponType,
            onChange
        };
    }
});
</script>

<style lang="scss">
@import '@/styles/element-variables.scss';
.coupon-query {
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
    &__span_bold {
        font-weight: bold;
    }
}
</style>
