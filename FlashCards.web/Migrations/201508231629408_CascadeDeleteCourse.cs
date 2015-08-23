namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDeleteCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "CardSet_Id", "dbo.CardSets");
            DropForeignKey("dbo.CardSets", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Cards", new[] { "CardSet_Id" });
            DropIndex("dbo.CardSets", new[] { "Course_Id" });
            AlterColumn("dbo.Cards", "CardSet_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CardSets", "Course_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "CardSet_Id");
            CreateIndex("dbo.CardSets", "Course_Id");
            AddForeignKey("dbo.Cards", "CardSet_Id", "dbo.CardSets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CardSets", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardSets", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Cards", "CardSet_Id", "dbo.CardSets");
            DropIndex("dbo.CardSets", new[] { "Course_Id" });
            DropIndex("dbo.Cards", new[] { "CardSet_Id" });
            AlterColumn("dbo.CardSets", "Course_Id", c => c.Int());
            AlterColumn("dbo.Cards", "CardSet_Id", c => c.Int());
            CreateIndex("dbo.CardSets", "Course_Id");
            CreateIndex("dbo.Cards", "CardSet_Id");
            AddForeignKey("dbo.CardSets", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Cards", "CardSet_Id", "dbo.CardSets", "Id");
        }
    }
}
