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
    public class VacantesController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Vacantes
        public ActionResult Index(string VacanteLocalidadId, string VacanteSueldoId , string VacanteAreaId,string EmpresaId)
        {

            ViewBag.VacanteLocalidadId = new SelectList(db.VacanteLocalidad, "VacanteLocalidadId", "Clave");
            ViewBag.VacanteSueldoId = new SelectList(db.VacanteSueldo, "VacanteSueldoId", "Clave");
            ViewBag.VacanteAreaId = new SelectList(db.VacanteArea, "VacanteAreaId", "Clave");
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");

            var Candidato = from s in db.Vacante select s;


            if (!string.IsNullOrEmpty(VacanteLocalidadId))
            {
                int es = Convert.ToInt32(VacanteLocalidadId);
                return View(Candidato.Where(x => x.VacanteLocalidadId == es));
            }

            if (!string.IsNullOrEmpty(VacanteSueldoId))
            {
                int gr = Convert.ToInt32(VacanteSueldoId);
                return View(Candidato.Where(x => x.VacanteSueldoId == gr));
            }
            if (!string.IsNullOrEmpty(VacanteAreaId))
            {
                int sl = Convert.ToInt32(VacanteAreaId);
                return View(Candidato.Where(X => X.VacanteAreaId == sl));
            }

            if (!string.IsNullOrEmpty(EmpresaId))
            {
                int ec = Convert.ToInt32(EmpresaId);
                return View(Candidato.Where(x => x.EmpresaId == ec));
            }

            //if (!string.IsNullOrEmpty(EmpresaId))
            //{
            //    int et = Convert.ToInt32(EmpresaId);
            //    return View(Candidato.Where(x => x.EmpresaId == et));
            //}


            else
            {
                ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
                return View(Candidato);
            }


            //var vacante = db.Vacante.Include(v => v.VacanteArea).Include(v => v.VacanteEstatus).Include(v => v.VacanteLocalidad).Include(v => v.VacanteSueldo).Include(v => v.Empresa);
            //return View(vacante.ToList());
        }

        // GET: Vacantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // GET: Vacantes/Create
        public ActionResult Create()
        {
            ViewBag.VacanteAreaId = new SelectList(db.VacanteArea, "VacanteAreaId", "Clave");
            ViewBag.VacanteEstatusId = new SelectList(db.VacanteEstatus, "VacanteEstatusId", "Clave");
            ViewBag.VacanteLocalidadId = new SelectList(db.VacanteLocalidad, "VacanteLocalidadId", "Clave");
            ViewBag.VacanteSueldoId = new SelectList(db.VacanteSueldo, "VacanteSueldoId", "Clave");
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");
            return View();
        }

        // POST: Vacantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacanteId,VacanteTitulo,VacanteFecha,VacanteAreaId,VacanteLocalidadId,Delegacion_Municipio,VacanteSueldoId,DescripcionVacante,VacanteEstatusId,CometarioVacante,EmpresaId,RepresentanteEmpresa")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Vacante.Add(vacante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VacanteAreaId = new SelectList(db.VacanteArea, "VacanteAreaId", "Clave", vacante.VacanteAreaId);
            ViewBag.VacanteEstatusId = new SelectList(db.VacanteEstatus, "VacanteEstatusId", "Clave", vacante.VacanteEstatusId);
            ViewBag.VacanteLocalidadId = new SelectList(db.VacanteLocalidad, "VacanteLocalidadId", "Clave", vacante.VacanteLocalidadId);
            ViewBag.VacanteSueldoId = new SelectList(db.VacanteSueldo, "VacanteSueldoId", "Clave", vacante.VacanteSueldoId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", vacante.EmpresaId);
            return View(vacante);
        }

        // GET: Vacantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            ViewBag.VacanteAreaId = new SelectList(db.VacanteArea, "VacanteAreaId", "Clave", vacante.VacanteAreaId);
            ViewBag.VacanteEstatusId = new SelectList(db.VacanteEstatus, "VacanteEstatusId", "Clave", vacante.VacanteEstatusId);
            ViewBag.VacanteLocalidadId = new SelectList(db.VacanteLocalidad, "VacanteLocalidadId", "Clave", vacante.VacanteLocalidadId);
            ViewBag.VacanteSueldoId = new SelectList(db.VacanteSueldo, "VacanteSueldoId", "Clave", vacante.VacanteSueldoId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", vacante.EmpresaId);
            return View(vacante);
        }

        // POST: Vacantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacanteId,VacanteTitulo,VacanteFecha,VacanteAreaId,VacanteLocalidadId,Delegacion_Municipio,VacanteSueldoId,DescripcionVacante,VacanteEstatusId,CometarioVacante,EmpresaId,RepresentanteEmpresa")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VacanteAreaId = new SelectList(db.VacanteArea, "VacanteAreaId", "Clave", vacante.VacanteAreaId);
            ViewBag.VacanteEstatusId = new SelectList(db.VacanteEstatus, "VacanteEstatusId", "Clave", vacante.VacanteEstatusId);
            ViewBag.VacanteLocalidadId = new SelectList(db.VacanteLocalidad, "VacanteLocalidadId", "Clave", vacante.VacanteLocalidadId);
            ViewBag.VacanteSueldoId = new SelectList(db.VacanteSueldo, "VacanteSueldoId", "Clave", vacante.VacanteSueldoId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave", vacante.EmpresaId);
            return View(vacante);
        }

        // GET: Vacantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // POST: Vacantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacante vacante = db.Vacante.Find(id);
            db.Vacante.Remove(vacante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Este es el metodo para consulatar las vacacntes 

        public ActionResult BusquedaVacante(string Nombre, string LocalidadId, string SueldoId, string EscolaridadId, string EspecialidadId, string EstatusId, string EmpresaId)
        {
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Clave");
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave");
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "Clave");

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
            if (!string.IsNullOrEmpty(EstatusId))
            {
                int et = Convert.ToInt32(EstatusId);
                return View(Candidato.Where(x => x.EstatusId == et));
            }
            if (!string.IsNullOrEmpty(EmpresaId))
            {
                int em = Convert.ToInt32(EmpresaId);
                return View(Candidato.Where(x => x.EmpresaId == em));
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
