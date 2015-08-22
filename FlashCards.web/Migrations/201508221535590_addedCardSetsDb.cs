namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCardSetsDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cards", "frontText", c => c.String());
            AddColumn("dbo.cards", "backText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.cards", "backText");
            DropColumn("dbo.cards", "frontText");
        }
    }
}
