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
    public class tbl_poblacionController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_poblacion
        public ActionResult Index()
        {
            var tbl_poblacion = db.tbl_poblacion.Include(t => t.tbl_especies);
            return View(tbl_poblacion.ToList());
        }

        // GET: tbl_poblacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_poblacion tbl_poblacion = db.tbl_poblacion.Find(id);
            if (tbl_poblacion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_poblacion);
        }

        // GET: tbl_poblacion/Create
        public ActionResult Create()
        {
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre");
            return View();
        }

        // POST: tbl_poblacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPob,Especie,Cantidad")] tbl_poblacion tbl_poblacion)
        {
            if (ModelState.IsValid)
            {
                db.tbl_poblacion.Add(tbl_poblacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_poblacion.Especie);
            return View(tbl_poblacion);
        }

        // GET: tbl_poblacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_poblacion tbl_poblacion = db.tbl_poblacion.Find(id);
            if (tbl_poblacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_poblacion.Especie);
            return View(tbl_poblacion);
        }

        // POST: tbl_poblacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPob,Especie,Cantidad")] tbl_poblacion tbl_poblacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_poblacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_poblacion.Especie);
            return View(tbl_poblacion);
        }

        // GET: tbl_poblacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_poblacion tbl_poblacion = db.tbl_poblacion.Find(id);
            if (tbl_poblacion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_poblacion);
        }

        // POST: tbl_poblacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_poblacion tbl_poblacion = db.tbl_poblacion.Find(id);
            db.tbl_poblacion.Remove(tbl_poblacion);
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
