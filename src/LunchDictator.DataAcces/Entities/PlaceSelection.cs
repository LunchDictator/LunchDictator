namespace LunchDictator.DataAccess.Entities
{
    using System;

    public class PlaceSelection : BaseEntity
    {
        public DateTime Date { get; set; }

        public virtual Place Place { get; set; }
    }
}