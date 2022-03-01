export default class {
    id = '';
    template = 0;
    intro = '';
    signatureUrl = '';
    constructor(id = '', template = 0, intro = '', signatureUrl = '') {
        this.id = id;
        this.template = template;
        this.intro = intro;
        this.signatureUrl = signatureUrl;
    }
}
