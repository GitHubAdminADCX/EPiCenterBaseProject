using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;
using EPiCenterBaseProject.Models.ViewModels;

namespace EPiCenterBaseProject.Controllers
{
    public class StartPageController : BasePageController<StartPage>, IController
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = new StartPageViewModel();
            model.Title  = currentPage.Title;
            return View(model);
        }

    }
}
