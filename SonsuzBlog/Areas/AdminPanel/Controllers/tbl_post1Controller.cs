using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SonsuzBlog.Models;

namespace SonsuzBlog.Areas.AdminPanel.Controllers
{
    public class tbl_post1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_post1
        public ActionResult Index()
        {
            var tbl_post = db.tbl_post.Include(t => t.tbl_category).Include(t => t.tbl_sekil).Include(t => t.tbl_users);
            return View(tbl_post.ToList());
        }

        // GET: AdminPanel/tbl_post1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_post tbl_post = db.tbl_post.Find(id);
            if (tbl_post == null)
            {
                return HttpNotFound();
            }
            return View(tbl_post);
        }

        // GET: AdminPanel/tbl_post1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Ad");
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik");
            ViewBag.MuellifId = new SelectList(db.tbl_users, "UserId", "Ad");
            return View();
        }

        // POST: AdminPanel/tbl_post1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,MuellifId,Baslig,Context,PhotoId,CategoryId,Tarixi,Baxis,Beyenme,Keyword")] tbl_post tbl_post)
        {
            if (ModelState.IsValid)
            {
                db.tbl_post.Add(tbl_post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Ad", tbl_post.CategoryId);
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_post.PhotoId);
            ViewBag.MuellifId = new SelectList(db.tbl_users, "UserId", "Ad", tbl_post.MuellifId);
            return View(tbl_post);
        }

        // GET: AdminPanel/tbl_post1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_post tbl_post = db.tbl_post.Find(id);
            if (tbl_post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Ad", tbl_post.CategoryId);
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_post.PhotoId);
            ViewBag.MuellifId = new SelectList(db.tbl_users, "UserId", "Ad", tbl_post.MuellifId);
            return View(tbl_post);
        }

        // POST: AdminPanel/tbl_post1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,MuellifId,Baslig,Context,PhotoId,CategoryId,Tarixi,Baxis,Beyenme,Keyword")] tbl_post tbl_post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Ad", tbl_post.CategoryId);
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_post.PhotoId);
            ViewBag.MuellifId = new SelectList(db.tbl_users, "UserId", "Ad", tbl_post.MuellifId);
            return View(tbl_post);
        }

        // GET: AdminPanel/tbl_post1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_post tbl_post = db.tbl_post.Find(id);
            if (tbl_post == null)
            {
                return HttpNotFound();
            }
            return View(tbl_post);
        }

        // POST: AdminPanel/tbl_post1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_post tbl_post = db.tbl_post.Find(id);
            db.tbl_post.Remove(tbl_post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
