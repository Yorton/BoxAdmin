<template lang="pug">
el-dialog(:title="title" v-model="state.dialogVisible" @closed="onClosed" :close-on-click-modal="false" :show-close="false")
    .box-edit-card-message-template
        el-table(:data="data")
            el-table-column(width="40px")
                template(#default="{$index}")
                    el-radio(v-model="state.radioValue" :label="$index")
                        span
            el-table-column(prop="title" label="名稱")
            el-table-column(prop="messageText" label="內容")
        .box-edit-card-message-template__buttons.ob-mt-2.ob-mr-1.ob-align-center
            el-button(type="info" @click="onClose") 取消
            el-button(type="primary" @click="onSend") 確認
</template>
<script lang="ts">
import { defineComponent, PropType, reactive, watch } from 'vue';
import BoxEditCardMessageTemplateModel from '@/models/box-management/box-edit/BoxEditCardMessageTemplateModel';
import { ElMessageBox } from 'element-plus';
export default defineComponent({
    name: 'BoxEditCardMessageTemplate',
    emits: ['onSelect', 'update:visible'],
    props: {
        data: {
            type: Object as PropType<Array<BoxEditCardMessageTemplateModel>>,
            default: () => {
                return new Array<BoxEditCardMessageTemplateModel>();
            }
        },
        title: {
            type: String,
            default: ''
        },
        visible: {
            type: Boolean,
            defaul: false
        }
    },
    components: {},
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
                ElMessageBox.alert('請選擇文案範本！');
                return;
            }
            ctx.emit('onSelect', props.data[state.radioValue].messageText);
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
