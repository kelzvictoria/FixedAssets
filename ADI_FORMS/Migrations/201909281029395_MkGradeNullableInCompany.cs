namespace ADI_FORMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MkGradeNullableInCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "GradeId", "dbo.Grades");
            DropIndex("dbo.Companies", new[] { "GradeId" });
            AlterColumn("dbo.Companies", "GradeId", c => c.Int());
            CreateIndex("dbo.Companies", "GradeId");
            AddForeignKey("dbo.Companies", "GradeId", "dbo.Grades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "GradeId", "dbo.Grades");
            DropIndex("dbo.Companies", new[] { "GradeId" });
            AlterColumn("dbo.Companies", "GradeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "GradeId");
            AddForeignKey("dbo.Companies", "GradeId", "dbo.Grades", "Id", cascadeDelete: true);
        }
    }
}
