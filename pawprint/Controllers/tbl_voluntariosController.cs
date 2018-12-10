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
    public class tbl_voluntariosController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_voluntarios
        public ActionResult Index()
        {
            var tbl_voluntarios = db.tbl_voluntarios.Include(t => t.tbl_usuarios);
            return View(tbl_voluntarios.ToList());
        }

        // GET: tbl_voluntarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voluntarios tbl_voluntarios = db.tbl_voluntarios.Find(id);
            if (tbl_voluntarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_voluntarios);
        }

        // GET: tbl_voluntarios/Create
        public ActionResult Create()
        {
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: tbl_voluntarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVoluntario,Usuario,Edad")] tbl_voluntarios tbl_voluntarios)
        {
            if (ModelState.IsValid)
            {
                db.tbl_voluntarios.Add(tbl_voluntarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_voluntarios.Usuario);
            return View(tbl_voluntarios);
        }

        // GET: tbl_voluntarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voluntarios tbl_voluntarios = db.tbl_voluntarios.Find(id);
            if (tbl_voluntarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_voluntarios.Usuario);
            return View(tbl_voluntarios);
        }

        // POST: tbl_voluntarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVoluntario,Usuario,Edad")] tbl_voluntarios tbl_voluntarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_voluntarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Usuario = new SelectList(db.tbl_usuarios, "IdUsuario", "Nombre", tbl_voluntarios.Usuario);
            return View(tbl_voluntarios);
        }

        // GET: tbl_voluntarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voluntarios tbl_voluntarios = db.tbl_voluntarios.Find(id);
            if (tbl_voluntarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_voluntarios);
        }

        // POST: tbl_voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_voluntarios tbl_voluntarios = db.tbl_voluntarios.Find(id);
            db.tbl_voluntarios.Remove(tbl_voluntarios);
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
