namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropLifespanInAVD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssetsValuationDetails", "LifeSpan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetsValuationDetails", "LifeSpan", c => c.Int());
        }
    }
}
