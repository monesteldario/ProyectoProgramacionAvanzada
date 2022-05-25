using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GentelellaTemplate.Models;
using GentelellaTemplate.Entities;
using GentelellaTemplate.BaseDatos;
using GentelellaTemplate.Permisos;

namespace GentelellaTemplate.Controllers
{
    public class UsuariosController : Controller
    {
        // APIs 
        UsuariosModel model = new UsuariosModel();
        EmpleosModel modelEmpleos = new EmpleosModel();

        [HttpPost]

        public ActionResult Login(string correo, string contrasena)
        {
            try
            {
                var resultado = model.ConsultarLogin(correo, contrasena);
                if (resultado.Count() >= 1)
                {

                    Session["Rol"] = resultado[0].id_rol.ToString();
                    Session["Correo"] = resultado[0].correo;
                    Session["Mensaje"] = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    return View();
                }
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "Login", Session["Correo"] as string);
                throw ex;

            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarUsuario")]
        public UsuariosClaveOBJ ConsultarUsuario(String correo)
        {
            try
            {
                var resultado = model.ConsultarUsuario(correo);

                return resultado;
            }

            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "ConsultarUsuario", Session["Correo"] as string);
                return new UsuariosClaveOBJ();
            }
        }


        [HttpGet]
        [Route("api/Usuarios/ConsultarCandidato")]
        public CandidatosOBJ ConsultarCandidato(String correo)
        {
            try
            {
                var resultado = model.ConsultarCandidato(correo);

                return resultado;
            }

            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "ConsultarCandidato", Session["Correo"] as string);
                return new CandidatosOBJ();
            }
        }


        [HttpGet]
        [Route("api/Usuarios/ConsultarReclutador")]
        public ReclutadoresOBJ ConsultarReclutadores(String correo)
        {
            try
            {
                var resultado = model.ConsultarReclutador(correo);

                return resultado;
            }

            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "ConsultarReclutadores", Session["Correo"] as string);
                return new ReclutadoresOBJ();
            }
        }

        [HttpPost]
        public ActionResult RegistrarReclutador(UsuarioReclutadorOBJ reclutador)
        {
            if (reclutador.contrasena.Equals(reclutador.confirmar_contrasena))
            {
                try
                {
                    UsuariosOBJ usuario = new UsuariosOBJ();
                    usuario.correo = reclutador.correo_reclutador;
                    usuario.contrasena = reclutador.contrasena;
                    usuario.id_rol = 1;

                    model.RegistrarUsuario(usuario);
                    model.RegistrarReclutador(reclutador);
                    Session["Mensaje"] = "¡Te has registrado correctamente!";
                    return RedirectToAction("InicioSesion", "Usuarios");
                }
                catch (Exception ex)
                {
                    model.RegistrarBitacora(ex.Message, "RegistrarReclutador", Session["Correo"] as string);
                    throw ex;

                }
            }
            else
            {
                return View();

            }
        }

        [HttpPost]
        public ActionResult RegistrarCandidato(UsuarioCandidatoOBJ candidato)
        {
            if (candidato.contrasena.Equals(candidato.confirmar_contrasena))
            {
                try
                {
                    UsuariosOBJ usuario = new UsuariosOBJ();
                    usuario.correo = candidato.correo_candidato;
                    usuario.contrasena = candidato.contrasena;
                    usuario.id_rol = 2;

                    model.RegistrarUsuario(usuario);
                    model.RegistrarCandidato(candidato);
                    Session["Mensaje"] = "¡Te has registrado correctamente!";
                    return RedirectToAction("InicioSesion", "Usuarios");

                }
                catch (Exception ex)
                {
                    model.RegistrarBitacora(ex.Message, "RegistrarCandidato", Session["Correo"] as string);
                    throw ex;

                }
            }
            else
            {
                return View();

            }
        }


        [HttpPut]
        [Route("api/Usuarios/ActualizarReclutador")]
        public ReclutadoresRespuestaOBJ ActualizarReclutador(ReclutadoresOBJ reclutador)
        {
            using (var context = new WorknetEntities())
                try
                {
                    model.ActualizarReclutador(reclutador);
                    return model.RespuestaReclutador(0, "Reclutador actualizado.", new List<ReclutadoresOBJ>());


                }
                catch (Exception ex)
                {
                    model.RegistrarBitacora(ex.Message, "ActualizarReclutador", Session["Correo"] as string);
                    return model.RespuestaReclutador(99, ex.Message, new List<ReclutadoresOBJ>());
                }
        }

        [HttpPut]

        [Route("api/Usuarios/ActualizarCandidato")]
        public CandidatosRespuestaOBJ ActualizarCandidato(CandidatosOBJ candidato)
        {
            using (var context = new WorknetEntities())
                try
                {
                    model.ActualizarCandidato(candidato);
                    return model.RespuestaCandidato(0, "Candidato actualizado.", new List<CandidatosOBJ>());


                }
                catch (Exception ex)
                {
                    model.RegistrarBitacora(ex.Message, "ActualizarCandidato", Session["Correo"] as string);
                    return model.RespuestaCandidato(99, ex.Message, new List<CandidatosOBJ>());
                }
        }

        [HttpPost]
        [Route("api/Usuarios/InsertarUsuario")]
        public UsuariosRespuestaOBJ InsertarUsuario(UsuariosOBJ usuario)
        {
            try
            {
                model.RegistrarUsuario(usuario);
                List<UsuariosOBJ> usuarioInsertado = new List<UsuariosOBJ>();
                usuarioInsertado.Add(usuario);
                return model.ArmarRespuesta(0, "Usuario registrado correctamente.", usuarioInsertado);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "InsertarUsuario", Session["Correo"] as string);
                return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
            }

        }

        // Views
        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        public ActionResult Candidatos()
        {
            try
            {
                var resultado = model.ConsultarCandidatos();
                return View(resultado);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "Candidatos", Session["Correo"] as string);
                return View();
            }
        }

        [HttpGet]
        public ActionResult InicioSesion()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult RegistroCandidato()
        {
            try
            {
                var categorias = new UsuarioCandidatoOBJ();
                ViewBag.comboCategorias = model.ConsultarTodaslasCategorias();
                ViewBag.estudios = modelEmpleos.LlenarEstudios();
                return View();
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "RegistroCandidato", Session["Correo"] as string);
                return View();

            }

        }

        [HttpGet]
        public ActionResult RegistroReclutador()
        {
            return View();
        }
        // Views
        [HttpGet]
        [ValidarLogin]
        [ValidarReclutador]
        public ActionResult EditarReclutador()
        {
            try
            {
                var correo = Session["Correo"] as string;
                var resultado = ConsultarReclutadores(correo);
                ViewBag.reclutador = resultado;

                return View(ViewBag.reclutador);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "EditarReclutador", Session["Correo"] as string);
                return View();
            }

        }

        [HttpPost]
        public ActionResult ReclutadorEditado(ReclutadoresOBJ reclutador)
        {
            try
            {
                ActualizarReclutador(reclutador);
                //agregar mensaje de validación de datos actualizados.
                return View("EditarReclutador", reclutador);

            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "ReclutadorEditado", Session["Correo"] as string);
                return View("EditarReclutador", reclutador);
            }
        }

        [HttpGet]
        [ValidarLogin]
        [ValidarCandidato]
        public ActionResult EditarCandidato()
        {
            try
            {
                var correo = Session["Correo"] as string;
                var resultado = ConsultarCandidato(correo);
                ViewBag.cat = modelEmpleos.ConsultarCategorias();
                ViewBag.estudios = modelEmpleos.LlenarEstudios();
                return View(resultado);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "EditarCandidato", Session["Correo"] as string);
                return View();

            }

        }

        [HttpPost]
        public ActionResult CandidatoEditado(CandidatosOBJ candidato)
        {
            try
            {
                ActualizarCandidato(candidato);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "CandidatoEditado", Session["Correo"] as string);
                return View(candidato);
            }
        }

        [HttpGet]
        [ValidarLogin]
        public ActionResult CambiarClave()
        {
            try
            {
                var correo = Session["Correo"] as string;
                var resultado = ConsultarUsuario(correo);
                return View(resultado);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora(ex.Message, "CambiarClave", Session["Correo"] as string);
                return View();
            }

        }

        [HttpPost]
        [Route("api/Usuarios/ActualizarClave")]
        public ActionResult ConfirmarCambioClave(UsuariosClaveOBJ usuario)
        {
            using (var context = new WorknetEntities())
                try
                {
                    model.CambiarClave(usuario);

                    return RedirectToAction("CambiarClave", "Usuarios");

                }
                catch (Exception ex)
                {
                    model.RegistrarBitacora(ex.Message, "ConfirmarCambioClave", Session["Correo"] as string);
                    return View(usuario);
                }
        }

    }
}