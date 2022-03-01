// store/getters.ts
import { GetterTree } from 'vuex';
import { RootState } from '@/store';
import { State } from './state';

export type Getters = {
    getToken(state: State): string;
    getRoles(state: State): string[];
};

export const getters: GetterTree<State, RootState> & Getters = {
    getToken(state) {
        return state.token;
    },
    getRoles(state) {
        return state.roles;
    }
};
