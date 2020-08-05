using SonsuzBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonsuzBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        Model1 db = new Model1();
        // GET: Post
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Post/{baslig}-{id:int}")]
        public ActionResult PostDetail(int id)
        {
            ViewBag.Istifadeci = Session["Istifadeci"];
            tbl_post post = db.tbl_post.FirstOrDefault(x => x.PostId == id);
            return View(post);
        }

        public ActionResult EvvelkiPost(int id)
        {
            tbl_post pst = db.tbl_post.FirstOrDefault(x => x.PostId == id);
            pst.PostId--;
            return View();
        }

        public ActionResult CommentYaz(tbl_comment Comment)
        {
            Comment.Tarixi = DateTime.Now;
            //Comment.Baslig = "";
            //Comment.Aktiv = false;
            db.tbl_comment.Add(Comment);
            db.SaveChanges();
            return RedirectToAction("PostDetail", new { id = Comment.PostId });
        }
        [AllowAnonymous]
        public string PostBeyen(int id)
        {
            tbl_post pst = db.tbl_post.FirstOrDefault(x => x.PostId == id);
            pst.Beyenme++;
            db.SaveChanges();
            return pst.Beyenme.ToString();
        }

        [AllowAnonymous]
        public void Baxildi(int id)
        {
            tbl_post pst = db.tbl_post.FirstOrDefault(x => x.PostId == id);
            pst.Baxis++;
            db.SaveChanges();

        }

    }
}