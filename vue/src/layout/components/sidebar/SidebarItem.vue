<template lang="pug">
.sidebar-item(v-if="state.show")
    router-link(v-if="theOnlyOneChild || !hasChildren" :to="state.path")
        el-menu-item( :index='state.path') 
            i(:class="state.icon")
            span {{state.name}}
    el-submenu(v-else-if="hasChildren" :index='state.path')
        template(#title)
            i(:class="state.icon")
            span {{state.name}}
        SidebarItem(
                v-for="(child, index) in item.children"
                :item="child"
                :parentPath="toChildPath"
                :key="`sidebar-item-${index}`"
            )
</template>
<script lang="ts">
import RouteModel from '@/models/router/RouteModel';
import { computed, defineComponent, reactive, watchEffect } from 'vue';
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
        const routeItem: RouteModel = props.item as RouteModel;
        const state = reactive({
            path: '',
            icon: '',
            name: '',
            show: !props.item.meta || !props.item.meta.hidden
        });
        const hasChildren = computed(() => {
            return routeItem.children && routeItem.children.length > 0;
        });
        const theOnlyOneChild = computed(() => {
            return hasChildren.value && routeItem.children.length === 1;
        });
        const toChildPath = computed(() => {
            return state.path;
        });
        const getIcon = (item: RouteModel) => {
            return item.meta && item.meta.icon && `el-icon-${item.meta.icon}`;
        };
        const initSetting = () => {
            state.path = `${props.parentPath}/${routeItem.path}`;
            state.icon = getIcon(routeItem);
            state.name = routeItem.name;
            if (theOnlyOneChild.value) {
                const firstChild = routeItem.children[0];
                state.path += `/${firstChild.path}`;
                state.icon = getIcon(firstChild);
                state.name = firstChild.name;
            }
            state.path = state.path.replace(/\/+/g, '/');
        };
        watchEffect(initSetting);
        return {
            state,
            toChildPath,
            hasChildren,
            theOnlyOneChild
        };
    }
});
</script>
<style lang="scss"></style>
