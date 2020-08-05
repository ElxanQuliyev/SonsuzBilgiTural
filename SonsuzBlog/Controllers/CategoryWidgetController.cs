using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SonsuzBlog.Models;

namespace SonsuzBlog.Controllers
{
    public class CategoryWidgetController : Controller
    {
        Model1 db = new Model1();
        // GET: CategoryWidget


        [Route("Category/{KateqoriAd}-{id:int}")]
        public ActionResult Index(int id)
        {
            return View(id); 
        }


        public ActionResult PostList(int id)
        {
            var data = db.tbl_post.Where(x => x.CategoryId == id).ToList();
            return View("PostList",data); 
        }
        
        public ActionResult CategoryWidgetGetir()
        {
            return View(db.tbl_category.ToList());
        }
        public ActionResult CategoryWidgetNumber()
        {
            return View(db.tbl_category.OrderByDescending(x=>x.tbl_post.Count).ToList());
        }

        
        public ActionResult PostListCat(int id)
        {
            var data = db.tbl_post.Where(x => x.CategoryId == id).ToList();
            ViewBag.post = db.tbl_category.First();
            return View("PostListCat", data);
        }
        public  ActionResult BreakingNews()
        {
            return View(db.tbl_post.OrderByDescending(x => x.Tarixi).Take(3).ToList());
        }
    }
}