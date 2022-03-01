<template lang="pug">
.box-edit-card
    el-scrollbar
        el-row
            el-col
                h2.box-edit-card__title.ob-mr-1 小卡製作
                el-button(size="mini" type="primary" @click="onSave") 儲存
                el-button(size="mini" type="info" @click="onPreview") 預覽
        el-row.ob-ml-3.ob-mt-1
            el-col(:span="16")
                el-row
                    el-col
                        h3.box-edit-card__subtitle 小卡版型
                        .box-edit-card__board.ob-mt-1
                            image-box
                            el-button.box-edit-card__card-btn(size="mini" type="info") 選擇小卡版型
                el-row.ob-mt-1
                    el-col
                        el-row
                            el-col(:span="20")
                                h3.box-edit-card__subtitle 小卡問候語(限300字)
                            el-col.ob-align-right(:span="4")
                                el-button(size="mini" type="info" icon="el-icon-plus" @click="onAddMessage(1)")
                        el-row.ob-mt-1
                            el-col
                                el-input.box-edit-card__text(
                                    v-model="state.message"
                                    type="textarea" 
                                    placeholder="請輸入小卡問候語" 
                                    maxlength="300" 
                                    show-word-limit
                                    :autosize="{minRows: 3}"
                                )
                el-row.ob-mt-1
                    el-col
                        el-row
                            el-col(:span="20")
                                h3.box-edit-card__subtitle 搭配師簽名檔
                            el-col.ob-align-right(:span="4")
                                el-button(size="mini" type="info" icon="el-icon-plus" @click="onAddSignature")
                        el-row.ob-mt-1
                            el-col
                                .box-edit-card__sign-box
                                    ImageBox(:src="state.signatureImage")
                el-row.ob-mt-1
                    el-col
                        h3.box-edit-card__subtitle BOX內商品
                        el-table.ob-mt-1(:data="state.productList" :show-header="false" :border="true")
                            el-table-column(width="150")
                                template(#default="{row}")
                                    product-item(:data="row.product1")
                            el-table-column(width="150")
                                template(#default="{row}")
                                    product-item(:data="row.product2")
                            el-table-column
                                template(#default="{row, $index}")
                                    .box-edit-card__copywriting
                                        .box-edit-card__copywriting-title 搭配文案(限300字)
                                        el-button.box-edit-card__copywriting-button(size="mini" type="info" icon="el-icon-plus" @click="onAddMessage(2, $index)")
                                        el-input.ob-mt-1(
                                            v-model="row.text" 
                                            type="textarea" 
                                            placeholder="請輸入搭配文案" 
                                            maxlength="300" 
                                            show-word-limit
                                            :autosize="{minRows: 6}"
                                        )
    box-edit-card-message-template(:data="msgTemplates" :title="msgTemplateTitle" v-model:visible="state.msgTempVisible" @on-select="onSelectMessage")
    box-edit-card-signature(:data="state.signatures" title="搭配師簽名檔" v-model:visible="state.signatureVisible" @on-select="onSelectSignature")
    box-edit-card-preview(v-model:visible="state.previewVisible")
</template>
<script lang="ts">
import { computed, defineComponent, inject, reactive, ref, watch } from 'vue';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
import ImageBox from '@/components/common/image-box/Index.vue';
import ProductItem from '@/components/common/product-item/Index.vue';
import BoxEditCardMessageTemplate from './BoxEditCardMessageTemplate.vue';
import BoxEditCardSignature from './BoxEditCardSignature.vue';
import BoxEditCardPreview from './BoxEditCardPreview.vue';
import ProductItemModel from '@/models/components/common/ProductItemModel';
import BoxEditCardTableModel from '@/models/box-management/box-edit/BoxEditCardTableModel';
import BoxEditCardMessageTemplateModel from '@/models/box-management/box-edit/BoxEditCardMessageTemplateModel';
import MessageTemplateModel from '@/models/api/reservation/MessageTemplateModel';
import CardGroupModel from '@/models/api/reservation/CardGroupModel';
import BoxEditDataModel from '@/models/box-management/box-edit/BoxEditDataModel';
import CardGroupItemModel from '@/models/api/reservation/CardGroupItemModel';
import { GetMessageTemplate, SaveCard } from '@/_api/reservation.api';
import { GetMatchingMakerDetail } from '@/_api/matching-maker.api';
import { SetLoading } from '@/_utils/common';
import { ElMessageBox } from 'element-plus';
export default defineComponent({
    name: 'BoxEditCard',
    components: {
        ImageBox,
        ProductItem,
        BoxEditCardMessageTemplate,
        BoxEditCardSignature,
        BoxEditCardPreview
    },
    setup() {
        const boxData = inject('boxData', ref(new BoxEditDataModel()));
        const matchedList = inject(
            'matchedList',
            ref(new Array<BoxEditGroupModel>())
        );
        const getBoxInformation = inject(
            'getBoxInformation',
            (id: string, bol = true) => {
                console.log(id, bol);
            }
        );
        const state = reactive({
            cardType: 1, //卡片版型
            message: boxData.value.card.intro, // 小卡問候語
            signatureImage: boxData.value.card.signatureUrl, // 搭配師簽名檔
            productList: new Array<BoxEditCardTableModel>(), // 搭配品清單
            productNum: 0, // 搭配品位置
            signatures: new Array<string>(), // 搭配師簽名檔
            signatureVisible: false, // 搭配師簽名列表是否開啟
            copywritingTemplates: new Array<BoxEditCardMessageTemplateModel>(), // 搭配品文案範本
            messageTemplates: new Array<BoxEditCardMessageTemplateModel>(), // 問候語文案範例
            msgTempType: 1, // 文案範本類別 1: 問候語 2: 搭配文案
            msgTempVisible: false, // 文案範本選擇是否開啟
            previewVisible: false //預覽是否打開
        });
        const msgTemplates = computed(() => {
            return state.msgTempType === 1
                ? state.messageTemplates
                : state.copywritingTemplates;
        });
        const isMessage = computed(() => {
            return state.msgTempType === 1;
        });
        // const isCopywriting = computed(() => {
        //     return state.msgTempType === 2;
        // });
        const msgTemplateTitle = computed(() => {
            return isMessage.value ? '小卡問候語' : '搭配文案';
        });
        const setTableList = () => {
            state.productList = [];
            matchedList.value.forEach(item => {
                const cardTable: BoxEditCardTableModel = new BoxEditCardTableModel(
                    item.id
                );
                item.items.forEach((subItem, index) => {
                    if (!subItem.sku) return;
                    const productItem: ProductItemModel = new ProductItemModel(
                        subItem.imageUrl,
                        subItem.productName,
                        subItem.color,
                        subItem.size,
                        subItem.price
                    );
                    if (index === 0) {
                        cardTable.product1 = productItem;
                    } else {
                        cardTable.product2 = productItem;
                    }
                    cardTable.text = item.matchingMessage;
                });
                if (cardTable.product1.src || cardTable.product2.src) {
                    state.productList.push(cardTable);
                }
            });
        };

        const init = () => {
            state.cardType = boxData.value.card.template;
            state.message = boxData.value.card.intro;
            state.signatureImage = boxData.value.card.signatureUrl;
        };

        const getMessageTemplate = async () => {
            if (msgTemplates.value.length) {
                state.msgTempVisible = true;
                return;
            }
            try {
                const { data } = await GetMessageTemplate(
                    new MessageTemplateModel(state.msgTempType)
                );
                if (data.succeeded) {
                    if (isMessage.value) {
                        state.messageTemplates = [...data.data.items];
                    } else {
                        state.copywritingTemplates = [...data.data.items];
                    }
                    state.msgTempVisible = true;
                } else {
                    throw new Error(data.message);
                }
            } catch (error) {
                console.log(error);
            }
        };

        const getSignature = async () => {
            if (state.signatures.length) {
                state.signatureVisible = true;
                return;
            }
            try {
                const { data } = await GetMatchingMakerDetail(
                    boxData.value.matchmaker.id
                );
                if (data.succeeded) {
                    state.signatures = [...data.data.signatureUrl];
                    state.signatureVisible = true;
                } else {
                    throw new Error(data.message);
                }
            } catch (error) {
                console.log(error);
            }
        };

        const saveCard = async () => {
            try {
                const sendObj = new CardGroupModel(
                    boxData.value.id,
                    state.cardType,
                    state.message,
                    state.signatureImage
                );
                state.productList.forEach(item => {
                    sendObj.groups.push(
                        new CardGroupItemModel(item.groupId, item.text)
                    );
                });
                SetLoading(true);
                const { data } = await SaveCard(sendObj);
                if (data.succeeded) {
                    ElMessageBox.alert('卡片儲存成功！', {
                        callback: () => {
                            getBoxInformation(boxData.value.id);
                        }
                    });
                } else {
                    throw new Error(data.message);
                }
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };

        const onAddSignature = () => {
            getSignature();
        };

        const onAddMessage = (type = 1, index = 0) => {
            state.msgTempType = type;
            state.productNum = index;
            getMessageTemplate();
        };
        const onSelectMessage = (text = '') => {
            if (isMessage.value) {
                state.message = text;
            } else {
                state.productList[state.productNum].text = text;
            }
        };
        const onSelectSignature = (pic = '') => {
            state.signatureImage = pic;
        };
        const onSave = () => {
            saveCard();
        };
        const onPreview = () => {
            state.previewVisible = true;
        };

        watch(() => matchedList.value, setTableList, { immediate: true });
        watch(() => boxData.value, init, { immediate: true });
        return {
            state,
            msgTemplates,
            msgTemplateTitle,
            onAddSignature,
            onAddMessage,
            onSelectMessage,
            onSelectSignature,
            onSave,
            onPreview
        };
    }
});
</script>
<style lang="scss">
.box-edit-card {
    position: relative;
    height: 94%;
    &__title {
        display: inline-block;
        margin: 0;
    }
    &__subtitle {
        margin: 0;
        font-weight: normal;
    }
    &__board {
        position: relative;
        width: 120px;
        min-height: 150px;
        border: 1px solid #dcdfe6;
    }
    &__card-btn {
        position: absolute;
        bottom: 10px;
        left: 50%;
        transform: translateX(-50%);
    }
    &__sign-box {
        border: 1px solid #dcdfe6;
        min-height: 100px;
    }
    &__copywriting {
        position: relative;
    }
    &__copywriting-button {
        position: absolute;
        top: 0;
        right: 0;
    }
}
</style>
