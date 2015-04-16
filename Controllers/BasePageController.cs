using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Controllers
{
    public class BasePageController<T> : PageController<T> where T : BasePage
    {
        //
        // GET: /BasePage/

        

    }
}
