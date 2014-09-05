namespace LunchDictator.DataAccess
{
    using System.Data.Entity;

    using LunchDictator.DataAccess.Entities;
    using LunchDictator.DataAccess.Migrations;

    public class LunchContext : DbContext
    {
        static LunchContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LunchContext, Configuration>());
        }

        public LunchContext()
            : base("Name=LunchDictatorConnectionString")
        {
        }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<PlaceSelection> PlaceSelections { get; set; }
    }
}