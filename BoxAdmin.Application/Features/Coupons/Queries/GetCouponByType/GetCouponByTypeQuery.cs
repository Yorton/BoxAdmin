using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;
using Swashbuckle.AspNetCore.Annotations;

using BoxAdmin.Application.Interfaces.Shared;
using Microsoft.EntityFrameworkCore.Storage;

using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponByType
{
    /// <summary>
    /// Coupon類型
    /// </summary>
    public enum CouponType
    {
        一般Coupon = 1,
        專屬生日禮 = 2,
        升等會員購物禮 = 3,
        續訂禮 = 4,
        訂閱費折抵 = 5,
        滿件折 = 6
    }


    public class GetCouponByTypeQuery : IRequest<GetCouponByTypeResponse>
    {
        /// <summary>
        /// Coupon類型- 1:一般, 2:專屬生日禮, 3:升等會員購物禮, 4:續訂禮, 5:訂閱費折抵, 6:滿件折
        /// </summary>
        [SwaggerParameter(Description = "Coupon類型- 1:一般, 2:專屬生日禮, 3:升等會員購物禮, 4:續訂禮, 5:訂閱費折抵, 6:滿件折")]
        public int CouponType { get; set; }
    }

    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByTypeQuery, GetCouponByTypeResponse> 
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IConfiguration _configuration;

        public GetCouponByIdQueryHandler(IMapper mapper, IBoxDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        public async Task<GetCouponByTypeResponse> Handle(GetCouponByTypeQuery command, CancellationToken cancellationToken) 
        {
            GetCouponByTypeResponse response = new GetCouponByTypeResponse();

            response.Id = GetCouponId();
            response.CouponRuleId = Guid.NewGuid();
            response.MarketingActivitiesId = Guid.NewGuid();

            response.Status = "";

            switch (command.CouponType) 
            {
                case (int)CouponType.一般Coupon:

                    #region 一般Coupon
                    response.CouponName = "幸運兒就是你！首購免費一盒";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 1;
                    response.CouponTypeName = "一般";


                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點: 0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 0;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 0;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 1;

                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 2;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 1;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "1";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 1;
                    #endregion

                    break;
                case (int)CouponType.專屬生日禮:

                    #region 專屬生日禮
                    response.CouponName = "專屬生日禮";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 2;
                    response.CouponTypeName = "專屬生日禮";

                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點:  0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 2;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 3;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 1;

                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 2;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 0;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "1";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 1;
                    #endregion

                    break;
                case (int)CouponType.升等會員購物禮:

                    #region 升等會員購物禮
                    response.CouponName = "升等會員購物禮";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 3;
                    response.CouponTypeName = "升等會員購物禮";

                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點: 0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 3;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 1;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 1;


                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 2;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 0;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "3";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 1;
                    #endregion

                    break;
                case (int)CouponType.續訂禮:

                    #region 續訂禮
                    response.CouponName = "續訂方案禮";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 4;
                    response.CouponTypeName = "續訂禮";

                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點: 0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 3;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 1;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 1;


                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 2;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 0;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "3";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 1;
                    #endregion

                    break;
                case (int)CouponType.訂閱費折抵:

                    #region 訂閱費折抵

                    response.CouponName = "訂閱方案390元方案抵折訂閱費";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 5;
                    response.CouponTypeName = "訂閱費折抵";

                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點: 0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 1;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 2;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 0;


                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 0;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 0;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "2";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 1;
                    #endregion

                    break;
                case (int)CouponType.滿件折:

                    #region 滿件折
                    response.CouponName = "滿件折";

                    //Coupon類型: 1. 一般 2. 專屬生日禮 3. 升等會員購物禮 4. 續訂禮 5. 訂閱費折抵 6. 滿件折
                    response.CouponType = 6;
                    response.CouponTypeName = "滿件折";

                    //領取/歸戶方式: 1. 使用者手動領取/歸戶 2. 使用者結帳後歸戶 3. 系統(排程)自動歸戶
                    response.ReceiveType = 3;

                    //活動時間由畫面選擇
                    //response.MarketingActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                    //response.MarketingActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyy/MM/dd");

                    //指定發送時間點: 0. 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
                    response.SendTimePoint = 1;

                    //發送條件: 1. 服務方案續訂訂單成立 2. 商品訂單(盒內商品)結帳時 3. 生日月為發送日當月
                    response.SendCondition = 2;

                    //發送限制: 0. 無(預設) 1. 活動區間內限領用１張 2. 活動區間內每天限領用１張
                    response.SendLimitType = 0;


                    //可用時間選項: 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
                    response.CanUseType = 0;

                    //使用限制: 1. 第一張服務訂單成立　2. 盒內商品數全滿(含加衣券)
                    response.UseLimitType = 2;

                    //產出類型: 1. 即時產出 2. 預先產出
                    //response.OutputType = 1;

                    //對象: 1. 全部會員 2. 一般會員 3. 訂閱會員(季) 4. 指定會員
                    response.SendTarget = 3;

                    //優惠項目: 1. 服務訂單(服務方案)　2. 商品訂單(盒內商品)　3. 商品訂單(直購)
                    response.CartType = "2";

                    //優惠門檻類型: 0.無 1. 滿件 2.滿元
                    response.DiscountThresholdType = 0;

                    //優惠目標: 1. 商品總金額
                    response.DiscountTarget = 1;

                    //優惠內容類型: 　1. 折[N]元 　2. 打[N]折
                    response.DiscountContentType = 2;
                    #endregion
                    break;
            }

            return await Task.FromResult(response);
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
    }
}
