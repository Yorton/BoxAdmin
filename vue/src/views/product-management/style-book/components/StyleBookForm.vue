<template lang="pug">
el-dialog(:title="formTitle" v-model="state.dialogVisible" @closed="onClosed" :close-on-click-modal="false")
    .style-book-form
        el-form(:model="state.styleBookData" label-width="140px")
            el-form-item(label="穿搭組合照" width="100px")
                el-row
                    el-col
                        UploadImage(v-model:list="state.matchingProductImages" :limit="1")
            el-form-item(label="搭配商品")
                el-row(:gutter="5")
                    el-col(
                        :span="6" 
                        v-for="(item, index) in state.styleBookData.items" 
                        :key="`matching-product1-${index}`"
                    )
                        image-box(:src="item.imageUrl")
            el-form-item(label="風格分類")
                el-row
                    el-col(:span="12")
                        el-select(v-model="state.styleBookData.styleId")
                            el-option(
                                v-for="(item, index) in state.styleList" 
                                :label='item.label' 
                                :value='item.value'
                                :key="`style-${index}`")
            el-form-item(label="情境場合")
                el-row
                    el-col(:span="12")
                        el-select(v-model="state.styleBookData.occasionId")
                            el-option(
                                v-for="(item, index) in state.occasionList" 
                                :label='item.label' 
                                :value='item.value'
                                :key="`style-${index}`")
            el-form-item(label="穿搭顧問")
                el-row
                    el-col(:span="12")
                        el-select(v-model="state.styleBookData.matchmaker.id")
                            el-option(
                                v-for="(item, index) in state.matchingMakerList" 
                                :label='item.label' 
                                :value='item.value'
                                :key="`style-${index}`")
            el-form-item(label="更新時間")
                el-row
                    el-col {{state.styleBookData.modifyDate}}
            el-form-item(label="最後異動人員")
                el-row
                    el-col {{state.styleBookData.modifier}}
    template(#footer)
        span.dialog-footer
            el-button(@click="onClose") 取 消
            el-button(type='primary' @click="onSave") 儲 存
</template>

<script lang="ts">
import { computed, defineComponent, PropType, reactive, watch } from 'vue';
import UploadImage from '@/components/common/upload-image/Index.vue';
import { UploadFile } from 'element-plus/lib/el-upload/src/upload.type';
// import StyleBookFormModel from '@/models/api/style-book/StyleBookFormModel';
import StyleBookFormResponseModel from '@/models/api/style-book/StyleBookFormResponseModel';
import {
    GetStyleBookDetail,
    UpdateStyleBook,
    UpdateStyleBookImage
} from '@/_api/style-book.api';
// import { ElMessage, ElMessageBox } from 'element-plus';
import { SetLoading } from '@/_utils/common';
import StyleItemModel from '@/models/api/style-book/StyleItemModel';
import OccasionItemModel from '@/models/api/style-book/OccasionItemModel';
import OptionModel from '@/models/OptionModel';
import ImageBox from '@/components/common/image-box/Index.vue';
import MatchMasterModel from '@/models/api/matching-maker/MatchMasterModel';
import StyleBookFormModel from '@/models/api/style-book/StyleBookFormModel';
import { ElMessageBox } from 'element-plus';

export default defineComponent({
    name: 'StyleBookForm',
    props: {
        visible: {
            type: Boolean,
            default: false
        },
        id: {
            type: String,
            default: ''
        },
        styleList: {
            type: Array as PropType<Array<StyleItemModel>>,
            default: () => {
                return [];
            }
        },
        occasionList: {
            type: Array as PropType<Array<OccasionItemModel>>,
            default: () => {
                return [];
            }
        },
        matchingMakerList: {
            type: Array as PropType<Array<MatchMasterModel>>,
            default: () => {
                return [];
            }
        }
    },
    components: {
        UploadImage,
        ImageBox
    },
    setup(props, ctx) {
        const state = reactive({
            styleBookData: new StyleBookFormResponseModel(),
            matchingProductImages: new Array<string | UploadFile>(),
            styleList: computed(() => {
                return [
                    new OptionModel('請選擇風格'),
                    ...props.styleList.map((item: StyleItemModel) => {
                        return new OptionModel(item.title, item.id);
                    })
                ];
            }),
            occasionList: computed(() => {
                return [
                    new OptionModel('請選擇情境場合'),
                    ...props.occasionList.map((item: OccasionItemModel) => {
                        return new OptionModel(item.title, item.id);
                    })
                ];
            }),
            matchingMakerList: computed(() => {
                return [
                    new OptionModel('請選擇穿搭顧問'),
                    ...props.matchingMakerList.map((item: MatchMasterModel) => {
                        return new OptionModel(item.name, item.id);
                    })
                ];
            }),
            dialogVisible: false,
            pictureUpload: new Array<UploadFile>(),
            uploadId: ''
        });
        const formTitle = computed(() => {
            return `搭配組合-${props.id === '' ? '新增' : '編輯'}`;
        });

        const onClose = () => {
            state.dialogVisible = false;
        };
        const onClosed = () => {
            state.styleBookData = new StyleBookFormResponseModel();
            state.matchingProductImages = [];
            ctx.emit('update:visible', false);
        };

        const onSaved = () => {
            onClose();
            ctx.emit('onSaved', '');
        };

        const getStyleBookDetail = async () => {
            try {
                SetLoading(true);
                const { data } = await GetStyleBookDetail(props.id);
                state.styleBookData = {
                    ...(data.data as StyleBookFormResponseModel)
                };
                state.styleBookData.imageUrl &&
                    state.matchingProductImages.push(
                        state.styleBookData.imageUrl
                    );
                console.log(state.styleBookData);
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };
        const updateStyleBookImage = async (files: Array<UploadFile>) => {
            try {
                const formData = new FormData();
                files.forEach(file => {
                    formData.append('file', file.raw);
                });
                SetLoading(true);
                const { data } = await UpdateStyleBookImage(
                    state.uploadId,
                    formData
                );
                console.log(data);
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        const updateStyleBook = async () => {
            try {
                const sendObj = new StyleBookFormModel();
                sendObj.id = state.styleBookData.id;
                sendObj.matchmakerInfoId = state.styleBookData.matchmaker.id;
                sendObj.styleId = state.styleBookData.styleId;
                sendObj.occasionId = state.styleBookData.occasionId;
                sendObj.items = [...state.styleBookData.items];
                state.matchingProductImages.forEach(item => {
                    if (typeof item === 'string') {
                        sendObj.imageUrl = String(item);
                    } else {
                        state.pictureUpload.push(item);
                    }
                });
                SetLoading(true);
                const { data } = await UpdateStyleBook(sendObj);
                console.log(data);
                state.uploadId = data.data.id;
                state.pictureUpload.length &&
                    (await updateStyleBookImage(state.pictureUpload));
                ElMessageBox.alert('儲存成功').then(onSaved.bind(this));
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const onSave = () => {
            if (!state.matchingProductImages.length) {
                ElMessageBox.alert('請上傳穿搭組合照');
                return;
            }
            if (!state.styleBookData.items.length) {
                ElMessageBox.alert('請選擇搭配商品');
                return;
            }
            if (!state.styleBookData.styleId) {
                ElMessageBox.alert('請選擇風格');
                return;
            }
            if (!state.styleBookData.occasionId) {
                ElMessageBox.alert('請選擇情境場合');
                return;
            }
            if (!state.styleBookData.matchmaker.id) {
                ElMessageBox.alert('請選擇穿搭顧問');
                return;
            }
            // if (!state.styleBookData.likeStyle) {
            //     ElMessageBox.alert('輸入搭配師擅長風格');
            //     return;
            // }
            // if (!state.styleBookData.signatureUrl.length) {
            //     ElMessageBox.alert('請至少上傳一張簽名檔');
            //     return;
            // }

            updateStyleBook();
        };
        const handleVisible = () => {
            if (props.visible) {
                state.dialogVisible = props.visible;
                if (props.id) {
                    getStyleBookDetail();
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
