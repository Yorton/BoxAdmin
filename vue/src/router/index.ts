import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// import Home from '../views/Home.vue';
import Layout from '@/layout/Index.vue';
const Login = () =>
    import(/* webpackChunkName: "login" */ '@/views/login/Index.vue');
const Home = () =>
    import(/* webpackChunkName: "Home" */ '@/views/home/Index.vue');
// const About = () =>
//     import(/* webpackChunkName: "About" */ '@/views/about/Index.vue');

const BoxOrders = () =>
    import(
        /* webpackChunkName: "BoxOrders" */ '@/views/box-management/box-orders/Index.vue'
    );
const BoxOrdersDetail = () =>
    import(
        /* webpackChunkName: "BoxOrdersDetail" */ '@/views/box-management/box-orders/detail/Index.vue'
    );
const BoxOrdersSurveyAnswer = () =>
    import(
        /* webpackChunkName: "BoxOrdersSurveyAnswer" */ '@/views/box-management/box-orders/surveyAnswer/Index.vue'
    );
const BoxOrdersReservation = () =>
    import(
        /* webpackChunkName: "BoxOrdersReservation" */ '@/views/box-management/box-orders/reservation/Index.vue'
    );
const BoxOrdersMembers = () =>
    import(
        /* webpackChunkName: "BoxOrdersMember" */ '@/views/box-management/box-orders/members/Index.vue'
    );

const BoxService = () =>
    import(
        /* webpackChunkName: "BoxService" */ '@/views/box-management/box-service/Index.vue'
    );
const BoxServiceDetail = () =>
    import(
        /* webpackChunkName: "BoxServiceDetail" */ '@/views/box-management/box-service/detail/Index.vue'
    );
const BoxServiceSurveyAnswer = () =>
    import(
        /* webpackChunkName: "BoxServiceSurveyAnswer" */ '@/views/box-management/box-service/surveyAnswer/Index.vue'
    );

// const ServiceOrders = () =>
//     import(
//         /* webpackChunkName: "ServiceOrders" */ '@/views/box-management/service-orders/Index.vue'
//     );
const ShoppingOrders = () =>
    import(
        /* webpackChunkName: "ShoppingOrders" */ '@/views/box-management/shopping-orders/Index.vue'
    );
const ShoppingOrderDetail = () =>
    import(
        /* webpackChunkName: "ShoppingOrders" */ '@/views/box-management/shopping-orders/detail/Index.vue'
    );
const BoxList = () =>
    import(
        /* webpackChunkName: "BoxList" */ '@/views/product-management/box-list/Index.vue'
    );
const BoxEdit = () =>
    import(
        /* webpackChunkName: "BoxEdit" */ '@/views/product-management/box-edit/Index.vue'
    );
const StyleBook = () =>
    import(
        /* webpackChunkName: "StyleBook" */ '@/views/product-management/style-book/Index.vue'
    );
const Designer = () =>
    import(
        /* webpackChunkName: "Designer" */ '@/views/product-management/designer/Index.vue'
    );
const Coupon = () =>
    import(
        /* webpackChunkName: "Coupon" */ '@/views/activity-management/coupon/Index.vue'
    );

const CouponQuery = () =>
    import(
        /* webpackChunkName: "CouponQuery" */ '@/views/coupon-management/query/Index.vue'
    );

const CouponEdit = () =>
    import(
        /* webpackChunkName: "CouponEdit" */ '@/views/coupon-management/edit/Index.vue'
    );

const CouponDetail = () =>
    import(
        /* webpackChunkName: "CouponEdit" */ '@/views/coupon-management/detail/Index.vue'
    );

const basicRoutes: Array<RouteRecordRaw> = [
    {
        path: '/login',
        name: 'Login',
        component: Login
    }
];
/*
    menuRoutes??????

    name: ????????????
    meta: {
        roles: ['admin', 'editor']  ????????????
        icon: ''                    ??????icon??????
        hidden: false               ?????????????????? 
        activeMenu: ''              ??????highlight??????
    }
*/
export const menuRoutes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'Home',
        component: Layout,
        redirect: '/dashboard',
        children: [
            {
                path: 'dashboard',
                component: Home,
                name: 'Dashboard',
                meta: {
                    title: 'dashboard',
                    icon: 's-home',
                    roles: ['admin']
                }
            }
        ]
    },
    {
        path: '/orders-management',
        name: '????????????',
        component: Layout,
        redirect: '/orders-management/box-orders',
        meta: {
            icon: 's-order'
        },
        children: [
            {
                path: 'box-orders',
                component: BoxOrders,
                name: 'Box????????????'
            },
            {
                path: 'box-orders/detail',
                component: BoxOrdersDetail,
                name: 'Box????????????-??????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'box-orders/surveyanswer',
                component: BoxOrdersSurveyAnswer,
                name: 'Box????????????-??????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'box-orders/reservation',
                component: BoxOrdersReservation,
                name: 'Box????????????-?????????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'box-orders/members',
                component: BoxOrdersMembers,
                name: 'Box????????????-????????????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'box-service',
                component: BoxService,
                name: '??????????????????'
            },
            {
                path: 'box-service/detail',
                component: BoxServiceDetail,
                name: '??????????????????-??????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'box-service/surveyanswer',
                component: BoxServiceSurveyAnswer,
                name: '??????????????????-??????',
                meta: {
                    hidden: true
                }
            },
            /*{
                path: 'service-orders',
                component: ServiceOrders,
                name: '??????????????????',
                meta: {
                    hidden: true
                }
            },*/
            {
                path: 'shopping-orders',
                component: ShoppingOrders,
                name: '??????????????????'
            },
            {
                path: 'shopping-orders/detail',
                component: ShoppingOrderDetail,
                name: '??????????????????-??????',
                meta: {
                    hidden: true
                }
            }
        ]
    },
    {
        path: '/product-management',
        name: '??????????????????',
        component: Layout,
        redirect: '/product-management/style-book',
        meta: {
            icon: 's-management'
        },
        children: [
            {
                path: 'box-list',
                component: BoxList,
                name: 'Box????????????'
            },
            {
                path: 'box-edit',
                component: BoxEdit,
                name: 'Box??????',
                meta: {
                    activeMenu: '/product-management/box-list',
                    hidden: true
                }
            },

            {
                path: 'style-book',
                component: StyleBook,
                name: 'StyleBook??????'
            },
            {
                path: 'designer',
                component: Designer,
                name: '???????????????'
            }
        ]
    },
    {
        path: '/activity-management',
        name: '??????????????????',
        component: Layout,
        redirect: '/activity-management/coupon',
        meta: {
            icon: 's-promotion',
            hidden: true
        },
        children: [
            {
                path: 'coupon',
                component: Coupon,
                name: 'Coupon??????',
                meta: {
                    icon: 's-promotion'
                }
            }
        ]
    },
    {
        path: '/coupon-management',
        name: 'Coupon????????????',
        component: Layout,
        redirect: '/coupon-management/query',
        meta: {
            icon: 's-promotion'
        },
        children: [
            {
                path: 'query',
                component: CouponQuery,
                name: 'Coupon??????',
                meta: {
                    icon: 's-promotion'
                }
            },
            {
                path: 'edit',
                component: CouponEdit,
                name: 'Coupon??????',
                meta: {
                    hidden: true
                }
            },
            {
                path: 'detail',
                component: CouponDetail,
                name: 'Coupon??????',
                meta: {
                    hidden: true
                }
            }
        ]
    }
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes: [...basicRoutes, ...menuRoutes]
});

export default router;
