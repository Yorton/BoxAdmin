<template lang="pug">
el-dialog(title="請選擇要加入的位置" v-model="state.dialogVisible" width="20%" @closed="onClosed")
    .box-edit-add-product
        .box-edit-add-product__radio-group.ob-m-2
            el-radio(:label="1" v-model="state.radioValue") 預選清單
            el-radio(:label="2" v-model="state.radioValue")
                span BOX內商品
                el-select.box-edit-add-product__select.ob-ml-1(v-model="state.selectValue" @click="state.radioValue=2")
                    el-option(v-for="(item, index) in selectOptions" :value="item" :key="`option-${index}`") {{item}}
    template(#footer)
        el-button(type="info" @click="onClose") 取消
        el-button(type="primary" @click="onAdd") 確定
</template>
<script lang="ts">
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import {
    computed,
    defineComponent,
    inject,
    PropType,
    reactive,
    ref,
    watch
} from 'vue';
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
import { ElMessageBox } from 'element-plus';
export default defineComponent({
    name: 'BoxEditAddToList',
    props: {
        productItem: {
            type: Object as PropType<BoxEditProductItemModel>,
            default: () => {
                return new BoxEditProductItemModel();
            }
        },
        source: {
            type: Number,
            default: 0
        },
        visible: {
            type: Boolean,
            defaul: false
        }
    },
    components: {},
    setup(props, ctx) {
        const addPreselectList = inject(
            'addPreselectList',
            (item: BoxEditProductItemModel) => {
                console.log(item);
            }
        );
        const changeMachedList = inject(
            'changeMachedList',
            (value: string, item?: BoxEditGroupItemModel) => {
                console.log(value);
                console.log(item);
            }
        );
        const matchLables = inject(
            'matchLables',
            ref(new Array<Array<string>>())
        );
        const state = reactive({
            dialogVisible: false,
            radioValue: 1,
            selectValue: '請選擇'
        });
        const selectOptions = computed(() => {
            return ['請選擇'].concat(matchLables.value.flat());
        });
        const onRadioChange = (index: number) => {
            state.radioValue = index;
        };
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const onClose = () => {
            state.dialogVisible = false;
        };
        const onAdd = () => {
            if (state.radioValue === 1) {
                addPreselectList(props.productItem);
            } else if (state.radioValue === 2) {
                if (state.selectValue === selectOptions.value[0]) {
                    ElMessageBox.alert('請選擇BOX內商品位置!');
                    return;
                } else {
                    changeMachedList(
                        state.selectValue,
                        new BoxEditGroupItemModel(
                            props.productItem.series,
                            props.productItem.sku,
                            props.productItem.color,
                            props.productItem.image,
                            props.productItem.name,
                            props.productItem.size,
                            props.productItem.price,
                            props.source
                        )
                    );
                }
            }
            onClose();
        };
        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    state.dialogVisible = props.visible;
                    state.radioValue = 1;
                    state.selectValue = selectOptions.value[0];
                }
            },
            { immediate: true }
        );
        return {
            state,
            selectOptions,
            onAdd,
            onClose,
            onClosed,
            onRadioChange
        };
    }
});
</script>
<style lang="scss">
.box-edit-add-product {
    position: relative;
    &__title {
        margin: 0;
    }
    &__select {
        width: 100px;
    }
    &__buttons {
        position: relative;
        text-align: center;
    }
}
</style>
