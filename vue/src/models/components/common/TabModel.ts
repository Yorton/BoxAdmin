export default class {
    label = '';
    name = '';
    disabled = false;
    constructor(label = '', name = '', disabled = false) {
        this.label = label;
        this.name = name;
        this.disabled = disabled;
    }
}
