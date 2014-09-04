namespace LunchDictator.DataAccess
{
    using System.Data.Entity;

    using LunchDictator.DataAccess.Entities;

    public class LunchContext : DbContext
    {
        public LunchContext()
            : base("Name=LunchDictatorConnectionString")
        {
        }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<PlaceSelection> PlaceSelections { get; set; }
    }
}