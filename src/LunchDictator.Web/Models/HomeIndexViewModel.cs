namespace LunchDictator.Web.Models
{
    using System.Collections.Generic;

    using LunchDictator.Web.Core;

    public class HomeIndexViewModel
    {
        public string SelectedPlace { get; set; }

        public List<PlaceViewModel> Places { get; set; }

        public string OrganisationName
        {
            get
            {
                return RandomOrganisationNameProvider.GetRandomOrganisationName();
            }
        }
    }
}