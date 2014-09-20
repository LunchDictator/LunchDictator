namespace LunchDictator.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    using LunchDictator.DataAccess;
    using LunchDictator.DataAccess.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<LunchContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LunchContext context)
        {
            context.Places.AddOrUpdate(
                e => e.Name,
                new Place
                {
                    Id = 1,
                    ImageUrl = "http://www.dalton-park.co.uk/wp-content/uploads/2009/06/subway_705.jpg",
                    Name = "Subway"
                },
                new Place { Id = 1, ImageUrl = "http://intu.co.uk/uploads/tortilla-logo-v2.jpg", Name = "Tortilla" },
                new Place
                {
                    Id = 2,
                    ImageUrl = "http://www.caratmanchester.co.uk/uploads/134545511071057/resize_then_crop_540_350.jpg",
                    Name = "Greggs"
                },
                new Place
                {
                    Id = 3,
                    ImageUrl = "http://www.reed.co.uk/resources/cms/images/logos/Banner_17236.png",
                    Name = "Wenzel's"
                },
                new Place
                {
                    Id = 4,
                    ImageUrl =
                        "http://www.londondiscountvouchers.com/wp-content/themes/couponpress/thumbs/BananaTree_logo.jpg",
                    Name = "Banana Tree"
                },
                new Place
                {
                    Id = 5,
                    ImageUrl = "http://www.watford.gov.uk/ccm/cms-service/stream/image/?image_id=18880016",
                    Name = "The Market"
                });
        }
    }
}
