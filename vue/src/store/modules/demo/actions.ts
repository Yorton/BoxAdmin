// /store/action.ts
import { ActionContext, ActionTree } from 'vuex';
import { Mutations } from './mutations';
import { RootState } from '@/store';
import { State } from './state';

import { DemoActionTypes, DemoMutationTypes } from './types';
// /store/action.ts
type ActionAugments = Omit<ActionContext<State, RootState>, 'commit'> & {
    commit<K extends keyof Mutations>(
        key: K,
        payload: Parameters<Mutations[K]>[1]
    ): ReturnType<Mutations[K]>;
};
export type Actions = {
    [DemoActionTypes.GetTaskItems](context: ActionAugments): void;
    [DemoActionTypes.SetCreateModal](context: ActionAugments): void;
    [DemoActionTypes.SetEditModal](context: ActionAugments): void;
};
//action.ts
const sleep = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));
export const actions: ActionTree<State, RootState> & Actions = {
    async [DemoActionTypes.GetTaskItems]({ commit }) {
        commit(DemoMutationTypes.SetLoading, true);
        await sleep(1000);
        commit(DemoMutationTypes.SetLoading, false);
        commit(DemoMutationTypes.SetTasks, [
            {
                id: 1,
                title: 'Create a new programming language',
                description:
                    'The programing language should have full typescript support ',
                createdBy: 'Emmanuel John',
                assignedTo: 'Saviour Peter',
                completed: false,
                editing: false
            }
        ]);
    },
    async [DemoActionTypes.SetCreateModal]({ commit }) {
        commit(DemoMutationTypes.SetCreateModal, true);
    },
    async [DemoActionTypes.SetEditModal]({ commit }) {
        commit(DemoMutationTypes.SetEditModal, {
            showModal: true,
            taskId: 1
        });
    }
};
