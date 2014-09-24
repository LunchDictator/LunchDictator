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

        public IDbSet<User> Users { get; set; }

        public IDbSet<Dictatorship> Dictatorships { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictatorship>().HasMany(d => d.Users).WithMany(u => u.Dictatorships).Map(
                m =>
                    {
                        m.ToTable("DictatorshipUser");
                        m.MapLeftKey("Dictatorship_Id");
                        m.MapRightKey("User_Id");
                    });
        }
    }
}