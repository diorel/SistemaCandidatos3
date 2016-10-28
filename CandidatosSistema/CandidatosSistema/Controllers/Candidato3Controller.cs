﻿using System;
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
    public class Candidato3Controller : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Candidato3
        public ActionResult Index()
        {
            var candidato = db.Candidato.Include(c => c.Escolaridad).Include(c => c.Localidad).Include(c => c.Sueldo).Include(c => c.Especialidad).Include(c => c.Estatus).Include(c => c.Empresa);
            return View(candidato.ToList());
        }

        // GET: Candidato3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: Candidato3/Create
        public ActionResult Create()
        {
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Descripcion");
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave");
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");
            return View();
        }

        // POST: Candidato3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo,Municipio_colonia,EstatusId,ComentarioEstatus,Area,EmpresaId")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Candidato.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Descripcion", candidato.EspecialidadId);
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave", candidato.EstatusId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", candidato.EmpresaId);
            return View(candidato);
        }

        // GET: Candidato3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Descripcion", candidato.EspecialidadId);
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave", candidato.EstatusId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", candidato.EmpresaId);
            return View(candidato);
        }

        // POST: Candidato3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo,Municipio_colonia,EstatusId,ComentarioEstatus,Area,EmpresaId")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Descripcion", candidato.EspecialidadId);
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave", candidato.EstatusId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", candidato.EmpresaId);
            return View(candidato);
        }

        // GET: Candidato3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Candidato3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidato.Find(id);
            db.Candidato.Remove(candidato);
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
