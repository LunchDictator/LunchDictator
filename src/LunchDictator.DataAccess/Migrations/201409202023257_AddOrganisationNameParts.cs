namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganisationNameParts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganisationNameParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        OrganisationNamePartType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrganisationNameParts");
        }
    }
}
