// /store/action.ts
import { ActionContext, ActionTree } from 'vuex';
import { Mutations } from './mutations';
import { RootState } from '@/store';
import { State } from './state';

// import { RouterActionTypes, RouterMutationTypes } from './types';
// /store/action.ts
type ActionAugments = Omit<ActionContext<State, RootState>, 'commit'> & {
    commit<K extends keyof Mutations>(
        key: K,
        payload: Parameters<Mutations[K]>[1]
    ): ReturnType<Mutations[K]>;
};
export type Actions = {};
export const actions: ActionTree<State, RootState> & Actions = {};
