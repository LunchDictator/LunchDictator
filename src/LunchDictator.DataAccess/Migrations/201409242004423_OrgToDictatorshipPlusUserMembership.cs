namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrgToDictatorshipPlusUserMembership : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Organisations", newName: "Dictatorships");
            CreateTable(
                "dbo.DictatorshipUser",
                c => new
                    {
                        Dictatorship_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dictatorship_Id, t.User_Id })
                .ForeignKey("dbo.Dictatorships", t => t.Dictatorship_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Dictatorship_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DictatorshipUser", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DictatorshipUser", "Dictatorship_Id", "dbo.Dictatorships");
            DropIndex("dbo.DictatorshipUser", new[] { "User_Id" });
            DropIndex("dbo.DictatorshipUser", new[] { "Dictatorship_Id" });
            DropTable("dbo.DictatorshipUser");
            RenameTable(name: "dbo.Dictatorships", newName: "Organisations");
        }
    }
}
