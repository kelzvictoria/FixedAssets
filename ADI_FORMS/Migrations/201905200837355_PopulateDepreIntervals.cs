namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepreIntervals : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DeprIntervals(Name) VALUES('Monthly')");
            Sql("INSERT INTO DeprIntervals(Name) VALUES('Quarterly')");
            Sql("INSERT INTO DeprIntervals(Name) VALUES('Half Yearly')");
            Sql("INSERT INTO DeprIntervals(Name) VALUES('Yearly')");
        }

        public override void Down()
        {
        }
    }
}
