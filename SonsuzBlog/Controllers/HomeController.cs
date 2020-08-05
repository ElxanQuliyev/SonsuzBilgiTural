using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SonsuzBlog.Models;
namespace SonsuzBlog.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        // GET: Home
        [Route("")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllPostList()
        {
            var postlar = db.tbl_post.OrderByDescending(x => x.PostId).Where(x => x.QebulEdildi == true).ToList();
            return View("PostList", postlar);
        }
        public ActionResult AllWidgets()
        {
            return View();
        }
    }
}