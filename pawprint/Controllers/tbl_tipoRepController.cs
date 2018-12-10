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
    public class tbl_tipoRepController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_tipoRep
        public ActionResult Index()
        {
            return View(db.tbl_tipoRep.ToList());
        }

        // GET: tbl_tipoRep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoRep tbl_tipoRep = db.tbl_tipoRep.Find(id);
            if (tbl_tipoRep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoRep);
        }

        // GET: tbl_tipoRep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_tipoRep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipo,Tipo")] tbl_tipoRep tbl_tipoRep)
        {
            if (ModelState.IsValid)
            {
                db.tbl_tipoRep.Add(tbl_tipoRep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tipoRep);
        }

        // GET: tbl_tipoRep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoRep tbl_tipoRep = db.tbl_tipoRep.Find(id);
            if (tbl_tipoRep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoRep);
        }

        // POST: tbl_tipoRep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipo,Tipo")] tbl_tipoRep tbl_tipoRep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tipoRep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tipoRep);
        }

        // GET: tbl_tipoRep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipoRep tbl_tipoRep = db.tbl_tipoRep.Find(id);
            if (tbl_tipoRep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipoRep);
        }

        // POST: tbl_tipoRep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_tipoRep tbl_tipoRep = db.tbl_tipoRep.Find(id);
            db.tbl_tipoRep.Remove(tbl_tipoRep);
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
