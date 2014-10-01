namespace LunchDictator.DataAccess.Entities
{
    public class Place : BaseEntity
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public virtual Dictatorship Dictatorship { get; set; }
    }
}