namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceSelections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.Place_Id)
                .Index(t => t.Place_Id);            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.PlaceSelections", "Place_Id", "dbo.Places");
            this.DropIndex("dbo.PlaceSelections", new[] { "Place_Id" });
            this.DropTable("dbo.PlaceSelections");
            this.DropTable("dbo.Places");
        }
    }
}
