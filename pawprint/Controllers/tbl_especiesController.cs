using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pawprint.Models;

namespace pawprint.Controllers
{
    public class tbl_especiesController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_especies
        public ActionResult Index()
        {
            return View(db.tbl_especies.ToList());
        }

        // GET: tbl_especies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especies tbl_especies = db.tbl_especies.Find(id);
            if (tbl_especies == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especies);
        }

        // GET: tbl_especies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_especies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEspecie,Nombre")] tbl_especies tbl_especies)
        {
            if (ModelState.IsValid)
            {
                db.tbl_especies.Add(tbl_especies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_especies);
        }

        // GET: tbl_especies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especies tbl_especies = db.tbl_especies.Find(id);
            if (tbl_especies == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especies);
        }

        // POST: tbl_especies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEspecie,Nombre")] tbl_especies tbl_especies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_especies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_especies);
        }

        // GET: tbl_especies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especies tbl_especies = db.tbl_especies.Find(id);
            if (tbl_especies == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especies);
        }

        // POST: tbl_especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_especies tbl_especies = db.tbl_especies.Find(id);
            db.tbl_especies.Remove(tbl_especies);
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
