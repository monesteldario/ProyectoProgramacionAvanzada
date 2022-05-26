using ProyectoPrograAvnzd.BaseDatos;
using ProyectoPrograAvnzd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Models
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
                          correo =item.CORREO_USUARIO,
                          contrasena =item.CONTRASENA,
                          id_rol=item.ID_ROL
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

        public List<UsuariosOBJ> ConsultarUsuario(string correoIng)
        {
            List<UsuariosOBJ> resultado = new List<UsuariosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.USUARIOS
                                 where x.CORREO_USUARIO == correoIng
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

        public List<CandidatosOBJ> ConsultarCandidato(string correoIngresado)
        {
            List<CandidatosOBJ> resultado = new List<CandidatosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Candidato(correoIngresado);

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
                            categoria_descripcion = item.categoria_descripcion

                        }); ;
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
                            compania =  item.COMPANIA,
                            telefono_reclutador =item.TELEFONO_RECLUTADOR

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

        public List<ReclutadoresOBJ> ConsultarReclutador(string correoIngresado)
        {
            List<ReclutadoresOBJ> resultado = new List<ReclutadoresOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.RECLUTADORES
                                 where  x.CORREO_RECLUTADOR == correoIngresado
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

        public void RegistrarCandidato(CandidatosOBJ candidato)
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

        public void RegistrarReclutador(ReclutadoresOBJ reclutador)
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

        public void ActualizarCandidato (CandidatosOBJ candidato)
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
                        resultado.AREA_INTERES =  candidato.area_interes;

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

        public ReclutadoresRespuestaOBJ RespuestaReclutador (int indicador, string mensaje, List<ReclutadoresOBJ> datos)
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

        public CandidatosRespuestaOBJ RespuestaCandidato(int indicador, string mensaje, List<CandidatosOBJ> datos)
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

    }
}