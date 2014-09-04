namespace LunchDictator.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using LunchDictator.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Places =
                    new List<PlaceViewModel>
                    {
                        new PlaceViewModel
                        {
                            ImageUrl = "http://www.dalton-park.co.uk/wp-content/uploads/2009/06/subway_705.jpg",
                            Name = "Subway"
                        },
                        new PlaceViewModel
                        {
                            ImageUrl = "http://intu.co.uk/uploads/tortilla-logo-v2.jpg",
                            Name = "Tortilla"
                        },
                        new PlaceViewModel
                        {
                            ImageUrl = "http://www.fastfind.info/photos/greggs_phppogjnl_big.jpg",
                            Name = "Greggs"
                        },
                        new PlaceViewModel
                        {
                            ImageUrl = "http://www.reed.co.uk/resources/cms/images/logos/Banner_17236.png",
                            Name = "Wenzel's"
                        },
                        new PlaceViewModel
                        {
                            ImageUrl = "http://www.londondiscountvouchers.com/wp-content/themes/couponpress/thumbs/BananaTree_logo.jpg",
                            Name = "Banana Tree"
                        },
                        new PlaceViewModel
                        {
                            ImageUrl = "http://www.watford.gov.uk/ccm/cms-service/stream/image/?image_id=18880016",
                            Name = "The Market"
                        }
                    }
            };

            return this.View(model);
        }
    }
}