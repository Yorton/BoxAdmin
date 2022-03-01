<template>
    <el-image :class="style" :src="path" v-if="path || !description">
        <template #error>
            <div class="image-slot">
                <i class="el-icon-picture-outline"></i>
            </div>
        </template>
    </el-image>
    <div :class="style" v-else>
        {{ props.description }}
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
export default defineComponent({
    props: {
        path: {
            type: String,
            required: false
        },
        style: {
            type: String,
            required: false
        },
        description: {
            type: String,
            required: false
        }
    },
    name: 'Image',
    setup(props) {
        return { props };
    }
});
</script>
