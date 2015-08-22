namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToCardModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "Name");
        }
    }
}
