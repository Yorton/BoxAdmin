<template lang="pug">
.login
    el-form.login__container(label-width="70px" :rules="state.rules" :model="state.form" ref="loginFormEle")
        h3.login__title Boxing 管理介面
        el-form-item(label="帳號" prop="email")
            el-input(v-model="state.form.email" placeholder="請輸入帳號")
        el-form-item(label="密碼" prop="password")
            el-input(v-model="state.form.password" type="password" placeholder="請輸入密碼")
        el-button.login__send-btn(type="primary" @click="onClick") 登入
</template>
<script lang="ts">
import { computed, defineComponent, reactive, Ref, ref } from 'vue';
import { useStore } from '@/store';
import { Login } from '@/_api/account.api';
import LoginModel from '@/models/account/LoginModel';
import { useRouter, useRoute } from 'vue-router';
import { SetUser } from '@/_utils/cookies';
import { SetLoading } from '@/_utils/common';
import { ElMessageBox } from 'element-plus';
// import LoginResponseModel from '@/models/account/LoginResponseModel';
export default defineComponent({
    name: 'Login',
    components: {},
    setup() {
        const store = useStore();
        const router = useRouter();
        const route = useRoute();
        const state = reactive({
            form: new LoginModel(),
            rules: {
                email: [
                    {
                        required: true,
                        message: '帳號(Email)不能為空',
                        trigger: 'blur'
                    },
                    {
                        type: 'email',
                        message: 'Email格式錯誤!',
                        trigger: 'blur'
                    }
                ],
                password: [
                    {
                        required: true,
                        message: '密碼不能為空',
                        trigger: 'blur'
                    }
                ]
            },
            getToken: computed(() => {
                return store.getters.getToken;
            })
        });
        const loginFormEle: Ref<HTMLFormElement | null> = ref(null);
        const alert = (msg: string) => {
            ElMessageBox.alert(msg, '登入失敗');
        };
        const send = async () => {
            // 送出表單
            try {
                SetLoading(true);
                const { data } = await Login(state.form);
                if (data.succeeded) {
                    SetUser(data.data);
                    router.push({
                        path: route.query.redirect?.toString() || '/'
                    });
                } else {
                    alert(data.message);
                    console.log(data.message);
                }
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        };
        const onClick = () => {
            // 檢查表單
            loginFormEle.value?.validate((valid: boolean) => {
                if (valid) {
                    send();
                } else {
                    alert('尚有欄位未填寫或格式不對');
                }
            });
        };
        state.form.email = 'admin@ob.com';
        state.form.password = 'admin@ob.com';
        return {
            state,
            loginFormEle,
            onClick
        };
    }
});
</script>
<style lang="scss">
$lightGray: #eee;
$darkGray: #889aa4;
$loginBg: #2d3a4b;
$loginCursorColor: #fff;
.login {
    position: relative;
    background: $loginBg;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    color: $lightGray;
    &__container {
        position: absolute;
        width: 400px;
        top: 50%;
        left: 50%;
        margin-top: -200px;
        margin-left: -200px;
    }
    &__title {
    }
    &__send-btn {
        position: relative;
        width: 100%;
    }
    .el-form-item__label {
        font-size: 18px;
        color: $lightGray;
    }
}
</style>
