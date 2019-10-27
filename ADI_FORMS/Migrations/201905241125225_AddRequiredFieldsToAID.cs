namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFieldsToAID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetsInsuranceDetails", "InsuranceCompany", c => c.String(nullable: false));
            AlterColumn("dbo.AssetsInsuranceDetails", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.AssetsInsuranceDetails", "Interval", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetsInsuranceDetails", "Interval", c => c.String());
            AlterColumn("dbo.AssetsInsuranceDetails", "Address", c => c.String());
            AlterColumn("dbo.AssetsInsuranceDetails", "InsuranceCompany", c => c.String());
        }
    }
}
