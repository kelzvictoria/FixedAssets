namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddBranchesToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "BranchId", c => c.Int());
            CreateIndex("dbo.Companies", "BranchId");
            AddForeignKey("dbo.Companies", "BranchId", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "BranchId", "dbo.Branches");
            DropIndex("dbo.Companies", new[] { "BranchId" });
            DropColumn("dbo.Companies", "BranchId");
        }
    }
}
