using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Reservations.Commands.AddReservationOrder
{
    public class BoxOrder
    {
        /// <summary>
        /// 購物車ID
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Box訂購ID
        /// </summary>
        public Guid SourceTransactionNo { get; set; }

        /// <summary>
        /// 購物車單號
        /// </summary>
        public string TransactionNo { get; set; }

        /// <summary>
        /// 帳號ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 訂單類型(1:直購 2:Box預約單 3:訂閱服務單)
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 實際結帳金額
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 匯款金額
        /// </summary>
        public decimal PaymentAmt { get; set; }

        /// <summary>
        /// 匯款時間(訂單時間)
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        public int OrderState { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }

        /// <summary>
        /// 卡號末四碼
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 發票統編
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// 買家姓名
        /// </summary>
        public string OrdererName { get; set; }

        /// <summary>
        /// 收件者姓名
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// 國別
        /// </summary>
        public int Country { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 地區
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 電話加密
        /// </summary>
        public int MobileEncrypt { get; set; }

        /// <summary>
        /// 寄送方式
        /// </summary>
        public int DeliveryMethod { get; set; }

        /// <summary>
        /// 門市店號
        /// </summary>
        public string StorePickupCode { get; set; }

        /// <summary>
        /// 門市名稱
        /// </summary>
        public string StorePickupName { get; set; }

        /// <summary>
        /// 路線路順
        /// </summary>
        public string ShippingRoute { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 已核帳
        /// </summary>
        public bool Verify { get; set; }

        /// <summary>
        /// 核帳人
        /// </summary>
        public string VerifyAuditor { get; set; }

        /// <summary>
        /// 核帳備註
        /// </summary>
        public string VerifyRemark { get; set; }

        /// <summary>
        /// 預購
        /// </summary>
        public int PreOrder { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 來源
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 通路
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 發票抬頭
        /// </summary>
        public string InvTitle { get; set; }

        /// <summary>
        /// 發票捐贈
        /// </summary>
        public bool? InvDonateYn { get; set; }

        /// <summary>
        /// 發票捐贈碼
        /// </summary>
        public string InvDonateCode { get; set; }

        /// <summary>
        /// 載具類型(1:會員載具 2:手機條碼 3:自然人憑證)
        /// </summary>
        public string InvDevice { get; set; }

        /// <summary>
        /// 載具代碼
        /// </summary>
        public string InvDeviceCode { get; set; }

        /// <summary>
        /// 發票收件人
        /// </summary>
        public string InvReceiver { get; set; }

        /// <summary>
        /// 發票收件人電話
        /// </summary>
        public string InvReceiverTel { get; set; }

        /// <summary>
        /// 發票收件人地址
        /// </summary>
        public string InvReceiverAddr { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 產品名稱
        /// </summary>
        public string SkuName { get; set; }



    }
}
