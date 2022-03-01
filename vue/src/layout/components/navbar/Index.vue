<template lang="pug">
.navbar
    .navbar__info
        el-dropdown(trigger="click")
            .el-dropdown-link.navbar__info-head
                el-avatar(icon="el-icon-user-solid")
                i.el-icon-caret-bottom
            template(#dropdown)
                el-dropdown-menu
                    el-dropdown-item(@click="onLogout") 登出
    .clearfix
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { RemoveUser } from '@/_utils/cookies';
import { useRouter } from 'vue-router';
export default defineComponent({
    name: 'Navbar',
    components: {},
    setup() {
        const router = useRouter();
        const onLogout = () => {
            RemoveUser();
            router.go(0);
        };
        return {
            onLogout
        };
    }
});
</script>
<style lang="scss">
.navbar {
    position: relative;
    top: 0;
    left: 0;
    background: #fff;
    border-bottom: 1px solid;
    padding: 5px;
    &__info {
        position: relative;
        float: right;
        right: 10px;
    }
    &__info-head {
        cursor: pointer;
    }
}
</style>
