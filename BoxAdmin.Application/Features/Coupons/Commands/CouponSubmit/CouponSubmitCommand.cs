using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;


namespace BoxAdmin.Application.Features.Coupons.Commands.CouponSubmit
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class CouponSubmitCommand : IRequest<CouponSubmitResponse>
    {
        /// <summary>
        /// Coupon ID
        /// </summary>
        [SwaggerParameter(Description = "Coupon ID")]
        public string Id { get; set; }

        /// <summary>
        /// CouponRule ID
        /// </summary>
        [SwaggerParameter(Description = "CouponRule ID")]
        public Guid? CouponRuleId { get; set; }

        /// <summary>
        /// MarketingActivities ID
        /// </summary>
        [SwaggerParameter(Description = "MarketingActivities ID")]
        public Guid? MarketingActivitiesId { get; set; }

        /// <summary>
        /// Coupon名稱
        /// </summary>
        [SwaggerParameter(Description = "Coupon名稱")]
        public string CouponName { get; set; }

        /// <summary>
        /// 指定碼
        /// </summary>
        [SwaggerParameter(Description = "指定碼")]
        public string SpecialCode { get; set; }

        /// <summary>
        /// 領取時間
        /// </summary>
        //[SwaggerParameter(Description = "領取時間")]
        //public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// 實際使用的時間
        /// </summary>
        //[SwaggerParameter(Description = "實際使用的時間")]
        //public string UsedDate { get; set; }


        /// <summary>
        /// 優惠項目
        /// </summary>
        [SwaggerParameter(Description = "優惠項目")]
        public string CartType { get; set; }

        /// <summary>
        /// 優惠門檻類型
        /// </summary>
        [SwaggerParameter(Description = "優惠門檻類型")]
        public int DiscountThresholdType { get; set; }

        /// <summary>
        /// 優惠門檻值
        /// </summary>
        [SwaggerParameter(Description = "優惠門檻值")]
        public int? DiscountThresholdValue { get; set; }

        /// <summary>
        /// 優惠目標
        /// </summary>
        [SwaggerParameter(Description = "優惠目標")]
        public int DiscountTarget { get; set; }

        /// <summary>
        /// 優惠內容類型
        /// </summary>
        [SwaggerParameter(Description = "優惠內容類型")]
        public int DiscountContentType { get; set; }

        /// <summary>
        /// 優惠內容值
        /// </summary>
        [SwaggerParameter(Description = "優惠內容值")]
        public int DiscountContentValue { get; set; }

        /// <summary>
        /// Coupon類型名稱
        /// </summary>
        [SwaggerParameter(Description = "Coupon類型名稱")]
        public string CouponTypeName { get; set; }

        /// <summary>
        /// Coupon類型
        /// </summary>
        [SwaggerParameter(Description = "Coupon類型")]
        public int CouponType { get; set; }

        /// <summary>
        /// 領取/歸戶方式
        /// </summary>
        [SwaggerParameter(Description = "領取/歸戶方式")]
        public int ReceiveType { get; set; }
            

        /// <summary>
        /// 活動時間開始日
        /// </summary>
        [SwaggerParameter(Description = "活動時間開始日")]
        public string MarketingActivityStartDate { get; set; }

        /// <summary>
        /// 活動時間結束日
        /// </summary>
        [SwaggerParameter(Description = "活動時間結束日")]
        public string MarketingActivityEndDate { get; set; }


        /// <summary>
        /// 可用時間選項- 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
        /// </summary>
        [SwaggerParameter(Description = "可用時間選項")]
        public int CanUseType { get; set; }

        /// <summary>
        /// 可使用時間開始日
        /// </summary>
        [SwaggerParameter(Description = "可使用時間開始日")]
        public string CanUseStartDate { get; set; }

        /// <summary>
        /// 可使用時間結束日
        /// </summary>
        [SwaggerParameter(Description = "可使用時間結束日")]
        public string CanUseEndDate { get; set; }


        /// <summary>
        /// 歸戶後 [N] 天內可使用
        /// </summary>
        [SwaggerParameter(Description = "歸戶後 [N] 天內可使用")]
        public int? CanUseByReceiveDay { get; set; }

        /// <summary>
        /// 發送條件
        /// </summary>
        [SwaggerParameter(Description = "發送條件")]
        public int SendCondition { get; set; }

        /// <summary>
        /// 發送限制
        /// </summary>
        [SwaggerParameter(Description = "發送限制")]
        public int SendLimitType { get; set; }


        /// <summary>
        /// 總數限量
        /// </summary>
        [SwaggerParameter(Description = "總數限量")]
        public int LimitQuantity { get; set; }

        /// <summary>
        /// 對象
        /// </summary>
        [SwaggerParameter(Description = "對象")]
        public int SendTarget { get; set; }

        /// <summary>
        /// 產出類型 1.即時產出 2.預先產出
        /// </summary>
        [SwaggerParameter(Description = "產出類型")]
        public int OutputType { get; set; }

        /// <summary>
        /// 使用限制
        /// </summary>
        [SwaggerParameter(Description = "使用限制")]
        public int UseLimitType { get; set; }

    }


    public class CouponSubmitCommandHandler : IRequestHandler<CouponSubmitCommand, CouponSubmitResponse> 
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IConfiguration _configuration;

        public CouponSubmitCommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
            _configuration = configuration;
        }

        public async Task<CouponSubmitResponse> Handle(CouponSubmitCommand command, CancellationToken cancellationToken) 
        {
            var response = new CouponSubmitResponse();

            Coupon coupon = null;
            CouponRule couponRule = null;
            MarketingActivities marketingActivity = null;
            bool isNewCoupon = false;

            Guid? couponRuleId = null;
            Guid? marketingActivityId = null;

            using (var dbtc = _context.BeginTransaction)
            {
                try
                {
                    coupon = _context.Coupons.SingleOrDefault(a => a.Id == command.Id);

                    if (coupon == null)
                    {
                        isNewCoupon = true;

                        couponRuleId = (command.CouponRuleId == Guid.Empty || command.CouponRuleId == null) ? Guid.NewGuid() : command.CouponRuleId;
                        marketingActivityId = (command.MarketingActivitiesId == Guid.Empty || command.MarketingActivitiesId == null) ? Guid.NewGuid() : command.MarketingActivitiesId;
                    }
                    else
                    {
                        couponRule = _context.CouponRules.SingleOrDefault(a => a.Id == coupon.CouponRuleId);
                        if (couponRule != null) couponRuleId = couponRule.Id;

                        marketingActivity = _context.MarketingActivities.SingleOrDefault(a => a.Id == coupon.MarketingActivitiesId);
                        if (marketingActivity != null) marketingActivityId = marketingActivity.Id;
                    }

                    if (isNewCoupon)
                    {
                        #region Add

                        #region Coupon

                        string singleSpecialCode = "";
                        if (command.OutputType == 1) singleSpecialCode = !string.IsNullOrEmpty(command.SpecialCode) ? command.SpecialCode : GetSpecialCode();

                        //Coupon類型為 訂閱費折抵或滿件折只能產一張
                        int CouponCount = (command.CouponType == 5 || command.CouponType == 6) ? 1 : command.LimitQuantity;

                        for (int i = 0; i < CouponCount; i++)
                        {
                            coupon = new Coupon()
                            {
                                Id = GetCouponId(),
                                CouponRuleId = couponRuleId ?? Guid.NewGuid(),
                                MarketingActivitiesId = marketingActivityId,
                                Name = command.CouponName,

                                StartDate = !string.IsNullOrEmpty(command.CanUseStartDate) ? DateTime.Parse(command.CanUseStartDate) : null,
                                EndDate = !string.IsNullOrEmpty(command.CanUseEndDate) ? DateTime.Parse(command.CanUseEndDate) : null,

                                Creator = _authenticatedUserService.UserId,
                                CreatedDate = DateTime.Now,
                                //CustomerId (後台Coupon不會處理)
                                SpecialCode = command.OutputType == 2 ? GetSpecialCode() : singleSpecialCode,//預先產出: 不同張數的指定碼, 即時產出: 相同指定碼
                                                                                                             //ReceivedDate  (後台Coupon不會處理)
                                                                                                             //UsedDate =  (後台Coupon不會處理) command.UsedDate != null ? DateTime.Parse(command.UsedDate) : null
                                                                                                             //TransactionId (後台Coupon不會處理) 
                            };

                            _context.Coupons.Add(coupon);
                        }
                        #endregion

                        #region CouponRule
                        couponRule = new CouponRule
                        {
                            Id = couponRuleId ?? Guid.NewGuid(),
                            UseLimitType = command.UseLimitType,
                            CartType = command.CartType,
                            DiscountThresholdType = command.DiscountThresholdType,
                            DiscountThresholdValue = command.DiscountThresholdValue,
                            DiscountTarget = command.DiscountTarget,
                            DiscountContentType = command.DiscountContentType,
                            DiscountContentValue = command.DiscountContentValue,
                            Enable = true
                        };

                        _context.CouponRules.Add(couponRule);
                        #endregion

                        #region MarketingActivities
                        marketingActivity = new MarketingActivities
                        {
                            Id = marketingActivityId ?? Guid.NewGuid(),
                            Name = command.CouponTypeName,
                            Type = command.CouponType,
                            ReceiveType = command.ReceiveType,
                            StartDate = DateTime.Parse(command.MarketingActivityStartDate),
                            EndDate = DateTime.Parse(command.MarketingActivityEndDate),

                            CanUseType = command.CanUseType,

                            //排程處裡
                            //CanUseStartDate = !string.IsNullOrEmpty(command.CanUseStartDate) ? DateTime.Parse(command.CanUseStartDate) : null,
                            //CanUseEndDate = !string.IsNullOrEmpty(command.CanUseEndDate) ? DateTime.Parse(command.CanUseEndDate) : null,

                            CanUseByReceiveDay = command.CanUseByReceiveDay,

                            SendCondition = command.SendCondition,
                            SendLimitType = command.SendLimitType,
                            LimitQuantity = command.LimitQuantity,
                            SendTarget = command.SendTarget,
                            OutputType = command.OutputType,
                            UseLimitType = command.UseLimitType,

                            Creator = _authenticatedUserService.UserId,
                            CreatedDate = DateTime.Now
                        };

                        _context.MarketingActivities.Add(marketingActivity);
                        #endregion

                        #endregion
                    }
                    else //Id查詢有Coupon資料
                    {
                        #region Update

                        #region Coupon
                        coupon.CouponRuleId = couponRuleId ?? Guid.NewGuid();
                        coupon.MarketingActivitiesId = marketingActivityId ?? Guid.NewGuid();
                        coupon.Name = command.CouponName;

                        coupon.StartDate = !string.IsNullOrEmpty(command.CanUseStartDate) ? DateTime.Parse(command.CanUseStartDate) : null;
                        coupon.EndDate = !string.IsNullOrEmpty(command.CanUseEndDate) ? DateTime.Parse(command.CanUseEndDate) : null;

                        coupon.SpecialCode = command.SpecialCode;
                        //coupon.UsedDate = command.UsedDate != null ? DateTime.Parse(command.UsedDate) : null;
                        #endregion

                        #region CouponRule
                        if (couponRule == null)
                        {
                            couponRule = new CouponRule
                            {
                                Id = coupon.CouponRuleId,
                                UseLimitType = command.UseLimitType,
                                CartType = command.CartType,
                                DiscountThresholdType = command.DiscountThresholdType,
                                DiscountThresholdValue = command.DiscountThresholdValue,
                                DiscountTarget = command.DiscountTarget,
                                DiscountContentType = command.DiscountContentType,
                                DiscountContentValue = command.DiscountContentValue,
                                Enable = true
                            };

                            _context.CouponRules.Add(couponRule);
                        }
                        else
                        {
                            couponRule.UseLimitType = command.UseLimitType;
                            couponRule.CartType = command.CartType;
                            couponRule.DiscountThresholdType = command.DiscountThresholdType;
                            couponRule.DiscountThresholdValue = command.DiscountThresholdValue;
                            couponRule.DiscountTarget = command.DiscountTarget;
                            couponRule.DiscountContentType = command.DiscountContentType;
                            couponRule.DiscountContentValue = command.DiscountContentValue;
                        }
                        #endregion

                        #region MarketingActivities

                        if (marketingActivity == null)
                        {
                            marketingActivity = new MarketingActivities
                            {
                                Id = coupon.MarketingActivitiesId ?? Guid.NewGuid(),
                                Name = command.CouponTypeName,
                                Type = command.CouponType,
                                ReceiveType = command.ReceiveType,
                                StartDate = DateTime.Parse(command.MarketingActivityStartDate),
                                EndDate = DateTime.Parse(command.MarketingActivityEndDate),

                                CanUseType = command.CanUseType,

                                //排程處裡
                                //CanUseStartDate = !string.IsNullOrEmpty(command.CanUseStartDate) ? DateTime.Parse(command.CanUseStartDate) : null,
                                //CanUseEndDate = !string.IsNullOrEmpty(command.CanUseEndDate) ? DateTime.Parse(command.CanUseEndDate) : null,

                                CanUseByReceiveDay = command.CanUseByReceiveDay,

                                SendCondition = command.SendCondition,
                                SendLimitType = command.SendLimitType,
                                SendTarget = command.SendTarget,

                                //既有資料不可編輯
                                //LimitQuantity = command.LimitQuantity,
                                //OutputType = command.OutputType,

                                UseLimitType = command.UseLimitType,

                                Creator = _authenticatedUserService.UserId,
                                CreatedDate = DateTime.Now
                            };

                            _context.MarketingActivities.Add(marketingActivity);
                        }
                        else
                        {
                            marketingActivity.Name = command.CouponTypeName;
                            marketingActivity.Type = command.CouponType;
                            marketingActivity.ReceiveType = command.ReceiveType;
                            marketingActivity.StartDate = DateTime.Parse(command.MarketingActivityStartDate);
                            marketingActivity.EndDate = DateTime.Parse(command.MarketingActivityEndDate);

                            marketingActivity.CanUseType = command.CanUseType;

                            //排程處裡
                            //marketingActivity.CanUseStartDate = !string.IsNullOrEmpty(command.CanUseStartDate) ? DateTime.Parse(command.CanUseStartDate) : null;
                            //marketingActivity.CanUseEndDate = !string.IsNullOrEmpty(command.CanUseEndDate) ? DateTime.Parse(command.CanUseEndDate) : null;

                            marketingActivity.CanUseByReceiveDay = command.CanUseByReceiveDay;

                            marketingActivity.SendCondition = command.SendCondition;
                            marketingActivity.SendLimitType = command.SendLimitType;
                            marketingActivity.SendTarget = command.SendTarget;

                            //既有資料不可編輯
                            //marketingActivity.LimitQuantity = command.LimitQuantity;
                            //marketingActivity.OutputType = command.OutputType;

                            marketingActivity.UseLimitType = command.UseLimitType;

                            marketingActivity.Modifier = _authenticatedUserService.UserId;
                            marketingActivity.ModifyDate = DateTime.Now;
                        }
                        #endregion

                        #endregion
                    }

                    await _context.SaveChangesAsync(cancellationToken);

                    dbtc.Commit();

                    response.Message = "儲存成功";
                }
                catch (Exception ex)
                {
                    dbtc.Rollback();
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        private string GetCouponId()
        {
            string CouponId = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BoxAdminConnection")))
                {

                    String sql = @"SELECT 'CP' + RIGHT(REPLICATE('0',10) + CAST(NEXT VALUE FOR CouponNumSeq AS VARCHAR), 10)";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        CouponId = sqlCommand.ExecuteScalar().ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                return "";
            }

            return CouponId;
        }

        private string GetSpecialCode() 
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
