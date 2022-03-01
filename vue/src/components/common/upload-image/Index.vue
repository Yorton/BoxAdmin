<template lang="pug">
.upload-image
    el-upload(
        action="#"
        list-type="picture-card"
        :class="otherClass"
        :auto-upload="false"
        :limit="limit"
        :file-list="imgList"
        :on-change="onUploadFileChange"
        :on-remove="onRemove"
        :on-preview="onPreview"
    )
        template(#default)
            i.el-icon-plus
    el-dialog(v-model='state.dialogVisible')
        img(style="width:100%;" :src='state.dialogImageUrl' alt)
</template>
<script lang="ts">
import { computed, defineComponent, PropType, reactive } from 'vue';
import ImageBox from '@/components/common/image-box/Index.vue';
import ElUploadFileModel from '@/models/components/common/ElUploadFileModel';
import { UploadFile } from 'node_modules/element-plus/lib/el-upload/src/upload.type';
export default defineComponent({
    name: 'UploadImage',
    components: {
        ImageBox
    },
    props: {
        list: {
            type: Object as PropType<Array<string>>,
            default: () => {
                return [];
            }
        },
        limit: {
            type: Number,
            default: 1
        }
    },
    setup(props, ctx) {
        const state = reactive({
            dialogVisible: false,
            dialogImageUrl: ''
        });
        const imgList = computed(() => {
            const arr: Array<ElUploadFileModel | UploadFile> = [];
            props.list.forEach(item => {
                if (item) {
                    if (typeof item === 'string') {
                        arr.push(new ElUploadFileModel('', item));
                    } else {
                        arr.push((item as unknown) as UploadFile);
                    }
                }
            });
            return arr;
        });

        const otherClass = computed(() => {
            return {
                'upload-image__hidden-upload-tool':
                    imgList.value.length === props.limit
            };
        });

        const onEmit = (fileList: Array<UploadFile>) => {
            // window.console.log('============== onEmit =============');
            // window.console.log([...fileList]);
            const arr: Array<string | UploadFile> = [];
            fileList.forEach((item: UploadFile) => {
                if (item.raw) {
                    arr.push(item);
                } else {
                    arr.push(String(item.url));
                }
            });
            ctx.emit('update:list', arr);
        };

        const onPreview = (file: UploadFile) => {
            state.dialogVisible = true;
            state.dialogImageUrl = String(file.url);
        };

        const onUploadFileChange = (
            file: UploadFile,
            fileList: Array<UploadFile>
        ) => {
            // window.console.log(
            //     '============== onUploadFileChange ============='
            // );
            // window.console.log(file);
            // window.console.log(fileList);
            onEmit(fileList);
        };

        const onRemove = (file: UploadFile, fileList: Array<UploadFile>) => {
            // window.console.log('============== onRemove =============');
            // window.console.log(file);
            // window.console.log(fileList);
            onEmit(fileList);
        };

        return {
            state,
            imgList,
            otherClass,
            onPreview,
            onUploadFileChange,
            onRemove
        };
    }
});
</script>
<style lang="scss">
.upload-image {
    position: relative;
    min-width: 100px;
    min-height: 100px;
    &__content {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        z-index: 1;
    }
    &__bg {
        position: relative;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: #000;
        opacity: 0.2;
        cursor: pointer;
    }
    &__upload {
        position: absolute;
        font-size: 30px;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        cursor: pointer;
        z-index: 1;
        color: #fff;
    }
    &__delete {
        position: absolute;
        margin: 5px;
        bottom: 0;
        left: 0;
        color: #fff;
        cursor: pointer;
        z-index: 1;
    }
    &__hidden-upload-tool {
        .el-upload--picture-card {
            display: none;
        }
    }
}
</style>
