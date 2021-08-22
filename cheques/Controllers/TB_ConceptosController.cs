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
    public class TB_ConceptosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TB_Conceptos
        public ActionResult Index()
        {
            return View(db.TB_Conceptos.ToList());
        }

        // GET: TB_Conceptos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Conceptos tB_Conceptos = db.TB_Conceptos.Find(id);
            if (tB_Conceptos == null)
            {
                return HttpNotFound();
            }
            return View(tB_Conceptos);
        }

        // GET: TB_Conceptos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_Conceptos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Identificador,Descripcion,Estado")] TB_Conceptos tB_Conceptos)
        {
            if (ModelState.IsValid)
            {
                db.TB_Conceptos.Add(tB_Conceptos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Conceptos);
        }

        // GET: TB_Conceptos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Conceptos tB_Conceptos = db.TB_Conceptos.Find(id);
            if (tB_Conceptos == null)
            {
                return HttpNotFound();
            }
            return View(tB_Conceptos);
        }

        // POST: TB_Conceptos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Identificador,Descripcion,Estado")] TB_Conceptos tB_Conceptos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Conceptos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Conceptos);
        }

        // GET: TB_Conceptos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Conceptos tB_Conceptos = db.TB_Conceptos.Find(id);
            if (tB_Conceptos == null)
            {
                return HttpNotFound();
            }
            return View(tB_Conceptos);
        }

        // POST: TB_Conceptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Conceptos tB_Conceptos = db.TB_Conceptos.Find(id);
            db.TB_Conceptos.Remove(tB_Conceptos);
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
