using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiCenterBaseProject.Models.Pages
{
    /// <summary>
    /// Used for the site's start page and also acts as a container for site settings
    /// </summary>
    [ContentType(
        GUID = "19671657-B684-4D95-A61F-8DD4FE60D559",
        GroupName = Global.GroupNames.Specialized)]
    public class StartPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Content Area",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentArea BannerContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News List ContentArea",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual ContentArea NewsListContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News List Container",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual PageReference NewsListContainer { get; set; }
    }
}