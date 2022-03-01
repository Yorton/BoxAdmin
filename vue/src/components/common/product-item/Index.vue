<template lang="pug">
.product-item
    .product-item__img-box
        image-box(:src="data.src")
        .product-item__hint(v-if="hint") {{hint}}
    .product-item__flex
        .product-item__name {{data.name}}
        .product-item__price {{data.price}}
    .product-item__flex
        .product-item__color {{data.color}}
        .product-item__size {{data.size}}
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import ImageBox from '@/components/common/image-box/Index.vue';
import ProductItemModel from '@/models/components/common/ProductItemModel';
export default defineComponent({
    name: 'ProductItem',
    props: {
        data: {
            type: Object as PropType<ProductItemModel>,
            default: () => {
                return new ProductItemModel();
            }
        },
        hint: {
            type: String,
            default: ''
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
@import '@/styles/element-variables.scss';
.product-item {
    position: relative;
    display: inline-block;
    width: 100%;
    max-width: 250px;
    font-size: 12px;
    &__img-box {
        position: relative;
    }
    &__hint {
        position: absolute;
        width: 100%;
        bottom: 0;
        z-index: 1;
        border: #b2b2b2 5px solid;
        background: #7c7c7c;
        color: #fff;
        text-align: center;
        padding: 5px;
    }
    &__flex {
        display: flex;
        justify-content: space-between;
        margin-top: 0px;
        padding: 5px;
    }
    &__name {
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        width: 80%;
        &:hover {
            position: absolute;
            background: #fff;
            white-space: normal;
            overflow: unset;
            width: auto;
            z-index: 1;
            color: $--color-primary;
        }
    }
}
</style>
