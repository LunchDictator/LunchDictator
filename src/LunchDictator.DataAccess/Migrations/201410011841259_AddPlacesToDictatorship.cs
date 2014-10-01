namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlacesToDictatorship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Dictatorship_Id", c => c.Int());
            CreateIndex("dbo.Places", "Dictatorship_Id");
            AddForeignKey("dbo.Places", "Dictatorship_Id", "dbo.Dictatorships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "Dictatorship_Id", "dbo.Dictatorships");
            DropIndex("dbo.Places", new[] { "Dictatorship_Id" });
            DropColumn("dbo.Places", "Dictatorship_Id");
        }
    }
}
