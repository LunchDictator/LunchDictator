namespace LunchDictator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using LunchDictator.DataAccess;
    using LunchDictator.DataAccess.Entities;
    using LunchDictator.Web.Core;
    using LunchDictator.Web.Models;
    using LunchDictator.Web.Resources;

    public class DictatorshipController : Controller
    {
        // GET: Dictatorship
        // Todo: Should user be able to see the dictatorship if they're not a member?
        [Authorize]
        [HttpGet]
        public ActionResult Details(int id)
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
                    // Dictatorship not found! Panic!
                    // Todo: Handle this with some kind of "dictatorship not found" error message
                    return this.RedirectToAction("Index", "Home");
                }

                var model = new DictatorshipViewModel
                {
                    Id = dictatorship.Id,
                    Name = dictatorship.Name,
                    ImageUrl = dictatorship.ImageUrl
                };

                return this.View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return this.View(new DictatorshipViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(DictatorshipViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            using (var ctx = new LunchContext())
            {
                var user = ctx.Users.SingleOrDefault(u => u.EmailAddress == User.Identity.Name);
                var dictatorship = new Dictatorship
                                       {
                                           Name = viewModel.Name,
                                           ImageUrl = viewModel.ImageUrl,
                                           Users = new Collection<User> { user }
                                       };

                ctx.Dictatorships.Add(dictatorship);
                ctx.SaveChanges();
            }

            this.TempData["Message"] = WebCommon.DictatorshipAdded;
            return this.View(new DictatorshipViewModel());
        }

        [HttpGet]
        public ActionResult GetRandomDictatorshipName()
        {
            return this.Json(new { Name = RandomDictatorshipNameProvider.GetRandomDictatorshipName() }, JsonRequestBehavior.AllowGet);
        }
    }
}