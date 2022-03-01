<template>
    <div style="padding: 0px">
        <el-card class="box-card" shadow="never">
            <template #header>
                <div class="card-header">
                    <span>BOX 清單管理</span>
                </div>
            </template>
            <div style="margin-bottom: 20px">
                <el-radio-group v-model="state.tagStatus">
                    <el-radio-button label="0" v-model="state.tagStatus"
                        >全部</el-radio-button
                    >
                    <el-radio-button label="2" v-model="state.tagStatus"
                        >待預覽</el-radio-button
                    >
                    <el-radio-button label="3" v-model="state.tagStatus"
                        >待搭配</el-radio-button
                    >
                    <el-radio-button label="7" v-model="state.tagStatus"
                        >試穿體驗中</el-radio-button
                    >
                    <el-radio-button label="8" v-model="state.tagStatus"
                        >試穿逾期</el-radio-button
                    >
                    <el-radio-button label="9" v-model="state.tagStatus"
                        >退貨處理中</el-radio-button
                    >
                </el-radio-group>

                <el-form :inline="true" style="margin-top: 1%;">
                    <el-row>
                        <el-col>
                            <el-form-item
                                label="BOX編號"
                                prop="boxNo"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.boxNo"
                                ></el-input>
                            </el-form-item>
                            <el-form-item
                                label="會員ID"
                                prop="customerId"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.customerId"
                                ></el-input>
                            </el-form-item>
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
                </el-form>

                <el-form :inline="true">
                    <el-row>
                        <el-col>
                            <!-- <el-select v-model="state.timeFiltersSelectValue" style="width: 15%;" size="mini">
                                <el-option v-for="(item, index) in state.timeFiltersOptions" :label="item.label" :value="item.value" :key="`timeFiltersOptions-${index}`">
                                </el-option>
                            </el-select> -->
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
                                        value="0"
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
                            <span>&emsp;</span>
                            <el-date-picker
                                v-model="state.searchform.deliveryExpected"
                                type="date"
                                value-format="yyyy-MM-dd"
                                style="width:12%;"
                                size="mini"
                            ></el-date-picker>
                            <span>&emsp;</span>
                            <el-form-item
                                label="搭配師"
                                prop="matchMaker"
                                size="mini"
                            >
                                <el-select
                                    v-model="state.searchform.matchMaker"
                                >
                                    <el-option
                                        label="請選擇"
                                        value="0"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.matchMakersList"
                                        :label="item.name"
                                        :value="item.id"
                                        :key="`matchMakersOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <span>&emsp;</span>
                            <el-form-item
                                v-if="
                                    state.tagStatus != 7 &&
                                        state.tagStatus != 8 &&
                                        state.tagStatus != 9
                                "
                                label="是否表態"
                                prop="isDeclare"
                                size="mini"
                            >
                                <el-select v-model="state.searchform.isDeclare">
                                    <el-option
                                        label="請選擇"
                                        value="0"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.isDeclareOptions"
                                        :label="item.label"
                                        :value="item.value"
                                        :key="`isDeclareOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <span>&emsp;</span>
                            <el-form-item
                                v-if="
                                    state.tagStatus != 2 &&
                                        state.tagStatus != 3 &&
                                        state.tagStatus != 7 &&
                                        state.tagStatus != 8 &&
                                        state.tagStatus != 9
                                "
                                label="狀態"
                                prop="boxStatus"
                                size="mini"
                            >
                                <el-select v-model="state.searchform.boxStatus">
                                    <el-option
                                        label="請選擇"
                                        value="0"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.boxStatusList"
                                        :label="item.name"
                                        :value="item.id"
                                        :key="`boxStatusOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                        </el-col>
                    </el-row>
                </el-form>
                <el-form :inline="true">
                    <el-row>
                        <el-col>
                            <el-button
                                type="primary"
                                size="small"
                                style="float: right; margin-right: 2%;"
                                @click="onQuery"
                                >查詢</el-button
                            >
                        </el-col>
                    </el-row>
                </el-form>
            </div>
            <el-table
                :data="
                    state.list.slice(
                        (state.page - 1) * state.pageSize,
                        state.page * state.pageSize
                    )
                "
                small
                stripe
                border
                class="table__wrapper border-light"
                style="box-shadow: none"
                :cell-style="tableCellStyle"
            >
                <el-table-column prop="boxNo" label="BOX編號"></el-table-column>
                <el-table-column
                    prop="customerId"
                    label="會員ID"
                ></el-table-column>
                <el-table-column
                    prop="customerName"
                    label="會員姓名"
                ></el-table-column>
                <el-table-column
                    prop="matchmakerName"
                    label="搭配師"
                ></el-table-column>
                <el-table-column
                    v-if="
                        state.tagStatus != 7 &&
                            state.tagStatus != 8 &&
                            state.tagStatus != 9
                    "
                    prop="deliveryExpected"
                    label="期望配送時間"
                ></el-table-column>
                <el-table-column
                    v-if="
                        state.tagStatus != 7 &&
                            state.tagStatus != 8 &&
                            state.tagStatus != 9
                    "
                    prop="custId"
                    label="是否表態"
                ></el-table-column>
                <el-table-column
                    v-if="
                        state.tagStatus != 2 &&
                            state.tagStatus != 3 &&
                            state.tagStatus != 7 &&
                            state.tagStatus != 8 &&
                            state.tagStatus != 9
                    "
                    prop="custId"
                    label="出貨時間"
                ></el-table-column>
                <el-table-column
                    v-if="state.tagStatus != 2 && state.tagStatus != 3"
                    prop="custId"
                    label="配達時間"
                ></el-table-column>
                <el-table-column
                    v-if="state.tagStatus != 2 && state.tagStatus != 3"
                    prop="custId"
                    label="試穿期限"
                ></el-table-column>
                <el-table-column
                    v-if="state.tagStatus == 8"
                    prop="custId"
                    label="已逾期天數"
                ></el-table-column>
                <el-table-column
                    v-if="state.tagStatus == 9"
                    prop="custId"
                    label="申請退回時間"
                ></el-table-column>
                <el-table-column
                    v-if="
                        state.tagStatus != 2 &&
                            state.tagStatus != 3 &&
                            state.tagStatus != 7 &&
                            state.tagStatus != 8 &&
                            state.tagStatus != 9
                    "
                    prop="statusName"
                    label="狀態"
                ></el-table-column>
                <el-table-column prop="" label="動作">
                    <template #default="{row}">
                        <el-button
                            size="mini"
                            type="primary"
                            @click="onDetail(row)"
                            >明細</el-button
                        >
                        <el-button
                            size="mini"
                            type="primary"
                            @click="onGowith(row)"
                            >商品搭配管理</el-button
                        >
                    </template>
                </el-table-column>
            </el-table>
            <div style="text-align: center;margin-top: 1%;">
                <el-pagination
                    background
                    layout="prev, pager, next, sizes"
                    :page-sizes="[10, 25, 50]"
                    :page-size="state.pageSize"
                    :total="state.total"
                    :current-page="state.page"
                    @size-change="onSizeChange"
                    @current-change="onCurrentChange"
                >
                </el-pagination>
            </div>
        </el-card>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, onBeforeMount, reactive } from 'vue';

import {
    GetBoxStatus,
    GetMatchmakers,
    GetBoxOrders
} from '@/_api/box-orders.api';

import BoxStatusModel from '@/models/box-management/box-orders/BoxStatusModel';
import MatchmakersModel from '@/models/box-management/box-orders/MatchmakersModel';
import BoxOrdersParamsModel from '@/models/box-management/box-orders/BoxOrdersParamsModel';
import BoxOrdersResultModel from '@/models/box-management/box-orders/BoxOrdersResultModel';
import { SetLoading } from '@/_utils/common';
import { useRouter } from 'vue-router';

export default defineComponent({
    name: 'BoxOrders',
    components: {},
    setup() {
        const router = useRouter();

        const state = reactive({

            tagStatus: 0,

            paramsObj: new BoxOrdersParamsModel(),

            searchform: {
                boxNo: '',
                customerId: '',
                customerName: '',
                timeFilter: '',
                deliveryExpected: '',
                matchMaker: '',
                isDeclare: '',
                boxStatus: ''
            },

            timeFiltersSelectValue: 0,
            timeFiltersOptions: [
                // {
                // value: 0,
                // label: '時間區間篩選'
                // },
                {
                    value: 1,
                    label: '期望配送時間'
                },
                {
                    value: 2,
                    label: '最後表態時間'
                },
                {
                    value: 3,
                    label: '出貨時間'
                },
                {
                    value: 4,
                    label: '配達時間'
                },
                {
                    value: 5,
                    label: '試穿最後期限'
                }
            ],

            boxStatusList: new Array<BoxStatusModel>(),
            matchMakersList: new Array<MatchmakersModel>(),

            isDeclareSelectValue: 0,
            isDeclareOptions: [
                {
                    value: 0,
                    label: '全部'
                },
                {
                    value: 1,
                    label: '是'
                },
                {
                    value: 2,
                    label: '否'
                }
            ],

            list: new Array<BoxOrdersResultModel>(), //new Array<BoxListItemModel>(),
            total: 0,
            page: 0,
            pageSize: 0
        });
        const tableCellStyle = () => 'padding: 5px 0';

        const initSelOptData = async () => {
            const [statusData, matchMakersData] = await Promise.all([
                GetBoxStatus(),
                GetMatchmakers()
            ]);

            state.boxStatusList = statusData.data.data;
            state.matchMakersList = matchMakersData.data.data;
        };

        const execQuery = async () => {
            try {
                SetLoading(true);

                state.paramsObj.BoxNo = state.searchform.boxNo;
                state.paramsObj.CustomerId = state.searchform.customerId;
                state.paramsObj.CustomerName = state.searchform.customerName;
                state.paramsObj.TimeFilter =
                    state.searchform.timeFilter == ''
                        ? 0
                        : parseInt(state.searchform.timeFilter);
                state.paramsObj.DeliveryExpected =
                    state.searchform.deliveryExpected;

                state.paramsObj.MatchmakerId = 
                    state.searchform.matchMaker == '0'
                        ? '' 
                        : state.searchform.matchMaker;
                
                //是否表態
                
                state.paramsObj.StatusId =
                    state.searchform.boxStatus == ''
                        ? 0
                        : parseInt(state.searchform.boxStatus);

                const { data } = await GetBoxOrders(state.paramsObj);

                state.list = [...data.data];

                state.total = state.list.length;
                state.page = 1;
                state.pageSize = 10;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        const getSearchParams = () => {
            const searchObjJsonStr = sessionStorage.getItem('boxOrdersSearchObj');
            if (searchObjJsonStr != null) {
                const searchObj = JSON.parse(searchObjJsonStr || '{}');

                state.tagStatus = searchObj.tagStatus;
                state.searchform.boxNo = searchObj.boxNo;
                state.searchform.customerId = searchObj.customerId;
                state.searchform.customerName = searchObj.customerName;
                state.searchform.timeFilter = searchObj.timeFilter;
                state.searchform.deliveryExpected = searchObj.deliveryExpected;
                state.searchform.matchMaker = searchObj.matchMaker;
                state.searchform.isDeclare = searchObj.isDeclare;
                state.searchform.boxStatus = searchObj.boxStatus;

                sessionStorage.removeItem('boxOrdersSearchObj');
            }
        };

        onBeforeMount(() => {

    
            //取得原來的查詢條件
            getSearchParams();
        });

        onMounted(() => {
            initSelOptData();

            execQuery();
        });

        const onQuery = () => {
            execQuery();
        };

        const keepSearchData = () => {
            const searchObj = {
                tagStatus: state.tagStatus,
                boxNo: state.searchform.boxNo,
                customerId: state.searchform.customerId,
                customerName: state.searchform.customerName,
                timeFilter: state.searchform.timeFilter,
                deliveryExpected: state.searchform.deliveryExpected,
                matchMaker: state.searchform.matchMaker,

                //是否表態
                isDeclare: state.searchform.isDeclare,

                boxStatus: state.searchform.boxStatus
            };
            sessionStorage.setItem('boxOrdersSearchObj', JSON.stringify(searchObj));
        };

        const onDetail = (item: BoxOrdersResultModel) => {
            //紀錄搜尋條件
            keepSearchData();

            const params = {
                reservationId: item.id,
                customerId: item.customerId
            };

            router.push({
                path: '/orders-management/box-orders/detail',
                query: params
            });
        };

        const onGowith = (item: BoxOrdersResultModel) => {
            //紀錄搜尋條件
            keepSearchData();

            if (state.tagStatus == 3) {
                //待搭配

                //const params2 = { reservationBoxNo: item.boxNo };
                //const mergeParams = {...params, ...params2};

                const params = { reservationBoxNo: item.boxNo };

                router.push({
                    path: '/orders-management/box-orders/reservation',
                    query: params
                });
            } else {
                //待預覽, 試穿體驗中, 試穿逾期, 退貨處理中

                //const params2 = { qryCustomerId: item.customerId };
                //const mergeParams = {...params, ...params2};

                const params = { qryCustomerId: item.customerId };

                router.push({
                    path: '/orders-management/box-orders/members',
                    query: params
                });
            }
        };

        const onCurrentChange = (currentPage: number) => {
            state.page = currentPage;
        };

        const onSizeChange = (size: number) => {
            state.pageSize = size;
        };

        return {
            state,
            tableCellStyle,
            onQuery,
            onDetail,
            onGowith,
            onCurrentChange,
            onSizeChange
        };
    }
});
</script>
