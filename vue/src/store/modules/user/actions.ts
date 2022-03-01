// /store/action.ts
import { ActionContext, ActionTree } from 'vuex';
import { Mutations } from './mutations';
import { RootState } from '@/store';
import { State } from './state';

import { UserActionTypes, UserMutationTypes } from './types';
// /store/action.ts
type ActionAugments = Omit<ActionContext<State, RootState>, 'commit'> & {
    commit<K extends keyof Mutations>(
        key: K,
        payload: Parameters<Mutations[K]>[1]
    ): ReturnType<Mutations[K]>;
};
export type Actions = {
    [UserActionTypes.SetToken](context: ActionAugments, value: string): void;
    [UserActionTypes.SetRoles](context: ActionAugments, arr: string[]): void;
};
//action.ts
export const actions: ActionTree<State, RootState> & Actions = {
    [UserActionTypes.SetToken]({ commit }, value) {
        commit(UserMutationTypes.SetToken, value);
    },
    async [UserActionTypes.SetRoles]({ commit }, arr) {
        commit(UserMutationTypes.SetRoles, arr);
    }
};
