namespace LunchDictator.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using LunchDictator.DataAccess;
    using LunchDictator.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new LunchContext())
            {
                var model = new HomeIndexViewModel
                {
                    Places =
                        ctx.Places.Select(p => new PlaceViewModel { ImageUrl = p.ImageUrl, Name = p.Name }).ToList()
                };

                return this.View(model);
            }
        }
    }
}