namespace LunchDictator.Web.Models
{
    using System;
    using System.Collections.Generic;

    public class HomeIndexDictatorshipViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SelectedPlace { get; set; }

        public List<PlaceViewModel> Places { get; set; }
    }
}