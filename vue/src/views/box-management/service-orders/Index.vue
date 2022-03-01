<template>
    <div class="pd-5 table">
        <el-table
            :data="state.tableData"
            stripe
            border
            class="table__wrapper border-light"
        >
            <el-table-column
                align="center"
                fixed
                prop="name"
                label="服務訂單編號"
                width="100"
                sortable
            ></el-table-column>
            <el-table-column align="center" label="會員ID" width="350">
                <template #default="scope">
                    <Image
                        :style="'table__img'"
                        v-for="(item, index) in scope.row.images"
                        :key="index"
                        :path="item"
                    ></Image>
                </template>
            </el-table-column>
            <el-table-column
                align="center"
                prop="haveMatch"
                label="會員姓名"
                width="100"
            >
            </el-table-column>
            <el-table-column label="購買方案" width="200">
                <template #default="scope">
                    <p
                        v-for="(item, index) in scope.row.matchList"
                        :key="index"
                        :src="item"
                    >
                        {{ `${item.style}： ${item.nb}盒` }}
                    </p>
                </template>
            </el-table-column>
            <el-table-column
                align="center"
                prop="updateTime"
                label="成立方式"
                width="120"
            ></el-table-column>
            <el-table-column
                align="center"
                prop="createTime"
                label="BOX已啟用數"
                width="120"
            ></el-table-column>
            <el-table-column
                align="center"
                prop="createTime"
                label="申請暫停"
                width="120"
            ></el-table-column>
            <el-table-column
                align="center"
                prop="updateTime"
                label="訂閱狀態"
                width="120"
                sortable
            ></el-table-column>
            <el-table-column
                align="center"
                prop="updateTime"
                label="訂閱結束狀態"
                width="120"
                sortable
            ></el-table-column>
            <el-table-column
                align="center"
                fixed="right"
                label="動作"
                width="150"
            >
                <template>
                    <el-button size="mini">編輯</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import Image from '@/components/Image.vue';

export default defineComponent({
    name: 'ServiceOrders',
    components: { Image },
    setup() {
        const state = reactive({
            tableData: [
                {
                    name: '阿湯哥',
                    images: [
                        'https://obcdn4.obdesign.com.tw/catalog/products/AB14444/AB14444@1_50.jpg',
                        'https://obcdn4.obdesign.com.tw/catalog/products/DA8003/DA8003@1_50.jpg'
                    ],
                    haveMatch: 2,
                    matchList: [
                        { style: '率性休閒', nb: 2 },
                        { style: '率性休閒', nb: 2 }
                    ],
                    createTime: '2020-11-30',
                    updateTime: '2020-11-30'
                },
                {
                    name: '阿湯哥',
                    images: [
                        'https://obcdn4.obdesign.com.tw/catalog/products/AB14444/AB14444@1_50.jpg',
                        'https://obcdn4.obdesign.com.tw/catalog/products/DA8003/DA8003@1_50.jpg'
                    ],
                    haveMatch: 2,
                    matchList: [
                        { style: '率性休閒', nb: 2 },
                        { style: '率性休閒', nb: 2 }
                    ],
                    createTime: '2020-11-30',
                    updateTime: '2020-11-30'
                }
            ]
        });
        return {
            state
        };
    }
});
</script>
