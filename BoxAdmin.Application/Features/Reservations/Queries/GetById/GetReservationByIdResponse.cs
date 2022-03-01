using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Reservations.Queries.GetById
{
    public class GetReservationByIdResponse
    {
        [SwaggerSchema("預約單ID")] public Guid Id { get; set; }
        [SwaggerSchema("訂閱單ID")] public Guid SubscribeId { get; set; }
        [SwaggerSchema("會員ID")] public Guid CustomerId { get; set; }
        [SwaggerSchema("BOX訂閱盒編號")] public string BoxNo { get; set; }
        [SwaggerSchema("BOX訂閱盒類型ID")] public int BoxType { get; set; }
        [SwaggerSchema("BOX訂閱盒類型")] public string BoxTypeName { get; set; }
        [SwaggerSchema("預約單流程狀態")] public ReservationState State { get; set; }
        [SwaggerSchema("預約單流編輯流程狀態")] public ReservationFlowState FlowState { get; set; }
        [SwaggerSchema("搭配師ID")] public Guid MatchmakerId { get; set; }
        [SwaggerSchema("搭配師")] public ReservationMatchmaker Matchmaker { get; set; }
        [SwaggerSchema("搭配商品組合")] public List<ReservationLineItemGroup> ItemGroups { get; set; } = new List<ReservationLineItemGroup>();
        [SwaggerSchema("收件資訊")] public ReservationRecipient Recipient { get; set; }
        [SwaggerSchema("會員資訊")] public ReservationCustomer Customer { get; set; }
        [SwaggerSchema("卡片製作")] public GetReservationById_ReservationCard Card { get; set; }
        [SwaggerSchema("訂閱盒問卷資訊")] public List<ReservationSurvey> Surveys { get; set; } = new List<ReservationSurvey>();
    }

    public class ReservationLineItemGroup
    {
        public Guid Id { get; set; }
        public string MatchingMessage { get; set; }
        public Guid? StyleId { get; set; }
        public Guid? OccasionId { get; set; }
        public int SortNum { get; set; }
        public bool HasStyleBook { get; set; }
        [SwaggerSchema("搭配商品")] public List<ReservationLineItem> Items { get; set; } = new List<ReservationLineItem>();
    }

    public class ReservationLineItem
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid GroupId { get; set; }
        public string Series { get; set; }
        public string Sku { get; set; }
        public bool DislikeFeedback { get; set; }
        public string DislikeReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        [SwaggerSchema("建立來源")] public int Source { get; set; }
    }

    [SwaggerSchema("卡片製作")]
    public class GetReservationById_ReservationCard
    {
        [SwaggerSchema("卡片製作ID")] public Guid Id { get; set; }
        [SwaggerSchema("版型類別")] public int Template { get; set; }
        [SwaggerSchema("問候語")] public string Intro { get; set; }
        [SwaggerSchema("簽名檔")] public string SignatureUrl { get; set; }
    }

    [SwaggerSchema("預約單問卷資料")]
    public class ReservationSurvey
    {
        public string Title { get; set; }
        public string Answer { get; set; }
    }

    [SwaggerSchema("會員資訊")]
    public class ReservationCustomer
    {
        [SwaggerSchema("預約人會員ID")] public string No { get; set; }
        [SwaggerSchema("預約人名稱")] public string Name { get; set; }
        [SwaggerSchema("預約人電話")] public string Mobile { get; set; }
    }

    /// <summary>
    /// 收件人
    /// </summary>
    [SwaggerSchema("預約單收件人資訊")]
    public class ReservationRecipient
    {
        [SwaggerSchema("收件人名稱")] public string Name { get; set; }
        [SwaggerSchema("手機號碼")] public string Mobile { get; set; }
        [SwaggerSchema("郵遞區號")] public string Zip { get; set; }
        [SwaggerSchema("城市")] public string City { get; set; }
        [SwaggerSchema("地區")] public string Region { get; set; }
        [SwaggerSchema("地址")] public string Address { get; set; }
    }

    [SwaggerSchema("預約單搭配師資料")]
    public class ReservationMatchmaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    [SwaggerSchema("預約單狀態")]
    public class ReservationState
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    [SwaggerSchema("編輯流程狀態")]
    public class ReservationFlowState
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
