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
    public class sejoursController : Controller
    {
        private LocamerEntities db = new LocamerEntities();

        // GET: sejours
        public ActionResult Index()
        {
            var sejours = db.sejours.Include(s => s.option);
            return View(sejours.ToList());
        }

        // GET: sejours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sejour sejour = db.sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // GET: sejours/Create
        public ActionResult Create()
        {
            ViewBag.idOption = new SelectList(db.options, "idOption", "libelleOption");
            return View();
        }

        // POST: sejours/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSejour,dateDeb,dateFin,idOption")] sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.sejours.Add(sejour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOption = new SelectList(db.options, "idOption", "libelleOption", sejour.idOption);
            return View(sejour);
        }

        // GET: sejours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sejour sejour = db.sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOption = new SelectList(db.options, "idOption", "libelleOption", sejour.idOption);
            return View(sejour);
        }

        // POST: sejours/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSejour,dateDeb,dateFin,idOption")] sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sejour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOption = new SelectList(db.options, "idOption", "libelleOption", sejour.idOption);
            return View(sejour);
        }

        // GET: sejours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sejour sejour = db.sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // POST: sejours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sejour sejour = db.sejours.Find(id);
            db.sejours.Remove(sejour);
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
