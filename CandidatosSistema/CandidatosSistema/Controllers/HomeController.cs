using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandidatosSistema.Models;

namespace CandidatosSistema.Controllers
{
    public class HomeController : Controller
    {

        public static string CandidatosActivos() 
            {

            SisCandidatosEntities bd = new SisCandidatosEntities();
            var consultacadidatos = bd.Candidato.ToLookup(x => x.CandidatoId).Select(x => new { NoCandidatos = x.Count() }).ToList();
            string  NOCandidatosActivos = Convert.ToString(consultacadidatos.Count);
      
            return (NOCandidatosActivos);
            }

        SisCandidatosEntities bd = new SisCandidatosEntities();
       
      

        public ActionResult Index()
        {

            using (var bd = new SisCandidatosEntities())
            {
                var consultacadidatos = bd.Candidato.ToLookup(x => x.CandidatoId).Select(x => new { NoCandidatos = x.Count() }).ToList();
                string CandidatosActivos = Convert.ToString(consultacadidatos.Count);


                ViewBag.Message = CandidatosActivos;
                ViewBag.Saludo = "3";


            }



            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                using (var bd = new SisCandidatosEntities())
                {
                    var consultacadidatos = bd.Candidato.ToLookup(x => x.CandidatoId).Select(x => new { NoCandidatos = x.Count() }).ToList();
                    string CandidatosActivos = Convert.ToString(consultacadidatos.Count);


                    ViewBag.Message = CandidatosActivos;
                    ViewBag.Saludo = "Hola Mundo";


                }

    

                return RedirectToAction("AfterLogin");
            }


       

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


       public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Usuario u)
        {
            // esto es para enviar el metodo post
            if (ModelState.IsValid) // esto checa si el valido
            {
                using ( Models.SisCandidatosEntities dc = new Models.SisCandidatosEntities())
                {
                    var v = dc.Usuario.Where(a => a.Usuario1.Equals(u.Usuario1) && a.Clave.Equals(u.Clave)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UsuarioId.ToString();
                        Session["LogedUserFullname"] = v.Nombre.ToString();
                        return RedirectToAction("Index");
                    }
                }

            }
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }


        }




    }
}