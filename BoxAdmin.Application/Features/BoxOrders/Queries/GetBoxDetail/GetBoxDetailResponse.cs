using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxDetail
{
    public class GetBoxDetailResponse
    {

        //問卷A, 問卷B, 問卷C 

        /// <summary>
        /// Box預約單主檔
        /// </summary>
        [SwaggerParameter(Description = "Box預約單主檔")]
        public MainReservation MainReservationData { get; set; }

        /// <summary>
        /// 歷程檔
        /// </summary>
        [SwaggerParameter(Description = "歷程檔")]
        public TimeRecords TimeRecordsData { get; set; }

        /// <summary>
        /// 預約商品清單
        /// </summary>
        [SwaggerParameter(Description = "預約商品清單")]
        public List<ProductsPreview> ProductsPreviewData { get; set; }

        /// <summary>
        /// 出貨商品清單
        /// </summary>
        [SwaggerParameter(Description = "出貨商品清單")]
        public List<ProductsShipment> ProductsShipmentData { get; set; }

    }

    public class MainReservation 
    {
        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        [SwaggerParameter(Description = "BOX訂閱盒編號")]
        public string BoxNo { get; set; }

        /// <summary>
        /// 購物訂單編號
        /// </summary>
        [SwaggerParameter(Description = "購物訂單編號")]
        public string TransactionNo { get; set; }

        /// <summary>
        /// Box退貨單號
        /// </summary>
        [SwaggerParameter(Description = "Box退貨單號")]
        public string ReturnNo { get; set; }


        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        [SwaggerParameter(Description = "會員姓名")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        [SwaggerParameter(Description = "手機號碼")]
        public string Mobile { get; set; }

        /// <summary>
        /// 搭配師
        /// </summary>
        [SwaggerParameter(Description = "搭配師")]
        public string MatchmakerName { get; set; }

        /// <summary>
        /// 期望配送日期
        /// </summary>
        [SwaggerParameter(Description = "期望配送日期")]
        public string DeliveryExpected { get; set; }
    }

    public class TimeRecords 
    {
        //BOX啟用(預約完成)時間

        /// <summary>
        /// 待預覽期限
        /// </summary>
        [SwaggerParameter(Description = "待預覽期限")]
        public string PreviewDueDate { get; set; }

        /// <summary>
        /// 期望配送時間
        /// </summary>
        [SwaggerParameter(Description = "期望配送時間")]
        public string DeliveryExpected { get; set; }

        //表態完成時間

        /// <summary>
        /// 出貨時間
        /// </summary>
        [SwaggerParameter(Description = "出貨時間")]
        public string ShipDate { get; set; }

        //配達時間

        /// <summary>
        /// 試穿期限
        /// </summary>
        [SwaggerParameter(Description = "試穿期限")]
        public string TryonExpire { get; set; }

        /// <summary>
        /// 選購付款時間
        /// </summary>
        [SwaggerParameter(Description = "選購付款時間")]
        public string OrderDateTime { get; set; }

        /// <summary>
        /// 申請退回時間
        /// </summary>
        [SwaggerParameter(Description = "申請退回時間")]
        public string ReturnTime { get; set; }

        //退回檢驗完成時間

    }

    public class ProductsPreview 
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        [SwaggerParameter(Description = " BOX預約單ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 商品圖
        /// </summary>
        [SwaggerParameter(Description = "商品圖")]
        public string Picture { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        [SwaggerParameter(Description = "商品編號")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [SwaggerParameter(Description = "商品名稱")]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品規格
        /// </summary>
        [SwaggerParameter(Description = "商品規格")]
        public string ProductSpec { get; set; }

        /// <summary>
        /// 商品註記
        /// </summary>
        [SwaggerParameter(Description = "商品註記")]
        public string ProductNoted { get; set; }
    }

    public class ProductsShipment 
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        [SwaggerParameter(Description = " BOX預約單ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 商品圖
        /// </summary>
        [SwaggerParameter(Description = "商品圖")]
        public string Picture { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        [SwaggerParameter(Description = "商品編號")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [SwaggerParameter(Description = "商品名稱")]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品規格
        /// </summary>
        [SwaggerParameter(Description = "商品規格")]
        public string ProductSpec { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [SwaggerParameter(Description = "價格")]
        public string Price { get; set; }

        /// <summary>
        /// 購買/退回
        /// </summary>
        [SwaggerParameter(Description = "購買/退回")]
        public string RefundNoted { get; set; }
    }
}
