namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedAssets", "DeprIntervalId", c => c.Int());
            AddColumn("dbo.FixedAssets", "MonthsId", c => c.Int());
            CreateIndex("dbo.FixedAssets", "DeprIntervalId");
            CreateIndex("dbo.FixedAssets", "MonthsId");
            AddForeignKey("dbo.FixedAssets", "DeprIntervalId", "dbo.DeprIntervals", "Id");
            AddForeignKey("dbo.FixedAssets", "MonthsId", "dbo.Months", "Id");
            DropColumn("dbo.FixedAssets", "DepreciationInterval");
            DropColumn("dbo.FixedAssets", "LastDeprMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FixedAssets", "LastDeprMonth", c => c.DateTime());
            AddColumn("dbo.FixedAssets", "DepreciationInterval", c => c.String());
            DropForeignKey("dbo.FixedAssets", "MonthsId", "dbo.Months");
            DropForeignKey("dbo.FixedAssets", "DeprIntervalId", "dbo.DeprIntervals");
            DropIndex("dbo.FixedAssets", new[] { "MonthsId" });
            DropIndex("dbo.FixedAssets", new[] { "DeprIntervalId" });
            DropColumn("dbo.FixedAssets", "MonthsId");
            DropColumn("dbo.FixedAssets", "DeprIntervalId");
        }
    }
}
