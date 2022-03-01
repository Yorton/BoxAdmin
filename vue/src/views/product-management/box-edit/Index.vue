<template lang="pug">
.box-edit.ob-ml-1
    .box-edit__info
        box-edit-info
    .box-edit__content.ob-pl-1.ob-pr-1
        Tabs.ob-mt-1.ob-mb-1(:items="state.tabs" v-model:active-name="state.activeName")
        box-edit-member-info(v-if="state.activeName==state.tabs[0].name")
        box-edit-match(v-if="state.activeName==state.tabs[1].name")
        box-edit-card(v-if="state.activeName==state.tabs[2].name")
</template>
<script lang="ts">
/**
 * 因訂閱盒功能較為複雜，因此使用provide做資料處理，故box-edit底下的組件是不可被拆開使用的。
 */
import { defineComponent, onMounted, provide, reactive, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import BoxEditInfo from './components/info/BoxEditInfo.vue';
import BoxEditMemberInfo from './components/info/BoxEditMemberInfo.vue';
import BoxEditMatch from './components/match/BoxEditMatch.vue';
import BoxEditCard from './components/card/BoxEditCard.vue';
import Tabs from '@/components/common/tabs/Index.vue';
import { GetBoxInformation } from '@/_api/reservation.api';
import { GetCustomer } from '@/_api/customer.api';
import { SetLoading } from '@/_utils/common';
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import CustomerModel from '@/models/customer/CustomerModel';
import TabModel from '@/models/components/common/TabModel';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
export default defineComponent({
    name: 'BoxEdit',
    components: {
        Tabs,
        BoxEditInfo,
        BoxEditMemberInfo,
        BoxEditMatch,
        BoxEditCard
    },
    setup() {
        const route = useRoute();
        const router = useRouter();
        const state = reactive({
            activeName: 'info', // 頁簽初始值
            tabs: [
                new TabModel('會員資訊', 'info'),
                new TabModel('商品搭配', 'match'),
                new TabModel('小卡製作', 'card', true)
            ]
        });
        // 到小卡製作
        const gotoCardEdit = () => {
            state.activeName = state.tabs[2].name;
        };
        provide('gotoCardEdit', gotoCardEdit);
        // 訂閱盒資料
        const boxData = ref(new BoxEditDataModel());
        provide('boxData', boxData);
        // 客戶資料
        const customerData = ref(new CustomerModel());
        provide('customerData', customerData);
        // 客戶ID
        const customerId = ref('');
        provide('customerId', customerId);
        const surveyInfoList = ref([]);
        provide('surveyInfoList', surveyInfoList);
        // 預選清單資料
        const preselectList = ref(new Array<BoxEditProductItemModel>());
        provide('preselectList', preselectList);
        // Box內商品資料
        const matchedList = ref(new Array<BoxEditGroupModel>());
        provide('matchedList', matchedList);
        // 搭配品位置清單
        const matchLables = ref(new Array<Array<string>>());
        provide('matchLables', matchLables);
        // 更換Box內商品資料
        const changeMachedList = (
            value: string,
            item?: BoxEditGroupItemModel
        ) => {
            const index = matchLables.value.flat().indexOf(value);
            const positions = [index >> 1, index % 2];
            let changeItem: BoxEditGroupItemModel = new BoxEditGroupItemModel();
            if (item) {
                changeItem = item;
            }
            matchedList.value[positions[0]].items[positions[1]] = {
                ...changeItem
            };
        };
        provide('changeMachedList', changeMachedList);
        const setMatchLabel = (index: number) => {
            const en = String.fromCharCode(65 + index);
            matchLables.value.push([`${en}-1`, `${en}-2`]);
        };
        // Box資料重整
        const resetBoxData = () => {
            matchLables.value = [];
            customerId.value = boxData.value.customerId;
            matchedList.value = JSON.parse(
                JSON.stringify(boxData.value.itemGroups)
            ) as Array<BoxEditGroupModel>;
            matchedList.value.forEach((item, index) => {
                while (item.items.length < 2) {
                    item.items.push(new BoxEditGroupItemModel());
                }
                item.items.sort((a, b) => {
                    return a.position - b.position;
                });
                setMatchLabel(index);
            });
            console.log(matchedList.value);
        };
        //取得客戶資訊
        const getCustomer = async (id: string) => {
            try {
                SetLoading(true);
                console.log('getCustomer');
                const { data } = await GetCustomer(id);
                customerData.value = data.data as CustomerModel;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        //取得訂閱盒資料
        const getBoxInformation = async (id: string, bol = false) => {
            try {
                SetLoading(true);
                const { data } = await GetBoxInformation(id);
                if (data.succeeded) {
                    boxData.value = data.data as BoxEditDataModel;
                    resetBoxData();
                    bol && getCustomer(customerId.value);
                } else {
                    throw new Error(data.message);
                }
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        provide('getBoxInformation', getBoxInformation);
        // 加入預選清單
        const addPreselectList = (item: BoxEditProductItemModel) => {
            preselectList.value.push(item);
        };
        provide('addPreselectList', addPreselectList);
        // 從預選清單刪除
        const delectPreselectList = (item: BoxEditProductItemModel) => {
            const index = preselectList.value.findIndex(
                oldItem => oldItem.sku === item.sku
            );
            if (index > -1) {
                preselectList.value.splice(index, 1);
            }
        };
        provide('delectPreselectList', delectPreselectList);
        onMounted(() => {
            const id = route.query.id?.toString();
            if (id) {
                getBoxInformation(id, true);
                // state.activeName = 'match';
            } else {
                router.push({ path: '/orders-management/box-list' });
            }
        });
        return {
            state
        };
    }
});
</script>
<style lang="scss">
.box-edit {
    position: relative;
    display: flex;
    height: 94%;
    &__info {
        position: relative;
        width: 300px;
        height: 100%;
    }
    &__content {
        flex: 1;
    }
    .el-tabs {
        position: relative;
        height: 100%;
        &__content {
            position: relative;
            height: 94%;
        }
        .el-tab-pane {
            position: relative;
            height: 100%;
        }
    }
}
</style>
