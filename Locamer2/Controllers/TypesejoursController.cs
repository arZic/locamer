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
    public class TypesejoursController : Controller
    {
        private locamer_szEntities db = new locamer_szEntities();

        // GET: Typesejours
        public ActionResult Index()
        {
            return View(db.Typesejours.ToList());
        }

        // GET: Typesejours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typesejour typesejour = db.Typesejours.Find(id);
            if (typesejour == null)
            {
                return HttpNotFound();
            }
            return View(typesejour);
        }

        // GET: Typesejours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Typesejours/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_typesejour,libelle_typesjour,prix")] Typesejour typesejour)
        {
            if (ModelState.IsValid)
            {
                db.Typesejours.Add(typesejour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typesejour);
        }

        // GET: Typesejours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typesejour typesejour = db.Typesejours.Find(id);
            if (typesejour == null)
            {
                return HttpNotFound();
            }
            return View(typesejour);
        }

        // POST: Typesejours/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_typesejour,libelle_typesjour,prix")] Typesejour typesejour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesejour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typesejour);
        }

        // GET: Typesejours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typesejour typesejour = db.Typesejours.Find(id);
            if (typesejour == null)
            {
                return HttpNotFound();
            }
            return View(typesejour);
        }

        // POST: Typesejours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Typesejour typesejour = db.Typesejours.Find(id);
            db.Typesejours.Remove(typesejour);
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
