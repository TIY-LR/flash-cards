namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cardSets", "creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.cardSets", new[] { "creator_Id" });
            DropColumn("dbo.cards", "creatorId");
            DropColumn("dbo.cardSets", "creator_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cardSets", "creator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.cards", "creatorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.cardSets", "creator_Id");
            AddForeignKey("dbo.cardSets", "creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
