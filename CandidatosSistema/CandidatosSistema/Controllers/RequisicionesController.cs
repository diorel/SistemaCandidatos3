using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidatosSistema.Models;

namespace CandidatosSistema.Controllers
{
    public class RequisicionesController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Requisiciones
        public ActionResult Index()
        {
            var requisicion = db.Requisicion.Include(r => r.Empresa).Include(r => r.RequisicionArea).Include(r => r.RequisicionEstatus).Include(r => r.RequisicionLocalidad).Include(r => r.RequisicionSueldo).Include(r => r.UsuarioRequisicion);
            return View(requisicion.ToList());
        }




        //// GET: Requisiciones
        //public ActionResult Index()
        //{
        //    var requisicion = db.Requisicion.Include(r => r.Empresa).Include(r => r.RequisicionArea).Include(r => r.RequisicionEstatus).Include(r => r.RequisicionLocalidad).Include(r => r.RequisicionSueldo).Include(r => r.UsuarioRequisicion);
        //    return View(requisicion.ToList());
        //}

        // GET: Requisiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicion requisicion = db.Requisicion.Find(id);
            if (requisicion == null)
            {
                return HttpNotFound();
            }
            return View(requisicion);
        }

        // GET: Requisiciones/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");
            ViewBag.RequisicionAreaId = new SelectList(db.RequisicionArea, "RequisicionAreaId", "Clave");
            ViewBag.RequisicionEstatusId = new SelectList(db.RequisicionEstatus, "RequisicionEstatusId", "Clave");
            ViewBag.RequisicionLocalidadId = new SelectList(db.RequisicionLocalidad, "RequisicionLocalidadId", "Clave");
            ViewBag.RequisicionSueldoId = new SelectList(db.RequisicionSueldo, "RequisicionSueldoId", "Clave");
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo");
            return View();
        }

        // POST: Requisiciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequisicionId,RequisicionTitulo,RequisicionFecha,RequisicionAreaId,RequisicionLocalidadId,Delegacion_Municipio,RequisicionSueldoId,DescripcionRequisicion,RequisicionEstatusId,CometarioRequisicion,CantidadRequisicion,EmpresaId,UsuarioRequisicionId")] Requisicion requisicion)
        {
            if (ModelState.IsValid)
            {
                db.Requisicion.Add(requisicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", requisicion.EmpresaId);
            ViewBag.RequisicionAreaId = new SelectList(db.RequisicionArea, "RequisicionAreaId", "Clave", requisicion.RequisicionAreaId);
            ViewBag.RequisicionEstatusId = new SelectList(db.RequisicionEstatus, "RequisicionEstatusId", "Clave", requisicion.RequisicionEstatusId);
            ViewBag.RequisicionLocalidadId = new SelectList(db.RequisicionLocalidad, "RequisicionLocalidadId", "Clave", requisicion.RequisicionLocalidadId);
            ViewBag.RequisicionSueldoId = new SelectList(db.RequisicionSueldo, "RequisicionSueldoId", "Clave", requisicion.RequisicionSueldoId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", requisicion.UsuarioRequisicionId);
            return View(requisicion);
        }

        // GET: Requisiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicion requisicion = db.Requisicion.Find(id);
            if (requisicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", requisicion.EmpresaId);
            ViewBag.RequisicionAreaId = new SelectList(db.RequisicionArea, "RequisicionAreaId", "Clave", requisicion.RequisicionAreaId);
            ViewBag.RequisicionEstatusId = new SelectList(db.RequisicionEstatus, "RequisicionEstatusId", "Clave", requisicion.RequisicionEstatusId);
            ViewBag.RequisicionLocalidadId = new SelectList(db.RequisicionLocalidad, "RequisicionLocalidadId", "Clave", requisicion.RequisicionLocalidadId);
            ViewBag.RequisicionSueldoId = new SelectList(db.RequisicionSueldo, "RequisicionSueldoId", "Clave", requisicion.RequisicionSueldoId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", requisicion.UsuarioRequisicionId);
            return View(requisicion);
        }

        // POST: Requisiciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequisicionId,RequisicionTitulo,RequisicionFecha,RequisicionAreaId,RequisicionLocalidadId,Delegacion_Municipio,RequisicionSueldoId,DescripcionRequisicion,RequisicionEstatusId,CometarioRequisicion,CantidadRequisicion,EmpresaId,UsuarioRequisicionId")] Requisicion requisicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", requisicion.EmpresaId);
            ViewBag.RequisicionAreaId = new SelectList(db.RequisicionArea, "RequisicionAreaId", "Clave", requisicion.RequisicionAreaId);
            ViewBag.RequisicionEstatusId = new SelectList(db.RequisicionEstatus, "RequisicionEstatusId", "Clave", requisicion.RequisicionEstatusId);
            ViewBag.RequisicionLocalidadId = new SelectList(db.RequisicionLocalidad, "RequisicionLocalidadId", "Clave", requisicion.RequisicionLocalidadId);
            ViewBag.RequisicionSueldoId = new SelectList(db.RequisicionSueldo, "RequisicionSueldoId", "Clave", requisicion.RequisicionSueldoId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", requisicion.UsuarioRequisicionId);
            return View(requisicion);
        }

        // GET: Requisiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicion requisicion = db.Requisicion.Find(id);
            if (requisicion == null)
            {
                return HttpNotFound();
            }
            return View(requisicion);
        }

        // POST: Requisiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisicion requisicion = db.Requisicion.Find(id);
            db.Requisicion.Remove(requisicion);
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
