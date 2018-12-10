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
    public class tbl_adopcionesController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_adopciones
        public ActionResult Index()
        {
            var tbl_adopciones = db.tbl_adopciones.Include(t => t.tbl_animales).Include(t => t.tbl_usuarios);
            return View(tbl_adopciones.ToList());
        }

        // GET: tbl_adopciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_adopciones tbl_adopciones = db.tbl_adopciones.Find(id);
            if (tbl_adopciones == null)
            {
                return HttpNotFound();
            }
            return View(tbl_adopciones);
        }

        // GET: tbl_adopciones/Create
        public ActionResult Create()
        {
            ViewBag.Animal = new SelectList(db.tbl_animales, "IdAnimal", "Nombre");
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: tbl_adopciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdopcion,Fecha,Estado,Animal,Usuario")] tbl_adopciones tbl_adopciones)
        {
            if (ModelState.IsValid)
            {
                db.tbl_adopciones.Add(tbl_adopciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Animal = new SelectList(db.tbl_animales, "IdAnimal", "Nombre", tbl_adopciones.Animal);
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_adopciones.Usuario);
            return View(tbl_adopciones);
        }

        // GET: tbl_adopciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_adopciones tbl_adopciones = db.tbl_adopciones.Find(id);
            if (tbl_adopciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Animal = new SelectList(db.tbl_animales, "IdAnimal", "Nombre", tbl_adopciones.Animal);
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_adopciones.Usuario);
            return View(tbl_adopciones);
        }

        // POST: tbl_adopciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdopcion,Fecha,Estado,Animal,Usuario")] tbl_adopciones tbl_adopciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_adopciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Animal = new SelectList(db.tbl_animales, "IdAnimal", "Nombre", tbl_adopciones.Animal);
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_adopciones.Usuario);
            return View(tbl_adopciones);
        }

        // GET: tbl_adopciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_adopciones tbl_adopciones = db.tbl_adopciones.Find(id);
            if (tbl_adopciones == null)
            {
                return HttpNotFound();
            }
            return View(tbl_adopciones);
        }

        // POST: tbl_adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_adopciones tbl_adopciones = db.tbl_adopciones.Find(id);
            db.tbl_adopciones.Remove(tbl_adopciones);
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
