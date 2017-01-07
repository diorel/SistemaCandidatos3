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
    public class EmpresaUsuarioRequisicionesController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: EmpresaUsuarioRequisiciones
        public ActionResult Index()
        {
            var empresaUsuarioRequisicion = db.EmpresaUsuarioRequisicion.Include(e => e.Empresa).Include(e => e.UsuarioRequisicion);
            return View(empresaUsuarioRequisicion.ToList());
        }

        // GET: EmpresaUsuarioRequisiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUsuarioRequisicion empresaUsuarioRequisicion = db.EmpresaUsuarioRequisicion.Find(id);
            if (empresaUsuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            return View(empresaUsuarioRequisicion);
        }

        // GET: EmpresaUsuarioRequisiciones/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo");
            return View();
        }

        // POST: EmpresaUsuarioRequisiciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpresaUsuarioRequisicion,EmpresaId,UsuarioRequisicionId,Descripcion")] EmpresaUsuarioRequisicion empresaUsuarioRequisicion)
        {
            if (ModelState.IsValid)
            {
                db.EmpresaUsuarioRequisicion.Add(empresaUsuarioRequisicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", empresaUsuarioRequisicion.EmpresaId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", empresaUsuarioRequisicion.UsuarioRequisicionId);
            return View(empresaUsuarioRequisicion);
        }

        // GET: EmpresaUsuarioRequisiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUsuarioRequisicion empresaUsuarioRequisicion = db.EmpresaUsuarioRequisicion.Find(id);
            if (empresaUsuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", empresaUsuarioRequisicion.EmpresaId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", empresaUsuarioRequisicion.UsuarioRequisicionId);
            return View(empresaUsuarioRequisicion);
        }

        // POST: EmpresaUsuarioRequisiciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpresaUsuarioRequisicion,EmpresaId,UsuarioRequisicionId,Descripcion")] EmpresaUsuarioRequisicion empresaUsuarioRequisicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresaUsuarioRequisicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", empresaUsuarioRequisicion.EmpresaId);
            ViewBag.UsuarioRequisicionId = new SelectList(db.UsuarioRequisicion, "UsuarioRequisicionId", "Correo", empresaUsuarioRequisicion.UsuarioRequisicionId);
            return View(empresaUsuarioRequisicion);
        }

        // GET: EmpresaUsuarioRequisiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUsuarioRequisicion empresaUsuarioRequisicion = db.EmpresaUsuarioRequisicion.Find(id);
            if (empresaUsuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            return View(empresaUsuarioRequisicion);
        }

        // POST: EmpresaUsuarioRequisiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpresaUsuarioRequisicion empresaUsuarioRequisicion = db.EmpresaUsuarioRequisicion.Find(id);
            db.EmpresaUsuarioRequisicion.Remove(empresaUsuarioRequisicion);
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
