using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Uygulamalar Sayfanız.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim Sayfanız.";

            return View();
        }
    }
}