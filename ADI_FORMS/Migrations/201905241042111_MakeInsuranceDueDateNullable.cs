namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeInsuranceDueDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetsInsuranceDetails", "DatePaid", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetsInsuranceDetails", "DatePaid", c => c.DateTime(nullable: false));
        }
    }
}
