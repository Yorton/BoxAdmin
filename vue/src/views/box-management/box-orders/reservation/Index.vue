<template>
    <div style="padding: 0px">
        <el-card class="box-card" shadow="never">
            <template #header>
                <div class="card-header">
                    <span>BOX 預約單</span>
                </div>
            </template>
            <div style="margin-bottom: 20px">
                <el-form :inline="true" style="margin-top: 1%;">
                    <el-row>
                        <el-col>
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
                                label="BOX ID"
                                prop="boxNo"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.boxNo"
                                ></el-input>
                            </el-form-item>
                            <span>&emsp;</span>
                            <el-form-item
                                label="會員 ID"
                                prop="customerId"
                                size="mini"
                            >
                                <el-input
                                    v-model="state.searchform.customerId"
                                ></el-input>
                            </el-form-item>
                            <span>&emsp;</span>
                            <el-button
                                type="primary"
                                size="small"
                                @click="onQuery"
                                >搜尋</el-button
                            >
                        </el-col>
                    </el-row>
                </el-form>
            </div>
            <el-table
                :data="state.list"
                small
                stripe
                border
                class="table__wrapper border-light"
                style="box-shadow: none; margin-bottom: 20px;"
                :cell-style="tableCellStyle"
            >
                <el-table-column prop="boxNo" label="BOX ID"></el-table-column>
                <el-table-column
                    prop="deliveryExpected"
                    label="期望配送時間"
                ></el-table-column>
                <el-table-column
                    prop="statusName"
                    label="狀態"
                ></el-table-column>
                <el-table-column
                    prop="matchmakerName"
                    label="搭配師"
                ></el-table-column>
                <el-table-column
                    prop="customerId"
                    label="會員ID"
                ></el-table-column>
                <el-table-column
                    prop="subscriptionPlanName"
                    label="訂閱方案"
                ></el-table-column>
                <el-table-column
                    prop="addPurchaseName"
                    label="是否加購盒"
                ></el-table-column>
                <el-table-column prop="" label="">
                    <template #default="{row}">
                        <el-link type="primary" @click="onGowith(row, $event)"
                            >開始搭配</el-link
                        >
                    </template>
                </el-table-column>
            </el-table>

            <div style="text-align: center;">
                <el-button type="primary" size="small" @click="onBack()"
                    >返回列表</el-button
                >
            </div>
        </el-card>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';

import { GetMatchmakers, GetBoxReservation } from '@/_api/box-orders.api';

import MatchmakersModel from '@/models/box-management/box-orders/MatchmakersModel';
import BoxReservationParamsModel from '@/models/box-management/box-orders/BoxReservationParamsModel';
import BoxReservationResultModel from '@/models/box-management/box-orders/BoxReservationResultModel';
import { SetLoading } from '@/_utils/common';
import { useRoute, useRouter } from 'vue-router';

export default defineComponent({
    name: 'BoxReservation',
    components: {},
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            paramsObj: new BoxReservationParamsModel(),

            searchform: {
                boxNo: '',
                customerId: '',
                matchMaker: ''
            },

            matchMakersList: new Array<MatchmakersModel>(),

            list: new Array<BoxReservationResultModel>()
        });

        const tableCellStyle = () => 'padding: 5px 0';

        const initSelOptData = async () => {
            const [matchMakersData] = await Promise.all([GetMatchmakers()]);

            state.matchMakersList = matchMakersData.data.data;
        };

        const execQuery = async () => {
            try {
                SetLoading(true);

                state.paramsObj.BoxNo = state.searchform.boxNo;
                state.paramsObj.CustomerId = state.searchform.customerId;
                state.paramsObj.MatchmakerId = state.searchform.matchMaker;

                const { data } = await GetBoxReservation(state.paramsObj);

                state.list = [...data.data];
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        onMounted(() => {
            const reservationBoxNo = route.query.reservationBoxNo?.toString();
            if (reservationBoxNo) {
                state.searchform.boxNo = reservationBoxNo;
            }

            initSelOptData();

            execQuery();
        });

        const onQuery = () => {
            execQuery();
        };

        const onGowith = (item: BoxReservationResultModel, e: MouseEvent) => {
            e.preventDefault();
        };

        const onBack = () => {
            router.push({
                path: '/orders-management/box-orders'
            });
        };

        return {
            state,
            tableCellStyle,
            onQuery,
            onGowith,
            onBack
        };
    }
});
</script>
