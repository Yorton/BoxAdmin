import { ElLoading } from 'element-plus';
import { ILoadingInstance } from 'element-plus/lib/el-loading/src/loading.type';
import moment from 'moment';
let loadingNum = 0;
let elLoading!: ILoadingInstance;
export const SetLoading = (bol = false) => {
    if (bol) {
        loadingNum++;
    } else {
        loadingNum--;
        if (loadingNum < 0) {
            loadingNum = 0;
        }
    }
    if (loadingNum > 0) {
        elLoading = ElLoading.service({
            fullscreen: true,
            background: '#ffffff50'
        });
    } else {
        elLoading.close();
    }
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const formatDate = (d: any, format: any) => {
    if (d == '' || d == null) {
        return '';
    }
    if (format !== undefined) {
        return moment(d).format(format);
    } else {
        return moment(d).format('YYYY-MM-DD HH:mm:ss');
    }
};
