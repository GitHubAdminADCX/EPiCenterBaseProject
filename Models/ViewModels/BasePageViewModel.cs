using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiCenterBaseProject.Controllers;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class BasePageViewModel
    {
        private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public string Title { get; set; }
        public PageData StartPage { get; set;  }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}