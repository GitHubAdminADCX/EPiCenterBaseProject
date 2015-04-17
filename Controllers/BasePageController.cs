using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;
using EPiCenterBaseProject.Business.Interfaces;
using EPiServer.ServiceLocation;

namespace EPiCenterBaseProject.Controllers
{
    public class BasePageController<T> : PageController<T> where T : BasePage
    {
         private readonly IPageService _pageService = ServiceLocator.Current.GetInstance<IPageService>();

        public T CurrentPage
        {
            get
            {
                try
                {
                    return (T)PageContext.Page;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public virtual TModel CreateModel<TModel>(TModel model) where TModel : BasePageViewModel
        {
            return CreateModel(CurrentPage, model);
        }

        public virtual TModel CreateModel<TModel>(T currentPage, TModel model) where TModel : BasePageViewModel
        {
            if (String.IsNullOrEmpty(model.Title))
            {
                if (currentPage != null)
                {
                    model.Title = !string.IsNullOrEmpty(currentPage["Title"] as string)
                        ? currentPage["Title"] as string
                        : currentPage.Name;
                }
            }
            model.HeaderViewModel = CreateHeaderModel();

           
            return model;
        }

        private HeaderViewModel CreateHeaderModel()
        {
            var model = new HeaderViewModel()
            {
                StartPage = _pageService.GetStartPage()
            };
            return model;
        }

    }
}
