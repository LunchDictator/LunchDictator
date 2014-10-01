namespace LunchDictator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using LunchDictator.DataAccess;
    using LunchDictator.DataAccess.Entities;
    using LunchDictator.Web.Core;
    using LunchDictator.Web.Models;

    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            using (var ctx = new LunchContext())
            {
                var today = DateTime.Now.Date;
                var user = ctx.Users.SingleOrDefault(u => u.EmailAddress == User.Identity.Name);

                var model = new HomeIndexViewModel { DictatorshipViewModels = new List<HomeIndexDictatorshipViewModel>() };

                foreach (var dictatorship in user.Dictatorships)
                {
                    var places = ctx.Places.ToList();
                    var dictatorshipModel = new HomeIndexDictatorshipViewModel()
                    {
                        Places =
                            places.Where(p => p.Dictatorship.Id == dictatorship.Id).Select(p => new PlaceViewModel { ImageUrl = p.ImageUrl, Name = p.Name, Id = p.Id })
                                .ToList()
                    };

                    var selection = ctx.PlaceSelections.SingleOrDefault(s => s.Date == today && s.Place.Dictatorship.Id == dictatorship.Id);

                    if (selection == null)
                    {
                        var rand = new Random();
                        selection = new PlaceSelection { Date = today, Place = places[rand.Next(places.Count)] };
                        ctx.PlaceSelections.Add(selection);

                        ctx.SaveChanges();
                    }


                    var selectedPlace = dictatorshipModel.Places.Single(p => p.Id == selection.Place.Id);
                    selectedPlace.IsSelected = true;
                    dictatorshipModel.SelectedPlace = selectedPlace.Name;

                    model.DictatorshipViewModels.Add(dictatorshipModel);
                }

                return this.View(model);
            }
        }
    }
}