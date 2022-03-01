using System;

namespace BoxAdmin.Application.Features.Reservations.Queries.Get
{
    public class ReservationItem
    {
        /// <summary>
        /// BOX預約單ID (等同訂單購物車ID)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 訂閱服務訂單ID
        /// </summary>
        public Guid SubscribeId { get; set; }

        /// <summary>
        /// 方案名稱
        /// </summary>
        public string SubscribeName { get; set; }

        /// <summary>
        /// 會員ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// BOX訂閱盒編號(唯一)
        /// </summary>
        public string BoxNo { get; set; }

        /// <summary>
        /// BOX訂閱盒類型(1:一般 2:加購盒)
        /// </summary>
        public int BoxType { get; set; }

        /// <summary>
        /// 預約單流程狀態(ref. ReservationState)
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 預約單流程狀態名稱
        /// </summary>
        public string StateTitle { get; set; }

        /// <summary>
        /// 編輯流程狀態 (0:待編輯 1:商品搭配 2:商品組合貼標 4:卡片製作)
        /// </summary>
        public int FlowState { get; set; }

        /// <summary>
        /// 編輯流程狀態名稱
        /// </summary>
        public string FlowStateTitle
        {
            get
            {
                switch (FlowState)
                {
                    case 0:
                        {
                            return "待編輯";
                        }
                    case 1:
                        {
                            return "商品搭配";
                        }
                    case 2:
                        {
                            return "商品組合貼標";
                        }
                    case 4:
                        {
                            return "卡片製作";
                        }
                    default:
                        {
                            return "";
                        }
                }
            }
        }

        /// <summary>
        /// 搭配師ID
        /// </summary>
        public Guid MatchmakerId { get; set; }

        /// <summary>
        /// 搭配師名稱
        /// </summary>
        public string MatchmakerName { get; set; }

        /// <summary>
        /// 期望配送日期
        /// </summary>
        public DateTime? DeliveryExpected { get; set; }

        /// <summary>
        /// 待預覽期限
        /// </summary>
        public DateTime? PreviewDueDate { get; set; }
    }
}
