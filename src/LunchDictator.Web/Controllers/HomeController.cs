namespace LunchDictator.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using LunchDictator.DataAccess;
    using LunchDictator.DataAccess.Entities;
    using LunchDictator.Web.Core;
    using LunchDictator.Web.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            using (var ctx = new LunchContext())
            {
                var places = ctx.Places.ToList();
                var model = new HomeIndexViewModel
                {
                    Places =
                        places.Select(p => new PlaceViewModel { ImageUrl = p.ImageUrl, Name = p.Name, Id = p.Id })
                            .ToList()
                };

                var today = DateTime.Now.Date;
                var selection = ctx.PlaceSelections.SingleOrDefault(s => s.Date == today);

                if (selection == null)
                {
                    var rand = new Random();
                    selection = new PlaceSelection { Date = today, Place = places[rand.Next(places.Count)] };
                    ctx.PlaceSelections.Add(selection);

                    ctx.SaveChanges();
                }

                var selectedPlace = model.Places.Single(p => p.Id == selection.Place.Id);
                selectedPlace.IsSelected = true;
                model.SelectedPlace = selectedPlace.Name;

                return this.View(model);
            }
        }
    }
}