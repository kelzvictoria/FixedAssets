namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransDateToAVD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetsValuationDetails", "TransDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssetsValuationDetails", "TransDate");
        }
    }
}
