<template lang="pug">
.tabs
    .tabs__pane(
        v-for="(item, index) in items" 
        :class="{'tabs__pane--last':(index===items.length-1), 'tabs__pane--active': item.name===activeName, 'tabs__pane--disabled': item.disabled}"
        @click="!item.disabled&&onTabClick(item.name)"
        :key="`tabs-pane-${index}`") {{item.label}}
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import TabModel from '@/models/components/common/TabModel';
export default defineComponent({
    name: 'Tabs',
    props: {
        activeName: {
            type: String,
            default: ''
        },
        items: {
            type: Array as PropType<Array<TabModel>>,
            default: () => {
                return [];
            }
        }
    },
    components: {},
    setup(props, ctx) {
        const onTabClick = (value: string) => {
            ctx.emit('update:activeName', value);
        };
        return {
            onTabClick
        };
    }
});
</script>
<style lang="scss">
@import '@/styles/element-variables.scss';
.tabs {
    border-bottom: $--border-color-light solid 2px;
    &__pane {
        display: inline-block;
        padding: 5px 10px;
        border: $--border-color-light solid 1px;
        border-right-width: 0;
        border-bottom-width: 0;
        cursor: pointer;
        &--last {
            border-right-width: 1px;
        }
        &--active {
            color: #fff;
            background: #ccc;
        }
        &--disabled {
            cursor: no-drop;
        }
    }
}
</style>
