import MainReservationModel from './MainReservationModel';
import TimeRecordsModel from './TimeRecordsModel';
import ProductsPreviewModel from './ProductsPreviewModel';
import ProductsShipmentModel from './ProductsShipmentModel';

export default class {
    //問卷A, 問卷B, 問卷C

    mainReservationData: MainReservationModel = new MainReservationModel();
    timeRecordsData: TimeRecordsModel = new TimeRecordsModel();
    productsPreviewData: ProductsPreviewModel[] = [];
    productsShipmentData: ProductsShipmentModel[] = [];
}
