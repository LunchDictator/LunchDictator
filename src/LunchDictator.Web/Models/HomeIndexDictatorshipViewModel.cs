namespace LunchDictator.Web.Models
{
    using System.Collections.Generic;

    using LunchDictator.Web.Core;

    public class HomeIndexDictatorshipViewModel
    {
        public string SelectedPlace { get; set; }

        public List<PlaceViewModel> Places { get; set; }

        public string DictatorshipName
        {
            get
            {
                return RandomDictatorshipNameProvider.GetRandomDictatorshipName();
            }
        }
    }
}