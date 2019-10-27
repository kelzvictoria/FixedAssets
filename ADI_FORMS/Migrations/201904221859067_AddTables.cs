namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetMaintenanceIntervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetsDetailReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        SortById = c.Int(nullable: false),
                        FixedAsset_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAsset_Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.SortBies", t => t.SortById, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId)
                .Index(t => t.FixedAsset_Id)
                .Index(t => t.LocationId)
                .Index(t => t.SortById);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RCNumber = c.String(),
                        TaxReference = c.String(),
                        NPSCode = c.String(),
                        CurrentYear = c.Int(nullable: false),
                        CurrentMonth = c.Int(nullable: false),
                        BudgetedStaff = c.Int(nullable: false),
                        BudgetedSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnionDuePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnionDueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MidMonthPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AnnualLeavePay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MidMonthAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LargeCompanyName = c.String(),
                        GradeId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FixedAssets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        StaffAssigned = c.String(),
                        InitialCost = c.Decimal(precision: 18, scale: 2),
                        AssetStatusId = c.Int(nullable: false),
                        SerialNo = c.Long(),
                        PurchasesOrderNo = c.Long(),
                        Model = c.String(),
                        PurchaseRecptNo = c.Long(nullable: false),
                        VendorId = c.Int(nullable: false),
                        YearOfManufacture = c.Int(nullable: false),
                        PurchasedDate = c.DateTime(nullable: false),
                        AssetAccountNo = c.Long(nullable: false),
                        EngineNo = c.Long(),
                        ClassicNo = c.Long(),
                        AssetMaintenanceIntervalId = c.Int(nullable: false),
                        MaintenanceFigure = c.Int(),
                        PresentValue = c.Decimal(precision: 18, scale: 2),
                        DateRegistered = c.DateTime(nullable: false),
                        LastValuationDate = c.DateTime(),
                        DepreciationInterval = c.String(),
                        LifeSpan = c.Int(),
                        LastDeprMonth = c.DateTime(),
                        LastDeprYear = c.DateTime(),
                        Residual = c.Decimal(precision: 18, scale: 2),
                        AnnualDeprAmount = c.Decimal(precision: 18, scale: 2),
                        DepreciationRate = c.Decimal(precision: 18, scale: 2),
                        LastDeprDate = c.DateTime(),
                        LastDeprAmt = c.Decimal(precision: 18, scale: 2),
                        DeprYTD = c.Decimal(precision: 18, scale: 2),
                        DeprToDate = c.Decimal(precision: 18, scale: 2),
                        GLDebitAcc = c.Int(),
                        GLCreditAcc = c.Int(),
                        DeprMethod = c.String(),
                        DeprCommenced = c.DateTime(),
                        DeprEndDate = c.DateTime(),
                        CurrentYear = c.DateTime(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetMaintenanceIntervals", t => t.AssetMaintenanceIntervalId, cascadeDelete: true)
                .ForeignKey("dbo.AssetStatus", t => t.AssetStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.AssetMaintenanceIntervalId)
                .Index(t => t.AssetStatusId)
                .Index(t => t.BranchId)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId)
                .Index(t => t.LocationId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.AssetStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        ContactPerson = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                        OrderPending = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastOrder = c.DateTime(nullable: false),
                        OrderYearToDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StateId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SortBies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetsDisposalDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        DisposalDate = c.DateTime(nullable: false),
                        DisposedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        Recipient = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.FixedAssetId);

            CreateTable(
                "dbo.AssetsInspectionDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FixedAssetId = c.Int(nullable: false),
                    InspectionDate = c.DateTime(nullable: false),
                    InspectedBy = c.String(),
                    AssetStatusId = c.Int(nullable: false),
                    Remarks = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetStatus", t => t.AssetStatusId, cascadeDelete: true)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: false)
                .Index(t => t.AssetStatusId)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.AssetsInsuranceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        PeriodFrom = c.DateTime(),
                        PeriodTo = c.DateTime(),
                        InsuranceCompany = c.String(),
                        Address = c.String(),
                        InsuredValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsurancePremium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PremiumToDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateFirstInsured = c.DateTime(nullable: false),
                        PremiumPayable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interval = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        DatePaid = c.DateTime(nullable: false),
                        PayMode = c.String(),
                        PolicyNo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.AssetsMaintenanceCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetsMaintenanceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        MaintenanceSupervisor = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maint_Description = c.String(),
                        GLDebit = c.Long(),
                        GLCredit = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.AssetsTransferDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        NewLocation = c.String(),
                        NewCompany = c.String(),
                        NewBranch = c.String(),
                        TransferDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.AssetsValuationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        DepreciationMTDId = c.Int(nullable: false),
                        LifeSpan = c.Int(),
                        LastValDate = c.DateTime(),
                        Eff_Date = c.DateTime(nullable: false),
                        NewDeprMethod = c.String(),
                        NewLifeSpan = c.Int(nullable: false),
                        NewResidual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewDeprStartDate = c.DateTime(nullable: false),
                        NewDeprRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstSalesValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewDeprToDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewDeprYearToDate = c.Int(nullable: false),
                        NewDeprAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepreciationMTDs", t => t.DepreciationMTDId, cascadeDelete: true)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.DepreciationMTDId)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.DepreciationMTDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetUsageLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixedAssetId = c.Int(nullable: false),
                        Trans_Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Destination = c.String(),
                        StaffIdentification = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssetId, cascadeDelete: true)
                .Index(t => t.FixedAssetId);
            
            CreateTable(
                "dbo.EndOfMonths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthsId = c.Int(nullable: false),
                        FinancialYear = c.Int(nullable: false),
                        FinancialPeriod = c.String(),
                        NewAssets = c.Int(nullable: false),
                        Revaluation = c.Int(nullable: false),
                        Insurance = c.Int(nullable: false),
                        Inspections = c.Int(nullable: false),
                        Transfers = c.Int(nullable: false),
                        Disposals = c.Int(nullable: false),
                        Renewals = c.Int(nullable: false),
                        CummB_S = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PL_Acc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UpdateAccum = c.Boolean(nullable: false),
                        RecordScan = c.Int(nullable: false),
                        Information = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Months", t => t.MonthsId, cascadeDelete: true)
                .Index(t => t.MonthsId);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EndOfYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthsId = c.Int(nullable: false),
                        FinancialYear = c.Int(nullable: false),
                        FinancialPeriod = c.String(),
                        File = c.String(),
                        RecordNo = c.Int(nullable: false),
                        NoOfRecords = c.Int(nullable: false),
                        Information = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Months", t => t.MonthsId, cascadeDelete: true)
                .Index(t => t.MonthsId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EndOfYears", "MonthsId", "dbo.Months");
            DropForeignKey("dbo.EndOfMonths", "MonthsId", "dbo.Months");
            DropForeignKey("dbo.AssetUsageLogs", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsValuationDetails", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsValuationDetails", "DepreciationMTDId", "dbo.DepreciationMTDs");
            DropForeignKey("dbo.AssetsTransferDatas", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsMaintenanceDetails", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsInsuranceDetails", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsInspectionDetails", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsInspectionDetails", "AssetStatusId", "dbo.AssetStatus");
            DropForeignKey("dbo.AssetsDisposalDatas", "FixedAssetId", "dbo.FixedAssets");
            DropForeignKey("dbo.AssetsDetailReports", "SortById", "dbo.SortBies");
            DropForeignKey("dbo.AssetsDetailReports", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.AssetsDetailReports", "FixedAsset_Id", "dbo.FixedAssets");
            DropForeignKey("dbo.FixedAssets", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "StateId", "dbo.States");
            DropForeignKey("dbo.Vendors", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.FixedAssets", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.FixedAssets", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.FixedAssets", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FixedAssets", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.FixedAssets", "AssetStatusId", "dbo.AssetStatus");
            DropForeignKey("dbo.FixedAssets", "AssetMaintenanceIntervalId", "dbo.AssetMaintenanceIntervals");
            DropForeignKey("dbo.AssetsDetailReports", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Companies", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AssetsDetailReports", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AssetsDetailReports", "BranchId", "dbo.Branches");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.EndOfYears", new[] { "MonthsId" });
            DropIndex("dbo.EndOfMonths", new[] { "MonthsId" });
            DropIndex("dbo.AssetUsageLogs", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsValuationDetails", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsValuationDetails", new[] { "DepreciationMTDId" });
            DropIndex("dbo.AssetsTransferDatas", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsMaintenanceDetails", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsInsuranceDetails", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsInspectionDetails", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsInspectionDetails", new[] { "AssetStatusId" });
            DropIndex("dbo.AssetsDisposalDatas", new[] { "FixedAssetId" });
            DropIndex("dbo.AssetsDetailReports", new[] { "SortById" });
            DropIndex("dbo.AssetsDetailReports", new[] { "LocationId" });
            DropIndex("dbo.AssetsDetailReports", new[] { "FixedAsset_Id" });
            DropIndex("dbo.FixedAssets", new[] { "VendorId" });
            DropIndex("dbo.Vendors", new[] { "StateId" });
            DropIndex("dbo.Vendors", new[] { "CountryId" });
            DropIndex("dbo.FixedAssets", new[] { "LocationId" });
            DropIndex("dbo.FixedAssets", new[] { "CompanyId" });
            DropIndex("dbo.FixedAssets", new[] { "CategoryId" });
            DropIndex("dbo.FixedAssets", new[] { "BranchId" });
            DropIndex("dbo.FixedAssets", new[] { "AssetStatusId" });
            DropIndex("dbo.FixedAssets", new[] { "AssetMaintenanceIntervalId" });
            DropIndex("dbo.AssetsDetailReports", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "GradeId" });
            DropIndex("dbo.Companies", new[] { "BranchId" });
            DropIndex("dbo.AssetsDetailReports", new[] { "CategoryId" });
            DropIndex("dbo.AssetsDetailReports", new[] { "BranchId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EndOfYears");
            DropTable("dbo.Months");
            DropTable("dbo.EndOfMonths");
            DropTable("dbo.AssetUsageLogs");
            DropTable("dbo.DepreciationMTDs");
            DropTable("dbo.AssetsValuationDetails");
            DropTable("dbo.AssetsTransferDatas");
            DropTable("dbo.AssetsMaintenanceDetails");
            DropTable("dbo.AssetsMaintenanceCodes");
            DropTable("dbo.AssetsInsuranceDetails");
            DropTable("dbo.AssetsInspectionDetails");
            DropTable("dbo.AssetsDisposalDatas");
            DropTable("dbo.SortBies");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Vendors");
            DropTable("dbo.Locations");
            DropTable("dbo.AssetStatus");
            DropTable("dbo.FixedAssets");
            DropTable("dbo.Grades");
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
            DropTable("dbo.Branches");
            DropTable("dbo.AssetsDetailReports");
            DropTable("dbo.AssetMaintenanceIntervals");
        }
    }
}
