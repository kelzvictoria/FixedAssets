namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDeprMethods : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[DepreciationMTDs] ON
                INSERT INTO [dbo].[DepreciationMTDs] ([Id], [Name]) VALUES (1, N'DIMINISHING')
                INSERT INTO [dbo].[DepreciationMTDs] ([Id], [Name]) VALUES (2, N'STRAIGHT LINE')
                SET IDENTITY_INSERT [dbo].[DepreciationMTDs] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
