using GentelellaTemplate.BaseDatos;
using GentelellaTemplate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GentelellaTemplate.Models
{
    public class UsuariosModel
    {

        public List<UsuariosOBJ> ConsultarLogin(string correo, string contrasena)
        {
            List<UsuariosOBJ> resultado = new List<UsuariosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Buscar_Usuario(correo, contrasena);

                    foreach (var item in datos)
                    {
                        resultado.Add(new UsuariosOBJ
                        {
                            correo = item.CORREO_USUARIO,
                            contrasena = item.CONTRASENA,
                            id_rol = item.ID_ROL
                        });
                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }


        public List<UsuariosOBJ> ConsultarUsuarios()
        {
            List<UsuariosOBJ> resultado = new List<UsuariosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.USUARIOS
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        resultado.Add(new UsuariosOBJ
                        {
                            correo = item.CORREO_USUARIO,
                            contrasena = item.CONTRASENA,
                            id_rol = item.ID_ROL
                        });
                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public UsuariosClaveOBJ ConsultarUsuario(string correoIng)
        {

            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.USUARIOS
                                 where x.CORREO_USUARIO == correoIng
                                 select x).FirstOrDefault();

                    UsuariosClaveOBJ resultado = new UsuariosClaveOBJ();

                    resultado.correo = datos.CORREO_USUARIO;
                    resultado.contrasena1 = datos.CONTRASENA;
                    resultado.id_rol = datos.ID_ROL;
                    resultado.contrasena2 = "";

                    context.Dispose();
                    return resultado;

                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public List<CandidatosOBJ> ConsultarCandidatos()
        {
            List<CandidatosOBJ> resultado = new List<CandidatosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Llenar_Candidatos();

                    foreach (var item in datos)
                    {
                        resultado.Add(new CandidatosOBJ
                        {
                            correo_candidato = item.CORREO_USUARIO,
                            nombre_candidato = item.NOMBRE_CANDIDATO,
                            apellido_candidato = item.APELLIDO_CANDIDATO,
                            experiencia = item.EXP_CANDIDATO,
                            grado_estudio = item.GRADO_ESTUDIO,
                            telefono_candidato = item.TELEFONO_CANDIDATO,
                            area_interes = item.AREA_INTERES,
                            categoria_descripcion = item.categoria_descripcion,

                        });
                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public CandidatosOBJ ConsultarCandidato(string correoIngresado)
        {

            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.CANDIDATOS
                                 where x.CORREO_USUARIO == correoIngresado
                                 select x).FirstOrDefault();

                    CandidatosOBJ resultado = new CandidatosOBJ();

                    resultado.correo_candidato = datos.CORREO_USUARIO;
                    resultado.nombre_candidato = datos.NOMBRE_CANDIDATO;
                    resultado.apellido_candidato = datos.APELLIDO_CANDIDATO;
                    resultado.grado_estudio = datos.GRADO_ESTUDIO;
                    resultado.experiencia = datos.EXP_CANDIDATO;
                    resultado.telefono_candidato = datos.TELEFONO_CANDIDATO;
                    resultado.area_interes = datos.AREA_INTERES;

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }
        public List<ReclutadoresOBJ> ConsultarReclutadores()
        {
            List<ReclutadoresOBJ> resultado = new List<ReclutadoresOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.RECLUTADORES
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        resultado.Add(new ReclutadoresOBJ
                        {
                            correo_reclutador = item.CORREO_RECLUTADOR,
                            nombre_reclutador = item.NOMBRE_RECLUTADOR,
                            apellido_reclutador = item.APELLIDO_RECLUTADOR,
                            compania = item.COMPANIA,
                            telefono_reclutador = item.TELEFONO_RECLUTADOR

                        });
                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public ReclutadoresOBJ ConsultarReclutador(string correoIngresado)
        {

            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.RECLUTADORES
                                 where x.CORREO_RECLUTADOR == correoIngresado
                                 select x).FirstOrDefault();

                    ReclutadoresOBJ resultado = new ReclutadoresOBJ();

                    resultado.compania = datos.COMPANIA;
                    resultado.correo_reclutador = datos.CORREO_RECLUTADOR;
                    resultado.nombre_reclutador = datos.NOMBRE_RECLUTADOR;
                    resultado.apellido_reclutador = datos.APELLIDO_RECLUTADOR;
                    resultado.telefono_reclutador = datos.TELEFONO_RECLUTADOR;


                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void RegistrarUsuario(UsuariosOBJ usuario)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    USUARIOS obj = new USUARIOS();
                    obj.CORREO_USUARIO = usuario.correo;
                    obj.CONTRASENA = usuario.contrasena;
                    obj.ID_ROL = (int)usuario.id_rol;

                    context.USUARIOS.Add(obj);
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void RegistrarCandidato(UsuarioCandidatoOBJ candidato)
        {
            using (var context = new WorknetEntities())
            {
                try
                {

                    CANDIDATOS obj = new CANDIDATOS();
                    obj.CORREO_USUARIO = candidato.correo_candidato;
                    obj.NOMBRE_CANDIDATO = candidato.nombre_candidato;
                    obj.APELLIDO_CANDIDATO = candidato.apellido_candidato;
                    obj.GRADO_ESTUDIO = candidato.grado_estudio;
                    obj.EXP_CANDIDATO = candidato.experiencia;
                    obj.TELEFONO_CANDIDATO = candidato.telefono_candidato;
                    obj.AREA_INTERES = candidato.area_interes;

                    context.CANDIDATOS.Add(obj);
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void RegistrarReclutador(UsuarioReclutadorOBJ reclutador)
        {
            using (var context = new WorknetEntities())
            {
                try
                {

                    RECLUTADORES obj = new RECLUTADORES();
                    obj.CORREO_RECLUTADOR = reclutador.correo_reclutador;
                    obj.NOMBRE_RECLUTADOR = reclutador.nombre_reclutador;
                    obj.APELLIDO_RECLUTADOR = reclutador.apellido_reclutador;
                    obj.COMPANIA = reclutador.compania;
                    obj.TELEFONO_RECLUTADOR = reclutador.telefono_reclutador;

                    context.RECLUTADORES.Add(obj);
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void ActualizarReclutador(ReclutadoresOBJ reclutador)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    var resultado = (from x in context.RECLUTADORES
                                     where x.CORREO_RECLUTADOR == reclutador.correo_reclutador
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {

                        resultado.CORREO_RECLUTADOR = reclutador.correo_reclutador;
                        resultado.NOMBRE_RECLUTADOR = reclutador.nombre_reclutador;
                        resultado.APELLIDO_RECLUTADOR = reclutador.apellido_reclutador;
                        resultado.COMPANIA = reclutador.compania;
                        resultado.TELEFONO_RECLUTADOR = reclutador.telefono_reclutador;

                        context.SaveChanges();
                    }
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void CambiarClave(UsuariosClaveOBJ usuario)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    var resultado = (from x in context.USUARIOS
                                     where x.CORREO_USUARIO == usuario.correo
                                     select x).FirstOrDefault();

                    if (resultado != null && resultado.CONTRASENA == usuario.contrasena1)
                    {

                        resultado.CONTRASENA = usuario.contrasena2;

                        context.SaveChanges();
                    }
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public void ActualizarCandidato(CandidatosOBJ candidato)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    var resultado = (from x in context.CANDIDATOS
                                     where x.CORREO_USUARIO == candidato.correo_candidato
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {

                        resultado.CORREO_USUARIO = candidato.correo_candidato;
                        resultado.NOMBRE_CANDIDATO = candidato.nombre_candidato;
                        resultado.APELLIDO_CANDIDATO = candidato.apellido_candidato;
                        resultado.EXP_CANDIDATO = candidato.experiencia;
                        resultado.GRADO_ESTUDIO = candidato.grado_estudio;
                        resultado.TELEFONO_CANDIDATO = candidato.telefono_candidato;
                        resultado.AREA_INTERES = candidato.area_interes;

                        context.SaveChanges();
                    }
                    context.SaveChanges();
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public UsuariosRespuestaOBJ ArmarRespuesta(int indicador, string mensaje, List<UsuariosOBJ> datos)
        {
            try
            {
                UsuariosRespuestaOBJ response = new UsuariosRespuestaOBJ();

                if (indicador == 0)
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = datos;
                }
                else
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = new List<UsuariosOBJ>();
                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReclutadoresRespuestaOBJ RespuestaReclutador(int indicador, string mensaje, List<ReclutadoresOBJ> datos)
        {
            try
            {
                ReclutadoresRespuestaOBJ response = new ReclutadoresRespuestaOBJ();

                if (indicador == 0)
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = datos;
                }
                else
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = new List<ReclutadoresOBJ>();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CandidatosRespuestaOBJ RespuestaCandidato(int indicador, string mensaje, List<CandidatosOBJ> datos)
        {
            try
            {
                CandidatosRespuestaOBJ response = new CandidatosRespuestaOBJ();

                if (indicador == 0)
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = datos;
                }
                else
                {
                    response.CodigoRespuesta = indicador;
                    response.DescripcionRespuesta = mensaje;
                    response.DatosRespuesta = new List<CandidatosOBJ>();
                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SelectListItem> ConsultarTodaslasCategorias()
        {
            List<SelectListItem> listaDatos = new List<SelectListItem>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var resultado = (from x in context.CATEGORIAS
                                     select x).ToList();


                    foreach (var item in resultado)
                    {
                        listaDatos.Add(new SelectListItem
                        {
                            Value = item.ID_CATEGORIA.ToString(),
                            Text = item.CATEGORIA_DESCRIPCION
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listaDatos;
        }

        public void RegistrarBitacora(string descripcion_error, string origen_error, string correoUsuario_error)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    context.SP_Insertar_Bitacora(descripcion_error, origen_error, correoUsuario_error);
                    context.Dispose();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        }

    }
}