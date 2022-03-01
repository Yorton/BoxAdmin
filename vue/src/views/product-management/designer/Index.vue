<template lang="pug">
.designer.ob-p-3
    h3.designer__titile 搭配師管理
    .designer__container.ob-mt-3
        .ob-align-right
            el-button(type="primary" @click="onAdd") 新增
        el-table.ob-mt-1(:data="state.matchingMakers" height="700px" border)
            el-table-column(prop="name" label="搭配師名稱")
            el-table-column(label="搭配師照片")
                template(#default="{row}")
                    image-box.designer__img(
                        v-for="(item, index) in row.pictures"
                        :src="item"
                        :key="`picture-${index}`"
                    )
            el-table-column(label="已搭配盒子")
                template(#default="{row}")
                    span {{row.boxCount}} 盒
            el-table-column(prop="name" label="九大風格個搭配幾盒" align="center")
                template(#header)
                    p.designer__table-title 九大風格
                    p.designer__table-title 各搭配了幾盒
                template(#default="{row}")
                    p.designer__box-style(v-for="(item, index) in row.matchingCounts" :key="`box-style-${index}`") {{item.title}}：{{item.count}}
            el-table-column(prop="createdDate" label="建立時間")
            el-table-column(label="功能" width="100px")
                template(#default="{row}")
                    el-button(type="success" size="mini" @click="onEdit(row)") 編輯
        designer-form(v-model:visible="state.designerForm.visible" :id="state.designerForm.id" @on-saved="onFormSaved")
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';
import ImageBox from '@/components/common/image-box/Index.vue';
import DesignerForm from './components/DesignerForm.vue';
import MatchMasterModel from '@/models/api/matching-maker/MatchMasterModel';
// import { ElMessage, ElMessageBox } from 'element-plus';
import { GetMatchingMakerList } from '@/_api/matching-maker.api';
import { SetLoading } from '@/_utils/common';
export default defineComponent({
    name: 'Designer',
    components: {
        ImageBox,
        DesignerForm
    },
    setup() {
        const state = reactive({
            matchingMakers: new Array<MatchMasterModel>(),
            designerForm: {
                visible: false,
                id: ''
            }
        });
        const getMatchMakers = async () => {
            try {
                SetLoading(true);
                const { data } = await GetMatchingMakerList();
                if (data.succeeded) {
                    state.matchingMakers = [...data.data.matchingMakers];
                } else {
                    throw new Error(data.message);
                }
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const openDisgnerForm = (id = '') => {
            state.designerForm.id = id;
            state.designerForm.visible = true;
        };
        const onAdd = () => {
            openDisgnerForm();
        };
        const onEdit = (item: MatchMasterModel) => {
            openDisgnerForm(item.id);
        };
        const onFormSaved = () => {
            getMatchMakers();
        };
        onMounted(() => {
            getMatchMakers();
        });
        return {
            state,
            onAdd,
            onEdit,
            onFormSaved
        };
    }
});
</script>
<style lang="scss">
.designer {
    &__titile {
        margin: 0;
    }
    &__container {
        position: relative;
        // width: 80%;
    }
    &__img {
        width: 100px;
    }
    &__table-title {
        margin: 0;
    }
    &__box-style {
        margin: 0;
    }
}
</style>
