using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonsuzBlog.Areas.AdminPanel.Controllers
{
    public class YazarController : Controller
    {
        // GET: AdminPanel/Yazar
        public ActionResult Index()
        {
            return View();
        }
        
    }
}