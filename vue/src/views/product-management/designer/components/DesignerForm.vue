<template lang="pug">
el-dialog(:title="formTitle" v-model="state.dialogVisible" @closed="onClosed" :close-on-click-modal="false")
    .designer-form
        el-form(:model="state.disgnerData" label-width="140px")
            el-form-item(label="搭配師照片" width="100px")
                el-row
                    el-col
                        UploadImage(v-model:list="state.disgnerData.pictureUrl")
            el-form-item(label="搭配師名稱" prop="name")
                el-row
                    el-col(:span="12")
                        el-input(v-model="state.disgnerData.name" placeholder="請輸入")
            el-form-item(label="搭配師口號" prop="slogan")
                el-row
                    el-col(:span="12")
                        el-input(v-model="state.disgnerData.slogan" placeholder="請輸入")
            el-form-item(label="搭配師介紹" prop="selfIntroduction")
                el-row
                    el-col(:span="12")
                        el-input(v-model="state.disgnerData.selfIntroduction" type="textarea" placeholder="請輸入")
            el-form-item(label="搭配師擅長風格" prop="likeStyle")
                el-row
                    el-col(:span="12")
                        el-input(v-model="state.disgnerData.likeStyle" placeholder="請輸入")
            el-form-item(label="簽名檔" prop="slogan")
                el-row
                    el-col
                        UploadImage(v-model:list="state.disgnerData.signatureUrl" :limit="2")
    template(#footer)
        span.dialog-footer
            el-button(@click="onClose") 取 消
            el-button(type='primary' @click="onSave") 儲 存
</template>
<script lang="ts">
import { computed, defineComponent, reactive, watch } from 'vue';
import UploadImage from '@/components/common/upload-image/Index.vue';
import MatchMakerFormModel from '@/models/api/matching-maker/MatchMakerFormModel';
import {
    GetMatchingMakerDetail,
    UpdateMatchingMaker,
    UpdateMatchingMakerImage
} from '@/_api/matching-maker.api';
import { ElMessageBox } from 'element-plus';
import { UploadFile } from 'node_modules/element-plus/lib/el-upload/src/upload.type';
import { SetLoading } from '@/_utils/common';
export default defineComponent({
    name: 'DesignerForm',
    emits: ['onSaved', 'update:visible'],
    props: {
        visible: {
            type: Boolean,
            default: false
        },
        id: {
            type: String,
            default: ''
        }
    },
    components: {
        UploadImage
    },
    setup(props, ctx) {
        const state = reactive({
            disgnerData: new MatchMakerFormModel(),
            dialogVisible: false,
            pictureUpload: new Array<UploadFile>(),
            sloganUpload: new Array<UploadFile>(),
            uploadId: ''
        });
        const formTitle = computed(() => {
            return `${props.id === '' ? '新增' : '編輯'}設計師`;
        });

        const updateMatchingMakerImage = async (
            type: number,
            files: Array<UploadFile>
        ) => {
            try {
                const formData = new FormData();
                formData.append('type', String(type));
                files.forEach(file => {
                    formData.append('file', file.raw);
                });
                const { data } = await UpdateMatchingMakerImage(
                    state.uploadId,
                    formData
                );
                window.console.log(data);
            } catch (error) {
                window.console.log(error);
            }
        };

        const getMatchingMakerDetail = async () => {
            try {
                SetLoading(true);
                const { data } = await GetMatchingMakerDetail(props.id);
                state.disgnerData = data.data;
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };

        const onClose = () => {
            state.dialogVisible = false;
        };
        const onClosed = () => {
            state.disgnerData = new MatchMakerFormModel();
            ctx.emit('update:visible', false);
        };
        const onSaved = () => {
            onClose();
            ctx.emit('onSaved', '');
        };
        const updateMatchingMaker = async () => {
            try {
                const sendObj: MatchMakerFormModel = {
                    ...state.disgnerData
                } as MatchMakerFormModel;
                sendObj.pictureUrl = sendObj.pictureUrl.filter(item => {
                    if (typeof item === 'string') {
                        return true;
                    } else {
                        state.pictureUpload.push(item);
                        return false;
                    }
                });
                sendObj.signatureUrl = sendObj.signatureUrl.filter(item => {
                    if (typeof item === 'string') {
                        return true;
                    } else {
                        state.sloganUpload.push(item);
                        return false;
                    }
                });
                SetLoading(true);
                const { data } = await UpdateMatchingMaker(sendObj);
                window.console.log(data);
                state.uploadId = data.data.id;
                state.pictureUpload.length &&
                    (await updateMatchingMakerImage(1, state.pictureUpload));
                state.sloganUpload.length &&
                    (await updateMatchingMakerImage(2, state.sloganUpload));
                ElMessageBox.alert('儲存成功').then(onSaved.bind(this));
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };

        const onSave = () => {
            if (!state.disgnerData.pictureUrl.length) {
                ElMessageBox.alert('請上傳設計師照片');
                return;
            }
            if (!state.disgnerData.name) {
                ElMessageBox.alert('輸入搭配師名稱');
                return;
            }
            if (!state.disgnerData.slogan) {
                ElMessageBox.alert('輸入搭配師口號');
                return;
            }
            if (!state.disgnerData.selfIntroduction) {
                ElMessageBox.alert('輸入搭配師介紹');
                return;
            }
            if (!state.disgnerData.likeStyle) {
                ElMessageBox.alert('輸入搭配師擅長風格');
                return;
            }
            if (!state.disgnerData.signatureUrl.length) {
                ElMessageBox.alert('請至少上傳一張簽名檔');
                return;
            }

            updateMatchingMaker();
        };

        const handleVisible = () => {
            if (props.visible) {
                state.dialogVisible = props.visible;
                if (props.id) {
                    getMatchingMakerDetail();
                }
            }
        };
        watch(() => props.visible, handleVisible, { immediate: true });
        return {
            state,
            formTitle,
            onClose,
            onClosed,
            onSave
        };
    }
});
</script>
<style lang="scss">
.designer-form {
    position: relative;
}
</style>
