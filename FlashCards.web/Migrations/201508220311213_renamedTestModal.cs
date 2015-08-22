namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedTestModal : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TestModels", newName: "Cards");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cards", newName: "TestModels");
        }
    }
}
