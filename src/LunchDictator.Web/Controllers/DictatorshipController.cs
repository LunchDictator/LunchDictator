namespace LunchDictator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using LunchDictator.DataAccess;
    using LunchDictator.Web.Models;

    public class DictatorshipController : Controller
    {
        // GET: Dictatorship
        // Todo: Should user be able to see the dictatorship if they're not a member?
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                // No id specified, return to home page.
                return this.RedirectToAction("Index", "Home");
            }

            using (var ctx = new LunchContext())
            {
                var dictatorship = ctx.Dictatorships.SingleOrDefault(d => d.Id == id);

                if (dictatorship == null)
                {
                    // Dictatorship not found, panic.
                    // Todo: Handle this with some kind of "dictatorship not found" error message
                    return this.RedirectToAction("Index", "Home");
                }

                var model = new DictatorshipIndexViewModel
                {
                    Dictatorship = new DictatorshipViewModel { Id = dictatorship.Id, Name = dictatorship.Name, ImageUrl = dictatorship.ImageUrl }
                };

                return this.View(model);
            }
        }
    }
}