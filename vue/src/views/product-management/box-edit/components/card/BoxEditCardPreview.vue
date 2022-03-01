<template lang="pug">
el-dialog(
    v-model="state.dialogVisible"
    width="1000px"
    :close-on-click-modal="false" 
    :show-close="false"
    @closed="onClosed"
)
    template(#title)
        el-row
            el-col(:span="12")
                h3.box-edit-card-preview__title 預覽確認
            el-col.ob-align-right(:span="12")
                el-button(type="info" size="mini" @click="onClose") 取消
                el-button(type="primary" size="mini" @click="onSend") 確定
    .box-edit-card-preview
        .box-edit-card-preview__row
            span.box-edit-card-preview__logo LOGO
            span.box-edit-card-preview__box-id BOXID：
                span.box-edit-card-preview__box-id-value {{boxData.boxNo}}
        .box-edit-card-preview__row
            .box-edit-card-preview__text 你的BOX清單
        .box-edit-card-preview__row
            table.box-edit-card-preview__product-detail-table
                tbody
                    tr.box-edit-card-preview__product-detail-tr(v-for="(item, index) in productDetails" :key="`product-detail-${index}`")
                        td.box-edit-card-preview__product-detail-td {{index + 1}}
                        td.box-edit-card-preview__product-detail-td {{item.sku}}
                        td.box-edit-card-preview__product-detail-td {{item.productName}}
                        td.box-edit-card-preview__product-detail-td {{item.color}}
                        td.box-edit-card-preview__product-detail-td {{item.size}}
                        td.box-edit-card-preview__product-detail-td {{item.price}}
        .box-edit-card-preview__row
            p.box-edit-card-preview__message {{card.intro}}
        .box-edit-card-preview__row
            .box-edit-card-preview__product-list(v-for="(item, index) in productList" :key="`product-${index}`")
                .box-edit-card-preview__product-list-img-box
                    img.box-edit-card-preview__img(:src="item.items[0].imageUrl")
                .box-edit-card-preview__product-list-img-box
                    img.box-edit-card-preview__img(:src="item.items[1].imageUrl")
                p.box-edit-card-preview__product-list-text {{item.matchingMessage}}
        .box-edit-card-preview__row.box-edit-card-preview--align-right
            .box-edit-card-preview__signature
                img.box-edit-card-preview__img(:src="card.signatureUrl")
        .box-edit-card-preview__row
            .box-edit-card-preview__qrcode
                img.box-edit-card-preview__img(src="https://picsum.photos/100/100?random=1")
            p.box-edit-card-preview__hint 完成試穿後，請對商品進行評價並完成付款
        .box-edit-card-preview__row.box-edit-card-preview--align-right
            span.box-edit-card-preview__btn.box-edit-card-preview__btn--line LINE
            span.box-edit-card-preview__btn.box-edit-card-preview__btn--fb Facebook
            span.box-edit-card-preview__btn.box-edit-card-preview__btn--ig IG
</template>
<script lang="ts">
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import BoxEditGroupItemModel from '@/models/box-management/box-edit/BoxEditGroupItemModel';
import { ElMessageBox } from 'element-plus';
import { computed, defineComponent, inject, reactive, ref, watch } from 'vue';
export default defineComponent({
    name: 'BoxEditCardPreview',
    props: {
        visible: {
            tyep: Boolean,
            default: false
        }
    },
    components: {},
    setup(props, ctx) {
        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const state = reactive({
            dialogVisible: false
        });
        const productList = computed(() => {
            return boxData.value.itemGroups.filter(item => {
                return item.items.some(subItem => {
                    return subItem.sku;
                });
            });
        });
        const productDetails = computed(() => {
            let arr: BoxEditGroupItemModel[] = [];
            productList.value.forEach(item => {
                arr = arr.concat(item.items);
            });
            return arr;
        });
        const card = computed(() => {
            return boxData.value.card;
        });
        const onClose = () => {
            state.dialogVisible = false;
        };
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const onSend = () => {
            ElMessageBox.confirm(
                'p請再次確認資料是否正確<br>送出後無法修改，BOX將進入待出貨狀態。',
                {
                    dangerouslyUseHTMLString: true,
                    center: true,
                    closeOnClickModal: false,
                    confirmButtonText: '確定送出'
                }
            )
                .then(() => {
                    console.log('ok');
                    onClose();
                })
                .catch(() => {
                    console.log('cancel');
                });
        };
        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    state.dialogVisible = props.visible;
                }
            },
            {
                immediate: true
            }
        );
        return {
            state,
            boxData,
            productList,
            productDetails,
            card,
            onClose,
            onClosed,
            onSend
        };
    }
});
</script>
<style lang="scss">
.box-edit-card-preview {
    position: relative;
    &__title {
        margin: 0;
    }
    &__row {
        position: relative;
        margin-bottom: 10px;
    }
    &__logo {
        font-size: 24px;
    }
    &__box-id {
        position: absolute;
        right: 0;
    }
    &__box-id-value {
        color: blue;
    }
    &__product-detail {
        &-table {
            position: relative;
            width: 100%;
        }
        &-tr {
        }
        &-td {
            padding: 5px 0;
        }
    }
    &__message {
        border: 1px solid;
        padding: 5px;
        height: 80px;
        border-radius: 5px;
    }
    &__img {
        position: relative;
        width: 100%;
    }
    &__product-list {
        position: relative;
        width: 100%;
        margin: 20px 0;
        &-img-box {
            position: relative;
            display: inline-block;
            width: 150px;
            margin-right: 50px;
        }
        &-text {
            position: relative;
            display: inline-block;
            padding: 5px;
            border: 1px solid;
            border-radius: 5px;
            width: 510px;
            height: 200px;
            vertical-align: top;
            margin: 0 0 0 50px;
        }
    }
    &__signature {
        position: relative;
        display: inline-block;
        width: 200px;
        right: 10px;
    }
    &__qrcode {
        position: relative;
        display: inline-block;
        width: 100px;
    }
    &__hint {
        position: relative;
        display: inline-block;
        vertical-align: top;
        margin: 0 0 0 10px;
    }
    &__btn {
        position: relative;
        margin: 0 5px;
        border: 1px solid;
        padding: 5px 20px;
        cursor: pointer;
        color: #fff;
        &--line {
            background: #06c755;
        }
        &--fb {
            background: #365899;
        }
        &--ig {
            background: #125688;
        }
    }
    &--align-right {
        text-align: right;
    }
}
</style>
