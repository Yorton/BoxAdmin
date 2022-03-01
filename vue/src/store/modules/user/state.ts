// /store/state.ts
export type State = {
    token: string;
    roles: string[];
};
export const state: State = {
    token: '',
    roles: []
};
