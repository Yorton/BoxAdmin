import { createStore, createLogger } from 'vuex';
// import createPersistedState from 'vuex-persistedstate';

// TODO: How to surpass cyclical dependency linting errors cleanly?
import {
    store as routers,
    PermissionStore,
    PermissionState
} from '@/store/modules/permission';
import { store as users, UserStore, UserState } from '@/store/modules/user';

export type RootState = {
    permission: PermissionState;
    users: UserState;
};

export type Store = PermissionStore<Pick<RootState, 'permission'>> &
    UserStore<Pick<RootState, 'users'>>;

// Plug in logger when in development environment
const debug = process.env.NODE_ENV !== 'production';
const plugins = debug ? [createLogger({})] : [];

// Plug in session storage based persistence
// plugins.push(createPersistedState({ storage: window.sessionStorage }));

export const store = createStore({
    plugins,
    modules: {
        routers,
        users
    }
});

export function useStore(): Store {
    return store as Store;
}
