namespace LunchDictator.Models
{
    using System.Collections.Generic;

    public class HomeIndexViewModel
    {
        public string SelectedPlace { get; set; }

        public List<PlaceViewModel> Places { get; set; }
    }
}