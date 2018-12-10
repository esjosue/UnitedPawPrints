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
    public class tbl_reportesController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_reportes
        public ActionResult Index()
        {
            var tbl_reportes = db.tbl_reportes.Include(t => t.tbl_tipoRep);
            return View(tbl_reportes.ToList());
        }

        // GET: tbl_reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reportes tbl_reportes = db.tbl_reportes.Find(id);
            if (tbl_reportes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_reportes);
        }

        // GET: tbl_reportes/Create
        public ActionResult Create()
        {
            ViewBag.TipoReporte = new SelectList(db.tbl_tipoRep, "IdTipo", "Tipo");
            return View();
        }

        // POST: tbl_reportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReporte,TipoAnimal,TipoReporte,Telefono,Direccion")] tbl_reportes tbl_reportes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_reportes.Add(tbl_reportes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoReporte = new SelectList(db.tbl_tipoRep, "IdTipo", "Tipo", tbl_reportes.TipoReporte);
            return View(tbl_reportes);
        }

        // GET: tbl_reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reportes tbl_reportes = db.tbl_reportes.Find(id);
            if (tbl_reportes == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoReporte = new SelectList(db.tbl_tipoRep, "IdTipo", "Tipo", tbl_reportes.TipoReporte);
            return View(tbl_reportes);
        }

        // POST: tbl_reportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReporte,TipoAnimal,TipoReporte,Telefono,Direccion")] tbl_reportes tbl_reportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_reportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoReporte = new SelectList(db.tbl_tipoRep, "IdTipo", "Tipo", tbl_reportes.TipoReporte);
            return View(tbl_reportes);
        }

        // GET: tbl_reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reportes tbl_reportes = db.tbl_reportes.Find(id);
            if (tbl_reportes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_reportes);
        }

        // POST: tbl_reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_reportes tbl_reportes = db.tbl_reportes.Find(id);
            db.tbl_reportes.Remove(tbl_reportes);
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
