using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CandidatosSistema.Models;
using System.Web.Mvc;

namespace CandidatosSistema.Controllers
{
    public class GaficaConsultaController : Controller
    {
        // GET: GaficaConsulta
        public ActionResult Index()
        {

            using (var bd = new SisCandidatosEntities())
            {
                var data = bd.usp_Candidatos_Region();

                // esta llamada hace los mismo pero sin usar un sp
                // osea que es una consulta con LINQ y ya hciciste un join y agrupaste los datos. verdad? ok de hecho era lo que nesesitaba aun que todoavia no entiendo por que utilizaste el Usin y las llaves 


                var data2 = bd.Candidato.ToLookup(x => x.Localidad).Select(x =>new { Region  = x.Key.Descripcion, NumeroCandidatos=x.Count() });

             
            }

            

            return View();
        }
    }
}