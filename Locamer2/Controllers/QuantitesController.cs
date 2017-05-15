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
    public class QuantitesController : Controller
    {
        private locamer_szEntities2 db = new locamer_szEntities2();

        // GET: Quantites
        public ActionResult Index()
        {
            return View(db.Quantites.ToList());
        }

        // GET: Quantites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantite quantite = db.Quantites.Find(id);
            if (quantite == null)
            {
                return HttpNotFound();
            }
            return View(quantite);
        }

        // GET: Quantites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quantites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_quantite,id_sejour,id_option,quantite1,nb_jour_location")] Quantite quantite)
        {
            if (ModelState.IsValid)
            {
                db.Quantites.Add(quantite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quantite);
        }

        // GET: Quantites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantite quantite = db.Quantites.Find(id);
            if (quantite == null)
            {
                return HttpNotFound();
            }
            return View(quantite);
        }

        // POST: Quantites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_quantite,id_sejour,id_option,quantite1,nb_jour_location")] Quantite quantite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quantite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quantite);
        }

        // GET: Quantites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantite quantite = db.Quantites.Find(id);
            if (quantite == null)
            {
                return HttpNotFound();
            }
            return View(quantite);
        }

        // POST: Quantites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quantite quantite = db.Quantites.Find(id);
            db.Quantites.Remove(quantite);
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
