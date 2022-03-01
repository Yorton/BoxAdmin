using BoxAdmin.Domain.Entities.BoxContext;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrderInfo
{
    public class GetOrderInfoResponse
    {
        /// <summary>
        /// 訂單詳細資料
        /// </summary>
        [SwaggerParameter(Description = "訂單詳細資料")]
        public OrderInfo OrderInfo { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        [SwaggerParameter(Description = "訂單明細")]
        public List<OrderDetail> Details { get; set; }

        /// <summary>
        /// 匯款資料
        /// </summary>
        [SwaggerParameter(Description = "匯款資料")]
        public OrderPayment Payment { get; set; }

        /// <summary>
        /// 出貨資料
        /// </summary>
        [SwaggerParameter(Description = "出貨資料")]
        public Shipment Shipment { get; set; }
    }

    public class OrderInfo
    {
        /// <summary>
        /// 購物車ID
        /// </summary>
        [SwaggerParameter(Description = "購物車ID")]
        public Guid TransactionId { get; set; }

        /// <summary>
        /// 購物訂單編號
        /// </summary>
        [SwaggerParameter(Description = "購物訂單編號")]
        public string TransactionNo { get; set; }

        /// <summary>
        /// Box編號
        /// </summary>
        [SwaggerParameter(Description = "Box編號")]
        public string BoxNo { get; set; }

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
        /// 付款方式
        /// </summary>
        [SwaggerParameter(Description = "付款方式")]
        public int PayType { get; set; }

        /// <summary>
        /// 付款方式名稱
        /// </summary>
        [SwaggerParameter(Description = "付款方式名稱")]
        public string PayTypeName { get; set; }

        /// <summary>
        /// 載具類型 (1 會員載具  2 手機條碼  3 自然人憑證)
        /// </summary>
        [SwaggerParameter(Description = "載具類型 (1 會員載具  2 手機條碼  3 自然人憑證)")]
        public string InvDevice { get; set; }

        /// <summary>
        /// 載具類型名稱
        /// </summary>
        [SwaggerParameter(Description = "載具類型名稱")]
        public string InvDeviceName { get; set; }

        /// <summary>
        /// 載具代碼
        /// </summary>
        [SwaggerParameter(Description = "載具代碼")]
        public string InvDeviceCode { get; set; }

        /// <summary>
        /// 收貨人姓名
        /// </summary>
        [SwaggerParameter(Description = "收貨人姓名")]
        public string OrdererName { get; set; }

        /// <summary>
        /// 收貨人電話
        /// </summary>
        [SwaggerParameter(Description = "收貨人電話")]
        public string OrdererMobile { get; set; }

        /// <summary>
        /// 收貨地址-郵遞區號
        /// </summary>
        [SwaggerParameter(Description = "收貨地址-郵遞區號")]
        public string Zip { get; set; }

        /// <summary>
        /// 收貨地址-市
        /// </summary>
        [SwaggerParameter(Description = "收貨地址-市")]
        public string City { get; set; }

        /// <summary>
        /// 收貨地址-區
        /// </summary>
        [SwaggerParameter(Description = "收貨地址-區")]
        public string Region { get; set; }

        /// <summary>
        /// 收貨地址
        /// </summary>
        [SwaggerParameter(Description = "收貨地址")]
        public string Address { get; set; }

        /// <summary>
        /// 成立時間
        /// </summary>
        [SwaggerParameter(Description = "成立時間")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 待預覽期限
        /// </summary>
        [SwaggerParameter(Description = "待預覽期限")]
        public DateTime? PreviewDueDate { get; set; }

        /// <summary>
        /// 出貨時間
        /// </summary>
        [SwaggerParameter(Description = "出貨時間")]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// 到貨時間
        /// </summary>
        [SwaggerParameter(Description = "到貨時間")]
        public DateTime? DevileryTime { get; set; }

        /// <summary>
        /// 付款時間
        /// </summary>
        [SwaggerParameter(Description = "付款時間")]
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 鑑賞期
        /// </summary>
        [SwaggerParameter(Description = "鑑賞期")]
        public DateTime? AppreciationTime { get; set; }

        /// <summary>
        /// 退貨申請時間
        /// </summary>
        [SwaggerParameter(Description = "退貨申請時間")]
        public DateTime? ReturnApplyTime { get; set; }

        /// <summary>
        /// 退貨完成時間
        /// </summary>
        [SwaggerParameter(Description = "退貨完成時間")]
        public DateTime? RtnDate { get; set; }

        /// <summary>
        /// 退貨便號
        /// </summary>
        [SwaggerParameter(Description = "退貨便號")]
        public string RtnNo { get; set; }

        /// <summary>
        /// 是否退貨
        /// </summary>
        [SwaggerParameter(Description = "是否退貨")]
        public bool IsReturn { get; set; }

        /// <summary>
        /// 實際結帳金額
        /// </summary>
        [SwaggerParameter(Description = "實際結帳金額")]
        public decimal TotalPrice { get; set; }
    }

    public class OrderDetail
    {
        /// <summary>
        /// 圖片網址
        /// </summary>
        [SwaggerParameter(Description = "圖片網址")]
        public string ImagePath { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        [SwaggerParameter(Description = "產品編號")]
        public string Sku { get; set; }

        /// <summary>
        /// 產品名稱
        /// </summary>
        [SwaggerParameter(Description = "產品名稱")]
        public string SkuName { get; set; }

        /// <summary>
        /// 顏色
        /// </summary>
        [SwaggerParameter(Description = "顏色")]
        public string Color { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [SwaggerParameter(Description = "尺寸")]
        public string Size { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態")]
        public int State { get; set; }

        /// <summary>
        /// 訂單狀態名稱
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態名稱")]
        public string StateName { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        [SwaggerParameter(Description = "售價")]
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// 折扣金額
        /// </summary>
        [SwaggerParameter(Description = "折扣金額")]
        public decimal Discount { get; set; }

        /// <summary>
        /// 實際結帳金額
        /// </summary>
        [SwaggerParameter(Description = "實際結帳金額")]
        public decimal TotalPrice { get; set; }
    }
}
