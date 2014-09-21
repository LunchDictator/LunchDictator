namespace LunchDictator.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AlteredPasswordChangeSecretToNullable : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Users", "PasswordChangeSecret", c => c.Guid());
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Users", "PasswordChangeSecret", c => c.Guid(nullable: false));
        }
    }
}
