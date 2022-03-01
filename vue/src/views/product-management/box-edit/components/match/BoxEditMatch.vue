<template lang="pug">
.box-edit-match
    el-row
        el-col
            h2.box-edit-match__title.ob-mr-1 商品搭配
            el-button(size="mini" type="primary" @click="onSave") 儲存
            el-button(size="mini" type="info" @click="onNext") 下一步
    el-divider.ob-mt-1.ob-mb-1
    el-row.box-edit-match__row
        el-col.box-edit-match__col(:span="12")
            box-edit-product-match
        el-col.box-edit-match__col(:span="12")
            box-edit-product-list
    box-edit-add-to-list(v-model:visible="state.addToListVisible" :product-item="state.productItem" :source="state.addToListSource")
    box-edit-match-product-list(v-model:visible="state.matchProductListVisible" :data="state.matchProdcutFilterItem")
    box-edit-style-setting(:data="state.styleSettingData" :designer="matchmakerName" v-model:visible="state.styleSettingVisible")
</template>
<script lang="ts">
import {
    computed,
    defineComponent,
    inject,
    onMounted,
    provide,
    reactive,
    ref
} from 'vue';
import BoxEditProductMatch from './BoxEditProductMatch.vue';
import BoxEditProductList from './BoxEditProductList.vue';
import BoxEditAddToList from './BoxEditAddToList.vue';
import BoxEditMatchProductList from './BoxEditMatchProductList.vue';
import BoxEditStyleSetting from './BoxEditStyleSetting.vue';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import BoxEditStyleBookFilterModel from '@/models/box-management/box-edit/BoxEditStyleBookFilterModel';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
import AddItemModel from '@/models/api/reservation/AddItemModel';
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import GroupModel from '@/models/api/reservation/GroupModel';
import GroupProductItemModel from '@/models/api/reservation/GroupProductItemModel';
import { ElMessageBox } from 'element-plus';
import { SaveMatchItems } from '@/_api/reservation.api';
import { SetLoading } from '@/_utils/common';
export default defineComponent({
    name: 'BoxEditMatch',
    components: {
        BoxEditProductMatch,
        BoxEditProductList,
        BoxEditAddToList,
        BoxEditMatchProductList,
        BoxEditStyleSetting
    },
    setup() {
        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const matchedList = inject(
            'matchedList',
            ref(new Array<BoxEditGroupModel>())
        );
        const getBoxInformation = inject(
            'getBoxInformation',
            (id: string, bol = true) => {
                console.log(id, bol);
            }
        );
        const gotoCardEdit = inject('gotoCardEdit', () => {
            console.log('goto card edit!');
        });

        const state = reactive({
            addToListVisible: false,
            addToListSource: 0,
            productItem: new BoxEditProductItemModel(),
            matchProductListVisible: false,
            matchProdcutFilterItem: new BoxEditStyleBookFilterModel(),
            styleSettingVisible: false,
            styleSettingData: new Array<BoxEditGroupModel>()
        });
        const matchmakerName = computed(() => {
            return boxData.value.matchmaker.name;
        });
        // 開啟選擇加入預選清單或Box內商品頁面
        const onSelectProduct = (item: BoxEditProductItemModel, source = 0) => {
            state.productItem = { ...item };
            state.addToListSource = source;
            state.addToListVisible = true;
        };
        provide('onSelectProduct', onSelectProduct);
        //開啟搭配品選擇頁面
        const openMacthProductList = (item: BoxEditStyleBookFilterModel) => {
            state.matchProdcutFilterItem = { ...item };
            state.matchProductListVisible = true;
        };
        provide('openMacthProductList', openMacthProductList);
        // 檢查搭配商品內容
        const checkMatchLlist = (): boolean | AddItemModel => {
            let canSave = false;
            const addItem: AddItemModel = new AddItemModel(boxData.value.id);
            matchedList.value.forEach(item => {
                const groupList = new GroupModel(item.id);
                item.items.forEach((subItem, subIndex) => {
                    if (subItem.sku) {
                        canSave = true;
                        groupList.items.push(
                            new GroupProductItemModel(
                                subItem.sku,
                                subItem.source,
                                subIndex + 1
                            )
                        );
                    }
                });
                addItem.groups.push(groupList);
            });
            return canSave && addItem;
        };
        // 更新搭配組合資料
        const onSave = async () => {
            const saveObj: boolean | AddItemModel = checkMatchLlist();
            if (saveObj) {
                SetLoading(true);
                try {
                    const { data } = await SaveMatchItems(
                        saveObj as AddItemModel
                    );
                    if (data.succeeded) {
                        getBoxInformation(boxData.value.id);
                    } else {
                        throw new Error(data.message);
                    }
                    console.log(data);
                } catch (error) {
                    console.log(error);
                }
                SetLoading();
            } else {
                ElMessageBox.alert('搭配品為空的，請至少匹配一件以上！');
            }
        };
        // 下一步
        const onNext = () => {
            const bol = boxData.value.itemGroups.every((group, index) => {
                return group.items.every((item, subIndex) => {
                    return (
                        item.sku ===
                        matchedList.value[index].items[subIndex].sku
                    );
                });
            });
            if (bol) {
                state.styleSettingData = matchedList.value.filter(item => {
                    return (
                        !item.hasStyleBook &&
                        item.items.every(subItem => {
                            return subItem.sku;
                        })
                    );
                });
                if (!state.styleSettingData.length) {
                    gotoCardEdit();
                } else {
                    state.styleSettingVisible = true;
                }

                console.log('next');
            } else {
                ElMessageBox.alert('訂閱盒有異動，請先儲存。');
            }
        };
        onMounted(() => {
            console.log('BoxEditMatch');
        });
        return {
            state,
            matchmakerName,
            onSave,
            onNext
        };
    }
});
</script>
<style lang="scss">
.box-edit-match {
    position: relative;
    height: 94%;
    &__title {
        margin: 0;
        display: inline-block;
    }
    &__row {
        height: 93%;
    }
    &__col {
        height: 100%;
    }
}
</style>
