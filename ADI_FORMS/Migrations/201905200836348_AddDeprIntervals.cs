namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeprIntervals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeprIntervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeprIntervals");
        }
    }
}
