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
    public class tbl_animalesController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_animales
        public ActionResult Index()
        {
            var tbl_animales = db.tbl_animales.Include(t => t.tbl_especies).Include(t => t.tbl_poblacion);
            return View(tbl_animales.ToList());
        }

        // GET: tbl_animales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_animales tbl_animales = db.tbl_animales.Find(id);
            if (tbl_animales == null)
            {
                return HttpNotFound();
            }
            return View(tbl_animales);
        }

        // GET: tbl_animales/Create
        public ActionResult Create()
        {
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre");
            ViewBag.Poblacion = new SelectList(db.tbl_poblacion, "IdPob", "IdPob");
            return View();
        }

        // POST: tbl_animales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAnimal,Nombre,Clase,Sexo,Edad,Raza,Tamaño,FechaNac,Peso,Situacion,Color,Vacunas,Temperamento,Especie,Poblacion")] tbl_animales tbl_animales)
        {
            if (ModelState.IsValid)
            {
                db.tbl_animales.Add(tbl_animales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_animales.Especie);
            ViewBag.Poblacion = new SelectList(db.tbl_poblacion, "IdPob", "IdPob", tbl_animales.Poblacion);
            return View(tbl_animales);
        }

        // GET: tbl_animales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_animales tbl_animales = db.tbl_animales.Find(id);
            if (tbl_animales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_animales.Especie);
            ViewBag.Poblacion = new SelectList(db.tbl_poblacion, "IdPob", "IdPob", tbl_animales.Poblacion);
            return View(tbl_animales);
        }

        // POST: tbl_animales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAnimal,Nombre,Clase,Sexo,Edad,Raza,Tamaño,FechaNac,Peso,Situacion,Color,Vacunas,Temperamento,Especie,Poblacion")] tbl_animales tbl_animales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_animales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Especie = new SelectList(db.tbl_especies, "IdEspecie", "Nombre", tbl_animales.Especie);
            ViewBag.Poblacion = new SelectList(db.tbl_poblacion, "IdPob", "IdPob", tbl_animales.Poblacion);
            return View(tbl_animales);
        }

        // GET: tbl_animales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_animales tbl_animales = db.tbl_animales.Find(id);
            if (tbl_animales == null)
            {
                return HttpNotFound();
            }
            return View(tbl_animales);
        }

        // POST: tbl_animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_animales tbl_animales = db.tbl_animales.Find(id);
            db.tbl_animales.Remove(tbl_animales);
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
