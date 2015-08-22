namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestModels");
        }
    }
}
