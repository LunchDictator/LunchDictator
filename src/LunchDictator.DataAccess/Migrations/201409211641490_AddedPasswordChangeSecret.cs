namespace LunchDictator.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedPasswordChangeSecret : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Users", "PasswordChangeSecret", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Users", "PasswordChangeSecret");
        }
    }
}
