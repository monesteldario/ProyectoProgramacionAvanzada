using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GentelellaTemplate.Models;
using GentelellaTemplate.Entities;
using GentelellaTemplate.Permisos;

namespace GentelellaTemplate.Controllers
{
    public class SolicitudesController : Controller
    {

        //APIs
        SolicitudesModel modelSolicitudes = new SolicitudesModel();

        [HttpGet]
        [ValidarLogin]
        [Route("api/Solicitudes/ConsultarSolicitudes")]
        public ConsultaSolicitudesRespuestaOBJ ConsultarSolicitudes()
        {
            try
            {
                var resultado = modelSolicitudes.ConsultarSolicitudes(Session["Correo"] as string);
                return modelSolicitudes.RespuestaConsulta(0, "OK", resultado);
            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "ConsultarSolicitudes", Session["Correo"] as string);
                return modelSolicitudes.RespuestaConsulta(99, ex.Message, new List<ConsultaSolicitudesOBJ>());
            }
        }


        [HttpGet]
        [ValidarLogin]
        [Route("api/Solicitudes/ConsultarSolicitudPorID")]
        public ConsultaSolicitudesOBJ ConsultarSolicitudPorId(long id)
        {
            try
            {
                var resultado = modelSolicitudes.ConsultarSolicitudesPorID(id);

                return resultado;
            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "ConsultarSolicitudPorId", Session["Correo"] as string);
                return new ConsultaSolicitudesOBJ();
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        [Route("api/Solicitudes/VerSolicitudes")]
        public ConsultaSolicitudesRespuestaOBJ VerSolicitudes()
        {
            try
            {
                var resultado = modelSolicitudes.VerSolicitudes();
                return modelSolicitudes.RespuestaConsulta(0, "OK", resultado);
            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "VerSolicitudes", Session["Correo"] as string);
                return modelSolicitudes.RespuestaConsulta(99, ex.Message, new List<ConsultaSolicitudesOBJ>());
            }
        }

        [HttpPost]
        public ActionResult InsertarSolicitud(SolicitudesOBJ solicitud)
        {
            try
            {
                solicitud.correo_candidato = Session["Correo"] as string;
                modelSolicitudes.InsertarSolicitud(solicitud);
                Session["Mensaje"] = "¡Solicitud Enviada!";
                return RedirectToAction("Solicitudes", "Solicitudes");
            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "InsertarSolicitud", Session["Correo"] as string);
                return View("VerEmpleo", solicitud);
            }
        }

        // Views

        [HttpGet]
        [ValidarLogin]
        public ActionResult Solicitudes()
        {
            try
            {
                var solicitudes = modelSolicitudes.ConsultarSolicitudes(Session["Correo"] as string);
                return View(solicitudes);

            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "Solicitudes", Session["Correo"] as string);
                return View();
            }


        }

        [HttpGet]
        [ValidarLogin]
        public ActionResult verSolicitud(long q)
        {

            try
            {
                var resultado = ConsultarSolicitudPorId(q);
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelSolicitudes.RegistrarBitacora(ex.Message, "verSolicitud", Session["Correo"] as string);
                return RedirectToAction("Solicitudes", "Solicitudes");
            }
        }
    }
}