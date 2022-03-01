using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoxAdmin.Domain.Entities.BoxContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace BoxAdmin.Application.Interfaces.Contexts
{
    public interface IBoxDbContext
    {
        IDbConnection Connection { get; }
        IDbContextTransaction BeginTransaction { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

        #region Entities
        DbSet<AbandonedCart> AbandonedCarts { get; set; }
        DbSet<AbandonedCartDetail> AbandonedCartDetails { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<AccountValidate> AccountValidates { get; set; }
        DbSet<CardDesign> CardDesigns { get; set; }
        DbSet<CardDesignMessage> CardDesignMessages { get; set; }
        DbSet<Coupon> Coupons { get; set; }
        DbSet<CouponRule> CouponRules { get; set; }
        DbSet<CustomerDatum> CustomerData { get; set; }
        DbSet<CustomerInfo> CustomerInfos { get; set; }
        DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        DbSet<DeviceInfo> DeviceInfos { get; set; }
        DbSet<DislikeFeedbackReason> DislikeFeedbackReasons { get; set; }
        DbSet<EcpayAllowance> EcpayAllowances { get; set; }
        DbSet<EcpayAllowanceItem> EcpayAllowanceItems { get; set; }
        DbSet<EcpayAllowanceLog> EcpayAllowanceLogs { get; set; }
        DbSet<EcpayInvoice> EcpayInvoices { get; set; }
        DbSet<EcpayInvoiceItem> EcpayInvoiceItems { get; set; }
        DbSet<EcpayInvoiceLog> EcpayInvoiceLogs { get; set; }
        DbSet<ImageInfo> ImageInfos { get; set; }
        DbSet<MarketingActivitiesSendTargetList> MarketingActivitiesSendTargetLists { get; set; }
        DbSet<MarketingActivities> MarketingActivities { get; set; }
        DbSet<MatchmakerCollection> MatchmakerCollections { get; set; }
        DbSet<MatchmakerInfo> MatchmakerInfos { get; set; }
        DbSet<MatchmakerSignature> MatchmakerSignatures { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<OrderItemState> OrderItemStates { get; set; }
        DbSet<OrderPayType> OrderPayTypes { get; set; }
        DbSet<OrderPayment> OrderPayments { get; set; }
        DbSet<OrderRefund> OrderRefunds { get; set; }
        DbSet<OrderState> OrderStates { get; set; }
        DbSet<PageFrame> PageFrames { get; set; }
        DbSet<PageFrameContent> PageFrameContents { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<ProductFavorite> ProductFavorites { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductScore> ProductScores { get; set; }
        DbSet<ProductSeries> ProductSeries { get; set; }
        DbSet<ProductSizeReport> ProductSizeReports { get; set; }
        DbSet<ProductSku> ProductSkus { get; set; }
        DbSet<ProductTagToSeries> ProductTagToSeries { get; set; }
        DbSet<ProductTryReport> ProductTryReports { get; set; }
        DbSet<Qa> Qas { get; set; }
        DbSet<QaCatelog> QaCatelogs { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<ReservationCard> ReservationCards { get; set; }
        DbSet<ReservationCardMessage> ReservationCardMessages { get; set; }
        DbSet<ReservationCustomer> ReservationCustomers { get; set; }
        DbSet<ReservationFeedback> ReservationFeedbacks { get; set; }
        DbSet<ReservationFlowStateLog> ReservationFlowStateLogs { get; set; }
        DbSet<ReservationLineItem> ReservationLineItems { get; set; }
        DbSet<ReservationLineItemGroup> ReservationLineItemGroups { get; set; }
        DbSet<ReservationRecipient> ReservationRecipients { get; set; }
        DbSet<ReservationState> ReservationStates { get; set; }
        DbSet<Return> Returns { get; set; }
        DbSet<ReturnsItem> ReturnsItems { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RolesPermission> RolesPermissions { get; set; }
        DbSet<Shipment> Shipments { get; set; }
        DbSet<ShipmentOrderItem> ShipmentOrderItems { get; set; }
        DbSet<SmsMessageDatum> SmsMessageData { get; set; }
        DbSet<SmsMessageResult> SmsMessageResults { get; set; }
        DbSet<StyleBook> StyleBooks { get; set; }
        DbSet<StyleBookCondition> StyleBookConditions { get; set; }
        DbSet<StyleBookDetail> StyleBookDetails { get; set; }
        DbSet<StyleFavorite> StyleFavorites { get; set; }
        DbSet<Subscribe> Subscribes { get; set; }
        DbSet<SubscribeState> SubscribeStates { get; set; }
        DbSet<SubscribeSuspendLog> SubscribeSuspendLogs { get; set; }
        DbSet<SubscriptionPlanInfo> SubscriptionPlanInfos { get; set; }
        DbSet<Survey> Surveys { get; set; }
        DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        DbSet<SurveyReply> SurveyReplies { get; set; }
        DbSet<SurveyTitle> SurveyTitles { get; set; }
        DbSet<SurveyTitleMapping> SurveyTitleMappings { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UsersRole> UsersRoles { get; set; }
        DbSet<VersionInfo> VersionInfos { get; set; }
        #endregion ~Entities
    }
}
