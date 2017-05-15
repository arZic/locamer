using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Locamer2.Models;

namespace Locamer2.Controllers
{
    public class MobilhomesController : Controller
    {
        private locamer_szEntities db = new locamer_szEntities();

        // GET: Mobilhomes
        public ActionResult Index()
        {
            return View(db.Mobilhomes.ToList());
        }

        // GET: Mobilhomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilhome mobilhome = db.Mobilhomes.Find(id);
            if (mobilhome == null)
            {
                return HttpNotFound();
            }
            return View(mobilhome);
        }

        // GET: Mobilhomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mobilhomes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mobilhome,id_tarif,capacite,terrasse")] Mobilhome mobilhome)
        {
            if (ModelState.IsValid)
            {
                db.Mobilhomes.Add(mobilhome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobilhome);
        }

        // GET: Mobilhomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilhome mobilhome = db.Mobilhomes.Find(id);
            if (mobilhome == null)
            {
                return HttpNotFound();
            }
            return View(mobilhome);
        }

        // POST: Mobilhomes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mobilhome,id_tarif,capacite,terrasse")] Mobilhome mobilhome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilhome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobilhome);
        }

        // GET: Mobilhomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobilhome mobilhome = db.Mobilhomes.Find(id);
            if (mobilhome == null)
            {
                return HttpNotFound();
            }
            return View(mobilhome);
        }

        // POST: Mobilhomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mobilhome mobilhome = db.Mobilhomes.Find(id);
            db.Mobilhomes.Remove(mobilhome);
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
