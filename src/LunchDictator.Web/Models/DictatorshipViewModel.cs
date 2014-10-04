namespace LunchDictator.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using LunchDictator.Web.Resources;

    public class DictatorshipViewModel
    {
        public int Id { get; set; }

        [Display(Name = "DictatorshipName", ResourceType = typeof(WebCommon))]
        public string Name { get; set; }

        [Display(Name = "DictatorshipImageUrl", ResourceType = typeof(WebCommon))]
        public string ImageUrl { get; set; }
    }
}