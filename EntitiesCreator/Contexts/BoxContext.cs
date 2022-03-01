using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BoxAdmin.Domain.Entities.BoxContext;

#nullable disable

namespace BoxAdmin.Domain.Contexts
{
    public partial class BoxContext : DbContext
    {
        public BoxContext()
        {
        }

        public BoxContext(DbContextOptions<BoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbandonedCart> AbandonedCarts { get; set; }
        public virtual DbSet<AbandonedCartDetail> AbandonedCartDetails { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountValidate> AccountValidates { get; set; }
        public virtual DbSet<BoxDataSync> BoxDataSyncs { get; set; }
        public virtual DbSet<CardDesign> CardDesigns { get; set; }
        public virtual DbSet<CardDesignMessage> CardDesignMessages { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponRule> CouponRules { get; set; }
        public virtual DbSet<CustomerDatum> CustomerData { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }
        public virtual DbSet<DislikeFeedbackReason> DislikeFeedbackReasons { get; set; }
        public virtual DbSet<EcpayAllowance> EcpayAllowances { get; set; }
        public virtual DbSet<EcpayAllowanceItem> EcpayAllowanceItems { get; set; }
        public virtual DbSet<EcpayAllowanceLog> EcpayAllowanceLogs { get; set; }
        public virtual DbSet<EcpayInvoice> EcpayInvoices { get; set; }
        public virtual DbSet<EcpayInvoiceItem> EcpayInvoiceItems { get; set; }
        public virtual DbSet<EcpayInvoiceLog> EcpayInvoiceLogs { get; set; }
        public virtual DbSet<ImageInfo> ImageInfos { get; set; }
        public virtual DbSet<MarketingActivitiesSendTargetList> MarketingActivitiesSendTargetLists { get; set; }
        public virtual DbSet<MarketingActivity> MarketingActivities { get; set; }
        public virtual DbSet<MatchmakerCollection> MatchmakerCollections { get; set; }
        public virtual DbSet<MatchmakerInfo> MatchmakerInfos { get; set; }
        public virtual DbSet<MatchmakerSignature> MatchmakerSignatures { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderItemState> OrderItemStates { get; set; }
        public virtual DbSet<OrderPayType> OrderPayTypes { get; set; }
        public virtual DbSet<OrderPayment> OrderPayments { get; set; }
        public virtual DbSet<OrderRefund> OrderRefunds { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<PageFrame> PageFrames { get; set; }
        public virtual DbSet<PageFrameContent> PageFrameContents { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ProductFavorite> ProductFavorites { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductScore> ProductScores { get; set; }
        public virtual DbSet<ProductSeries> ProductSeries { get; set; }
        public virtual DbSet<ProductSeriesCategory> ProductSeriesCategories { get; set; }
        public virtual DbSet<ProductSizeReport> ProductSizeReports { get; set; }
        public virtual DbSet<ProductSku> ProductSkus { get; set; }
        public virtual DbSet<ProductTagToSeries> ProductTagToSeries { get; set; }
        public virtual DbSet<ProductTryReport> ProductTryReports { get; set; }
        public virtual DbSet<Qa> Qas { get; set; }
        public virtual DbSet<QaCatelog> QaCatelogs { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservationCard> ReservationCards { get; set; }
        public virtual DbSet<ReservationCardMessage> ReservationCardMessages { get; set; }
        public virtual DbSet<ReservationCustomer> ReservationCustomers { get; set; }
        public virtual DbSet<ReservationFeedback> ReservationFeedbacks { get; set; }
        public virtual DbSet<ReservationFlowStateLog> ReservationFlowStateLogs { get; set; }
        public virtual DbSet<ReservationLineItem> ReservationLineItems { get; set; }
        public virtual DbSet<ReservationLineItemGroup> ReservationLineItemGroups { get; set; }
        public virtual DbSet<ReservationRecipient> ReservationRecipients { get; set; }
        public virtual DbSet<ReservationState> ReservationStates { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<ReturnsItem> ReturnsItems { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShipmentOrderItem> ShipmentOrderItems { get; set; }
        public virtual DbSet<SmsMessageDatum> SmsMessageData { get; set; }
        public virtual DbSet<SmsMessageResult> SmsMessageResults { get; set; }
        public virtual DbSet<StyleBook> StyleBooks { get; set; }
        public virtual DbSet<StyleBookCondition> StyleBookConditions { get; set; }
        public virtual DbSet<StyleBookDetail> StyleBookDetails { get; set; }
        public virtual DbSet<StyleFavorite> StyleFavorites { get; set; }
        public virtual DbSet<Subscribe> Subscribes { get; set; }
        public virtual DbSet<SubscribeState> SubscribeStates { get; set; }
        public virtual DbSet<SubscribeSuspendLog> SubscribeSuspendLogs { get; set; }
        public virtual DbSet<SubscriptionPlanInfo> SubscriptionPlanInfos { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public virtual DbSet<SurveyReply> SurveyReplies { get; set; }
        public virtual DbSet<SurveyTitle> SurveyTitles { get; set; }
        public virtual DbSet<SurveyTitleMapping> SurveyTitleMappings { get; set; }
        public virtual DbSet<TakeCp> TakeCps { get; set; }
        public virtual DbSet<Temp產品> Temp產品s { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }
        public virtual DbSet<VersionInfo> VersionInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=stagingserver;Database=BOX;user id=orangebear;password=RxLGHgR*Earz;Connection Timeout=300;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<AbandonedCart>(entity =>
            {
                entity.ToTable("AbandonedCart");

                entity.HasComment("購物車暫存");

                entity.Property(e => e.Id).HasComment("購物車暫存Id");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("帳號");

                entity.Property(e => e.ModifityDate)
                    .HasColumnType("date")
                    .HasComment("最後更新時間(日期)");

                entity.Property(e => e.ModifityTime).HasComment("最後更新時間(時間)");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("通路");
            });

            modelBuilder.Entity<AbandonedCartDetail>(entity =>
            {
                entity.ToTable("AbandonedCartDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("購物車暫存明細Id");

                entity.Property(e => e.AbandonedCartId).HasComment("購物車暫存Id");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.MainSeries)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("主系列編號");

                entity.Property(e => e.PlatForm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("平台");

                entity.Property(e => e.Price).HasComment("單價");

                entity.Property(e => e.Quantity).HasComment("數量");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("產品編號");

                entity.Property(e => e.Type).HasComment("1=一般,2=盒子,3=預購,4=贈品,5=運費");

                entity.Property(e => e.Utm)
                    .HasColumnName("UTM")
                    .HasComment("媒體參數(utmSource/utmMedium/pv/utmCampaign/ecid)");

                entity.Property(e => e.Volume).HasComment("材積");

                entity.Property(e => e.Weight)
                    .HasColumnType("numeric(18, 3)")
                    .HasComment("重量");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.Account1, e.Type, e.CustomerId });

                entity.ToTable("Account");

                entity.HasComment("帳戶資料");

                entity.HasIndex(e => e.SyncGuid, "IX_Account_SyncGuid")
                    .IsUnique();

                entity.HasIndex(e => e.SyncGuid, "IX_Coupon_SyncGuid")
                    .IsUnique();

                entity.Property(e => e.Account1)
                    .HasMaxLength(100)
                    .HasColumnName("Account");

                entity.Property(e => e.Type)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1: 官網 2: 橘熊第三方登入");

                entity.Property(e => e.CustomerId)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("reference key with CustomerData/CustomerInfo/DeviceInfo Table");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SyncGuid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_CustomerInfo");
            });

            modelBuilder.Entity<AccountValidate>(entity =>
            {
                entity.HasKey(e => new { e.Account, e.ValidateType });

                entity.ToTable("AccountValidate");

                entity.HasComment("簡訊驗證資料");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.ValidateType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1註冊 2綁定 3忘記密碼");

                entity.Property(e => e.Valid).HasComment("是否已驗證");

                entity.Property(e => e.ValidateCheckCount).HasComment("驗證回填次數");

                entity.Property(e => e.ValidateCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("驗證碼");

                entity.Property(e => e.ValidateCodeSendCount).HasComment("發送次數");

                entity.Property(e => e.ValidateCodeSendDate)
                    .HasColumnType("datetime")
                    .HasComment("發送時間");
            });

            modelBuilder.Entity<BoxDataSync>(entity =>
            {
                entity.ToTable("BoxDataSync");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TableName");

                entity.Property(e => e.SyncAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("I: insert D: delete U: update");

                entity.Property(e => e.SyncValue)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CardDesign>(entity =>
            {
                entity.ToTable("CardDesign");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("卡片製作ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intro)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("問候語(介紹)");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReservationId).HasComment("BOX預約單ID (ref: Reservation)");

                entity.Property(e => e.SignatureId).HasComment("簽名檔ID (ref: MatchmakerSignature.Id)");

                entity.Property(e => e.Template).HasComment("版型類別");
            });

            modelBuilder.Entity<CardDesignMessage>(entity =>
            {
                entity.ToTable("CardDesignMessage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("卡片搭配文案ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("文案說明");

                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("訊息清單類型");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("名稱");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupon");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasComment("SELECT 'CP' + RIGHT(REPLICATE('0',10) + CAST(NEXT VALUE FOR CouponNumSeq AS VARCHAR), 10)");

                entity.Property(e => e.CouponRuleId).HasComment("CouponRuleId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("建立者");

                entity.Property(e => e.CustomerId).HasComment("領取會員Id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("啟用日期迄");

                entity.Property(e => e.MarketingActivitiesId).HasComment("MarketingActivitiesId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasComment("Coupon名稱");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("datetime")
                    .HasComment("領取時間");

                entity.Property(e => e.SpecialCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("行銷碼");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasComment("啟用日期起");

                entity.Property(e => e.TransactionId).HasComment("購物車Id");

                entity.Property(e => e.UsedDate)
                    .HasColumnType("datetime")
                    .HasComment("使用時間");
            });

            modelBuilder.Entity<CouponRule>(entity =>
            {
                entity.ToTable("CouponRule");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("");

                entity.Property(e => e.CartType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("優惠項目(存項目的16進位字串比如123)\r\n必填/可複選\r\n1. 服務訂單(服務方案)\r\n2. 商品訂單(盒內商品)\r\n3. 商品訂單(直購)\r\n");

                entity.Property(e => e.DiscountContentType).HasComment("優惠內容\r\n必填\r\n1. 折 [N] 元 (預設)\r\n2. 打 [N] 折\r\n");

                entity.Property(e => e.DiscountContentValue).HasComment("優惠內容\r\n必填\r\n1. 折 [N] 元 (預設)\r\n[N] 為 TextInput\r\n限輸入 1~99999 數字\r\n2. 打 [N] 折\r\n[N] 為 TextInput\r\n限輸入大於 0 的正整數\r\n限輸入 1~99 數字\r\n");

                entity.Property(e => e.DiscountTarget).HasComment("優惠目標\r\n1. 商品總金額");

                entity.Property(e => e.DiscountThresholdType).HasComment("優惠門檻\r0.無 \n1. 滿件 2.滿元");

                entity.Property(e => e.DiscountThresholdValue).HasComment("優惠門檻 Value\r\n1. 滿 [N] 元\r\n[N] 為 TextInput\r\n限輸入 1~99999 數字\r\n2. 滿 [N] 件\r\n[N] 為 TextInput\r\n限輸入 1~999 數字\r\n");

                entity.Property(e => e.Enable).HasComment("啟用/停用");

                entity.Property(e => e.UseLimitType).HasComment("使用限制\r\n0. 無\r\n1. 第一張服務訂單成立\r\n2. 盒內商品數全滿(含加衣券)\r\n");
            });

            modelBuilder.Entity<CustomerDatum>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasComment("客戶系統資料");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.ArrivalNotice).HasComment("貨到通知");

                entity.Property(e => e.ArrivalNoticeDate)
                    .HasColumnType("datetime")
                    .HasComment("貨到通知時間");

                entity.Property(e => e.Auth3Dok).HasColumnName("Auth3DOK");

                entity.Property(e => e.ChangePasswordDate).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DeviceID");

                entity.Property(e => e.Edm)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstPurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.GroupType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=一般顧客 2=員工 (ref dbo.MemberGroup)");

                entity.Property(e => e.InvoiceBindDate).HasColumnType("datetime");

                entity.Property(e => e.LineDisplayName).HasMaxLength(100);

                entity.Property(e => e.Obfriend).HasColumnName("OBFriend");

                entity.Property(e => e.Obuid).HasColumnName("OBUID");

                entity.Property(e => e.Store).HasComment("門市");

                entity.Property(e => e.ValidateCode).HasMaxLength(20);

                entity.Property(e => e.ValidateDate).HasColumnType("datetime");

                entity.Property(e => e.ValidateMappingCode).HasMaxLength(10);

                entity.Property(e => e.VipEndDate)
                    .HasColumnType("datetime")
                    .HasComment("SVIP結束時間");

                entity.Property(e => e.VipLevel).HasComment("0=一般 2=SVIP");

                entity.Property(e => e.VipStartDate)
                    .HasColumnType("datetime")
                    .HasComment("SVIP開始時間");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.CustomerDatum)
                    .HasForeignKey<CustomerDatum>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerData_CustomerInfo");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("CustomerInfo");

                entity.HasComment("客戶個人基本資料");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasComment("會員主檔資料 PK");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Birthday).HasColumnType("smalldatetime");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyNo).HasMaxLength(20);

                entity.Property(e => e.CompanyTitle).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("電話(新版), OBWeb.Common.Utilitys.SecurityUtility.Decrypt(...) 解密");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.PhoneCountryCode)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('1')")
                    .HasComment("手機國際碼序號\r\n1台灣\r\n2香港\r\n3新加坡\r\n4馬來西亞\r\n5澳門\r\n6美國\r\n7中國\r\n8澳洲\r\n9加拿大\r\n10越南\r\n11泰國\r\n12菲律賓\r\n13韓國\r\n14紐西蘭\r\n15日本\r\n16印度\r\n17杜拜\r\n18英國\r\n19印尼 \r\n20柬埔寨\r\n21法國\r\n22德國\r\n23緬甸\r\n");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.ToTable("DeliveryMethod");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("寄送方式Id(編號需跟官網出貨共用)");

                entity.Property(e => e.Comment)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("備註");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("寄送方式說明");
            });

            modelBuilder.Entity<DeviceInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("DeviceInfo");

                entity.HasComment("裝置平台資訊資料表");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasComment("裝置識別碼");

                entity.Property(e => e.Osversion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OSVersion")
                    .HasComment("平台作業系統版本");

                entity.Property(e => e.Platform).HasComment("裝置平台(1=Android, 2=iOS)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("裝置目前APP版本");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.DeviceInfo)
                    .HasForeignKey<DeviceInfo>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceInfo_CustomerInfo");
            });

            modelBuilder.Entity<DislikeFeedbackReason>(entity =>
            {
                entity.ToTable("DislikeFeedbackReason");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EcpayAllowance>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.IaAllowNo });

                entity.ToTable("ECPayAllowance");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(15)
                    .HasComment("發票號碼");

                entity.Property(e => e.IaAllowNo)
                    .HasMaxLength(20)
                    .HasColumnName("IA_Allow_No")
                    .HasComment("折讓單號");

                entity.Property(e => e.AiAllowDate)
                    .HasColumnType("datetime")
                    .HasColumnName("AI_Allow_Date")
                    .HasComment("折讓單日期");

                entity.Property(e => e.AiAllowNo)
                    .HasMaxLength(20)
                    .HasColumnName("AI_Allow_No")
                    .HasComment("折讓單號");

                entity.Property(e => e.AiBuyerIdentifier)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AI_Buyer_Identifier")
                    .HasComment("買方統編  0000000000 代表沒有統編");

                entity.Property(e => e.AiDate)
                    .HasColumnType("datetime")
                    .HasColumnName("AI_Date")
                    .HasComment("作廢時間");

                entity.Property(e => e.AiInvoiceNo)
                    .HasMaxLength(15)
                    .HasColumnName("AI_Invoice_No")
                    .HasComment("發票號碼");

                entity.Property(e => e.AiMerId)
                    .HasMaxLength(15)
                    .HasColumnName("AI_Mer_ID")
                    .HasComment("特店代號");

                entity.Property(e => e.AiSellerIdentifier)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AI_Seller_Identifier")
                    .HasComment("賣方統編");

                entity.Property(e => e.AiUploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("AI_Upload_Date")
                    .HasComment("上傳時間");

                entity.Property(e => e.AiUploadStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AI_Upload_Status")
                    .HasComment("上傳狀態  1：已上傳  0：未上傳");

                entity.Property(e => e.AreaId).HasComment("AreaId");

                entity.Property(e => e.IaCheckSendMail)
                    .HasMaxLength(20)
                    .HasColumnName("IA_Check_Send_Mail")
                    .HasComment("折讓通知類型  S：簡訊  E：電子郵件  A：皆通知時  N：皆不通知");

                entity.Property(e => e.IaDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IA_Date")
                    .HasComment("折讓時間");

                entity.Property(e => e.IaIdentifier)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IA_Identifier")
                    .HasComment("買受人統編  0000000000 代表沒有統編");

                entity.Property(e => e.IaInvalidStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IA_Invalid_Status")
                    .HasComment("折讓作廢狀態  1：折讓單已作廢  0：折讓單未作廢");

                entity.Property(e => e.IaInvoiceIssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IA_Invoice_Issue_Date")
                    .HasComment("發票開立時間");

                entity.Property(e => e.IaInvoiceNo)
                    .HasMaxLength(15)
                    .HasColumnName("IA_Invoice_No")
                    .HasComment("發票號碼");

                entity.Property(e => e.IaIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IA_IP")
                    .HasComment("折讓 IP");

                entity.Property(e => e.IaMerId)
                    .HasMaxLength(15)
                    .HasColumnName("IA_Mer_ID")
                    .HasComment("特店代號");

                entity.Property(e => e.IaSendMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IA_Send_Mail")
                    .HasComment("通知的 MAIL");

                entity.Property(e => e.IaSendPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IA_Send_Phone")
                    .HasComment("通知的手機");

                entity.Property(e => e.IaTaxAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IA_Tax_Amount")
                    .HasComment("營業稅額合計");

                entity.Property(e => e.IaTaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IA_Tax_Type")
                    .HasComment("課稅別  1：應稅  2：零稅率  3：免稅  4：應稅(特種稅率)");

                entity.Property(e => e.IaTotalAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IA_Total_Amount")
                    .HasComment("金 額 合 計( 不含稅之進貨額)");

                entity.Property(e => e.IaTotalTaxAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IA_Total_Tax_Amount")
                    .HasComment("金 額 合 計(含稅)");

                entity.Property(e => e.IaUploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IA_Upload_Date")
                    .HasComment("上傳時間");

                entity.Property(e => e.IaUploadStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IA_Upload_Status")
                    .HasComment("折讓上傳狀態  1：已上傳  0：未上傳");

                entity.Property(e => e.IisCustomerName)
                    .HasMaxLength(70)
                    .HasColumnName("IIS_Customer_Name")
                    .HasComment("買受人姓名");

                entity.Property(e => e.IsInvalid).HasComment("是否作廢");

                entity.Property(e => e.Reason)
                    .HasMaxLength(25)
                    .HasComment("作廢原因");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(15)
                    .HasComment("StoreId");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(15)
                    .HasComment("StoreName");

                entity.Property(e => e.VatNumber)
                    .HasMaxLength(15)
                    .HasComment("賣方統編");
            });

            modelBuilder.Entity<EcpayAllowanceItem>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.IaAllowNo, e.ItemSeq });

                entity.ToTable("ECPayAllowanceItem");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(15)
                    .HasComment("發票號碼");

                entity.Property(e => e.IaAllowNo)
                    .HasMaxLength(20)
                    .HasColumnName("IA_Allow_No")
                    .HasComment("折讓編號");

                entity.Property(e => e.ItemSeq).HasComment("序號");

                entity.Property(e => e.ItemAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("商品總價");

                entity.Property(e => e.ItemCount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("商品數量");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasComment("商品名稱");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("商品單價");

                entity.Property(e => e.ItemRateAmt)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("商品營業稅");

                entity.Property(e => e.ItemTaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("商品課稅別");

                entity.Property(e => e.ItemWord)
                    .HasMaxLength(6)
                    .HasComment("商品單位");
            });

            modelBuilder.Entity<EcpayAllowanceLog>(entity =>
            {
                entity.ToTable("ECPayAllowanceLog");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("GUID");

                entity.Property(e => e.AllowanceAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("折讓單總金額(含稅)");

                entity.Property(e => e.AllowanceNo)
                    .HasMaxLength(16)
                    .HasComment("折讓單號");

                entity.Property(e => e.AllowanceNotify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("通知類別  S：簡訊  E：電子郵件  A：皆通知時  N：皆不通知");

                entity.Property(e => e.AreaId).HasComment("門市代碼");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("建立時間");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(60)
                    .HasComment("客戶名稱");

                entity.Property(e => e.IaAllowNo)
                    .HasMaxLength(20)
                    .HasColumnName("IA_Allow_No")
                    .HasComment("折讓單號");

                entity.Property(e => e.IaDate)
                    .HasMaxLength(20)
                    .HasColumnName("IA_Date")
                    .HasComment("折讓時間");

                entity.Property(e => e.IaInvoiceNo)
                    .HasMaxLength(15)
                    .HasColumnName("IA_Invoice_No")
                    .HasComment("發票號碼");

                entity.Property(e => e.IaRemainAllowanceAmt)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IA_Remain_Allowance_Amt")
                    .HasComment("折讓剩餘金額");

                entity.Property(e => e.IaTempDate)
                    .HasMaxLength(20)
                    .HasColumnName("IA_TempDate")
                    .HasComment("線上折讓時間");

                entity.Property(e => e.IaTempExpireDate)
                    .HasMaxLength(20)
                    .HasColumnName("IA_TempExpireDate")
                    .HasComment("線上折讓同意到期日");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasComment("發票開立日期");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("發票號碼");

                entity.Property(e => e.Items).HasComment("商品資料Json");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MerchantID")
                    .HasComment("API MID");

                entity.Property(e => e.NotifyMail)
                    .HasMaxLength(100)
                    .HasComment("通知Mail");

                entity.Property(e => e.NotifyPhone)
                    .HasMaxLength(20)
                    .HasComment("通知手機");

                entity.Property(e => e.Reason)
                    .HasMaxLength(20)
                    .HasComment("作廢原因");

                entity.Property(e => e.ReturnUrl)
                    .HasMaxLength(200)
                    .HasColumnName("ReturnURL")
                    .HasComment("消費者同意後回傳網址");

                entity.Property(e => e.RtnCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("回傳Code");

                entity.Property(e => e.RtnMsg)
                    .HasMaxLength(200)
                    .HasComment("回傳訊息");

                entity.Property(e => e.StoreId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("平台/商店 ID");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("平台/商店 名稱");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("1: 開立折讓  2:作廢折讓");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasComment("平台/商店 統編");
            });

            modelBuilder.Entity<EcpayInvoice>(entity =>
            {
                entity.HasKey(e => e.IisNumber);

                entity.ToTable("ECPayInvoice");

                entity.Property(e => e.IisNumber)
                    .HasMaxLength(15)
                    .HasColumnName("IIS_Number")
                    .HasComment("發票號碼");

                entity.Property(e => e.AreaId).HasComment("AreaId");

                entity.Property(e => e.IiBuyerIdentifier)
                    .HasMaxLength(15)
                    .HasColumnName("II_Buyer_Identifier")
                    .HasComment("買方統編 0000000000 代表沒有統編");

                entity.Property(e => e.IiDate)
                    .HasColumnType("datetime")
                    .HasColumnName("II_Date")
                    .HasComment("作廢時間");

                entity.Property(e => e.IiInvoiceNo)
                    .HasMaxLength(15)
                    .HasColumnName("II_Invoice_No")
                    .HasComment("發票號碼");

                entity.Property(e => e.IiSellerIdentifier)
                    .HasMaxLength(15)
                    .HasColumnName("II_Seller_Identifier")
                    .HasComment("賣方統編");

                entity.Property(e => e.IiUploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("II_Upload_Date")
                    .HasComment("上傳時間");

                entity.Property(e => e.IiUploadStatus)
                    .HasMaxLength(1)
                    .HasColumnName("II_Upload_Status")
                    .HasComment("上傳狀態 1：已上傳 0：未上傳");

                entity.Property(e => e.IisAwardFlag)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Award_Flag")
                    .HasComment("中獎期標  空值：未對獎、不可對獎  0：未中獎  1：已中獎  X：有統編之發票");

                entity.Property(e => e.IisAwardType)
                    .HasMaxLength(2)
                    .HasColumnName("IIS_Award_Type")
                    .HasComment("中獎種類");

                entity.Property(e => e.IisCarrierNum)
                    .HasMaxLength(64)
                    .HasColumnName("IIS_Carrier_Num")
                    .HasComment("載具編號");

                entity.Property(e => e.IisCarrierType)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Carrier_Type")
                    .HasComment("載具類別 1：為綠界電子發票載具 2：為消費者自然人憑證 3：為消費者手機條碼  無載具，為空值");

                entity.Property(e => e.IisCategory)
                    .HasMaxLength(10)
                    .HasColumnName("IIS_Category")
                    .HasComment("發票類別  B2B：有統編  B2C：無統編");

                entity.Property(e => e.IisCheckNumber)
                    .HasMaxLength(4)
                    .HasColumnName("IIS_Check_Number")
                    .HasComment("發票檢查碼");

                entity.Property(e => e.IisClearanceMark)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Clearance_Mark")
                    .HasComment("通關方式 1：非經海關出口 2：經海關出口");

                entity.Property(e => e.IisCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IIS_Create_Date")
                    .HasComment("發票開立時間");

                entity.Property(e => e.IisCustomerAddr)
                    .HasMaxLength(120)
                    .HasColumnName("IIS_Customer_Addr")
                    .HasComment("客戶地址");

                entity.Property(e => e.IisCustomerEmail)
                    .HasMaxLength(80)
                    .HasColumnName("IIS_Customer_Email")
                    .HasComment("客戶電子信箱");

                entity.Property(e => e.IisCustomerId)
                    .HasMaxLength(25)
                    .HasColumnName("IIS_Customer_ID")
                    .HasComment("客戶編號");

                entity.Property(e => e.IisCustomerName)
                    .HasMaxLength(70)
                    .HasColumnName("IIS_Customer_Name")
                    .HasComment("客戶名稱");

                entity.Property(e => e.IisCustomerPhone)
                    .HasMaxLength(20)
                    .HasColumnName("IIS_Customer_Phone")
                    .HasComment("客戶電話");

                entity.Property(e => e.IisIdentifier)
                    .HasMaxLength(15)
                    .HasColumnName("IIS_Identifier")
                    .HasComment("買方統編  0000000000 代表沒有統編");

                entity.Property(e => e.IisInvalidStatus)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Invalid_Status")
                    .HasComment("發票作廢狀態 1：已作廢時  0：未作廢");

                entity.Property(e => e.IisIp)
                    .HasMaxLength(20)
                    .HasColumnName("IIS_IP")
                    .HasComment("發票開立 IP");

                entity.Property(e => e.IisIssueStatus)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Issue_Status")
                    .HasComment("發票開立狀態 1：發票開立 0：發票註銷");

                entity.Property(e => e.IisLoveCode)
                    .HasMaxLength(10)
                    .HasColumnName("IIS_Love_Code")
                    .HasComment("捐款單位捐贈碼");

                entity.Property(e => e.IisMerId)
                    .HasMaxLength(15)
                    .HasColumnName("IIS_Mer_ID")
                    .HasComment("特店編號");

                entity.Property(e => e.IisPrintFlag)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Print_Flag")
                    .HasComment("列印旗標  1：列印  0：不列印");

                entity.Property(e => e.IisRandomNumber)
                    .HasMaxLength(8)
                    .HasColumnName("IIS_Random_Number")
                    .HasComment("隨機碼");

                entity.Property(e => e.IisRelateNumber)
                    .HasMaxLength(35)
                    .HasColumnName("IIS_Relate_Number")
                    .HasComment("特店自訂編號");

                entity.Property(e => e.IisRemainAllowanceAmt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IIS_Remain_Allowance_Amt")
                    .HasComment("折讓剩餘金額");

                entity.Property(e => e.IisSalesAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IIS_Sales_Amount")
                    .HasComment("發票金額");

                entity.Property(e => e.IisTaxAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IIS_Tax_Amount")
                    .HasComment("稅金");

                entity.Property(e => e.IisTaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("IIS_Tax_Rate")
                    .HasComment("稅率 小數點 3 位");

                entity.Property(e => e.IisTaxType)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Tax_Type")
                    .HasComment("課稅別  1：應稅  2：零稅率  3：免稅  4：應稅(特種稅率)  9：若為混合應稅與免稅或零稅率");

                entity.Property(e => e.IisTurnkeyStatus)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Turnkey_Status")
                    .HasComment("發票上傳後接收狀態  C：成功  E：失敗  G：處理中(待財政部回覆狀態)  P：處理中(上傳財政部中)");

                entity.Property(e => e.IisType)
                    .HasMaxLength(2)
                    .HasColumnName("IIS_Type")
                    .HasComment("發票種類 07：一般稅額計算  08：特種稅額");

                entity.Property(e => e.IisUploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IIS_Upload_Date")
                    .HasComment("發票上傳時間");

                entity.Property(e => e.IisUploadStatus)
                    .HasMaxLength(1)
                    .HasColumnName("IIS_Upload_Status")
                    .HasComment("發票上傳狀態  1：已上傳  0：未上傳");

                entity.Property(e => e.InvoiceRemark)
                    .HasMaxLength(250)
                    .HasComment("發票備註");

                entity.Property(e => e.IsInvalid).HasComment("是否作廢");

                entity.Property(e => e.PosBarCode).HasComment("顯示電子發票 BARCODE用");

                entity.Property(e => e.QrcodeLeft)
                    .HasColumnName("QRCode_Left")
                    .HasComment("顯示電子發票 QRCODE左邊用");

                entity.Property(e => e.QrcodeRight)
                    .HasColumnName("QRCode_Right")
                    .HasComment("顯示電子發票 QRCODE右邊用");

                entity.Property(e => e.Reason)
                    .HasMaxLength(30)
                    .HasComment("作廢原因");

                entity.Property(e => e.SpecialTaxType)
                    .HasMaxLength(1)
                    .HasComment("");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(15)
                    .HasComment("StoreId");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(15)
                    .HasComment("StoreName");

                entity.Property(e => e.VatNumber)
                    .HasMaxLength(15)
                    .HasComment("賣方統編");
            });

            modelBuilder.Entity<EcpayInvoiceItem>(entity =>
            {
                entity.HasKey(e => new { e.IisNumber, e.ItemSeq });

                entity.ToTable("ECPayInvoiceItem");

                entity.Property(e => e.IisNumber)
                    .HasMaxLength(15)
                    .HasColumnName("IIS_Number")
                    .HasComment("發票號碼");

                entity.Property(e => e.ItemSeq).HasComment("序號");

                entity.Property(e => e.ItemAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("商品總價");

                entity.Property(e => e.ItemCount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("商品數量");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasComment("商品名稱");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("商品單價");

                entity.Property(e => e.ItemRemark)
                    .HasMaxLength(50)
                    .HasComment("商品備註");

                entity.Property(e => e.ItemTaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("商品課稅別");

                entity.Property(e => e.ItemWord)
                    .HasMaxLength(6)
                    .HasComment("商品單位");
            });

            modelBuilder.Entity<EcpayInvoiceLog>(entity =>
            {
                entity.ToTable("ECPayInvoiceLog");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Guid");

                entity.Property(e => e.Amt)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("發票金額");

                entity.Property(e => e.AreaId).HasComment("門市代碼");

                entity.Property(e => e.CarrierNo)
                    .HasMaxLength(64)
                    .HasComment("手機載具");

                entity.Property(e => e.CarrierType).HasComment("載具類型");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("建立時間");

                entity.Property(e => e.CustAddr)
                    .HasMaxLength(100)
                    .HasComment("客戶/公司地址");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(80)
                    .HasComment("連絡電子信箱");

                entity.Property(e => e.CustId)
                    .HasMaxLength(20)
                    .HasColumnName("CustID")
                    .HasComment("客戶ID");

                entity.Property(e => e.CustName)
                    .HasMaxLength(60)
                    .HasComment("客戶/公司名稱");

                entity.Property(e => e.CustPhone)
                    .HasMaxLength(20)
                    .HasComment("聯絡電話");

                entity.Property(e => e.GuiNo)
                    .HasMaxLength(8)
                    .HasComment("統一編號");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasComment("發票日期");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(10)
                    .HasComment("發票號碼");

                entity.Property(e => e.IsDonation).HasComment("是否捐贈");

                entity.Property(e => e.IsPrint).HasComment("是否列印");

                entity.Property(e => e.Items).HasComment("商品明細Json");

                entity.Property(e => e.LoveCode)
                    .HasMaxLength(7)
                    .HasComment("捐贈碼");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MerchantID")
                    .HasComment("API MID");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("訂單編號");

                entity.Property(e => e.RandomNumber)
                    .HasMaxLength(4)
                    .HasComment("隨機碼");

                entity.Property(e => e.Reason)
                    .HasMaxLength(20)
                    .HasComment("作廢原因");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasComment("備註");

                entity.Property(e => e.RtnCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("回傳code");

                entity.Property(e => e.RtnMsg)
                    .HasMaxLength(200)
                    .HasComment("回傳訊息");

                entity.Property(e => e.StoreId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("平台/商店 ID");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("平台/商店 名稱");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("1 :建立發票  2: 發票作廢");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasComment("平台/商店 統編");
            });

            modelBuilder.Entity<ImageInfo>(entity =>
            {
                entity.ToTable("ImageInfo");

                entity.HasComment("圖片版面");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('filename.jpg')");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.RelatedLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<MarketingActivitiesSendTargetList>(entity =>
            {
                entity.ToTable("MarketingActivitiesSendTargetList");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("帳號")
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("建立時間");

                entity.Property(e => e.MarketingActivitiesId).HasComment("活動Id");
            });

            modelBuilder.Entity<MarketingActivity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("");

                entity.Property(e => e.CanUseByReceiveDay).HasComment("歸戶後 [N] 天內可使用");

                entity.Property(e => e.CanUseEndDate)
                    .HasColumnType("datetime")
                    .HasComment("可使用的時間-迄");

                entity.Property(e => e.CanUseStartDate)
                    .HasColumnType("datetime")
                    .HasComment("可使用的時間-起");

                entity.Property(e => e.CanUseType).HasComment("可用時間選項\r\n\r\n1.時間區間 (預設)\r\n    起~迄\r\n    請給小日歷輔以輸入\r\n2.歸戶後 [N] 天內可使用\r\n   [N] 為 TextInput\r\n   限輸入 1 ~ 999 數字\r\n0.系統自動取用\r\n");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("建立者");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("活動時間-迄 (含)迄日");

                entity.Property(e => e.LimitQuantity)
                    .HasDefaultValueSql("((1))")
                    .HasComment("限領張數");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(20)
                    .HasComment("修改者");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改時間");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("行銷名稱");

                entity.Property(e => e.OutputType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1.即時產出\r\n2.預先產出\r\n需要搭配 總數限量 欄位\r\n");

                entity.Property(e => e.ReceiveType).HasComment("歸戶方式\r\n1. 使用者手動領取/歸戶\r\n2. 使用者結帳後歸戶\r\n3. 系統(排程)自動歸戶\r\n");

                entity.Property(e => e.SendCondition).HasComment("發送條件\r\n1. 服務方案續訂訂單成立\r\n2. 商品訂單(盒內商品)結帳時\r\n3. 生日月為發送日當月");

                entity.Property(e => e.SendLimitType).HasComment("發送限制\r\n0. 無(預設)\r\n1. 活動區間內限領用１張\r\n2. 活動區間內每天限領用１張\r\n");

                entity.Property(e => e.SendTarget).HasComment("發送對象\r\n1. 全部會員 (預設)\r\n2+3\r\n2. 一般會員\r\n定義：僅有註冊身份，沒有有效訂閱方案\r\n3. 訂閱會員(季)\r\n定義：註冊會員+擁有有效訂閱方案\r\r\n4.\n指定會員\r\n");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasComment("活動時間-起");

                entity.Property(e => e.Type).HasComment("行銷設定類型\r\n1. 一般\r\n2. 專屬生日禮\r\n3. 升等會員購物禮\r\n4. 續訂禮\r\n5. 訂閱費折抵\r\n6. 滿件折");

                entity.Property(e => e.UseLimitType).HasComment("使用限制\r\n0. 無\r\n1. 第一張服務訂單成立\r\n2. 盒內商品數全滿(含加衣券)\r\n");
            });

            modelBuilder.Entity<MatchmakerCollection>(entity =>
            {
                entity.ToTable("MatchmakerCollection");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("搭配師簽名檔ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatchmakerId).HasComment("搭配師ID (ref: MatchmakerInfo.Id)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("候選商品");

                entity.HasOne(d => d.Matchmaker)
                    .WithMany(p => p.MatchmakerCollections)
                    .HasForeignKey(d => d.MatchmakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchmakerCollection");
            });

            modelBuilder.Entity<MatchmakerInfo>(entity =>
            {
                entity.ToTable("MatchmakerInfo");

                entity.HasComment("搭配師資料");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LikeStyle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("擅長風格");

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("名稱");

                entity.Property(e => e.PictureUrl).HasComment("照片URL");

                entity.Property(e => e.SelfIntroduction)
                    .IsRequired()
                    .HasComment("自介");

                entity.Property(e => e.SignatureUrl).HasComment("簽名檔URL(用逗號區隔多張圖片)");

                entity.Property(e => e.Slogan)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("口號");
            });

            modelBuilder.Entity<MatchmakerSignature>(entity =>
            {
                entity.ToTable("MatchmakerSignature");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("搭配師簽名檔ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatchmakerId).HasComment("搭配師ID (ref: MatchmakerInfo.Id)");

                entity.Property(e => e.SignImageUrl)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("簽名檔圖片路徑");

                entity.HasOne(d => d.Matchmaker)
                    .WithMany(p => p.MatchmakerSignatures)
                    .HasForeignKey(d => d.MatchmakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchmakerSignature");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK_OrderPayData")
                    .IsClustered(false);

                entity.ToTable("Order");

                entity.HasComment("訂單主檔");

                entity.HasIndex(e => e.IdOrder, "IX_Order_SeqNo")
                    .IsClustered();

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasComment("購物車ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("地址");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasDefaultValueSql("('')")
                    .HasComment("卡號末四碼");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasComment("城市");

                entity.Property(e => e.Country).HasComment("國別");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("建立者");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("幣別");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("帳號ID");

                entity.Property(e => e.DeliveryMethod).HasComment("寄送方式");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Order")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.InvDevice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("載具類型 (1 會員載具  2 手機條碼  3 自然人憑證)");

                entity.Property(e => e.InvDeviceCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("載具代碼");

                entity.Property(e => e.InvDonateCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("發票捐贈碼");

                entity.Property(e => e.InvDonateYn)
                    .HasColumnName("InvDonateYN")
                    .HasComment("發票捐贈");

                entity.Property(e => e.InvReceiver)
                    .HasMaxLength(20)
                    .HasComment("發票收件人");

                entity.Property(e => e.InvReceiverAddr)
                    .HasMaxLength(255)
                    .HasComment("發票收件人地址");

                entity.Property(e => e.InvReceiverTel)
                    .HasMaxLength(255)
                    .HasComment("發票收件人電話");

                entity.Property(e => e.InvTitle).HasMaxLength(50);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IP")
                    .HasComment("IP");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("電話");

                entity.Property(e => e.MobileEncrypt).HasComment("電話加密");

                entity.Property(e => e.OrderState).HasComment("狀態");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasComment("匯款時間(訂單時間)");

                entity.Property(e => e.OrderType).HasComment("訂單類型 (1:直購 2:BOX預約單 3:訂閱服務單)");

                entity.Property(e => e.OrdererName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("買家姓名");

                entity.Property(e => e.PayType).HasComment("支付方式ID");

                entity.Property(e => e.PaymentAmt)
                    .HasColumnType("money")
                    .HasComment("匯款金額");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("來源");

                entity.Property(e => e.PreOrder).HasComment("預購");

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("收件人姓名");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasComment("地區");

                entity.Property(e => e.Remark).HasComment("備註");

                entity.Property(e => e.ShippingRoute)
                    .HasMaxLength(30)
                    .HasComment("路線路順");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("通路");

                entity.Property(e => e.SourceTransactionNo)
                    .HasDefaultValueSql("(0x)")
                    .HasComment("Reservation.id    BOX預約單ID (等同訂單購物車ID)");

                entity.Property(e => e.StorePickupCode)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')")
                    .HasComment("門市店號");

                entity.Property(e => e.StorePickupName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("門市名稱");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Tax_ID_Number")
                    .HasComment("發票統編");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasComment("實際結帳金額");

                entity.Property(e => e.TransactionNo)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(('P'+format(getdate(),'yyyyMMdd'))+right(replicate('0',(7))+CONVERT([nvarchar],NEXT VALUE FOR [TransationNumSeq]),(7)))")
                    .IsFixedLength(true)
                    .HasComment("購物車單號(前端看得), 編碼原則: P(1) + 年月日(8) + 流水號(7) EX:P202001210123456");

                entity.Property(e => e.Verify).HasComment("已核帳");

                entity.Property(e => e.VerifyAuditor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("核帳人");

                entity.Property(e => e.VerifyRemark)
                    .IsRequired()
                    .HasComment("核帳備註");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasComment("郵遞區號");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("OrderItem");

                entity.HasComment("訂單");

                entity.HasIndex(e => e.IdOrderItem, "IX_OrderItem_SeqNo")
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID")
                    .HasComment("訂單明細ID(NONCLUSTERED)");

                entity.Property(e => e.CouponAmt).HasComment("未知");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Currency).HasComment("訂單幣別");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("帳號ID");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasComment("折扣金額");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasComment("未知");

                entity.Property(e => e.IdOrderItem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_OrderItem")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("異動時間");

                entity.Property(e => e.OrderDateTime)
                    .HasColumnType("datetime")
                    .HasComment("下單時間");

                entity.Property(e => e.OrderType).HasComment("訂單類型(一般,盒子,預購,贈品,運費)");

                entity.Property(e => e.ProductCost)
                    .HasColumnType("money")
                    .HasComment("商品成本價");

                entity.Property(e => e.ProductCostCurrency).HasComment("商品成本幣別");

                entity.Property(e => e.PromoId)
                    .HasColumnName("PromoID")
                    .HasDefaultValueSql("((-1))")
                    .HasComment("促銷活動編號");

                entity.Property(e => e.Quentity).HasComment("數量");

                entity.Property(e => e.RealCouponAmt).HasComment("未知");

                entity.Property(e => e.ReturnNo)
                    .HasMaxLength(50)
                    .HasComment("退貨便號");

                entity.Property(e => e.ReturnOrderState).HasComment("退貨訂單狀態");

                entity.Property(e => e.ReturnReasonType).HasComment("退貨原因");

                entity.Property(e => e.ReturnTime)
                    .HasColumnType("datetime")
                    .HasComment("退貨時間");

                entity.Property(e => e.SellingPrice)
                    .HasColumnType("money")
                    .HasComment("售價");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .HasComment("產品編號");

                entity.Property(e => e.SkuName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("SKU_Name")
                    .HasComment("產品名稱");

                entity.Property(e => e.State).HasComment("訂單狀態");

                entity.Property(e => e.Store)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("商店");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasComment("實際結帳金額");

                entity.Property(e => e.TrackingId)
                    .HasColumnName("TrackingID")
                    .HasComment("官網目錄項目ID(可能不要)");

                entity.Property(e => e.TransactionId).HasComment("購物車ID");

                entity.Property(e => e.Verifity).HasComment("訂單已核帳(已寄出)");
            });

            modelBuilder.Entity<OrderItemState>(entity =>
            {
                entity.ToTable("OrderItemState");

                entity.HasComment("訂單明細狀態");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("訂單明細狀態Id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("備註");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("狀態說明");
            });

            modelBuilder.Entity<OrderPayType>(entity =>
            {
                entity.ToTable("OrderPayType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("訂單支付方式ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderPayment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("OrderPayment");

                entity.HasComment("匯款資料");

                entity.HasIndex(e => e.IdOrderPayment, "IX_OrderPayment_SeqNo")
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("入帳資料ID");

                entity.Property(e => e.AuthorizationCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("授權碼");

                entity.Property(e => e.BankReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("銀行回傳碼");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Currency).HasComment("幣別");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("帳號ID");

                entity.Property(e => e.IdOrderPayment)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_OrderPayment")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.MerchantNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentAmt)
                    .HasColumnType("money")
                    .HasComment("金額");

                entity.Property(e => e.PaymentType).HasComment("類別");

                entity.Property(e => e.RealPayment)
                    .HasColumnType("money")
                    .HasComment("實際出貨日");

                entity.Property(e => e.State).HasComment("已入帳");

                entity.Property(e => e.TradeNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("交易編號");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasComment("交易時間");

                entity.Property(e => e.TransactionId).HasComment("購物車ID");

                entity.Property(e => e.Verify).HasComment("買家已確認");
            });

            modelBuilder.Entity<OrderRefund>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("OrderRefund");

                entity.HasComment("訂單退款");

                entity.HasIndex(e => e.IdOrderRefund, "IX_OrderRefund_SeqNo")
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("訂單退款資料ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasComment("退款金額(正數)");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("申請日期");

                entity.Property(e => e.Comment)
                    .IsUnicode(false)
                    .HasComment("備註");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("建立人");

                entity.Property(e => e.CreditBack).HasComment("刷退");

                entity.Property(e => e.CustomerId).HasComment("帳號");

                entity.Property(e => e.IdOrderRefund)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_OrderRefund")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.OrderPaymentType).HasComment("入帳類別");

                entity.Property(e => e.RealAmount)
                    .HasColumnType("money")
                    .HasComment("實際退款金額(正數)");

                entity.Property(e => e.RefundDate)
                    .HasColumnType("date")
                    .HasComment("退款日期(匯款日期)");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasComment("");

                entity.Property(e => e.TransactionId).HasComment("購物車ID");

                entity.Property(e => e.Type).HasComment("訂單退款類別");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("更新人");

                entity.Property(e => e.UserApply).HasComment("使用者申請");
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.ToTable("OrderState");

                entity.HasComment("訂單狀態");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("訂單狀態Id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("備註");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("狀態說明");
            });

            modelBuilder.Entity<PageFrame>(entity =>
            {
                entity.ToTable("PageFrame");

                entity.HasComment("版面區塊");

                entity.HasIndex(e => new { e.Sort, e.FrameType, e.StartDate, e.CreatedDate }, "IX_PageFrame")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FrameType).HasComment("1圖片 2訂閱方案 3商品 4搭配顧問");

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PageFrameContent>(entity =>
            {
                entity.ToTable("PageFrameContent");

                entity.HasComment("版面區塊內容");

                entity.HasIndex(e => new { e.PageFrameId, e.Sort, e.CreatedDate }, "IX_PageFrameContent");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.RelatedId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sort).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductFavorite>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.Series, e.Color });

                entity.HasComment("產品收藏");

                entity.Property(e => e.Series)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Color).HasMaxLength(10);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => new { e.Series, e.Type, e.Sort, e.Color })
                    .HasName("PK_ProductColorImage");

                entity.ToTable("ProductImage");

                entity.HasComment("產品圖片");

                entity.Property(e => e.Series)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasComment("1:商品色塊圖 2:商品色塊主圖 3:商品內文主圖 4:商品內文圖");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('System')");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Image File')");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductScore>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.Sku })
                    .HasName("PK_MyLikes");

                entity.ToTable("ProductScore");

                entity.HasComment("產品評分");

                entity.Property(e => e.Sku)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductSeries>(entity =>
            {
                entity.HasKey(e => e.Series)
                    .HasName("PK_Product");

                entity.HasComment("產品系列");

                entity.HasIndex(e => new { e.ProductSeriesCategoryId, e.VendorType, e.Enable }, "IX_ProductSeries");

                entity.Property(e => e.Series)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("主要系列編號");

                entity.Property(e => e.Accessories)
                    .HasMaxLength(30)
                    .HasComment("詳情 配件");

                entity.Property(e => e.Attention)
                    .IsRequired()
                    .HasDefaultValueSql("('')")
                    .HasComment("注意事項");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("品牌布標");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .HasComment("詳情 色系");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasComment("商品描述");

                entity.Property(e => e.Enable).HasComment("啟用");

                entity.Property(e => e.FirstSellDate)
                    .HasColumnType("date")
                    .HasComment("首次上架");

                entity.Property(e => e.Material).HasComment("詳情 材質");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("異動時間");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("系列名稱");

                entity.Property(e => e.Origin)
                    .HasMaxLength(50)
                    .HasComment("詳情 產地");

                entity.Property(e => e.OverseasDeliverya).HasComment("海外配送");

                entity.Property(e => e.PriceMax).HasComment("單價區間(大)");

                entity.Property(e => e.PriceMin).HasComment("單價區間(小)");

                entity.Property(e => e.VendorType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("廠商");
            });

            modelBuilder.Entity<ProductSeriesCategory>(entity =>
            {
                entity.ToTable("ProductSeriesCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ProductSizeReport>(entity =>
            {
                entity.HasKey(e => new { e.Series, e.Size })
                    .HasName("PK_ProductTryReport");

                entity.ToTable("ProductSizeReport");

                entity.HasComment("產品尺寸表");

                entity.Property(e => e.Series).HasMaxLength(30);

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.AbdominalCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("腹圍");

                entity.Property(e => e.ArmCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("袖圍");

                entity.Property(e => e.ArmholeCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("袖口圍");

                entity.Property(e => e.ArmpitCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("腋圍");

                entity.Property(e => e.Bust)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("胸圍");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crotch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("褲檔");

                entity.Property(e => e.FitSizeMax).HasMaxLength(10);

                entity.Property(e => e.FitSizeMin).HasMaxLength(10);

                entity.Property(e => e.FullLength)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("全長");

                entity.Property(e => e.HeelHigh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("鞋跟高");

                entity.Property(e => e.Hem)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("下擺");

                entity.Property(e => e.HipCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("臀圍");

                entity.Property(e => e.ShoulderWidth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("肩寬");

                entity.Property(e => e.Sleeve)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')")
                    .HasComment("肩袖長");

                entity.Property(e => e.SleeveLength)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("袖長");

                entity.Property(e => e.ThighCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("大腿圍");

                entity.Property(e => e.TrouserWidth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("褲管寬");

                entity.Property(e => e.TryDescription)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TubeCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("筒圍");

                entity.Property(e => e.TubeLength)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("筒長");

                entity.Property(e => e.UnderBust)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("下胸圍");

                entity.Property(e => e.UpperBust)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("上胸圍");

                entity.Property(e => e.WaistCircumference)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')")
                    .HasComment("腰圍");
            });

            modelBuilder.Entity<ProductSku>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK_ProductSKU_1");

                entity.ToTable("ProductSKU");

                entity.HasComment("產品SKU");

                entity.Property(e => e.Sku)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .HasComment("產品編號");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("顏色");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Enable).HasComment("啟用");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("異動時間");

                entity.Property(e => e.PreStock).HasComment("預購庫存");

                entity.Property(e => e.SellingPrice).HasComment("單價");

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("主系列編號");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("尺寸");

                entity.Property(e => e.Stock).HasComment("庫存");

                entity.Property(e => e.SubSeries)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("子系列編號");

                entity.Property(e => e.Volume).HasDefaultValueSql("((20))");

                entity.Property(e => e.Weight)
                    .HasColumnType("numeric(18, 3)")
                    .HasComment("重量");
            });

            modelBuilder.Entity<ProductTagToSeries>(entity =>
            {
                entity.HasKey(e => new { e.SeriesNo, e.Type, e.GroupKey, e.TagCode });

                entity.HasIndex(e => e.SeriesNo, "ix_ProductTagToSeries");

                entity.HasIndex(e => e.TagCode, "ix_ProductTagToSeries2");

                entity.Property(e => e.SeriesNo).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroupKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductTryReport>(entity =>
            {
                entity.HasKey(e => new { e.Series, e.ModelId })
                    .HasName("PK_ProductTryReport_1");

                entity.ToTable("ProductTryReport");

                entity.HasComment("產品試穿報告");

                entity.Property(e => e.Series)
                    .HasMaxLength(30)
                    .HasComment("系列");

                entity.Property(e => e.ModelId).HasComment("ModelID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LowerBodySize)
                    .HasMaxLength(10)
                    .HasComment("下身尺寸");

                entity.Property(e => e.ModelBustWidth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("胸圍");

                entity.Property(e => e.ModelHeight)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("身高");

                entity.Property(e => e.ModelHipWidth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("臀圍");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("名");

                entity.Property(e => e.ModelWaistWidth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("腰圍");

                entity.Property(e => e.ModelWeight)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("體重");

                entity.Property(e => e.SizeMetrology)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("尺寸測量");

                entity.Property(e => e.TryReport)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("試穿結果");

                entity.Property(e => e.UpperBodySize)
                    .HasMaxLength(10)
                    .HasComment("上身尺寸");
            });

            modelBuilder.Entity<Qa>(entity =>
            {
                entity.ToTable("QA");

                entity.HasIndex(e => new { e.CustomerId, e.Catelog }, "IX_QA");

                entity.HasIndex(e => e.SyncGuid, "IX_QA_SyncGuid")
                    .IsUnique();

                entity.Property(e => e.Answer)
                    .HasDefaultValueSql("('')")
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.AnswerDate).HasColumnType("datetime");

                entity.Property(e => e.Answerer)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.Catelog)
                    .HasDefaultValueSql("('')")
                    .HasComment("1: 出貨相關\r\n2: 訂單相關\r\n3: 退貨/退款相關\r\n4: 紅包/熊幣相關\r\n5: 商品諮詢\r\n6: 發票相關\r\n7: 活動諮詢\r\n8: 其它");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.QuestionDate).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.SyncGuid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<QaCatelog>(entity =>
            {
                entity.ToTable("QA_Catelog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .UseCollation("Chinese_Taiwan_Stroke_90_CI_AI");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.HasIndex(e => e.BoxNo, "IX_Reservation_BoxNo")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("BOX預約單ID (等同訂單購物車ID)");

                entity.Property(e => e.AddPurchase).HasComment("是否加購");

                entity.Property(e => e.AllowanceAgree).HasComment("折讓授權");

                entity.Property(e => e.BoxNo)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(('B'+format(getdate(),'yyyyMMdd'))+right(replicate('0',(7))+CONVERT([nvarchar],NEXT VALUE FOR [SysNumSeq]),(7)))")
                    .IsFixedLength(true)
                    .HasComment("BOX訂閱盒編號(唯一), 編碼原則: B(1) + 年月日(8) + 流水號(7) EX:S202001210123456");

                entity.Property(e => e.BoxType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("BOX訂閱盒類型(1:一般 2:加購盒)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasComment("會員ID");

                entity.Property(e => e.DeliveryExpected)
                    .HasColumnType("date")
                    .HasComment("期望配送日期");

                entity.Property(e => e.DeliveryMethod).HasComment("配送方式");

                entity.Property(e => e.FlowState).HasComment("編輯流程狀態 (0:待編輯 1:商品搭配 2:商品組合貼標 4:卡片製作)");

                entity.Property(e => e.InvDevice)
                    .HasDefaultValueSql("((1))")
                    .HasComment("載具類型");

                entity.Property(e => e.InvDeviceCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("載具代碼");

                entity.Property(e => e.InvDonateCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("發票捐贈碼");

                entity.Property(e => e.MatchmakerId).HasComment("搭配師");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreviewDueDate)
                    .HasColumnType("datetime")
                    .HasComment("待預覽期限");

                entity.Property(e => e.State).HasComment("預約單流程狀態(ref. ReservationState)");

                entity.Property(e => e.SubscribeId).HasComment("訂閱服務訂單ID");

                entity.Property(e => e.TaxIdNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Tax_ID_Number")
                    .HasDefaultValueSql("('')")
                    .HasComment("發票統編");
            });

            modelBuilder.Entity<ReservationCard>(entity =>
            {
                entity.ToTable("ReservationCard");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("卡片製作ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intro)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("問候語(介紹)");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReservationId).HasComment("BOX預約單ID (ref: Reservation)");

                entity.Property(e => e.SignatureUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("簽名檔");

                entity.Property(e => e.Template).HasComment("版型類別");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationCards)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationCard");
            });

            modelBuilder.Entity<ReservationCardMessage>(entity =>
            {
                entity.ToTable("ReservationCardMessage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("卡片搭配文案ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("文案說明");

                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("訊息清單類型");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("名稱");
            });

            modelBuilder.Entity<ReservationCustomer>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.ToTable("ReservationCustomer");

                entity.Property(e => e.ReservationId)
                    .ValueGeneratedNever()
                    .HasComment("BOX預約單ID(ref. Reservation Table)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("預約人員電話");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("預約人員名稱");

                entity.HasOne(d => d.Reservation)
                    .WithOne(p => p.ReservationCustomer)
                    .HasForeignKey<ReservationCustomer>(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationCustomer");
            });

            modelBuilder.Entity<ReservationFeedback>(entity =>
            {
                entity.ToTable("ReservationFeedback");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reason).HasComment("不喜歡原因");

                entity.Property(e => e.ReservationId).HasComment("BOX ID");

                entity.Property(e => e.ReservationLineItemId).HasComment("BOX明細ID");

                entity.HasOne(d => d.ReservationLineItem)
                    .WithMany(p => p.ReservationFeedbacks)
                    .HasForeignKey(d => d.ReservationLineItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationFeedback");
            });

            modelBuilder.Entity<ReservationFlowStateLog>(entity =>
            {
                entity.ToTable("ReservationFlowStateLog");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlowState).HasComment("BOX預約單流程狀態");

                entity.Property(e => e.ReservationId).HasComment("BOX預約單ID");
            });

            modelBuilder.Entity<ReservationLineItem>(entity =>
            {
                entity.ToTable("ReservationLineItem");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("BOX預約單明細ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("會員問卷紀錄的Sku");

                entity.Property(e => e.DislikeFeedback).HasComment("不喜好商品(Y/N)");

                entity.Property(e => e.DislikeReason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("不喜好商品原因(ref. DislikeFeedbackReason Table)");

                entity.Property(e => e.GroupId).HasComment("BOX預約單商品組合ID (ref. ReservationLineItemGroup Table)");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position).HasDefaultValueSql("((1))");

                entity.Property(e => e.ReservationId).HasComment("BOX預約單ID (ref. Reservation Table)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("商品編號(ProductSKU.SKU)");

                entity.Property(e => e.Source)
                    .HasDefaultValueSql("((1))")
                    .HasComment("建立來源(1:APP 2:收藏清單 3:猜你喜歡 4:客人不喜歡 5:搭配師自選)");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("((1))")
                    .HasComment("狀態 1:一般 2:刪除");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ReservationLineItems)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationLineItem2");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationLineItems)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationLineItem1");
            });

            modelBuilder.Entity<ReservationLineItemGroup>(entity =>
            {
                entity.ToTable("ReservationLineItemGroup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("BOX預約單明細ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatchingMessage)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("搭配文案描述");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OccasionId).HasComment("情境場合ID (ref: StyleBookCondition)");

                entity.Property(e => e.ReservationId).HasComment("BOX預約單ID (ref. Reservation Table)");

                entity.Property(e => e.SortNum).HasComment("排序");

                entity.Property(e => e.StyleId).HasComment("風格分類ID (ref: StyleBookCondition)");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationLineItemGroups)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationLineItemGroup");
            });

            modelBuilder.Entity<ReservationRecipient>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.ToTable("ReservationRecipient");

                entity.Property(e => e.ReservationId)
                    .ValueGeneratedNever()
                    .HasComment("BOX預約單ID(ref. Reservation Table)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')")
                    .HasComment("地址");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("城市");

                entity.Property(e => e.Country).HasComment("國別");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("電話國碼(ex:886)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("收件人電話");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("收件人名稱");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("第區");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("收件人電話");

                entity.HasOne(d => d.Reservation)
                    .WithOne(p => p.ReservationRecipient)
                    .HasForeignKey<ReservationRecipient>(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationRecipient");
            });

            modelBuilder.Entity<ReservationState>(entity =>
            {
                entity.ToTable("ReservationState");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.HasComment("退貨");

                entity.HasIndex(e => e.IdReturns, "IX_Returns_SeqNo")
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("退貨檔ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasComment("退貨申請時間");

                entity.Property(e => e.IdReturns)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Returns")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.RtnDate)
                    .HasColumnType("datetime")
                    .HasComment("退貨完成時間");

                entity.Property(e => e.RtnNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("退貨便號");

                entity.Property(e => e.TransactionId).HasComment("購物車ID");
            });

            modelBuilder.Entity<ReturnsItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("ReturnsItem");

                entity.HasComment("退貨");

                entity.HasIndex(e => e.IdReturnsItem, "IX_ReturnsItem_SeqNo")
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("自動流水號");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.IdReturnsItem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_ReturnsItem")
                    .HasComment("系統流水號(CLUSTERED)");

                entity.Property(e => e.OrderItemId).HasComment("訂單明細ID");

                entity.Property(e => e.ReturnsId).HasComment("退貨主檔ID");

                entity.Property(e => e.State).HasComment("退貨處理狀態");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolesPermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Roles_Permissions");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RolePermissionId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(e => e.ShipmentId)
                    .IsClustered(false);

                entity.ToTable("Shipment");

                entity.HasComment("出貨資料");

                entity.HasIndex(e => e.IdShipment, "IX_Shipment_SeqNo")
                    .IsClustered();

                entity.Property(e => e.ShipmentId)
                    .ValueGeneratedNever()
                    .HasComment("出貨資料主檔ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("地址");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasComment("城市");

                entity.Property(e => e.Country).HasComment("國別");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("帳號ID");

                entity.Property(e => e.DeliveryMethod).HasComment("寄送方式");

                entity.Property(e => e.IdShipment)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Shipment")
                    .HasComment("自動流水號");

                entity.Property(e => e.InvAmt)
                    .HasColumnType("money")
                    .HasComment("發票金額");

                entity.Property(e => e.InvDate)
                    .HasColumnType("smalldatetime")
                    .HasComment("發票日期");

                entity.Property(e => e.Invoice).HasComment("開立發票");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("電話");

                entity.Property(e => e.MobileEncrypt).HasComment("電話加密");

                entity.Property(e => e.OrdererName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("買家姓名");

                entity.Property(e => e.Payment).HasComment("已付款");

                entity.Property(e => e.RealShipDate)
                    .HasColumnType("date")
                    .HasComment("實際出貨日");

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("收件人姓名");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasComment("地區");

                entity.Property(e => e.Remark).HasComment("備註");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("date")
                    .HasComment("出貨日期");

                entity.Property(e => e.ShippingNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("寄貨號碼");

                entity.Property(e => e.ShippingRoute)
                    .HasMaxLength(30)
                    .HasComment("路線路順");

                entity.Property(e => e.StorePickupCode)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')")
                    .HasComment("門市店號");

                entity.Property(e => e.StorePickupName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("門市名稱");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Tax_ID_Number")
                    .HasComment("發票統編");

                entity.Property(e => e.TransactionId).HasComment("購物車ID");

                entity.Property(e => e.Verify).HasComment("驗貨");

                entity.Property(e => e.VerifyAuditor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("核帳人");

                entity.Property(e => e.VerifyDate)
                    .HasColumnType("smalldatetime")
                    .HasComment("驗貨時間");

                entity.Property(e => e.Weight).HasComment("重量");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasComment("郵遞區號");
            });

            modelBuilder.Entity<ShipmentOrderItem>(entity =>
            {
                entity.ToTable("ShipmentOrderItem");

                entity.HasComment("出貨訂單勾稽");

                entity.HasIndex(e => e.OrderItemId, "IX_ShipmentOrderItem_OrderItemId");

                entity.HasIndex(e => e.ShipmentId, "IX_ShipmentOrderItem_ShipmentId");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newsequentialid())")
                    .HasComment("出貨訂單明細Id(自動流水號)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderItemId).HasComment("訂單明細ID");

                entity.Property(e => e.ShipmentId).HasComment("出貨資料主檔ID");
            });

            modelBuilder.Entity<SmsMessageDatum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasComment("簡訊內容");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立日期");

                entity.Property(e => e.Encrypted)
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否加密");

                entity.Property(e => e.Manufacture)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("廠商");

                entity.Property(e => e.MessageTokenId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("回傳的TokenId, 用來查詢發送結果");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("電話號碼");

                entity.Property(e => e.Priority).HasComment("發送優先順序 0:最高 9:最低");

                entity.Property(e => e.Send).HasComment("已寄送");

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasComment("排程發送時間");

                entity.Property(e => e.Sender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("簡訊類別");

                entity.Property(e => e.Status).HasComment("等待執行=0, 執行中=1, 已執行=2 ,執行失敗=3");
            });

            modelBuilder.Entity<SmsMessageResult>(entity =>
            {
                entity.ToTable("SmsMessageResult");

                entity.Property(e => e.CompleteDate)
                    .HasColumnType("datetime")
                    .HasComment("發送完成時間");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MsgStatusCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("狀態碼, 參考MarketigCloud狀態或其他家的");

                entity.Property(e => e.Result)
                    .IsUnicode(false)
                    .HasComment("備註");

                entity.Property(e => e.Status).HasComment("0:待更新 1:回報發送成功 2:回報發送失敗");

                entity.HasOne(d => d.SmsMessageData)
                    .WithMany(p => p.SmsMessageResults)
                    .HasForeignKey(d => d.SmsMessageDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SmsMessageResult");
            });

            modelBuilder.Entity<StyleBook>(entity =>
            {
                entity.ToTable("StyleBook");

                entity.HasComment("穿搭資料");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("StyleBook Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('System')")
                    .HasComment("建立者");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasComment("Style主圖");

                entity.Property(e => e.MatchmakerInfoId).HasComment("搭配師Id");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(20)
                    .HasComment("修改者");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改時間");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("風格名稱");

                entity.Property(e => e.OccasionId).HasComment("場合的Id, 關聯至StyleBookCondition.Id & StyleBookCondition.Type = 2");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.Property(e => e.State).HasComment("0 Disable 1 Enable");

                entity.Property(e => e.StyleId).HasComment("風格的Id, 關聯至StyleBookCondition.Id & StyleBookCondition.Type = 1");
            });

            modelBuilder.Entity<StyleBookCondition>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Sort, e.Id });

                entity.ToTable("StyleBookCondition");

                entity.HasComment("穿搭分類(過濾條件)");

                entity.Property(e => e.Type).HasComment("篩選器類型 1風格 2場合");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("篩選器條件Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("篩選條件的名稱");
            });

            modelBuilder.Entity<StyleBookDetail>(entity =>
            {
                entity.ToTable("StyleBookDetail");

                entity.HasComment("穿搭明細");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Id");

                entity.Property(e => e.CatelogName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("分類名稱");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("產品色");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('System')")
                    .HasComment("建立者");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasComment("Series Color主圖");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(20)
                    .HasComment("修改者");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改日期");

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("系列");

                entity.Property(e => e.StyleBookId).HasComment("StyleBookId.Id");

                entity.HasOne(d => d.StyleBook)
                    .WithMany(p => p.StyleBookDetails)
                    .HasForeignKey(d => d.StyleBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StyleBookDetail");
            });

            modelBuilder.Entity<StyleFavorite>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.StyleBookId })
                    .HasName("PK_DressingFavorites");

                entity.HasComment("穿搭收藏");

                entity.Property(e => e.CustomerId).HasComment("會員Id");

                entity.Property(e => e.StyleBookId).HasComment("StyleBookId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.ToTable("Subscribe");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("訂閱服務Id (等同訂單購物車ID)");

                entity.Property(e => e.AutoRenew)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("自動續約");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasComment("會員ID");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasComment("訂閱結束時間 (目前提供季卡,一季3個月,每個月以30天計算,共計90天,付款成功當天起算第1天)");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasComment("訂閱狀態 (ref: SubscribeState)");

                entity.Property(e => e.SubscribeNo)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(('S'+format(getdate(),'yyyyMMdd'))+right(replicate('0',(7))+CONVERT([nvarchar],NEXT VALUE FOR [SysNumSeq]),(7)))")
                    .IsFixedLength(true)
                    .HasComment("訂閱服務編號, 編碼原則: S(1) + 年月日(8) + 流水號(7) EX:S202001210123456");

                entity.Property(e => e.SubscriptionPlanId).HasComment("訂閱方案編號");
            });

            modelBuilder.Entity<SubscribeState>(entity =>
            {
                entity.ToTable("SubscribeState");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubscribeSuspendLog>(entity =>
            {
                entity.ToTable("SubscribeSuspendLog");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasComment("會員ID");

                entity.Property(e => e.SubscribeId).HasComment("訂閱服務訂單ID");

                entity.Property(e => e.SuspendState).HasComment("狀態 (1:申請暫停 2:申請恢復)");
            });

            modelBuilder.Entity<SubscriptionPlanInfo>(entity =>
            {
                entity.ToTable("SubscriptionPlanInfo");

                entity.HasComment("訂閱方案");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Modifier).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PictureUrl).IsRequired();

                entity.Property(e => e.ProductDescrption).HasComment("說明文案");

                entity.Property(e => e.SellingPrice).HasComment("售價                             ");

                entity.Property(e => e.SetPrice).HasComment("訂價");

                entity.Property(e => e.Type)
                    .HasDefaultValueSql("((1))")
                    .HasComment("訂閱類型(季,月,年)");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('System')")
                    .HasComment("建立者");

                entity.Property(e => e.Enable).HasComment("啟用/停用");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(20)
                    .HasComment("修改者");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改時間");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SurveyAnswer>(entity =>
            {
                entity.HasKey(e => new { e.SurveyId, e.TopicNo1, e.TopicNo2, e.TopicNo3, e.CustomerId });

                entity.ToTable("SurveyAnswer");

                entity.Property(e => e.TopicNo1)
                    .HasMaxLength(10)
                    .HasComment("1階題號");

                entity.Property(e => e.TopicNo2)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("2階題號");

                entity.Property(e => e.TopicNo3)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("3階題號");

                entity.Property(e => e.CustomerId).HasComment("會員Id");

                entity.Property(e => e.Answer).HasComment("答案, 複選用 | 隔開");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建立時間");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('System')")
                    .HasComment("建立者");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(20)
                    .HasComment("修改者");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改時間");

                entity.Property(e => e.SurveyReplyId).HasComment("訂閱/盒子問卷回覆ID");
            });

            modelBuilder.Entity<SurveyReply>(entity =>
            {
                entity.ToTable("SurveyReply");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourceId).HasComment("訂閱/盒子ID");

                entity.Property(e => e.SourceType).HasComment("類型: 1=盒子 2=訂閱");

                entity.Property(e => e.SurveyReplyId).HasComment("問卷回覆ID");
            });

            modelBuilder.Entity<SurveyTitle>(entity =>
            {
                entity.ToTable("SurveyTitle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsMapping).HasComment("對應");

                entity.Property(e => e.No).HasComment("題號");

                entity.Property(e => e.NoName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("題號說明");

                entity.Property(e => e.SubNo)
                    .HasMaxLength(50)
                    .HasComment("子題號");

                entity.Property(e => e.SubNoName)
                    .HasMaxLength(20)
                    .HasComment("子題號說明");

                entity.Property(e => e.SurveyId)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("問卷ID");

                entity.Property(e => e.SurveyType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("問卷名稱");
            });

            modelBuilder.Entity<SurveyTitleMapping>(entity =>
            {
                entity.ToTable("SurveyTitleMapping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer)
                    .HasMaxLength(10)
                    .HasComment("答案代號");

                entity.Property(e => e.AnswerName)
                    .HasMaxLength(30)
                    .HasComment("答案說明");

                entity.Property(e => e.No).HasComment("題號");

                entity.Property(e => e.SubNo)
                    .HasMaxLength(50)
                    .HasComment("子題號");

                entity.Property(e => e.SurveyId)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("問卷ID");

                entity.Property(e => e.SurveyType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("問卷名稱");
            });

            modelBuilder.Entity<TakeCp>(entity =>
            {
                entity.HasKey(e => new { e.MarketingActivitiesId, e.Mobile });

                entity.ToTable("TakeCP");

                entity.Property(e => e.MarketingActivitiesId).HasComment("活動Id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("手機");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Email");

                entity.Property(e => e.SpecialCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("領取的優惠碼");
            });

            modelBuilder.Entity<Temp產品>(entity =>
            {
                entity.HasKey(e => e.Series);

                entity.ToTable("Temp_產品");

                entity.Property(e => e.Series).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("AD或mail");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_Roles");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VersionInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VersionInfo");

                entity.HasComment("裝置更新版本資料表");

                entity.Property(e => e.Android)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Android版本資訊");

                entity.Property(e => e.AndroidTimeStamp)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Android版本更新時間戳記(由觸發程序更新)");

                entity.Property(e => e.IOs)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("iOS")
                    .HasComment("iOS版本資訊");

                entity.Property(e => e.IOstimeStamp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("iOSTimeStamp")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("iOS版本更新時間戳記(由觸發程序更新)");
            });

            modelBuilder.HasSequence<int>("CouponNumSeq").HasMin(1);

            modelBuilder.HasSequence<int>("CustomerNumSeq")
                .HasMin(1)
                .HasMax(99999999)
                .IsCyclic();

            modelBuilder.HasSequence<int>("SysNumSeq")
                .HasMin(1)
                .HasMax(9999999)
                .IsCyclic();

            modelBuilder.HasSequence("TransationNumSeq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
