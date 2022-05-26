using ProyectoPrograAvnzd.BaseDatos;
using ProyectoPrograAvnzd.Entities;
using ProyectoPrograAvnzd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoPrograAvnzd.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosModel model = new UsuariosModel();

        [HttpGet]
        [Route("api/Usuarios/LoginUsuario")]
        public UsuariosRespuestaOBJ Login(string correo, string contrasena)
        {
            try
            {
                var resultado = model.ConsultarLogin(correo, contrasena);
                if (resultado.Count() >= 1)
                {
                    return model.ArmarRespuesta(0, "Login exitoso", resultado);
                }
                else
                {
                    return model.ArmarRespuesta(99, "Usuario o contraseña incorrectos.", new List<UsuariosOBJ>());
                }
            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarUsuario")]
        public UsuariosRespuestaOBJ ConsultarUsuario(String correo)
        {
            try
            {
                var resultado = model.ConsultarUsuario(correo);
        
                    return model.ArmarRespuesta(0, "Usuario consultado", resultado);
                }
         
            catch (Exception ex)
            {
                return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarUsuarios")]
        public UsuariosRespuestaOBJ ConsultarUsuarios()
        {
            try
            {
                var resultado = model.ConsultarUsuarios();

                return model.ArmarRespuesta(0, "Usuarios consultados", resultado);
            }

            catch (Exception ex)
            {
                return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarCandidatos")]
        public CandidatosRespuestaOBJ ConsultarCandidatos()
        {
            try
            {
                var resultado = model.ConsultarCandidatos();

                return model.RespuestaCandidato(0, "Candidatos consultados", resultado);
            }

            catch (Exception ex)
            {
                return model.RespuestaCandidato(99, ex.Message, new List<CandidatosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarCandidato")]
        public CandidatosRespuestaOBJ ConsultarCandidato(String correo)
        {
            try
            {
                var resultado = model.ConsultarCandidato(correo);

                return model.RespuestaCandidato(0, "Candidato consultado", resultado);
            }

            catch (Exception ex)
            {
                return model.RespuestaCandidato(99, ex.Message, new List<CandidatosOBJ>());
            }
        }



        [HttpGet]
        [Route("api/Usuarios/ConsultarReclutadores")]
        public ReclutadoresRespuestaOBJ ConsultarReclutadores()
        {
            try
            {
                var resultado = model.ConsultarReclutadores();

                return model.RespuestaReclutador(0, "Reclutadores consultados", resultado);
            }

            catch (Exception ex)
            {
                return model.RespuestaReclutador(99, ex.Message, new List<ReclutadoresOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Usuarios/ConsultarReclutador")]
        public ReclutadoresRespuestaOBJ ConsultarReclutadores(String correo)
        {
            try
            {
                var resultado = model.ConsultarReclutador(correo);

                return model.RespuestaReclutador(0, "Reclutador consultado", resultado);
            }

            catch (Exception ex)
            {
                return model.RespuestaReclutador(99, ex.Message, new List<ReclutadoresOBJ>());
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RegistrarReclutador")]
        public UsuariosRespuestaOBJ RegistrarReclutador(ReclutadoresOBJ reclutador, string contrasena1, string contrasena2)
        {
            if (contrasena1.Equals(contrasena2))
            {
                try
                {
                    UsuariosOBJ usuario = new UsuariosOBJ();
                    usuario.correo = reclutador.correo_reclutador;
                    usuario.contrasena = contrasena1;
                    usuario.id_rol = 1;

                    model.RegistrarUsuario(usuario);
                    model.RegistrarReclutador(reclutador);
                    return model.ArmarRespuesta(0, "Usuario registrado correctamente.", new List<UsuariosOBJ>());
                }
                catch (Exception ex)
                {
                    return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
                }
            }
            else
            {
                return model.ArmarRespuesta(99, "Las contraseñas no coinciden.", new List<UsuariosOBJ>());
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RegistrarCandidato")]
        public UsuariosRespuestaOBJ RegistrarCandidato(CandidatosOBJ candidato, string contrasena1, string contrasena2)
        {
            if (contrasena1.Equals(contrasena2))
            {
                try
                {
                    UsuariosOBJ usuario = new UsuariosOBJ();
                    usuario.correo = candidato.correo_candidato;
                    usuario.contrasena = contrasena1;
                    usuario.id_rol = 2;

                    model.RegistrarUsuario(usuario);
                    model.RegistrarCandidato(candidato);
                    return model.ArmarRespuesta(0, "Usuario registrado correctamente.", new List<UsuariosOBJ>());
                }
                catch (Exception ex)
                {
                    return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
                }
            }
            else
            {
                return model.ArmarRespuesta(99, "Las contraseñas no coinciden.", new List<UsuariosOBJ>());
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
                    return model.ArmarRespuesta(99, ex.Message, new List<UsuariosOBJ>());
                }   
      
        }


    }
}
