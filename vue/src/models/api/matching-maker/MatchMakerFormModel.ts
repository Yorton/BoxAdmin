import { UploadFile } from 'element-plus/lib/el-upload/src/upload.type';

export default class {
    id = '';
    name = '';
    selfIntroduction = '';
    likeStyle = '';
    slogan = '';
    pictureUrl: (string | UploadFile)[] = [];
    signatureUrl: (string | UploadFile)[] = [];
}
