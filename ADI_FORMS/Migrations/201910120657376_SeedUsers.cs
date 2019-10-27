namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'0e17380c-809d-40fa-a9bb-ff8d37bd4586', N'Victoria', N'AMPJteUF+U2hiTH78l7ZLD2ghhL/SRsw3vb5ZR15Vwrodx39t/xUQQTh2N7ZKblP7A==', N'd6b3005c-8125-45c9-8860-9ddd22ae7199', N'ApplicationUser')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'ded6abb6-f6b6-4c0e-b283-8069bc1536f4', N'AdminFixedAssets', N'AFrJPufzLtUe1nIi7N89k37ASzjSqcZiZKtjadWUv41Pr5s/dF8UheCfBWqaTeu43w==', N'664c45f4-8795-42fd-a67e-e374a8e9c100', N'ApplicationUser')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5c974041-7465-4dac-9db3-c2bbaf388d78', N'CanManageApp')
                   
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ded6abb6-f6b6-4c0e-b283-8069bc1536f4', N'5c974041-7465-4dac-9db3-c2bbaf388d78')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
