<template lang="pug">

el-dialog(title="請選擇需要的Coupon類型" v-model="state.dialogVisible" width="20%"  @closed="onClosed")
    .coupon-type
            el-select.coupon-type__select.ob-ml-1(v-model="state.selectValue"  @change="selectedChange($event)")
                el-option(v-for="(item, index) in state.options" :label="item.label" :value="item.value" :key="`option-${index}`") 
            span.coupon-type__span 請注意!選擇後進入編輯頁，就無法再更改類型喔~
            .coupon-type__buttons.ob-mt-2.ob-mr-1.ob-align-center
                 el-button(type="info" @click="onClose") 取消
                 el-button(type="primary" @click="onSend") 確定

</template>
<script lang="ts">
import { defineComponent, reactive, watch } from 'vue';
import { useRouter } from 'vue-router';
import { ElMessageBox } from 'element-plus';
export default defineComponent({
    name: 'CouponType',

    emits: ['onSelect', 'update:visible'],

    props: {
        visible: {
            type: Boolean,
            defaul: false
        }
    },
    components: {},

    setup(props, ctx) {
        const router = useRouter();

        const state = reactive({
            dialogVisible: false,
            selectValue: 0,
            options: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '一般COUPON'
                },
                {
                    value: 2,
                    label: '專屬生日禮'
                },
                {
                    value: 3,
                    label: '升等會員購物禮'
                },
                {
                    value: 4,
                    label: '續訂禮'
                },
                {
                    value: 5,
                    label: '訂閱費折抵'
                },
                {
                    value: 6,
                    label: '滿件折'
                }
            ]
        });
        const onClose = () => {
            state.dialogVisible = false;
        };
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const onSend = () => {
            if (state.selectValue == 0) {
                ElMessageBox.alert('請選擇Coupon類型');
                return;
            }

            //ctx.emit('onSelect', state.selectValue);//可傳值至父視窗

            const params = { id: '', type: state.selectValue };

            router.push({
                path: '/coupon-management/edit',
                query: params
            });

            onClose();
        };

        const selectedChange = (value: string) => {
            //state.selectValue = value;//selectValue已綁定,可以不用設
            console.log(value);
        };

        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    state.dialogVisible = props.visible;
                }
            }
        );
        return {
            state,
            onClose,
            onClosed,
            onSend,
            selectedChange
        };
    }
});
</script>

<style lang="scss">
.coupon-type {
    position: relative;
    &__title {
        margin: 0;
    }
    &__select {
        width: 100%;
        margin-bottom: 5%;
    }
    &__buttons {
        position: relative;
        text-align: center;
    }
    &__span {
        margin-left: 3%;
    }
}
</style>
