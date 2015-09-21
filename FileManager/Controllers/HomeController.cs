using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fullUrl = this.Url.Action("Index", null, null, Request.Url.Scheme);

            ViewBag.BaseUrl = fullUrl;

            return View();
        }
    }
}
