// store/getters.ts
import { GetterTree } from 'vuex';
import { RootState } from '@/store';
import { State } from './state';

export type Getters = {};

export const getters: GetterTree<State, RootState> & Getters = {};
