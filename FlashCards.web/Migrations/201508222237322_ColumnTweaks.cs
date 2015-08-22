namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnTweaks : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cards", new[] { "CardSet_id" });
            CreateIndex("dbo.Cards", "CardSet_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cards", new[] { "CardSet_Id" });
            CreateIndex("dbo.Cards", "CardSet_id");
        }
    }
}
