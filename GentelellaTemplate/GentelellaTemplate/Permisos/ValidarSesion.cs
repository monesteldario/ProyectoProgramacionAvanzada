using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GentelellaTemplate.Permisos
{
    public class ValidarLogin : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Correo"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "InicioSesion",
                    Controller = "Usuarios"
                }));
            }
        }


    }
    public class ValidarReclutador : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Correo"] == null ||
                filterContext.HttpContext.Session["Rol"].ToString() != "1")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "InicioSesion",
                    Controller = "Usuarios"
                }));
            }
        }


    }

    public class ValidarCandidato : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Correo"] == null ||
                filterContext.HttpContext.Session["Rol"].ToString() != "2")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "InicioSesion",
                    Controller = "Usuarios"
                }));
            }
        }
    }
}