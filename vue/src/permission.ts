// import { useRouter } from 'vue-router';
import { RouteLocationNormalized } from 'vue-router';
import router from './router';
import { GetUser } from '@/_utils/cookies';
import { useStore } from '@/store';
import { UserActionTypes } from '@/store/modules/user/types';
const whiteList = ['/login'];

// const router = useRouter();
router.beforeEach(
    (to: RouteLocationNormalized, _: RouteLocationNormalized, next) => {
        const user = GetUser();
        if (user && user.jwToken) {
            const store = useStore();
            if (!store.getters.getToken) {
                store.dispatch(UserActionTypes.SetToken, user.jwToken || '');
                store.dispatch(UserActionTypes.SetRoles, user.roles || []);
            }
            next();
        } else {
            if (whiteList.includes(to.path)) {
                next();
            } else {
                next({
                    path: '/login',
                    query: { redirect: to.path }
                });
            }
        }
    }
);
console.log(router);
