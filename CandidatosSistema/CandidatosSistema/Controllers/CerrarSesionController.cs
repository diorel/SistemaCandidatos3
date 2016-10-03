using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidatosSistema.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult Index()
        {

            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

     
            
           // return RedirectToAction("Home","Login" );
           // return View("Home", "Login");

            return View();

            // return PartialView("_Layout");

        }
    }
}