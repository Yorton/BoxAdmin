<template lang="pug">
.sidebar
    el-scrollbar
        el-menu.sidebar__menu(
            :default-active='activeMenu'
            :unique-opened="false"
            :collapse-transition="false"
            :background-color="variables.menuBg"
            :text-color="variables.menuText"
            :active-text-color="variables.menuActiveText"
            @open='handleOpen' 
            @close='handleClose'
            :collapse="isCollapse"
        )
            sidebar-item(v-for="(route, index) in filterMenuRoutes" :item="route" :key="`sidebar-item-${index}`")
</template>

<script lang="ts">
import { computed, defineComponent, ref } from 'vue';
import Variables from '@/styles/_variables.scss';
import { menuRoutes } from '@/router/index';
import SidebarItem from './SidebarItem.vue';
import { useRoute } from 'vue-router';
export default defineComponent({
    name: 'siderbar',
    components: {
        SidebarItem
    },
    setup() {
        const isCollapse = ref(false);
        const filterMenuRoutes = computed(() => {
            return menuRoutes;
        });
        const variables = computed(() => {
            return Variables;
        });
        const activeMenu = computed(() => {
            const { meta, path } = useRoute();
            if (meta && meta.activeMenu) {
                return meta.activeMenu;
            }
            return path;
        });
        const handleOpen = () => {
            console.log(1);
        };
        const handleClose = () => {
            console.log(1);
        };
        return {
            activeMenu,
            filterMenuRoutes,
            isCollapse,
            variables,
            handleOpen,
            handleClose
        };
    }
});
</script>
<style lang="scss">
@import '@/styles/_variables.scss';
.sidebar {
    position: relative;
    height: 100%;
    .sidebar &__menu {
        border-right: 0;
    }
}
</style>
