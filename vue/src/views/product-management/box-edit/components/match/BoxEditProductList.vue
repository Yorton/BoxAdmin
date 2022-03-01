<template lang="pug">
.box-edit-product-list
    h3.box-edit-product-list__title 個人化商品清單
    tabs.ob-mt-1.ob-mb-1(:items="state.tabs" v-model:active-name="state.activeName")
    .box-edit-product-list__content(v-if="list.length>0 || isSearchTab")
        el-scrollbar
            template(v-if="isSearchTab")
                el-form.box-edit-product-list__search-form(:inline="true" size="mini")
                    el-form-item(label="商品貨號")
                        el-input(v-model="state.searchValue" placeholder="請輸入商品貨號")
                    el-form-item
                        el-button(type="primary" @click="onSearch") 查询
                p.box-edit-product-list__search-result.ob-mt-1.ob-mb-1 搜尋結果：
            .box-edit-product-list__product-item(v-for="(item, index) in list" :key="`product-${index}`")
                box-edit-product-item(:data="item" :source="tabIndex")
</template>
<script lang="ts">
import { computed, defineComponent, inject, reactive, ref, watch } from 'vue';
import Tabs from '@/components/common/tabs/Index.vue';
import BoxEditProductItem from './BoxEditProductItem.vue';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import TabModel from '@/models/components/common/TabModel';
import { SetLoading } from '@/_utils/common';
import { ElMessageBox } from 'element-plus';
import {
    GetFavoritesProductItems,
    GetScoreProductItems,
    GetSearchProductItemsBySeries
} from '@/_api/product.api';
export default defineComponent({
    name: 'BoxEditProductList',
    components: {
        Tabs,
        BoxEditProductItem
    },
    setup() {
        const state = reactive({
            activeName: 'favorite', // 頁簽初始值
            tabs: [
                new TabModel('系統推薦', 'system'),
                new TabModel('收藏清單', 'favorite'),
                new TabModel('猜你喜歡', 'like'),
                new TabModel('被刪除的商品', 'delete'),
                new TabModel('搜尋', 'search')
            ],
            addProductVisible: true,
            searchValue: ''
        });
        const isSearchTab = computed(() => {
            return state.activeName === state.tabs[4].name;
        });
        const tabIndex = computed(() => {
            return state.tabs.findIndex(item => {
                return item.name === state.activeName;
            });
        });
        const customerId = inject('customerId', ref(''));
        const list = ref(new Array<BoxEditProductItemModel>());
        const setList = (arr: BoxEditProductItemModel[]) => {
            list.value = [...arr];
        };
        const setSearchModel = () => {
            state.searchValue = '';
            setList([]);
        };
        const getProductItem = async () => {
            SetLoading(true);
            try {
                let res;
                switch (state.activeName) {
                    case state.tabs[1].name:
                        res = await GetFavoritesProductItems(customerId.value);
                        break;
                    case state.tabs[2].name:
                        res = await GetScoreProductItems(customerId.value);
                        break;
                    default:
                        break;
                }
                setList(res?.data.data.items);
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const getProductItemBySeries = async (seriesId: string) => {
            SetLoading(true);
            try {
                const { data } = await GetSearchProductItemsBySeries(seriesId);
                setList(data.data.items);
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        watch(
            customerId,
            () => {
                if (customerId.value) {
                    getProductItem();
                }
            },
            {
                immediate: true
            }
        );
        watch(
            () => state.activeName,
            () => {
                !isSearchTab.value ? getProductItem() : setSearchModel();
            }
        );
        const onSearch = () => {
            if (!state.searchValue) {
                ElMessageBox.alert('請輸入商品貨號');
                return;
            }
            getProductItemBySeries(state.searchValue);
        };
        return {
            state,
            list,
            isSearchTab,
            tabIndex,
            onSearch
        };
    }
});
</script>
<style lang="scss">
.box-edit-product-list {
    position: relative;
    height: 100%;
    &__title {
        margin: 0;
    }
    &__content {
        position: relative;
        height: 91%;
    }
    &__product-item {
        position: relative;
        display: inline-block;
        width: 150px;
        margin: 5px;
    }
    &__search-form {
        position: relative;
        border-bottom: 1px dashed;
    }
    &__search-result {
        position: relative;
        font-size: 14px;
        font-weight: bold;
    }
}
</style>
