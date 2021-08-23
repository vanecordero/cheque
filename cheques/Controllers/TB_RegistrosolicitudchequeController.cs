using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using cheques.Context;

namespace cheques.Controllers
{
    public class TB_RegistrosolicitudchequeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TB_Registrosolicitudcheque
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ActionResult Index()
        {
            var tB_Registrosolicitudcheque = db.TB_Registrosolicitudcheque.Include(t => t.TB_Conceptos).Include(t => t.TB_Proveedores);
            return View(tB_Registrosolicitudcheque.ToList());
        }

        // GET: TB_Registrosolicitudcheque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Registrosolicitudcheque tB_Registrosolicitudcheque = db.TB_Registrosolicitudcheque.Find(id);
            if (tB_Registrosolicitudcheque == null)
            {
                return HttpNotFound();
            }
            return View(tB_Registrosolicitudcheque);
        }

        // GET: TB_Registrosolicitudcheque/Create
        public ActionResult Create()
        {
            ViewBag.id_identificador = new SelectList(db.TB_Conceptos, "id_Identificador", "Descripcion");
            ViewBag.id_proveedor = new SelectList(db.TB_Proveedores, "id_proveedor", "Nombre");
            return View();
        }

        // POST: TB_Registrosolicitudcheque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_solicitud,id_proveedor,id_identificador,monto,fecha_registro,estado_estatus,cuenta_contable_proveedor,cuenta_empresa,id_asiento")] TB_Registrosolicitudcheque tB_Registrosolicitudcheque)
        {
            if (ModelState.IsValid)
            {
                db.TB_Registrosolicitudcheque.Add(tB_Registrosolicitudcheque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_identificador = new SelectList(db.TB_Conceptos, "id_Identificador", "Descripcion", tB_Registrosolicitudcheque.id_identificador);
            ViewBag.id_proveedor = new SelectList(db.TB_Proveedores, "id_proveedor", "Nombre", tB_Registrosolicitudcheque.id_proveedor);
            return View(tB_Registrosolicitudcheque);
        }

        // GET: TB_Registrosolicitudcheque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Registrosolicitudcheque tB_Registrosolicitudcheque = db.TB_Registrosolicitudcheque.Find(id);
            if (tB_Registrosolicitudcheque == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_identificador = new SelectList(db.TB_Conceptos, "id_Identificador", "Descripcion", tB_Registrosolicitudcheque.id_identificador);
            ViewBag.id_proveedor = new SelectList(db.TB_Proveedores, "id_proveedor", "Nombre", tB_Registrosolicitudcheque.id_proveedor);
            return View(tB_Registrosolicitudcheque);
        }

        // POST: TB_Registrosolicitudcheque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_solicitud,id_proveedor,id_identificador,monto,fecha_registro,estado_estatus,cuenta_contable_proveedor,cuenta_empresa,id_asiento")] TB_Registrosolicitudcheque tB_Registrosolicitudcheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Registrosolicitudcheque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_identificador = new SelectList(db.TB_Conceptos, "id_Identificador", "Descripcion", tB_Registrosolicitudcheque.id_identificador);
            ViewBag.id_proveedor = new SelectList(db.TB_Proveedores, "id_proveedor", "Nombre", tB_Registrosolicitudcheque.id_proveedor);
            return View(tB_Registrosolicitudcheque);
        }

        // GET: TB_Registrosolicitudcheque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Registrosolicitudcheque tB_Registrosolicitudcheque = db.TB_Registrosolicitudcheque.Find(id);
            if (tB_Registrosolicitudcheque == null)
            {
                return HttpNotFound();
            }
            return View(tB_Registrosolicitudcheque);
        }

        // POST: TB_Registrosolicitudcheque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Registrosolicitudcheque tB_Registrosolicitudcheque = db.TB_Registrosolicitudcheque.Find(id);
            db.TB_Registrosolicitudcheque.Remove(tB_Registrosolicitudcheque);
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
