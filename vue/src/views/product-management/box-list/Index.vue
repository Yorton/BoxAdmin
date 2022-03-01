<template lang="pug">
.box-List.ob-container
    el-row
        h2 BOX 預約單
    el-row
        el-form.box-List__search-bar(:inline="true")
            el-form-item.box-List__search-item(label="搭配師")
                el-select(v-model="state.searchObj.styleMaster")
                    el-option(
                        v-for="(item, index) in state.styleMasters" 
                        :label='item.name' 
                        :value='item.id'
                        :key="`style-master-${index}`")
            el-form-item.box-List__search-item(label="BOX ID")
                el-input(v-model="state.searchObj.BoxNo" placeholder='請輸入BOX ID')
            el-form-item.box-List__search-item(label="會員 ID")
                el-input(v-model="state.searchObj.memberId" placeholder='請輸入會員 ID')
            el-form-item.box-List__search-item
                el-button(size='medium' type='primary' icon='el-icon-search' @click="onSearch") 搜尋
    el-row
        el-table.box-List__table(:data="state.list" border stripe)
            el-table-column(prop="boxNo" label="BOX ID")
            el-table-column(prop="deliveryExpected" label="期望配送時間" sortable)
            el-table-column(prop="stateTitle" label="狀態" sortable)
            el-table-column(prop="matchmakerName" label="搭配師")
            el-table-column(prop="" label="會員 ID")
            el-table-column(prop="subscribeName" label="訂閱方案")
            el-table-column(prop="" label="是否加購盒")
            el-table-column
                template(#default="{row}")
                    el-button(size='mini' type="primary" v-if="row.flowState===0" @click="onEdit(row)") 開始搭配
                    el-button(size='mini' type="success" v-if="row.flowState===1" @click="onEdit(row)") 繼續搭配
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import { GetBoxList } from '@/_api/reservation.api';
import { GetMatchingMakerList } from '@/_api/matching-maker.api';
import BoxListSearchModel from '@/models/box-management/box-list/BoxListSearchModel';
import BoxListItemModel from '@/models/box-management/box-list/BoxListItemModel';
import MatchMasterModel from '@/models/api/matching-maker/MatchMasterModel';
import { useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';
export default defineComponent({
    name: 'BoxInfo',
    components: {},
    setup() {
        const router = useRouter();
        const state = reactive({
            searchObj: new BoxListSearchModel(),
            styleMasters: [new MatchMasterModel('', '請選擇')], // el-option有bug，故使用此方法解決渲染問題
            list: new Array<BoxListItemModel>()
        });
        const setStyleMaster = async () => {
            console.log('setStyleMaster');
            try {
                SetLoading(true);
                const { data } = await GetMatchingMakerList();
                state.styleMasters = state.styleMasters.concat(
                    data.data.matchingMakers
                );
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const onSearch = async () => {
            try {
                SetLoading(true);
                const { data } = await GetBoxList(state.searchObj);
                state.list = [...data.data.items];
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const onEdit = (item: BoxListItemModel) => {
            const params = { id: item.id, type: '' };
            if (item.flowState === 1) {
                params.type = 'edit';
            }
            router.push({
                path: '/product-management/box-edit',
                query: params
            });
        };
        onMounted(async () => {
            setStyleMaster();
            onSearch();
        });
        return {
            state,
            onSearch,
            onEdit
        };
    }
});
</script>
<style lang="scss">
@import '@/styles/element-variables.scss';
.box-List {
    &__search-bar {
        border: $--table-border;
        padding: 10px 5px;
    }
    &__search-item {
        margin-bottom: 0;
    }
    &__table {
        margin-top: 30px;
    }
}
</style>
