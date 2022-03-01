<template lang="pug">
.style-book.ob-container
    el-row
        h2 搭配組合
    el-row
        el-col
            el-form.style-book__search-bar.ob-p-2
                el-form-item.style-book__search-item(label="風格分類：")
                    custom-checkbox-group(v-model:value="searchForm.styles" :list="state.styleList")
                el-form-item.style-book__search-item(label="情境組合：")
                    custom-checkbox-group(v-model:value="searchForm.occasions" :list="state.occasionList")
                el-form-item.style-book__search-item(label="穿搭顧問：")
                    el-select(v-model="searchForm.matchmaker")
                        el-option(
                            v-for="(item, index) in state.matchingMakerList" 
                            :label='item.name' 
                            :value='item.id'
                            :key="`style-master-${index}`")
                el-form-item.style-book__search-item(label="穿搭照：")
                    el-radio(v-for="(item, index) in state.pictureTypes" v-model="searchForm.imageType" :label="parseInt(item.label)") {{item.name}}
                el-form-item.style-book__search-item.ob-align-right
                    el-button(size='medium' type='primary' icon='el-icon-search' @click="onSearch") 查詢
    el-row.style-book__list.ob-mt-2.ob-p-2
        el-col.ob-align-right
            el-button(size='mini' type='info' @click="onExport") 匯出
            el-button(size='mini' type='success' @click="onAdd") 新增
        el-col
            custom-table.ob-mt-1(:data="state.list" v-model:current-page="state.currentPage" border)
                el-table-column(label="穿搭組合照" min-width="150")
                    template(#default="{row}")
                        image-box(:src="row.imageUrl")
                el-table-column(label="商品色塊組圖" min-width="150")
                    template(#default="{row}")
                        image-box.style-book__table-img(
                            v-for="(item, index) in row.colorImage"
                            :src="item"
                            :key="`picture-${index}`"
                        )
                el-table-column(prop="style" label="風格分類" sortable='custom' min-width="105")
                el-table-column(prop="occasion" label="情境場合" sortable='custom' min-width="105")
                el-table-column(prop="matchmaker" label="穿搭顧問" sortable='custom' min-width="105")
                el-table-column(prop="createdDate" label="建立時間" sortable='custom' min-width="105")
                el-table-column(prop="modifyDate" label="最後異動時間" sortable='custom' min-width="130")
                el-table-column(prop="modifier" label="最後異動人員" sortable='custom' min-width="130")
                el-table-column(label="功能" min-width="150" fixed="right")
                    template(#default="{row}")
                        el-button(type="danger" size="mini" @click="onDelete(row)") 刪除
                        el-button(type="success" size="mini" @click="onEdit(row)") 編輯
    style-book-form(
        v-model:visible="state.styleBookForm.visible"
        :id="state.styleBookForm.id"
        :style-list="state.styleOiginList" 
        :occasion-list="state.occasionOiginList"
        :matching-maker-list="state.matchingMakerOiginList"
        @on-saved="onFormSaved"
    )
</template>

<script lang="ts">
import {
    GetOccasionList,
    GetStyleBookList,
    GetStyleList,
    RemoveStyleBook
} from '@/_api/style-book.api';
import { GetMatchingMakerList } from '@/_api/matching-maker.api';
import { defineComponent, onMounted, reactive } from 'vue';
import StyleBookSearchFormModel from '@/models/product-management/style-book/StyleBookSearchFormModel';
import CheckboxMode from '@/models/CheckboxModel';
import RadioModel from '@/models/RadioModel';
import StyleItemModel from '@/models/api/style-book/StyleItemModel';
import OccasionItemModel from '@/models/api/style-book/OccasionItemModel';
import MatchMasterModel from '@/models/api/matching-maker/MatchMasterModel';
import StyleBookQueryModel from '@/models/api/style-book/StyleBookQueryModel';
import StyleBookItemModel from '@/models/api/style-book/StyleBookItemModel';
import { SetLoading } from '@/_utils/common';
import CustomCheckboxGroup from '@/components/common/custom-checkbox-group/Index.vue';
import ImageBox from '@/components/common/image-box/Index.vue';
import CustomTable from '@/components/common/custom-table/Index.vue';
import StyleBookForm from './components/StyleBookForm.vue';
import { ElMessageBox } from 'element-plus';
// import { ElMessage, ElMessageBox } from 'element-plus';

export default defineComponent({
    name: 'StyleBook',
    components: {
        CustomCheckboxGroup,
        CustomTable,
        ImageBox,
        StyleBookForm
    },
    setup() {
        const state = reactive({
            styleSelecteds: [],
            occasionSelecteds: [],
            styleOiginList: new Array<StyleItemModel>(),
            occasionOiginList: new Array<OccasionItemModel>(),
            styleList: new Array<CheckboxMode>(),
            occasionList: new Array<CheckboxMode>(),
            matchingMakerOiginList: new Array<MatchMasterModel>(),
            matchingMakerList: [new MatchMasterModel('', '所有顧問')],
            pictureTypes: [
                new RadioModel('0', '全部'),
                new RadioModel('1', '已上傳'),
                new RadioModel('2', '未上傳')
            ],
            list: new Array<StyleBookItemModel>(),
            currentPage: 1,
            styleBookForm: {
                visible: false,
                id: ''
            }
        });
        const searchForm = reactive(new StyleBookSearchFormModel());
        const listFilter = (items: StyleBookItemModel[]) => {
            state.list = [...items];
        };
        const getInitData = async () => {
            try {
                SetLoading(true);
                const [res1, res2, res3] = await Promise.all([
                    GetStyleList(),
                    GetOccasionList(),
                    GetMatchingMakerList()
                ]);
                state.styleOiginList = res1.data.data.items as Array<
                    StyleItemModel
                >;
                state.occasionOiginList = res2.data.data.items as Array<
                    OccasionItemModel
                >;
                state.matchingMakerOiginList = res3.data.data
                    .matchingMakers as Array<MatchMasterModel>;
                state.styleList = state.styleOiginList.map(
                    (item: StyleItemModel) => {
                        return new CheckboxMode(item.id, item.title);
                    }
                );
                state.occasionList = state.occasionOiginList.map(
                    (item: OccasionItemModel) => {
                        return new CheckboxMode(item.id, item.title);
                    }
                );
                state.matchingMakerList = [
                    ...state.matchingMakerList,
                    ...state.matchingMakerOiginList
                ];
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };

        const getStyleBookList = async () => {
            try {
                SetLoading(true);
                const { data } = await GetStyleBookList(
                    new StyleBookQueryModel(
                        searchForm.matchmaker,
                        searchForm.styles.join(','),
                        searchForm.occasions.join(','),
                        searchForm.imageType
                    )
                );
                listFilter(data.data.items);
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };

        const removeItem = async (id: string) => {
            try {
                SetLoading(true);
                await RemoveStyleBook(id);
                getStyleBookList();
            } catch (error) {
                window.console.log(error);
            }
            SetLoading();
        };

        const onSearch = () => {
            state.currentPage = 1;
            getStyleBookList();
        };

        const onAdd = () => {
            state.styleBookForm.id = '';
            state.styleBookForm.visible = true;
            console.log('onAdd');
        };
        const onEdit = (item: StyleBookItemModel) => {
            state.styleBookForm.id = item.id;
            state.styleBookForm.visible = true;
            console.log(item);
        };
        const onDelete = (item: StyleBookItemModel) => {
            ElMessageBox.confirm('確定刪除？', '提示').then(() => {
                removeItem(item.id);
            });
        };

        const onFormSaved = () => {
            getStyleBookList();
        };

        const onExport = () => {
            console.log('onExport');
        };

        onMounted(() => {
            getInitData();
        });
        return {
            state,
            searchForm,
            onSearch,
            onAdd,
            onEdit,
            onDelete,
            onExport,
            onFormSaved
        };
    }
});
</script>
<style lang="scss">
@import '@/styles/element-variables.scss';
.style-book {
    position: relative;
    &__search-bar {
        border: $--table-border;
    }
    &__search-item {
        margin-bottom: 0;
    }
    &__list {
        border: $--table-border;
    }
    &__table {
        margin-top: 30px;
        &-img {
            display: inline-block;
            max-width: 70px;
            margin: 5px;
        }
    }
}
</style>
