<template lang="pug">
h1
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue';
import { VueCookieNext } from 'vue-cookie-next';
export default defineComponent({
    name: 'Home',
    components: {},
    setup() {
        const userData = computed(() => {
            return VueCookieNext.getCookie('user');
        });
        return {
            userData
        };
    }
});
</script>
