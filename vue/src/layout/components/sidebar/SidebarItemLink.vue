<template lang="pug">

</template>
<script lang="ts">
import { defineComponent, reactive } from 'vue';
export default defineComponent({
    name: 'SidebarItem',
    props: {
        item: {
            default: () => {
                return {};
            },
            type: Object
        },
        parentPath: {
            default: '',
            type: String
        }
    },
    components: {},
    setup(props) {
        const state = reactive({
            path: `${props.parentPath}/${props.item.path}`
        });

        return {
            state
        };
    }
});
</script>
<style lang="scss"></style>
