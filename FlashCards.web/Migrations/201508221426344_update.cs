namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cards",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        creatorId = c.Guid(nullable: false),
                        cardSet_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cardSets", t => t.cardSet_id)
                .Index(t => t.cardSet_id);
            
            CreateTable(
                "dbo.cardSets",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.creator_Id)
                .Index(t => t.creator_Id);
            
            DropTable("dbo.Cards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        cardSetId = c.Guid(nullable: false),
                        creatorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.cardSets", "creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.cards", "cardSet_id", "dbo.cardSets");
            DropIndex("dbo.cardSets", new[] { "creator_Id" });
            DropIndex("dbo.cards", new[] { "cardSet_id" });
            DropTable("dbo.cardSets");
            DropTable("dbo.cards");
        }
    }
}
