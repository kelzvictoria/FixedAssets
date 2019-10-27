namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeprMTDtoFA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedAssets", "DepreciationMTDId", c => c.Int());
            CreateIndex("dbo.FixedAssets", "DepreciationMTDId");
            AddForeignKey("dbo.FixedAssets", "DepreciationMTDId", "dbo.DepreciationMTDs", "Id");
            DropColumn("dbo.FixedAssets", "DeprMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FixedAssets", "DeprMethod", c => c.String());
            DropForeignKey("dbo.FixedAssets", "DepreciationMTDId", "dbo.DepreciationMTDs");
            DropIndex("dbo.FixedAssets", new[] { "DepreciationMTDId" });
            DropColumn("dbo.FixedAssets", "DepreciationMTDId");
        }
    }
}
