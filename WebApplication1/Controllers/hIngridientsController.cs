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
    // it's test git!!!!!!!! :DDDDDDDDDDDD
    public class hIngridientsController : Controller
    {
        private KOMK_v6Entities1 db = new KOMK_v6Entities1();

        // GET: hIngridients
        public ActionResult Index()
        {
            return View(db.hIngridient.ToList());
        }

        // GET: hIngridients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hIngridient hIngridient = db.hIngridient.Find(id);
            if (hIngridient == null)
            {
                return HttpNotFound();
            }
            return View(hIngridient);
        }

        // GET: hIngridients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hIngridients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngridientId,IngridientName,Exist")] hIngridient hIngridient)
        {
            if (ModelState.IsValid)
            {
                db.hIngridient.Add(hIngridient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hIngridient);
        }

        // GET: hIngridients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hIngridient hIngridient = db.hIngridient.Find(id);
            if (hIngridient == null)
            {
                return HttpNotFound();
            }
            return View(hIngridient);
        }

        // POST: hIngridients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngridientId,IngridientName,Exist")] hIngridient hIngridient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hIngridient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hIngridient);
        }

        // GET: hIngridients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hIngridient hIngridient = db.hIngridient.Find(id);
            if (hIngridient == null)
            {
                return HttpNotFound();
            }
            return View(hIngridient);
        }

        // POST: hIngridients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hIngridient hIngridient = db.hIngridient.Find(id);
            db.hIngridient.Remove(hIngridient);
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
