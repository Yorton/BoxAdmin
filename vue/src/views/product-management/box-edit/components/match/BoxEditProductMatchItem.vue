<template lang="pug">
.box-edit-product-match-item
    .box-edit-product-match-item__img
        image-box(:src="item.imageUrl")
    .box-edit-product-match-item__info
        .box-edit-product-match-item__row.box-edit-product-match-item__name {{item.productName}}
        .box-edit-product-match-item__row.box-edit-product-match-item__color {{item.color}}
        .box-edit-product-match-item__row.box-edit-product-match-item__size {{item.size}}
        .box-edit-product-match-item__row.box-edit-product-match-item__price {{item.price}}
        .box-edit-product-match-item__row.box-edit-product-match-item__text 使用者保留
        .box-edit-product-match-item__row.box-edit-product-match-item__buttons
            span.box-edit-product-match-item__button
                el-button(size="mini" type="success" @click="onMatch") 搭配品
            span.box-edit-product-match-item__button
                el-button(size="mini" type="danger" @click="onDelete") 刪除
</template>
<script lang="ts">
import { defineComponent, inject, PropType } from 'vue';
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
import BoxEditStyleBookFilterModel from '@/models/box-management/box-edit/BoxEditStyleBookFilterModel';
import ImageBox from '@/components/common/image-box/Index.vue';
export default defineComponent({
    name: 'BoxEditProductMatchItem',
    props: {
        item: {
            type: Object as PropType<BoxEditGroupItemModel>,
            default: () => {
                return new BoxEditGroupItemModel();
            }
        },
        position: {
            type: String,
            default: ''
        }
    },
    components: {
        ImageBox
    },
    setup(props) {
        const openMacthProductList = inject(
            'openMacthProductList',
            (item: BoxEditStyleBookFilterModel) => {
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

        const onMatch = () => {
            openMacthProductList(
                new BoxEditStyleBookFilterModel(
                    props.item.series,
                    props.item.color
                )
            );
        };
        const onDelete = () => {
            changeMachedList(props.position);
        };
        return {
            onMatch,
            onDelete
        };
    }
});
</script>
<style lang="scss">
.box-edit-product-match-item {
    display: flex;
    align-items: flex-start;
    &__img {
        width: 50%;
    }
    &__info {
        font-size: 14px;
        width: 50%;
        padding: 0 5px;
        box-sizing: border-box;
    }
    &__row {
        margin-bottom: 10px;
    }
    &__buttons {
        display: flex;
        width: 100%;
        flex-wrap: wrap;
        justify-content: space-between;
    }
    &__button {
        margin-top: 5px;
    }
}
</style>
