<template lang="pug">
.box-edit-style-setting-product
    .box-edit-style-setting-product__img
        image-box(:src="item.imageUrl")
    .box-edit-style-setting-product__info
        .box-edit-style-setting-product__name {{item.sku}}
        .box-edit-style-setting-product__color {{item.productName}}
        .box-edit-style-setting-product__size {{item.size}}
        .box-edit-style-setting-product__price {{item.price}}
</template>
<script lang="ts">
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
import { defineComponent, PropType } from 'vue';
import ImageBox from '@/components/common/image-box/Index.vue';
export default defineComponent({
    name: 'BoxEditStyleSettingProduct',
    props: {
        item: {
            type: Object as PropType<BoxEditGroupItemModel>,
            default: () => {
                return new BoxEditGroupItemModel();
            }
        }
    },
    components: {
        ImageBox
    },
    setup() {
        return {};
    }
});
</script>
<style lang="scss">
.box-edit-style-setting-product {
    display: flex;
    align-items: flex-start;
    &__img {
        flex: 0 0 100px;
    }
    &__info {
        font-size: 14px;
        padding: 0 5px;
        box-sizing: border-box;
    }
}
</style>
