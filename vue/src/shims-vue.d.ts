declare module '*.vue' {
    import { defineComponent } from 'vue';
    const Component: ReturnType<typeof defineComponent>;
    export default Component;
}
declare module '*.svg';
declare module '*.png';
declare module '*.jpeg';
declare module '*.jpg';
declare module '*.gif';
