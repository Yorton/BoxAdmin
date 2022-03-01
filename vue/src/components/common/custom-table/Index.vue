<template lang="pug">
.custom-table
    el-row
        el-col
            el-table(v-bind='$props' :data="currentData" @sort-change="onSrotChange")
                slot
    el-row.ob-mt-3.ob-align-right(v-if="state.total>0")
        el-col
            el-pagination(
                background
                v-model:current-page="state.currentPage"
                :page-sizes="pageSizes"
                v-model:page-size="state.pageSize"
                layout="sizes, prev, pager, next, total"
                :total="state.total"
                @current-change="onCurrentChange"
            )
</template>
<script lang="ts">
import {
    computed,
    defineComponent,
    onMounted,
    PropType,
    reactive,
    watch
} from 'vue';
import { ElTable } from 'element-plus';
export default defineComponent({
    name: 'CustomTable',
    extends: ElTable,
    emits: ['update:current-page'],
    props: {
        data: {
            default: () => {
                return [];
            },
            type: Array as PropType<Array<Record<string, unknown>>>
        },
        currentPage: {
            default: 1,
            type: Number
        },
        pageSizes: {
            default: [10, 25, 50, 100],
            type: Array as PropType<Array<number>>
        }
    },
    components: {},
    setup(props, ctx) {
        const state = reactive({
            list: new Array<Record<string, unknown>>(),
            pageSize: 10,
            total: computed(() => {
                return props.data.length;
            }),
            pageList: [],
            sortingFieldName: '',
            sortingType: '',
            currentPage: 1
        });

        const currentData = computed(() => {
            return state.list.slice(
                (props.currentPage - 1) * state.pageSize,
                props.currentPage * state.pageSize
            );
        });

        const pageListChange = () => {
            if (!props.data.length) {
                return;
            }
            if (!state.sortingType) {
                state.list = [...props.data];
                return;
            }
            let tempList = props.data.map((item, index) => {
                let value = item[state.sortingFieldName];
                if (typeof value === 'string') {
                    value = value.toLowerCase();
                }
                return { index, value };
            });
            tempList = tempList.sort(
                (a: Record<string, unknown>, b: Record<string, unknown>) => {
                    const valueA = a.value;
                    const valueB = b.value;
                    if (
                        typeof valueA === 'string' ||
                        typeof valueB === 'string'
                    ) {
                        if (String(valueA) > String(valueB)) return 1;
                        if (String(valueA) < String(valueB)) return -1;
                    }
                    if (
                        typeof valueA === 'number' ||
                        typeof valueB === 'number'
                    ) {
                        return Number(valueA) - Number(valueB);
                    }
                    return 0;
                }
            );
            if (state.sortingType === 'descending') {
                tempList = tempList.reverse();
            }
            state.list = tempList.map((item: Record<string, unknown>) => {
                return props.data[Number(item.index)];
            });
        };

        const resetData = () => {
            pageListChange();
        };

        const onSrotChange = (obj: Record<string, unknown>) => {
            state.sortingFieldName = '';
            state.sortingType = '';
            if (obj.prop) {
                state.sortingFieldName = String(obj.prop);
                state.sortingType = String(obj.order);
            }
            pageListChange();
            console.log(obj);
        };
        const onCurrentChange = () => {
            ctx.emit('update:current-page', state.currentPage);
        };
        watch(
            () => props.data,
            () => {
                resetData();
            },
            { immediate: true }
        );
        watch(
            () => props.currentPage,
            () => {
                state.currentPage = props.currentPage;
            },
            { immediate: true }
        );
        onMounted(() => {
            state.pageSize = props.pageSizes[0];
        });
        return {
            state,
            currentData,
            onSrotChange,
            onCurrentChange
        };
    }
});
</script>
