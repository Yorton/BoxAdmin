// /store/mutations.ts
import { MutationTree } from 'vuex';
import { State } from './state';
import { UserMutationTypes } from './types';
//mutations.ts
export type Mutations = {
    [UserMutationTypes.SetToken](state: State, value: string): void;
    [UserMutationTypes.SetRoles](state: State, arr: string[]): void;
};
// /store/mutation.js
export const mutations: MutationTree<State> & Mutations = {
    [UserMutationTypes.SetToken](state, value) {
        state.token = value;
    },
    [UserMutationTypes.SetRoles](state, arr) {
        state.roles = arr;
    }
};
