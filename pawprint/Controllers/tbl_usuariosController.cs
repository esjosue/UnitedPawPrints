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
    public class tbl_usuariosController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_usuarios
        public ActionResult Index()
        {
            var tbl_usuarios = db.tbl_usuarios.Include(t => t.tbl_login);
            return View(tbl_usuarios.ToList());
        }

        // GET: tbl_usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = db.tbl_usuarios.Find(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuarios);
        }

        // GET: tbl_usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Datos = new SelectList(db.tbl_login, "IdLogin", "Username");
            return View();
        }

        // POST: tbl_usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Nombre,Apellido,Telefono,Correo,Dui,Direccion,Datos")] tbl_usuarios tbl_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.tbl_usuarios.Add(tbl_usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Datos = new SelectList(db.tbl_login, "IdLogin", "Username", tbl_usuarios.Datos);
            return View(tbl_usuarios);
        }

        // GET: tbl_usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = db.tbl_usuarios.Find(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Datos = new SelectList(db.tbl_login, "IdLogin", "Username", tbl_usuarios.Datos);
            return View(tbl_usuarios);
        }

        // POST: tbl_usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Nombre,Apellido,Telefono,Correo,Dui,Direccion,Datos")] tbl_usuarios tbl_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Datos = new SelectList(db.tbl_login, "IdLogin", "Username", tbl_usuarios.Datos);
            return View(tbl_usuarios);
        }

        // GET: tbl_usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = db.tbl_usuarios.Find(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuarios);
        }

        // POST: tbl_usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_usuarios tbl_usuarios = db.tbl_usuarios.Find(id);
            db.tbl_usuarios.Remove(tbl_usuarios);
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
