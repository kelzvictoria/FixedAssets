namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMonths : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Months] ON
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (1, N'January')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (2, N'February')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (3,N'March')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (4, N'April')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (5, N'May')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (6,N'June')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (7, N'July')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (8, N'August')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (9,N'September')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (10, N'October')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (11, N'November')
                INSERT INTO [dbo].[Months] ([Id], [Name]) VALUES (12,N'December')
                
                SET IDENTITY_INSERT [dbo].[AssetStatus] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
