<template lang="pug">
el-dialog(title="搭配師簽名檔" v-model="state.dialogVisible" @closed="onClosed" :close-on-click-modal="false" :show-close="false")
    .box-edit-card-message-template
        el-table(:data="data")
            el-table-column(width="40px")
                template(#default="{$index}")
                    el-radio(v-model="state.radioValue" :label="$index")
                        span
            el-table-column(label="簽名檔" width="300px")
                template(#default="{row}")
                    ImageBox(:src="String(row)")
        .box-edit-card-message-template__buttons.ob-mt-2.ob-mr-1.ob-align-center
            el-button(type="info" @click="onClose") 取消
            el-button(type="primary" @click="onSend") 確認
</template>
<script lang="ts">
import { defineComponent, reactive, watch } from 'vue';
import { ElMessageBox } from 'element-plus';
import ImageBox from '@/components/common/image-box/Index.vue';
export default defineComponent({
    name: 'BoxEditCardMessageTemplate',
    emits: ['onSelect', 'update:visible'],
    props: {
        data: {
            type: Array,
            default: () => {
                return new Array<string>();
            }
        },
        visible: {
            type: Boolean,
            defaul: false
        }
    },
    components: {
        ImageBox
    },
    setup(props, ctx) {
        const state = reactive({
            dialogVisible: false,
            radioValue: -1
        });
        const onClose = () => {
            state.dialogVisible = false;
        };
        const onClosed = () => {
            ctx.emit('update:visible', false);
        };
        const onSend = () => {
            if (state.radioValue < 0) {
                ElMessageBox.alert('請選擇簽名圖檔！');
                return;
            }
            ctx.emit('onSelect', props.data[state.radioValue]);
            onClose();
        };
        watch(
            () => props.visible,
            () => {
                if (props.visible) {
                    state.radioValue = -1;
                    state.dialogVisible = props.visible;
                }
            }
        );
        return {
            state,
            onClose,
            onClosed,
            onSend
        };
    }
});
</script>
