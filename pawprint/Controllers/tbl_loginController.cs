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
    public class tbl_loginController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_login
        public ActionResult Index()
        {
            var tbl_login = db.tbl_login.Include(t => t.tbl_roles);
            return View(tbl_login.ToList());
        }

        // GET: tbl_login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_login tbl_login = db.tbl_login.Find(id);
            if (tbl_login == null)
            {
                return HttpNotFound();
            }
            return View(tbl_login);
        }

        // GET: tbl_login/Create
        public ActionResult Create()
        {
            ViewBag.Rol = new SelectList(db.tbl_roles, "IdRol", "Tipo");
            return View();
        }

        // POST: tbl_login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLogin,Username,Pass,Rol")] tbl_login tbl_login)
        {
            if (ModelState.IsValid)
            {
                db.tbl_login.Add(tbl_login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rol = new SelectList(db.tbl_roles, "IdRol", "Tipo", tbl_login.Rol);
            return View(tbl_login);
        }

        // GET: tbl_login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_login tbl_login = db.tbl_login.Find(id);
            if (tbl_login == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rol = new SelectList(db.tbl_roles, "IdRol", "Tipo", tbl_login.Rol);
            return View(tbl_login);
        }

        // POST: tbl_login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLogin,Username,Pass,Rol")] tbl_login tbl_login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rol = new SelectList(db.tbl_roles, "IdRol", "Tipo", tbl_login.Rol);
            return View(tbl_login);
        }

        // GET: tbl_login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_login tbl_login = db.tbl_login.Find(id);
            if (tbl_login == null)
            {
                return HttpNotFound();
            }
            return View(tbl_login);
        }

        // POST: tbl_login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_login tbl_login = db.tbl_login.Find(id);
            db.tbl_login.Remove(tbl_login);
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
