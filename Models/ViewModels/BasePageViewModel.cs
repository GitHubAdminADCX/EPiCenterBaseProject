using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiCenterBaseProject.Controllers;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class BasePageViewModel
    {
        public string Title { get; set; }
        public PageData StartPage { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}