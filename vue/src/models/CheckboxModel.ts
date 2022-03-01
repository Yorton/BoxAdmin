export default class {
    label = '';
    name = '';
    checked = false;
    constructor(label = '', name = '', checked = false) {
        this.label = label;
        this.name = name;
        this.checked = checked;
    }
}
