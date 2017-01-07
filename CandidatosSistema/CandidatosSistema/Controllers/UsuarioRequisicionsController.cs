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
    public class UsuarioRequisicionsController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: UsuarioRequisicions
        public ActionResult Index()
        {
            return View(db.UsuarioRequisicion.ToList());
        }

        // GET: UsuarioRequisicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRequisicion usuarioRequisicion = db.UsuarioRequisicion.Find(id);
            if (usuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRequisicion);
        }

        // GET: UsuarioRequisicions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioRequisicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioRequisicionId,Correo,Usuario,Contecraseña,EstadoUsuario,FechaAlta")] UsuarioRequisicion usuarioRequisicion)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioRequisicion.Add(usuarioRequisicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioRequisicion);
        }

        // GET: UsuarioRequisicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRequisicion usuarioRequisicion = db.UsuarioRequisicion.Find(id);
            if (usuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRequisicion);
        }

        // POST: UsuarioRequisicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioRequisicionId,Correo,Usuario,Contecraseña,EstadoUsuario,FechaAlta")] UsuarioRequisicion usuarioRequisicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioRequisicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioRequisicion);
        }

        // GET: UsuarioRequisicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRequisicion usuarioRequisicion = db.UsuarioRequisicion.Find(id);
            if (usuarioRequisicion == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRequisicion);
        }

        // POST: UsuarioRequisicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioRequisicion usuarioRequisicion = db.UsuarioRequisicion.Find(id);
            db.UsuarioRequisicion.Remove(usuarioRequisicion);
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
