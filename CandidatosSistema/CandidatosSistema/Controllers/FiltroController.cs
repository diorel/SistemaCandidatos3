﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidatosSistema.Models;
using System.IO;

namespace CandidatosSistema.Controllers
{
    public class FiltroController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();


        // GET: Candidato
        public ActionResult Index()
        {
            var candidato = db.Candidato.Include(c => c.Escolaridad).Include(c => c.Especialidad).Include(c => c.Localidad).Include(c => c.Sueldo);
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(candidato.ToList());
        }

        // GET: Candidato/Details/5
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
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(candidato);
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave");
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave");

            ViewBag.Title = "Index";
            ViewBag.Nombre = @Session["LogedUserFullname"].ToString();
            ViewBag.Fecha = Convert.ToString(DateTime.Today);
            ViewBag.Estado = true;



            return View();
        }



        // POST: Candidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CandisatoId,Nombre,Telefono,Correo,LocalidadId,Municipio_colonia,SueldoId,EscolaridadId,EspecialidadId,Area,EstadoCandidato,Capturista,FechaCaptura,EstatusId,ComentarioEstatus,Archivo")] Candidato candidato,
            HttpPostedFileBase Archivo)
        {
            if (ModelState.IsValid)
            {
                candidato.Archivo = null;
                if (Archivo != null && Archivo.ContentLength > 0)  //en esta parte validamos que existe un archivo y que su tamaño del archivo tiene que set mayor  a 0
                {
                    var fileName = Guid.NewGuid().ToString();
                    fileName += Path.GetExtension(Archivo.FileName);

                    var route = Server.MapPath(Properties.Settings.Default.CarpetaArchivos);

                    route = Path.Combine(route, fileName);

                    Archivo.SaveAs(route);
                    candidato.Archivo = fileName;
                }

                candidato.EstadoCandidato = true;
                candidato.EstatusId = 1;


                db.Candidato.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Busquedafilter");
            }

            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.LocalidadId = new SelectList(db.Estatus, "EstatusId", "Clave", candidato.EstatusId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // GET: Candidato/Edit/5
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
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo")] Candidato candidato,
            HttpPostedFileBase NuevoArchivo)
        {
            if (ModelState.IsValid)
            {
                if (NuevoArchivo != null && NuevoArchivo.ContentLength > 0)  //en esta parte validamos que existe un archivo y que su tamaño del archivo tiene que set mayor  a 0
                {
                    var fileName = Guid.NewGuid().ToString();
                    fileName += Path.GetExtension(NuevoArchivo.FileName);

                    var route = Server.MapPath(Properties.Settings.Default.CarpetaArchivos);

                    route = Path.Combine(route, fileName);

                    NuevoArchivo.SaveAs(route);
                    candidato.Archivo = fileName;
                }

                db.Candidato.Attach(candidato);
                db.Entry<Candidato>(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // GET: Candidato/Delete/5
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


        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidato.Find(id);
            db.Candidato.Remove(candidato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // Este es el metodo para la consulta

        public ActionResult Busquedafilter(string Nombre, string LocalidadId, string SueldoId, string EscolaridadId, string EspecialidadId)
        {
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave");

            var Candidato = from s in db.Candidato select s;

            if (!string.IsNullOrEmpty(Nombre))
            {
                Candidato = Candidato.Where(x => x.Nombre.Contains(Nombre));
            }

            if (!string.IsNullOrEmpty(LocalidadId))
            {
                int gr = Convert.ToInt32(LocalidadId);
                return View(Candidato.Where(x => x.LocalidadId == gr));
            }
            if (!string.IsNullOrEmpty(SueldoId))
            {
                int sl = Convert.ToInt32(SueldoId);
                return View(Candidato.Where(X => X.SueldoId == sl));
            }
            if (!string.IsNullOrEmpty(EscolaridadId))
            {
                int es = Convert.ToInt32(EscolaridadId);
                return View(Candidato.Where(x => x.EscolaridadId == es));
            }
            if (!string.IsNullOrEmpty(EspecialidadId))
            {
                int ec = Convert.ToInt32(EspecialidadId);
                return View(Candidato.Where(x => x.EspecialidadId == ec));
            }

            else
            {
                ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
                return View(Candidato);
            }
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
