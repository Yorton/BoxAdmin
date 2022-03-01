import { createApp } from 'vue';
import 'normalize.css';
import ElementPlus from 'element-plus';
import 'element-plus/lib/theme-chalk/index.css';
import locale from 'element-plus/lib/locale/lang/zh-tw';
import App from './App.vue';
import router from './router';
import { store } from './store';
import { VueCookieNext } from 'vue-cookie-next';
import '@/permission';

import '@/styles/element-variables.scss';
import '@/styles/index.scss';

createApp(App)
    .use(store)
    .use(router)
    .use(ElementPlus, { locale })
    .use(VueCookieNext)
    .mount('#app');
