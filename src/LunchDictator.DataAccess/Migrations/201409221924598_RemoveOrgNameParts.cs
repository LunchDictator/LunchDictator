namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrgNameParts : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OrganisationNameParts");
        }
        
        public override void Down()
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
    }
}
