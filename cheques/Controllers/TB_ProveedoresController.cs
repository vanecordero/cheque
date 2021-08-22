using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cheques.Context;

namespace cheques.Controllers
{
    public class TB_ProveedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TB_Proveedores
        public ActionResult Index()
        {
            return View(db.TB_Proveedores.ToList());
        }

        // GET: TB_Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Proveedores tB_Proveedores = db.TB_Proveedores.Find(id);
            if (tB_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tB_Proveedores);
        }

        // GET: TB_Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_Proveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proveedor,Nombre,Tipo_Persona,Cedula_or_RNC,Balance,Cuenta_contable_proveedor,Estado")] TB_Proveedores tB_Proveedores)
        {
            if (ModelState.IsValid)
            {
                db.TB_Proveedores.Add(tB_Proveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Proveedores);
        }

        // GET: TB_Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Proveedores tB_Proveedores = db.TB_Proveedores.Find(id);
            if (tB_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tB_Proveedores);
        }

        // POST: TB_Proveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proveedor,Nombre,Tipo_Persona,Cedula_or_RNC,Balance,Cuenta_contable_proveedor,Estado")] TB_Proveedores tB_Proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Proveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Proveedores);
        }

        // GET: TB_Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Proveedores tB_Proveedores = db.TB_Proveedores.Find(id);
            if (tB_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tB_Proveedores);
        }

        // POST: TB_Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Proveedores tB_Proveedores = db.TB_Proveedores.Find(id);
            db.TB_Proveedores.Remove(tB_Proveedores);
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
