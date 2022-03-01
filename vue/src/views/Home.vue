<template lang="pug">
.home
    img(alt='Vue logo' src='../assets/logo.png')
    helloworld(msg='Welcome to Your Vue.js + TypeScript App')
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src
// import { useStore } from '@/store';
// import { PermissionActionTypes } from '@/store/modules/permission/types';
export default defineComponent({
    name: 'Home',
    components: {
        HelloWorld
    },
    setup() {
        // const store = useStore();
        // onMounted(() => store.dispatch(PermissionActionTypes.GetTaskItems));
        // const completedCount = computed(() => store.getters.completedTaskCount);
        // const totalCount = computed(() => store.getters.totalTaskCount);
        return {
            // completedCount,
            // totalCount
        };
    }
});
</script>
