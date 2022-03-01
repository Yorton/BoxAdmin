<template>
    <div style="padding: 0px">
        <el-card class="box-card" shadow="never">
            <template #header>
                <div class="card-header">
                    <span>購物訂單管理</span>
                </div>
            </template>
            <div>
                <el-tabs v-model="state.searchform.orderType" type="card">
                    <el-tab-pane label="Box" name="2"></el-tab-pane>
                    <el-tab-pane label="直購" name="1"></el-tab-pane>
                </el-tabs>
                <el-form :inline="true" style="margin-top: 1%;">
                    <el-row>
                        <el-col :span="6">
                            <el-form-item
                                label="購物訂單編號"
                                prop="transactionNo"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.transactionNo"
                                ></el-input>
                            </el-form-item>
                        </el-col>
                        <el-col :span="5">
                            <el-form-item
                                label="會員ID"
                                prop="customerId"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.customerId"
                                ></el-input>
                            </el-form-item>
                        </el-col>
                        <el-col :span="11">
                            <el-form-item
                                label="會員姓名"
                                prop="customerName"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.customerName"
                                ></el-input>
                            </el-form-item>
                        </el-col>
                    </el-row>
                    <el-row>
                        <el-col :span="13">
                            <el-form-item
                                label="時間區間篩選"
                                prop="timeFilter"
                                size="mini"
                            >
                                <el-select
                                    v-model="state.searchform.timeFilter"
                                >
                                    <el-option
                                        label="請選擇"
                                        value="-1"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.timeFiltersOptions"
                                        :label="item.label"
                                        :value="item.value"
                                        :key="`timeFiltersOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <el-date-picker
                                v-model="state.searchform.searchDate"
                                type="daterange"
                                range-separator="至"
                                start-placeholder="起日"
                                end-placeholder="迄日"
                                size="mini"
                            >
                            </el-date-picker>
                        </el-col>
                        <el-col :span="11">
                            <el-form-item
                                label="狀態"
                                prop="orderState"
                                size="mini"
                            >
                                <el-select
                                    v-model="state.searchform.orderState"
                                >
                                    <el-option label="請選擇" value="-1" />
                                    <el-option
                                        v-for="(item,
                                        index) in state.orderStateList"
                                        :label="item.text"
                                        :value="item.value"
                                        :key="`orderStateOptions-${index}`"
                                    />
                                </el-select>
                            </el-form-item>
                        </el-col>
                    </el-row>
                    <el-row>
                        <el-col>
                            <el-button
                                type="primary"
                                size="small"
                                style="float: right; margin-right: 2%;"
                                @click="handleQuery"
                                >查詢</el-button
                            >
                        </el-col>
                    </el-row>
                </el-form>
            </div>
            <div style="margin-top: 20px;">
                <el-table
                    :data="
                        state.orderList.slice(
                            (state.page - 1) * state.row,
                            state.page * state.row
                        )
                    "
                    border
                    stripe
                    class="table__wrapper border-light"
                    empty-text="無資料"
                >
                    <el-table-column
                        prop="transactionNo"
                        label="購物訂單編號"
                        width="110"
                    ></el-table-column>
                    <el-table-column
                        prop="customerId"
                        label="會員ID"
                    ></el-table-column>
                    <el-table-column
                        prop="customerName"
                        label="會員姓名"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="OrderTypeName"
                        label="訂單類型"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="devileryTime"
                        label="到貨時間"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="orderTime"
                        label="付款時間"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="appreciationTime"
                        label="鑑賞期"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="createTime"
                        label="成立時間"
                        width="100"
                    ></el-table-column>
                    <el-table-column
                        prop="orderStateName"
                        label="狀態"
                        width="170"
                    ></el-table-column>
                    <el-table-column prop="" label="動作" width="60">
                        <template #default="{row}">
                            <a
                                style="color: #1a0dab;text-decoration: underline;"
                                @click="handleDetail(row.transactionNo)"
                                >明細</a
                            >
                        </template>
                    </el-table-column>
                </el-table>
                <div class="block" style="text-align: center;margin-top: 10px;">
                    <el-pagination
                        @size-change="handleSizeChange"
                        @current-change="handleCurrentChange"
                        :current-page="state.page"
                        :page-sizes="[10, 20, 30, 40, 50]"
                        :page-size="state.row"
                        layout="prev, pager, next, sizes"
                        :total="state.listCount"
                    >
                    </el-pagination>
                </div>
            </div>
        </el-card>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive, onBeforeMount } from 'vue';
import SelectOptionModel from '@/models/components/common/SelectOptionModel';
import OrderListResultModel from '@/models/box-management/shopping-orders/OrderListResultModel';
import OrderListParamsModel from '@/models/box-management/shopping-orders/OrderListParamsModel';
import { GetOrderStateList, GetOrderList } from '@/_api/shopping-orders.api';
import { SetLoading, formatDate } from '@/_utils/common';
import { useRouter } from 'vue-router';
// import Image from '@/components/Image.vue';

export default defineComponent({
    name: 'ShoppingOrders',
    // components: { Image },
    setup() {
        const router = useRouter();

        const state = reactive({
            searchform: {
                orderType: '2',
                transactionNo: '',
                customerId: '',
                customerName: '',
                timeFilter: '-1',
                searchDate: [],
                orderState: '-1'
            },
            searchParam: new OrderListParamsModel(),
            timeFiltersOptions: [
                { value: 1, label: '到貨時間' },
                { value: 2, label: '付款時間' },
                { value: 3, label: '鑑賞期' },
                { value: 4, label: '成立時間' }
            ],
            orderStateList: new Array<SelectOptionModel>(),
            orderList: new Array<OrderListResultModel>(),
            page: 1,
            row: 10,
            listCount: 0
        });

        const initSelOptData = async () => {
            const [orderStateList] = await Promise.all([GetOrderStateList()]);
            state.orderStateList = orderStateList.data.data;
        };

        const handleQuery = async () => {
            try {
                SetLoading(true);

                state.searchParam.orderType = state.searchform.orderType;
                state.searchParam.transactionNo =
                    state.searchform.transactionNo;
                state.searchParam.customerId = state.searchform.customerId;
                state.searchParam.customerName = state.searchform.customerName;
                state.searchParam.timeFilter = state.searchform.timeFilter;
                state.searchParam.startDate =
                    state.searchform.searchDate.length > 0
                        ? state.searchform.searchDate[0]
                        : '';
                state.searchParam.endDate =
                    state.searchform.searchDate.length > 1
                        ? state.searchform.searchDate[1]
                        : '';
                state.searchParam.orderState = state.searchform.orderState;

                const { data } = await GetOrderList(state.searchParam);
                const list = [...data.data].map(item => {
                    item.devileryTime = formatDate(
                        item.devileryTime,
                        'YYYY-MM-DD'
                    );
                    item.orderTime = formatDate(item.orderTime, 'YYYY-MM-DD');
                    item.appreciationTime = formatDate(
                        item.appreciationTime,
                        'YYYY-MM-DD'
                    );
                    item.createTime = formatDate(item.createTime, 'YYYY-MM-DD');
                    return item;
                });

                state.orderList = list;
                state.listCount = state.orderList.length;
                state.page = 1;
                state.row = 10;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        const handleDetail = (transactionNo: string) => {
            sessionStorage.setItem(
                'searchObj',
                JSON.stringify(state.searchform)
            );

            const params = { transactionNo: transactionNo.trim() };

            router.push({
                path: '/orders-management/shopping-orders/detail',
                query: params
            });
        };

        const handleCurrentChange = (currentPage: number) => {
            state.page = currentPage;
        };

        const handleSizeChange = (size: number) => {
            state.row = size;
        };

        onBeforeMount(() => {
            //取得原來的查詢條件
            const searchObjJsonStr = sessionStorage.getItem('searchObj');
            if (searchObjJsonStr != null) {
                const searchObj = JSON.parse(searchObjJsonStr || '{}');

                state.searchform.orderType = searchObj.orderType;
                state.searchform.transactionNo = searchObj.transactionNo;
                state.searchform.customerId = searchObj.customerId;
                state.searchform.customerName = searchObj.customerName;
                state.searchform.timeFilter = searchObj.timeFilter;
                state.searchform.searchDate = searchObj.searchDate;
                state.searchform.orderState = searchObj.orderState;

                sessionStorage.removeItem('searchObj');
            }
        });

        onMounted(() => {
            initSelOptData();
            handleQuery();
        });

        return {
            state,
            handleQuery,
            handleDetail,
            handleCurrentChange,
            handleSizeChange
        };
    }
});
</script>
