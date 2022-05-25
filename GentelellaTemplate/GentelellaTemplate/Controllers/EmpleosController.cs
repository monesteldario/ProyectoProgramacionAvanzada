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
    public class EmpleosController : Controller
    {
        // APIs

        EmpleosModel modelEmpleos = new EmpleosModel();
        UsuariosModel modelUsuarios = new UsuariosModel();
        SolicitudesModel modelSolicitudes = new SolicitudesModel();

        [HttpGet]
        [ValidarLogin]
        [ValidarCandidato]
        public ActionResult BusquedaEmpleos()
        {
            try
            {
                var resultado = modelEmpleos.ConsultarEmpleos();
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "BusquedaEmpleos", Session["Correo"] as string);
                return View();
            }
        }

        [HttpGet]
        [ValidarLogin]
        public ActionResult VerEmpleo(long q)
        {
            try
            {
                Session["Aplicado"] = modelSolicitudes.EmpleoAplicado(Session["Correo"] as string, q);
                var resultado = modelEmpleos.ConsultarEmpleo(q);
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "VerEmpleo", Session["Correo"] as string);
                return RedirectToAction("BusquedaEmpleos", "Empleos");
            }
        }

        [HttpGet]
        [Route("api/Empleos/FiltrarPorReclutador")]
        public EmpleosRespuestaOBJ FiltrarPorReclutador(string correoReclutador)
        {
            try
            {
                var resultado = modelEmpleos.FiltrarPorReclutador(correoReclutador);
                return modelEmpleos.ArmarRespuesta(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "FiltrarPorReclutador", Session["Correo"] as string);
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        public ActionResult CrearEmpleo()
        {
            try
            {
                ViewBag.categorias = modelEmpleos.ConsultarCategorias();
                ViewBag.estudios = modelEmpleos.LlenarEstudios();
                return View(new EmpleosOBJ());
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "CrearEmpleo", Session["Correo"] as string);
                return View(new EmpleosOBJ());
            }
        }

        [HttpPost]
        public ActionResult InsertarEmpleo(EmpleosOBJ empleo)
        {
            try
            {
                empleo.correo_reclutador = Session["Correo"] as string;
                modelEmpleos.InsertarEmpleo(empleo);
                Session["Mensaje"] = "¡El empleo se publicó correctamente!";
                return RedirectToAction("EmpleosPublicados", "Empleos");

            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "InsertarEmpleo", Session["Correo"] as string);
                return View(empleo);
            }
        }

        [HttpGet]
        [ValidarLogin]
        public ActionResult VerEmpleosPorCategoria()
        {
            try
            {

                var resultado = modelEmpleos.VerCategorias();
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "VerEmpleosPorCategoria", Session["Correo"] as string);
                return View();
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarCandidato]
        public ActionResult VerEmpleosFiltrados(long q)
        {
            try
            {
                ViewBag.categorias = modelEmpleos.ConsultarCategorias();
                var resultado = modelEmpleos.ConsultarEmpleosPorCategoria(q);
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "VerEmpleosFiltrados", Session["Correo"] as string);
                return View();
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        public ActionResult EmpleosPublicados()
        {
            try
            {
                ViewBag.categorias = modelEmpleos.ConsultarCategorias();
                var reclutador = Session["Correo"] as string;
                var resultado = modelEmpleos.FiltrarPorReclutador(reclutador);
                return View(resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "EmpleosPublicados", Session["Correo"] as string);
                return View();
            }
        }


        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        public ActionResult EditarEmpleo(long q)
        {
            try
            {
                ViewBag.categorias = modelEmpleos.ConsultarCategorias();
                ViewBag.estudios = modelEmpleos.LlenarEstudios();
                ViewBag.estado = modelEmpleos.LlenarEstado();

                var resultado = modelEmpleos.ConsultarEmpleo(q);
                return View(resultado);

            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "EditarEmpleo", Session["Correo"] as string);
                return View();
            }
        }


        [HttpPost]
        public ActionResult EditarEmpleo(EmpleosOBJ empleo)
        {
            try
            {
                empleo.correo_reclutador = Session["Correo"] as string;
                modelEmpleos.ActualizarEmpleo(empleo);

                return RedirectToAction("EmpleosPublicados", "Empleos");

            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "EditarEmpleo", Session["Correo"] as string);
                return View(empleo);
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarCandidato]
        public ActionResult EmpleoInteligente()
        {
            try
            {

                var candidato = modelUsuarios.ConsultarCandidato(Session["Correo"] as string);
                var resultado = modelEmpleos.EmpleoInteligente((int)candidato.area_interes, candidato.experiencia, candidato.grado_estudio);
                return View("BusquedaEmpleos", resultado);
            }
            catch (Exception ex)
            {
                modelEmpleos.RegistrarBitacora(ex.Message, "EmpleoInteligente", Session["Correo"] as string);
                return View("BusquedaEmpleos");
            }
        }


    }
}