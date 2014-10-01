namespace LunchDictator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnattachedPlaces : DbMigration
    {
        public override void Up()
        {
            this.Sql("Delete from PlaceSelections");
            this.Sql("Delete from Places where Dictatorship_Id is null");
        }
        
        public override void Down()
        {
        }
    }
}
