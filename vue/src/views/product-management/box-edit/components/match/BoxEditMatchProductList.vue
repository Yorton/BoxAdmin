<template lang="pug">
el-dialog(title="搭配商品" v-model="state.dialogVisible" @closed="onClosed")
    .box-edit-match-product-list.ob-p-1
        h3.box-edit-match-product-list__title
        el-scrollbar.box-edit-match-product-list__container(v-if="hasList")
            .box-edit-match-product-list__product-item.ob-m-1(v-for="(item, index) in list" :key="`product-${index}`")
                box-edit-product-item(:data="item" :source="10")
        el-empty(description="無相關搭配品" v-else)
</template>
<script lang="ts">
import { computed, defineComponent, PropType, reactive, ref, watch } from 'vue';
import BoxEditProductItem from './BoxEditProductItem.vue';
import BoxEditStyleBookFilterModel from '@/models/box-management/box-edit/BoxEditStyleBookFilterModel';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import { SetLoading } from '@/_utils/common';
import { GetStyleBookByFilter } from '@/_api/product.api';
export default defineComponent({
    name: 'BoxEditMatchProductList',
    props: {
        data: {
            type: Object as PropType<BoxEditStyleBookFilterModel>,
            default: () => {
                return new BoxEditStyleBookFilterModel();
            }
        },
        visible: {
            type: Boolean,
            defaul: false
        }
    },
    components: {
        BoxEditProductItem
    },
    setup(props, ctx) {
        const state = reactive({
            dialogVisible: false
        });
        const list = ref(new Array<BoxEditProductItemModel>());
        const hasList = computed(() => {
            return list.value.length > 0;
        });
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const searchList = async () => {
            list.value = [];
            SetLoading(true);
            try {
                const { data } = await GetStyleBookByFilter({ ...props.data });
                list.value = [...data.data.items];
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        watch(() => props.data, searchList);
        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    state.dialogVisible = props.visible;
                }
            },
            { immediate: true }
        );
        return {
            state,
            list,
            hasList,
            onClosed
        };
    }
});
</script>
<style lang="scss">
.box-edit-match-product-list {
    position: relative;
    &__title {
        margin: 0;
    }
    &__close-btn {
        position: absolute;
        top: 10px;
        right: 10px;
    }
    &__container {
        position: relative;
        height: 450px;
    }
    &__product-item {
        position: relative;
        display: inline-block;
        width: 200px;
    }
}
</style>
