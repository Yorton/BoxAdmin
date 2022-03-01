<template lang="pug">
.box-edit-product-item
    product-item(:data="productItem" :hint="hint")
    .box-edit-product-item__buttons
        el-button(size="mini" type="success" @click="onMatch") 搭配品
        el-button(size="mini" :type="addEnabled?'primary': 'default'" :disabled="!addEnabled" v-if="isAdd" @click="onSelectProduct(data, source)") 加入
        el-button(size="mini" type="danger" v-else @click="delectPreselectList(data)") 刪除
</template>
<script lang="ts">
import {
    computed,
    defineComponent,
    inject,
    onMounted,
    PropType,
    ref,
    watch
} from 'vue';
import ProductItem from '@/components/common/product-item/Index.vue';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
import ProductItemModel from '@/models/components/common/ProductItemModel';
import BoxEditStyleBookFilterModel from '@/models/box-management/box-edit/BoxEditStyleBookFilterModel';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
export default defineComponent({
    name: 'BoxEditProductItem',
    props: {
        data: {
            type: Object as PropType<BoxEditProductItemModel>,
            default: () => {
                return new BoxEditProductItemModel();
            }
        },
        source: {
            type: Number,
            default: 0
        },
        mode: {
            type: String,
            default: 'add' // add: 新增模式 delete: 刪除模式
        }
    },
    components: {
        ProductItem
    },
    setup(props) {
        const preselectList = inject(
            'preselectList',
            ref(new Array<BoxEditProductItemModel>())
        );
        const matchedList = inject(
            'matchedList',
            ref(new Array<BoxEditGroupModel>())
        );
        const onSelectProduct = inject(
            'onSelectProduct',
            (item: BoxEditProductItemModel) => {
                console.log(item);
            }
        );
        const delectPreselectList = inject(
            'delectPreselectList',
            (item: BoxEditProductItemModel) => {
                console.log(item);
            }
        );
        const openMacthProductList = inject(
            'openMacthProductList',
            (item: BoxEditStyleBookFilterModel) => {
                console.log(item);
            }
        );

        const productItem = ref(new ProductItemModel());
        const hasStock = computed(() => {
            return props.data.stock > 0;
        });
        // 判斷是否已加入預選清單|訂閱盒內
        const isAddedList = computed(() => {
            let bol = false;
            bol = preselectList.value.some(item => {
                return item.sku === props.data.sku;
            });
            if (!bol) {
                bol = matchedList.value.some(item => {
                    return item.items.some(subItem => {
                        return subItem.sku === props.data.sku;
                    });
                });
            }
            return bol;
        });
        const addEnabled = computed(() => {
            return hasStock.value && !isAddedList.value;
        });
        const isAdd = computed(() => {
            return props.mode === 'add';
        });
        const hint = computed(() => {
            return isAddedList.value
                ? '已加入清單'
                : !hasStock.value
                ? '商品無庫存'
                : '';
        });
        watch(
            () => props.data,
            () => {
                productItem.value.src = props.data.image;
                productItem.value.name = props.data.name;
                productItem.value.color = props.data.color;
                productItem.value.size = props.data.size;
                productItem.value.price = props.data.price;
            },
            {
                immediate: true
            }
        );
        onMounted(() => {
            // console.log('BoxEditProductItem');
        });
        const onMatch = () => {
            openMacthProductList(
                new BoxEditStyleBookFilterModel(
                    props.data.series,
                    props.data.color
                )
            );
        };
        return {
            productItem,
            hint,
            isAdd,
            addEnabled,
            onSelectProduct,
            delectPreselectList,
            onMatch
        };
    }
});
</script>
<style lang="scss">
.box-edit-product-item {
    position: relative;
    width: 100%;
    display: inline-block;
    &__buttons {
        display: flex;
        justify-content: space-between;
    }
}
</style>
