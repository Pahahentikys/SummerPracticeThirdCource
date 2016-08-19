using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class hPersonalsController : Controller
    {
        private KOMK_v6Entities1 db = new KOMK_v6Entities1();

        // GET: hPersonals
        public ActionResult Index()
        {
            return View(db.hPersonal.ToList());
        }

        // GET: hPersonals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hPersonal hPersonal = db.hPersonal.Find(id);
            if (hPersonal == null)
            {
                return HttpNotFound();
            }
            return View(hPersonal);
        }

        // GET: hPersonals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hPersonals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,PersonFlN,PersonCost1H,PersonDate,Exist")] hPersonal hPersonal)
        {
            if (ModelState.IsValid)
            {
                db.hPersonal.Add(hPersonal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hPersonal);
        }

        // GET: hPersonals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hPersonal hPersonal = db.hPersonal.Find(id);
            if (hPersonal == null)
            {
                return HttpNotFound();
            }
            return View(hPersonal);
        }

        // POST: hPersonals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,PersonFlN,PersonCost1H,PersonDate,Exist")] hPersonal hPersonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hPersonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hPersonal);
        }

        // GET: hPersonals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hPersonal hPersonal = db.hPersonal.Find(id);
            if (hPersonal == null)
            {
                return HttpNotFound();
            }
            return View(hPersonal);
        }

        // POST: hPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hPersonal hPersonal = db.hPersonal.Find(id);
            db.hPersonal.Remove(hPersonal);
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
