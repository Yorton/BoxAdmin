<template>
    <div style="padding: 0px">
        <el-card class="box-card" shadow="never">
            <template #header>
                <div class="card-header">
                    <span>服務訂單管理</span>
                </div>
            </template>
            <div style="margin-bottom: 20px">
                <el-form :inline="true" style="margin-top: 1%;">
                    <el-row>
                        <el-col>
                            <el-form-item
                                label="服務訂單編號"
                                prop="subscribeNo"
                                size="mini"
                            >
                                <el-input
                                    v-model="
                                        state.subscribeSearchform.subscribeNo
                                    "
                                ></el-input>
                            </el-form-item>
                            <el-form-item
                                label="會員ID"
                                prop="customerId"
                                size="mini"
                            >
                                <el-input
                                    v-model="
                                        state.subscribeSearchform.customerId
                                    "
                                ></el-input>
                            </el-form-item>
                            <el-form-item
                                label="會員姓名"
                                prop="customerName"
                                size="mini"
                            >
                                <el-input
                                    v-model="
                                        state.subscribeSearchform.customerName
                                    "
                                ></el-input>
                            </el-form-item>
                            <el-form-item
                                label="申請暫停"
                                prop="suspend"
                                size="mini"
                            >
                                <el-select
                                    v-model="state.subscribeSearchform.suspend"
                                >
                                    <el-option
                                        label="請選擇"
                                        value="0"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.suspendOptions"
                                        :label="item.label"
                                        :value="item.value"
                                        :key="`suspendOptions-${index}`"
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
                            <el-form-item
                                label="時間區間篩選"
                                prop="timeFilter"
                                size="mini"
                            >
                                <el-select
                                    v-model="
                                        state.subscribeSearchform.timeFilter
                                    "
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
                                v-model="state.subscribeSearchform.dueTime"
                                type="date"
                                value-format="yyyy-MM-dd"
                                style="width:12%;"
                                size="mini"
                            ></el-date-picker>
                            <span>&emsp;</span>
                            <el-form-item
                                label="訂閱狀態"
                                prop="subscribeStatus"
                                size="mini"
                            >
                                <el-select
                                    v-model="
                                        state.subscribeSearchform
                                            .subscribeStatus
                                    "
                                >
                                    <el-option
                                        label="請選擇"
                                        value="0"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.subscribeStateList"
                                        :label="item.name"
                                        :value="item.id"
                                        :key="`subscribeStateOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <span>&emsp;</span>
                            <el-form-item
                                label="成立方式"
                                prop="createdMethod"
                                size="mini"
                            >
                                <el-select
                                    v-model="
                                        state.subscribeSearchform.createdMethod
                                    "
                                    @change="
                                        onCreatedMethodSelectedChange($event)
                                    "
                                >
                                    <el-option
                                        label="請選擇"
                                        value="-1"
                                    ></el-option>
                                    <el-option
                                        v-for="(item,
                                        index) in state.createdMethodOptions"
                                        :label="item.label"
                                        :value="item.value"
                                        :key="`createdMethodOptions-${index}`"
                                    >
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <span>&emsp;</span>
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
                <el-table-column
                    prop="subscribeNo"
                    label="服務訂單編號"
                ></el-table-column>
                <el-table-column
                    prop="customerId"
                    label="會員ID"
                ></el-table-column>
                <el-table-column
                    prop="customerName"
                    label="會員姓名"
                ></el-table-column>
                <el-table-column
                    prop="purchasePlan"
                    label="購買方案"
                ></el-table-column>
                <el-table-column
                    prop="createdMethod"
                    label="成立方式"
                ></el-table-column>
                <el-table-column
                    prop="boxEnalbedCount"
                    label="BOX已啟用數"
                ></el-table-column>
                <el-table-column
                    prop="suspend"
                    label="申請暫停"
                ></el-table-column>
                <el-table-column
                    prop="subscribeStatus"
                    label="訂閱狀態"
                ></el-table-column>
                <el-table-column
                    prop="dueTime"
                    label="訂閱結束時間"
                ></el-table-column>
                <el-table-column prop="" label="動作">
                    <template #default="{row}">
                        <el-button
                            size="mini"
                            type="primary"
                            @click="onDetail(row)"
                            >明細</el-button
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

import { GetSubscribeList, GetSubscribeState } from '@/_api/box-service.api';
import SubscribeStateModel from '@/models/box-management/box-service/SubscribeStateModel';
import SubcribeListParamsModel from '@/models/box-management/box-service/SubcribeListParamsModel';
import SubcribeListResultModel from '@/models/box-management/box-service/SubcribeListResultModel';
import { SetLoading } from '@/_utils/common';
import { useRouter } from 'vue-router';

export default defineComponent({
    name: 'BoxService',
    components: {},
    setup() {
        const router = useRouter();

        const state = reactive({
            tagStatus: 0,

            paramsObj: new SubcribeListParamsModel(),

            subscribeSearchform: {
                subscribeNo: '',
                customerId: '',
                customerName: '',
                suspend: '',
                timeFilter: '',
                dueTime: '',
                subscribeStatus: '',
                createdMethod: '-1'
            },

            timeFiltersSelectValue: 0,
            timeFiltersOptions: [
                // {
                // value: 0,
                // label: '時間區間篩選'
                // },
                {
                    value: 1,
                    label: '訂閱完成時間'
                },
                {
                    value: 2,
                    label: '服務結束時間'
                },
                {
                    value: 3,
                    label: '申請暫停時間'
                }
            ],

            subscribeStateList: new Array<SubscribeStateModel>(),

            suspendSelectValue: 0,
            suspendOptions: [
                {
                    value: 1,
                    label: '已申請'
                },
                {
                    value: 2,
                    label: '未申請'
                }
            ],

            createdMethodSelectValue: -1,
            createdMethodOptions: [
                {
                    value: 0,
                    label: '會員下單'
                },
                {
                    value: 1,
                    label: '自動續約'
                }
            ],

            list: new Array<SubcribeListResultModel>(),
            total: 0,
            page: 0,
            pageSize: 0
        });
        const tableCellStyle = () => 'padding: 5px 0';

        const initSelOptData = async () => {
            const [subscribeList] = await Promise.all([GetSubscribeState()]);

            state.subscribeStateList = subscribeList.data.data;
        };

        const execQuery = async () => {
            try {
                SetLoading(true);

                state.paramsObj.SubscribeNo =
                    state.subscribeSearchform.subscribeNo;
                state.paramsObj.CustomerId =
                    state.subscribeSearchform.customerId;
                state.paramsObj.CustomerName =
                    state.subscribeSearchform.customerName;
                state.paramsObj.Suspend =
                    state.subscribeSearchform.suspend == ''
                        ? 0
                        : parseInt(state.subscribeSearchform.suspend);
                state.paramsObj.TimeFilter =
                    state.subscribeSearchform.timeFilter == ''
                        ? 0
                        : parseInt(state.subscribeSearchform.timeFilter);
                state.paramsObj.DueTime = state.subscribeSearchform.dueTime;
                state.paramsObj.CreatedMethod = parseInt(
                    state.subscribeSearchform.createdMethod
                );
                state.paramsObj.SubscribeStatusId =
                    state.subscribeSearchform.subscribeStatus == ''
                        ? 0
                        : parseInt(state.subscribeSearchform.subscribeStatus);

                const { data } = await GetSubscribeList(state.paramsObj);

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
            const searchObjJsonStr = sessionStorage.getItem('boxServiceSearchObj');
            if (searchObjJsonStr != null) {
                const searchObj = JSON.parse(searchObjJsonStr || '{}');

                state.subscribeSearchform.subscribeNo = searchObj.subscribeNo;
                state.subscribeSearchform.customerId = searchObj.customerId;
                state.subscribeSearchform.customerName = searchObj.customerName;
                state.subscribeSearchform.suspend = searchObj.suspend;
                state.subscribeSearchform.timeFilter = searchObj.timeFilter;
                state.subscribeSearchform.dueTime = searchObj.dueTime;
                state.subscribeSearchform.subscribeStatus =
                    searchObj.subscribeStatus;
                state.subscribeSearchform.createdMethod =
                    searchObj.createdMethod;

                sessionStorage.removeItem('boxServiceSearchObj');
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
                subscribeNo: state.subscribeSearchform.subscribeNo,
                customerId: state.subscribeSearchform.customerId,
                customerName: state.subscribeSearchform.customerName,
                suspend: state.subscribeSearchform.suspend,
                timeFilter: state.subscribeSearchform.timeFilter,
                dueTime: state.subscribeSearchform.dueTime,
                subscribeStatus: state.subscribeSearchform.subscribeStatus,
                createdMethod: state.subscribeSearchform.createdMethod
            };
            sessionStorage.setItem('boxServiceSearchObj', JSON.stringify(searchObj));
        };

        const onDetail = (item: SubcribeListResultModel) => {
            //紀錄搜尋條件
            keepSearchData();

            const params = {
                detailSubscribeId: item.id,
                customerId: item.customerId
            };

            router.push({
                path: '/orders-management/box-service/detail',
                query: params
            });
        };

        const onCurrentChange = (currentPage: number) => {
            state.page = currentPage;
        };

        const onSizeChange = (size: number) => {
            state.pageSize = size;
        };

        const onCreatedMethodSelectedChange = (value: string) => {
            state.subscribeSearchform.createdMethod = value;
        };

        return {
            state,
            tableCellStyle,
            onQuery,
            onDetail,
            onCurrentChange,
            onSizeChange,
            onCreatedMethodSelectedChange
        };
    }
});
</script>
