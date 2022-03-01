// /store/mutations.ts
import { MutationTree } from 'vuex';
import { State, TaskItem } from './state';
import { DemoMutationTypes } from './types';
//mutations.ts
export type Mutations = {
    [DemoMutationTypes.CreateTask](state: State, task: TaskItem): void;
    [DemoMutationTypes.SetTasks](state: State, tasks: TaskItem[]): void;
    [DemoMutationTypes.CompleteTask](
        state: State,
        task: Partial<TaskItem> & { id: number }
    ): void;
    [DemoMutationTypes.RemoveTask](
        state: State,
        task: Partial<TaskItem> & { id: number }
    ): void;
    [DemoMutationTypes.EditTask](
        state: State,
        task: Partial<TaskItem> & { id: number }
    ): void;
    [DemoMutationTypes.UpdateTask](
        state: State,
        task: Partial<TaskItem> & { id: number }
    ): void;
    [DemoMutationTypes.SetLoading](state: State, value: boolean): void;
    [DemoMutationTypes.SetCreateModal](state: State, value: boolean): void;
    [DemoMutationTypes.SetEditModal](
        state: State,
        value: { showModal: boolean; taskId: number | undefined }
    ): void;
    [DemoMutationTypes.SetTaskModal](
        state: State,
        value: { showModal: boolean; taskId: number | undefined }
    ): void;
};
// /store/mutation.js
export const mutations: MutationTree<State> & Mutations = {
    [DemoMutationTypes.CreateTask](state, task) {
        state.tasks.unshift(task);
    },
    [DemoMutationTypes.SetTasks](state, tasks) {
        state.tasks = tasks;
    },
    [DemoMutationTypes.CompleteTask](state, newTask) {
        const task = state.tasks.findIndex(
            element => element.id === newTask.id
        );
        if (task === -1) return;
        state.tasks[task] = { ...state.tasks[task], ...newTask };
    },
    [DemoMutationTypes.RemoveTask](state, Task) {
        const task = state.tasks.findIndex(element => element.id === Task.id);
        if (task === -1) return;
        //If Task exist in the state, remove it
        state.tasks.splice(task, 1);
    },
    [DemoMutationTypes.EditTask](state, Task) {
        const task = state.tasks.findIndex(element => element.id === Task.id);
        if (task === -1) return;
        //If Task exist in the state, toggle the editing property
        state.tasks[task] = {
            ...state.tasks[task],
            editing: !state.tasks[task].editing
        };
        console.log('taskino', state.tasks[task]);
    },
    [DemoMutationTypes.UpdateTask](state, Task) {
        state.tasks = state.tasks.map(task => {
            if (task.id === Task.id) {
                return { ...task, ...Task };
            }
            return task;
        });
    },
    [DemoMutationTypes.SetLoading](state, value) {
        state.loading = value;
        console.log('I am loading...');
    },
    [DemoMutationTypes.SetCreateModal](state, value) {
        state.showCreateModal = value;
    },
    [DemoMutationTypes.SetEditModal](state, value) {
        state.showEditModal = value.showModal;
        state.editModalTaskId = value.taskId;
    },
    [DemoMutationTypes.SetTaskModal](state, { showModal, taskId }) {
        state.showTaskModal = showModal;
        state.showTaskId = taskId;
    }
};
