namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToLongInVendor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "Phone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Phone", c => c.Int(nullable: false));
        }
    }
}
