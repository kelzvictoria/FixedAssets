namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAssetStatus : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                SET IDENTITY_INSERT [dbo].[AssetStatus] ON
                INSERT INTO [dbo].[AssetStatus] ([Id], [Name]) VALUES (1, N'ACTIVE')
                INSERT INTO [dbo].[AssetStatus] ([Id], [Name]) VALUES (2, N'DAMAGED')
                INSERT INTO [dbo].[AssetStatus] ([Id], [Name]) VALUES (3,N'DISABLED')
                SET IDENTITY_INSERT [dbo].[AssetStatus] OFF");
        }

        public override void Down()
        {
        }
    }
}
