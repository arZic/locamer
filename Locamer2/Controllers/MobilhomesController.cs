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
        private locamer_szEntities5 db = new locamer_szEntities5();

        // GET: Mobilhomes
        public ActionResult Index()
        {
            var mobilhomes = db.Mobilhomes.Include(m => m.Tarif);
            return View(mobilhomes.ToList());
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
            ViewBag.id_tarif = new SelectList(db.Tarifs, "id_tarif", "libelle_tarif");
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

            ViewBag.id_tarif = new SelectList(db.Tarifs, "id_tarif", "libelle_tarif", mobilhome.id_tarif);
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
            ViewBag.id_tarif = new SelectList(db.Tarifs, "id_tarif", "libelle_tarif", mobilhome.id_tarif);
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
            ViewBag.id_tarif = new SelectList(db.Tarifs, "id_tarif", "libelle_tarif", mobilhome.id_tarif);
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
