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
    public class tbl_rolesController : Controller
    {
        private dbpawprintsEntities db = new dbpawprintsEntities();

        // GET: tbl_roles
        public ActionResult Index()
        {
            return View(db.tbl_roles.ToList());
        }

        // GET: tbl_roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // GET: tbl_roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol,Tipo,Descripcion")] tbl_roles tbl_roles)
        {
            if (ModelState.IsValid)
            {
                db.tbl_roles.Add(tbl_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_roles);
        }

        // GET: tbl_roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // POST: tbl_roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol,Tipo,Descripcion")] tbl_roles tbl_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_roles);
        }

        // GET: tbl_roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // POST: tbl_roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            db.tbl_roles.Remove(tbl_roles);
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
