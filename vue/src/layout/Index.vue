<template lang="pug">
.layout
    .layout__menu
        Sidebar
    .layout__main
        Navbar
        router-view(:key="state.key")
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import Sidebar from './components/sidebar/Index.vue';
import Navbar from './components/navbar/Index.vue';
import { useRoute } from 'vue-router';
export default defineComponent({
    name: 'Layout',
    components: {
        Sidebar,
        Navbar
    },
    setup() {
        const state = reactive({
            key: useRoute().path
        });
        return {
            state
        };
    }
});
</script>
<style lang="scss">
@import '@/styles/_variables.scss';
.layout {
    position: relative;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    &__menu {
        width: $sideBarWidth;
        height: 100%;
        background-color: $menuBg;
        position: fixed;
        font-size: 0px;
        top: 0;
        left: 0;
        z-index: 999;
        overflow: hidden;
    }
    &__main {
        position: relative;
        top: 0;
        left: 0;
        margin-left: $sideBarWidth;
        height: 100%;
    }
}
</style>
