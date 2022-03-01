<template lang="pug">
.custom-checkbox-group
    el-checkbox(v-model="state.selectAll" @click.prevent.stop="onCheckboxAllClick") 全部
    el-checkbox(v-for="(item, index) in state.checkboxList" v-model="item.checked" :label="item.label" @change="onCheckboxChange") {{item.name}}
</template>
<script lang="ts">
import { defineComponent, PropType, reactive, watch } from 'vue';
import CheckboxMode from '@/models/CheckboxModel';
export default defineComponent({
    name: 'CustomCheckboxGroup',
    emits: ['update:value'],
    props: {
        value: {
            type: Object as PropType<Array<string>>,
            default: () => {
                return [];
            }
        },
        list: {
            type: Object as PropType<Array<CheckboxMode>>,
            default: () => {
                return [];
            }
        }
    },
    components: {},
    setup(props, ctx) {
        const SELECT_ALL = 'all';
        const state = reactive({
            selectAll: true,
            checkboxList: new Array<CheckboxMode>()
        });

        const setCheckbox = (type = '') => {
            state.checkboxList.forEach(item => {
                if (type === SELECT_ALL) {
                    item.checked = false;
                } else {
                    item.checked = props.value.some(valueItem => {
                        return valueItem === item.label;
                    });
                }
            });
        };

        watch(
            () => props.list,
            () => {
                if (props.list.length) {
                    state.checkboxList = props.list.map(item => {
                        return { ...item };
                    });
                } else {
                    state.checkboxList = [];
                }
            },
            {
                immediate: true
            }
        );

        watch(
            () => props.value,
            () => {
                state.selectAll = !props.value.length;
                if (state.selectAll) {
                    setCheckbox(SELECT_ALL);
                } else {
                    setCheckbox();
                }
            },
            {
                immediate: true
            }
        );

        const onCheckboxChange = () => {
            const selectArr: string[] = [];
            state.checkboxList.forEach(item => {
                if (item.checked) {
                    selectArr.push(item.label);
                }
            });
            ctx.emit('update:value', selectArr);
        };
        const onCheckboxAllClick = () => {
            if (state.selectAll) return;
            ctx.emit('update:value', []);
        };
        return {
            state,
            onCheckboxChange,
            onCheckboxAllClick
        };
    }
});
</script>
<style lang="scss">
.custom-checkbox-group {
}
</style>
