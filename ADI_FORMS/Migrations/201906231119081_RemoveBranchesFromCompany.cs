namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBranchesFromCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "BranchId", "dbo.Branches");
            DropIndex("dbo.Companies", new[] { "BranchId" });
            DropColumn("dbo.Companies", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "BranchId");
            AddForeignKey("dbo.Companies", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
