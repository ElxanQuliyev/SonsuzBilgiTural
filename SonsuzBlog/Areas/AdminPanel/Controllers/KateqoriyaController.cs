using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SonsuzBlog.App_Classes;
using SonsuzBlog.Models;

namespace SonsuzBlog.Areas.AdminPanel.Controllers
{
    public class KateqoriyaController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/Kateqoriya
        public ActionResult Index()
        {
            var tbl_category = db.tbl_category.Include(t => t.tbl_sekil);
            return View(tbl_category.ToList());
        }

        // GET: AdminPanel/Kateqoriya/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = db.tbl_category.Find(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_category);
        }

        // GET: AdminPanel/Kateqoriya/Create
        public ActionResult Create()
        {
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik");
            return View();
        }

        // POST: AdminPanel/Kateqoriya/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Ad,PhotoId,Aciqlama,Keyword")] tbl_category tbl_category,HttpPostedFileBase Sekil)
        {
            if (ModelState.IsValid)
            {

                if (Sekil != null)
                {
                    if (Sekil.ContentLength > 0)
                    {
                        Image img = Image.FromStream(Sekil.InputStream);
                        Bitmap kiciksekil = new Bitmap(img, Settings.SekilKicikBoy);
                        kiciksekil.Save(Server.MapPath("/Upload/Sekiller/balaca" + Sekil.FileName));
                        tbl_sekil skl = new tbl_sekil();
                        skl.Kicik = "/Upload/Sekiller/balaca" + Sekil.FileName;
                        db.tbl_sekil.Add(skl);
                        db.SaveChanges();
                        tbl_category.PhotoId = skl.PhotoId;
                        db.tbl_category.Add(tbl_category);
                        db.SaveChanges();
                    }
                }

                
                return RedirectToAction("Index");
            }

            //ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_category.PhotoId);
            return View(tbl_category);
        }

        // GET: AdminPanel/Kateqoriya/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = db.tbl_category.Find(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_category.PhotoId);
            return View(tbl_category);
        }

        // POST: AdminPanel/Kateqoriya/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Ad,PhotoId,Aciqlama,Keyword")] tbl_category tbl_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhotoId = new SelectList(db.tbl_sekil, "PhotoId", "Kicik", tbl_category.PhotoId);
            return View(tbl_category);
        }

        // GET: AdminPanel/Kateqoriya/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = db.tbl_category.Find(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_category);
        }

        // POST: AdminPanel/Kateqoriya/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_category tbl_category = db.tbl_category.Find(id);
            db.tbl_category.Remove(tbl_category);
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
