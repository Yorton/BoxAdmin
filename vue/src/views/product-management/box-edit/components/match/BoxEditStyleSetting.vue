<template lang="pug">
el-dialog(
    title="請設定以下商品組合的風格分類與情境場合標籤"
    width="80%"
    v-model="state.dialogVisible" 
    :close-on-click-modal="false" 
    @closed="onClosed"
)
    template(#title)
        h3.box-edit-style-setting__title 穿搭顧問:
            span.box-edit-style-setting__designer.ob-ml-1 {{designer}}
        p.box-edit-style-setting__hint.ob-mt-1 請設定以下商品組合的風格分類與情境場合標籤
    .box-edit-style-setting
        .box-edit-style-setting__table
            el-table(:data="groupItems" height="100%" :border="true")
                el-table-column(label="商品A")
                    template(#default="{row}")
                        box-edit-style-setting-product(:item="row[0]")
                el-table-column(label="商品B")
                    template(#default="{row}")
                        box-edit-style-setting-product(:item="row[1]")
                el-table-column(label="風格分類" width="150")
                    template(#default="{$index}")
                        el-select(v-model="state.styleValues[$index]")
                            el-option(v-for="item in state.styleList" :key="item.id" :label="item.title" :value="item.id")
                el-table-column(label="情境場合" width="150")
                    template(#default="{$index}")
                        el-select(v-model="state.occasionValues[$index]")
                            el-option(v-for="item in state.occasionList" :key="item.id" :label="item.title" :value="item.id")
    template(#footer)
        el-button(type="primary" size="medium" @click="onSave") 確定
</template>
<script lang="ts">
import {
    computed,
    defineComponent,
    inject,
    PropType,
    reactive,
    ref,
    watch
} from 'vue';
import StyleItemModel from '@/models/api/style-book/StyleItemModel';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
import StyleGroupModel from '@/models/api/style-book/StyleGroupModel';
import { GetStyleList, GetOccasionList } from '@/_api/style-book.api';
import { SetLoading } from '@/_utils/common';
import BoxEditStyleSettingProduct from './BoxEditStyleSettingProduct.vue';
import { ElMessageBox } from 'element-plus';
import UpdateStyleGroupModel from '@/models/api/reservation/UpdateStyleGroupModel';
import { UpdateStyleGroup } from '@/_api/reservation.api';
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
export default defineComponent({
    name: 'BoxEditStyleSetting',
    props: {
        data: {
            type: Array as PropType<Array<BoxEditGroupModel>>,
            default: () => {
                return new Array<BoxEditGroupModel>();
            }
        },
        designer: {
            type: String,
            default: ''
        },
        visible: {
            type: Boolean,
            default: false
        }
    },
    components: {
        BoxEditStyleSettingProduct
    },
    setup(props, ctx) {
        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const gotoCardEdit = inject('gotoCardEdit', () => {
            console.log('goto card edit!');
        });

        const getBoxInformation = inject(
            'getBoxInformation',
            (id: string, bol = true) => {
                console.log(id, bol);
            }
        );
        const state = reactive({
            dialogVisible: false,
            styleList: new Array<StyleItemModel>(),
            occasionList: new Array<StyleItemModel>(),
            styleValues: new Array<string>(),
            occasionValues: new Array<string>()
        });
        const groupItems = computed(() => {
            const arr: BoxEditGroupItemModel[][] = [];
            props.data.forEach(item => {
                if (item.items.length) {
                    arr.push(item.items);
                }
            });
            return arr;
        });
        const getList = async () => {
            try {
                SetLoading(true);
                const [styleData, occasionData] = await Promise.all([
                    GetStyleList(),
                    GetOccasionList()
                ]);
                state.styleList = styleData.data.data.items;
                state.occasionList = occasionData.data.data.items;
            } catch (error) {
                console.log(error);
            }
            SetLoading();
            state.dialogVisible = true;
        };
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const onClose = () => {
            state.dialogVisible = false;
        };
        const checkValues = (item: Array<string>): boolean => {
            return item.length === props.data.length;
        };
        const updateStyleGroup = async (obj: UpdateStyleGroupModel) => {
            try {
                const { data } = await UpdateStyleGroup(obj);
                if (data.succeeded) {
                    ElMessageBox.alert('貼標完成。').then(() => {
                        getBoxInformation(boxData.value.id);
                        gotoCardEdit();
                    });
                } else {
                    throw new Error(data.message);
                }
                console.log(data);
            } catch (error) {
                console.log(error);
            }
        };
        const onSave = () => {
            if (
                !checkValues(state.styleValues) ||
                !checkValues(state.occasionValues)
            ) {
                ElMessageBox.alert('尚有商品組合未貼標!');
                return;
            }
            const sendObj: UpdateStyleGroupModel = new UpdateStyleGroupModel();
            props.data.forEach((item, index) => {
                sendObj.items.push(
                    new StyleGroupModel(
                        item.id,
                        state.styleValues[index],
                        state.occasionValues[index]
                    )
                );
            });
            updateStyleGroup(sendObj);
        };
        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    if (!state.styleList.length) {
                        getList();
                    } else {
                        state.dialogVisible = true;
                    }
                    state.styleValues = [];
                    state.occasionValues = [];
                }
            },
            {
                immediate: true
            }
        );
        return {
            state,
            groupItems,
            onClose,
            onClosed,
            onSave
        };
    }
});
</script>
<style lang="scss">
.box-edit-style-setting {
    position: relative;
    &__title {
        margin: 0;
    }
    &__designer {
        color: blue;
    }
    &__hint {
        margin: 0;
    }
    &__table {
        position: relative;
        height: 500px;
    }
}
</style>
