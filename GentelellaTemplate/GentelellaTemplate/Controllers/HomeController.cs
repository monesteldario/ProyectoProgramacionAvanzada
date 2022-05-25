using GentelellaTemplate.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GentelellaTemplate.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Correo"] = null;
            Session["Rol"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("InicioSesion", "Usuarios");
        }


    }
}