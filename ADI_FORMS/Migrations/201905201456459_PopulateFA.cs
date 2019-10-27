namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFA : DbMigration
    {
        public override void Up()
        {
            Sql(@"
               SET IDENTITY_INSERT [dbo].[FixedAssets] ON
                INSERT INTO [dbo].[FixedAssets] ([Id], [Description], [CategoryId], [BranchId], [LocationId], [StaffAssigned], [InitialCost], [AssetStatusId], [SerialNo], [PurchasesOrderNo], [Model], [PurchaseRecptNo], [VendorId], [YearOfManufacture], [PurchasedDate], [AssetAccountNo], [EngineNo], [ClassicNo], [AssetMaintenanceIntervalId], [MaintenanceFigure], [PresentValue], [DateRegistered], [LastValuationDate], [LifeSpan], [LastDeprYear], [Residual], [AnnualDeprAmount], [DepreciationRate], [LastDeprDate], [LastDeprAmt], [DeprYTD], [DeprToDate], [GLDebitAcc], [GLCreditAcc], [DeprCommenced], [DeprEndDate], [CurrentYear], [CompanyId], [DepreciationMTDId], [DeprIntervalId], [MonthsId]) VALUES (1, N'CONTAINER CARRIER', 2, 1, 1, N'MR OPE', CAST(55000000.00 AS Decimal(18, 2)), 1, 10222220123, 19234, N'BENZ LOAD 2008', 1234, 1, 2019, N'2019-04-21 00:00:00', 1234456, 2309123, NULL, 4, 3, CAST(55000000.00 AS Decimal(18, 2)), N'2019-05-20 11:39:47', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
                INSERT INTO [dbo].[FixedAssets] ([Id], [Description], [CategoryId], [BranchId], [LocationId], [StaffAssigned], [InitialCost], [AssetStatusId], [SerialNo], [PurchasesOrderNo], [Model], [PurchaseRecptNo], [VendorId], [YearOfManufacture], [PurchasedDate], [AssetAccountNo], [EngineNo], [ClassicNo], [AssetMaintenanceIntervalId], [MaintenanceFigure], [PresentValue], [DateRegistered], [LastValuationDate], [LifeSpan], [LastDeprYear], [Residual], [AnnualDeprAmount], [DepreciationRate], [LastDeprDate], [LastDeprAmt], [DeprYTD], [DeprToDate], [GLDebitAcc], [GLCreditAcc], [DeprCommenced], [DeprEndDate], [CurrentYear], [CompanyId], [DepreciationMTDId], [DeprIntervalId], [MonthsId]) VALUES (2, N'FUEL TANKER', 2, 1, 1, N'MR OPE', CAST(55000000.00 AS Decimal(18, 2)), 1, 10222220123, 19234, N'BENZ LOAD 2008', 1234, 1, 2019, N'2019-04-21 00:00:00', 1234456, 2309123, NULL, 4, 3, CAST(55000000.00 AS Decimal(18, 2)), N'2019-05-20 11:39:47', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
                
                SET IDENTITY_INSERT [dbo].[FixedAssets] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
