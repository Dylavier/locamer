using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLocamer.Models;

namespace WebLocamer.Controllers
{
    public class mobilomesController : Controller
    {
        private LocamerEntities db = new LocamerEntities();

        // GET: mobilomes
        public ActionResult Index()
        {
            var mobilomes = db.mobilomes.Include(m => m.type);
            return View(mobilomes.ToList());
        }

        // GET: mobilomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobilome mobilome = db.mobilomes.Find(id);
            if (mobilome == null)
            {
                return HttpNotFound();
            }
            return View(mobilome);
        }

        // GET: mobilomes/Create
        public ActionResult Create()
        {
            ViewBag.idType = new SelectList(db.types, "idType", "nomType");
            return View();
        }

        // POST: mobilomes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeEmplacement,capacite,terrace,idType")] mobilome mobilome)
        {
            if (ModelState.IsValid)
            {
                db.mobilomes.Add(mobilome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idType = new SelectList(db.types, "idType", "nomType", mobilome.idType);
            return View(mobilome);
        }

        // GET: mobilomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobilome mobilome = db.mobilomes.Find(id);
            if (mobilome == null)
            {
                return HttpNotFound();
            }
            ViewBag.idType = new SelectList(db.types, "idType", "nomType", mobilome.idType);
            return View(mobilome);
        }

        // POST: mobilomes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeEmplacement,capacite,terrace,idType")] mobilome mobilome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idType = new SelectList(db.types, "idType", "nomType", mobilome.idType);
            return View(mobilome);
        }

        // GET: mobilomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobilome mobilome = db.mobilomes.Find(id);
            if (mobilome == null)
            {
                return HttpNotFound();
            }
            return View(mobilome);
        }

        // POST: mobilomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mobilome mobilome = db.mobilomes.Find(id);
            db.mobilomes.Remove(mobilome);
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
