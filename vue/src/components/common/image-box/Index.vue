<template lang="pug">
.image-box
    el-image.image-box__img(:src="src")
        template(#placeholder)
            .image-slot Loading
                .dot ...
        template(#error)
            .image-box__error
                i(class="el-icon-picture-outline")
</template>
<script lang="ts">
import { defineComponent } from 'vue';
export default defineComponent({
    name: 'ImageBox',
    props: {
        src: {
            type: String,
            default: ''
        }
    },
    components: {},
    setup() {
        return {};
    }
});
</script>
<style lang="scss">
.image-box {
    position: relative;
    width: 100%;
    &__img {
        position: relative;
        width: 100%;
    }
    &__error {
        position: relative;
        text-align: center;
        font-size: 40px;
    }
}
</style>
