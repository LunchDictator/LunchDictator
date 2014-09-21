namespace LunchDictator.Web.Core
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using LunchDictator.DataAccess;

    [Authorize]
    public class BaseController : Controller
    {
        private LunchContext context;

        public LunchContext LunchContext
        {
            get
            {
                return this.context ?? (this.context = new LunchContext());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.context != null)
            {
                this.context.Dispose();
                this.context = null;
            }

            base.Dispose(disposing);
        }
    }
}