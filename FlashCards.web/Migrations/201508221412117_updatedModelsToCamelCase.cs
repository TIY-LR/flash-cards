namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModelsToCamelCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "cardSetId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cards", "creatorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "creatorId");
            DropColumn("dbo.Cards", "cardSetId");
        }
    }
}
