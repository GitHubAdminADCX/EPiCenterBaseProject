using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiCenterBaseProject.Models.Blocks
{
    [ContentType(DisplayName = "NewsListBlock", GUID = "64b46a4b-8758-4564-ae82-ffd562412805", Description = "")]
    public class NewsListBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }
         */
    }
}