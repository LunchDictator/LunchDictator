namespace LunchDictator.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    using LunchDictator.DataAccess;

    internal sealed class Configuration : DbMigrationsConfiguration<LunchContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LunchContext context)
        {            
        }
    }
}
