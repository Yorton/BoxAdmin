<template lang="pug">
.box-edit-product-match.ob-mr-1
    el-scrollbar
        el-row
            el-col.box-edit-product-match__select-box.ob-p-1
                h3.box-edit-product-match__title 預選清單
                .box-edit-product-match__select-content.ob-mt-1(v-if="preselectList.length")
                    swiper.box-edit-product-match__swiper(
                            :slides-per-view="4"
                            :spaceBetween="10"
                            :navigation="{ nextEl:'.swiper-button-next', prevEl: '.swiper-button-prev' }"
                        )
                            swiper-slide(v-for="(item, index) in preselectList" :key="`preselect-list-${index}`") 
                                box-edit-product-item(:data="item" mode="delete")
                    .swiper-button-prev.box-edit-product-match__prev-btn
                    .swiper-button-next.box-edit-product-match__next-btn
                el-empty(description="無預選商品" :image-size="50" v-else)
        el-row
            el-col
                h3.box-edit-product-match__title.ob-mt-1.ob-mb-1 BOX內商品
                el-table(:data="matchLables" :border="true" :show-header="false" v-if="matchLables.length>0")
                    el-table-column(width="10px")
                        template(#default="scope")
                            span {{scope.row[0].split('-')[0]}}
                    el-table-column
                        template(#default="scope")
                            box-edit-product-match-item(
                                v-if="matchedList[scope.$index].items[0] && matchedList[scope.$index].items[0].sku"
                                :item="matchedList[scope.$index].items[0]"
                                :position="scope.row[0]"
                            )
                            el-empty(description="無搭配品" :image-size="100" v-else)
                            span.box-edit-product-match__number.ob-mr-1 {{scope.row[0]}}
                    el-table-column
                        template(#default="scope")
                            box-edit-product-match-item(
                                v-if="matchedList[scope.$index].items[1] && matchedList[scope.$index].items[1].sku"
                                :item="matchedList[scope.$index].items[1]"
                                :position="scope.row[1]"
                            )
                            el-empty(description="無搭配品" :image-size="100" v-else)
                            span.box-edit-product-match__number.ob-mr-1 {{scope.row[1]}}
            
</template>
<script lang="ts">
import { defineComponent, inject, ref } from 'vue';
import SwiperCore, { Navigation } from 'swiper';
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/components/navigation/navigation.scss';
import BoxEditProductItem from './BoxEditProductItem.vue';
import BoxEditProductMatchItem from './BoxEditProductMatchItem.vue';
import BoxEditGroupModel from '@/models/box-management/box-edit/BoxEditGroupModel';
import BoxEditProductItemModel from '@/models/box-management/box-edit/BoxEditProductItemModel';
SwiperCore.use([Navigation]);
export default defineComponent({
    name: 'BoxEditProductMatch',
    components: {
        Swiper,
        SwiperSlide,
        BoxEditProductItem,
        BoxEditProductMatchItem
    },
    setup() {
        const preselectList = inject(
            'preselectList',
            ref(new Array<BoxEditProductItemModel>())
        );
        const matchedList = inject(
            'matchedList',
            ref(new Array<BoxEditGroupModel>())
        );
        const matchLables = inject(
            'matchLables',
            ref(new Array<Array<string>>())
        );
        return {
            preselectList,
            matchedList,
            matchLables
        };
    }
});
</script>
<style lang="scss">
.box-edit-product-match {
    position: relative;
    height: 100%;
    &__title {
        margin: 0;
    }
    &__select-box {
        border: solid 1px;
        min-height: 200px;
    }
    &__select-content {
        position: relative;
        width: 100%;
    }
    &__swiper {
        position: relative;
        width: 93%;
    }
    &__prev-btn,
    &__next-btn {
        position: absolute;
        transform: scale(0.7);
        width: 0;
    }
    &__number {
        position: absolute;
        bottom: 0;
        right: 0;
    }
}
</style>
