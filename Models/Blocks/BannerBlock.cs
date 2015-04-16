using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "BannerBlock", GUID = "e5bd3032-58e3-41cb-91d7-498ae3b94d7c", Description = "")]
    public class BannerBlock : BlockData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Name",
            Description = "Banner Name",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String BannerName { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Info",
            Description = "Banner Info",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual String BannerInfo { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Banner Image",
            Description = "Banner Image",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BannerImage { get; set; }


        [CultureSpecific]
        [Required]
        [Editable(true)]
        [Display(
            Name = "Banner Link",
            Description = "BannerLink",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual PageReference BannerLink { get; set; }

    }
}