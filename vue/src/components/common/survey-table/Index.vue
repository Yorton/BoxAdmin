<template lang="pug">
table.survey-table(border)
    thead.survey-table__head
        tr
            th.survey-table__th(colspan="2") 123{{tableData.groupName}}
    tbody.survey-table__body
        tr(v-for="(item, index) in tableData.items" :key="`survey-${index}`")
            td.survey-table__td {{item.title}}
            td.survey-table__td(v-html="item.answer")
</template>
<script lang="ts">
import SurveyGroupMode from '@/models/customer/SurveyGroupMode';
import { defineComponent, PropType } from 'vue';
export default defineComponent({
    name: 'SurveyTable',
    props: {
        tableData: {
            type: Object as PropType<SurveyGroupMode>,
            default: () => {
                return new SurveyGroupMode();
            }
        }
    },
    components: {},
    setup() {
        return {};
    }
});
</script>
<style lang="scss">
.survey-table {
    border-collapse: collapse;
    width: 100%;
    font-size: 14px;
    line-height: 20px;
    text-align: left;
    &__head {
        background: #ccc;
    }
    &__th,
    &__td {
        padding: 5px;
    }
}
</style>
