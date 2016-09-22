using System;
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
    public class CapturistaController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Capturista
        public ActionResult Index()
        {
            var candidato = db.Candidato.Include(c => c.Escolaridad).Include(c => c.Localidad).Include(c => c.Sueldo).Include(c => c.Especialidad).Include(c => c.Estatus);
            return View(candidato.ToList());
        }

        // GET: Capturista/Details/5
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
            ViewBag.Fecha = Convert.ToString( DateTime.Today);
            ViewBag.Estado = true;




            //ViewBag.Capturista = "" 
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


        // GET: Capturista/Edit/5
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
            return View(candidato);
        }

        // POST: Capturista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo,Municipio_colonia,EstatusId,ComentarioEstatus,Area")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Busquedafilter");
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Descripcion", candidato.EspecialidadId);
            ViewBag.EstatusId = new SelectList(db.Estatus, "EstatusId", "Clave", candidato.EstatusId);
            return View(candidato);
        }

        // GET: Capturista/Delete/5
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

        // POST: Capturista/Delete/5
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

        public ActionResult Busquedafilter(string Nombre)
        {
            var Candidato = from s in db.Candidato select s;

            if (!string.IsNullOrEmpty(Nombre))
            {
                Candidato = Candidato.Where(x => x.Nombre.Contains(Nombre));
            }
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(Candidato);

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
