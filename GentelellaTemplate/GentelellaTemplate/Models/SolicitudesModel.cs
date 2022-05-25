using GentelellaTemplate.BaseDatos;
using GentelellaTemplate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentelellaTemplate.Models
{
    public class SolicitudesModel
    {
        public List<ConsultaSolicitudesOBJ> ConsultarSolicitudes(string correo)
        {
            List<ConsultaSolicitudesOBJ> resultado = new List<ConsultaSolicitudesOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Solicitudes(correo);

                    foreach (var item in datos)
                    {
                        resultado.Add(new ConsultaSolicitudesOBJ
                        {
                            //Agregar solicitudes recibidas.
                            id_solicitud = item.ID_SOLICITUD,
                            ID_EMPLEO = item.ID_EMPLEO.Value,
                            ID_CATEGORIA = item.ID_CATEGORIA.Value,
                            EXP_MINIMA = item.EXP_MINIMA.Value,
                            GRADO_ESTUDIO = item.GRADO_ESTUDIO,
                            COMPANIA = item.COMPANIA,
                            EMPLEO_NOMBRE = item.EMPLEO_NOMBRE,
                            ESTADO_PUESTO = item.ESTADO_PUESTO,
                            DESCRIPCION = item.DESCRIPCION,
                            REQUISITOS = item.REQUISITOS,
                            CORREO_RECLUTADOR = item.CORREO_RECLUTADOR,
                            categoria_descripcion = item.categoria_descripcion,
                            CORREO_CANDIDATO = item.CORREO_CANDIDATO
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

        public string EmpleoAplicado(string correo, long id)
        {

            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Empleo_Aplicado(correo, id).FirstOrDefault();

                    context.Dispose();

                    if (datos == null)
                    {
                        return "0";
                    }
                    else
                    {
                        return "1";
                    }
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public ConsultaSolicitudesOBJ ConsultarSolicitudesPorID(long id)
        {

            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Solicitudes_por_id(id).FirstOrDefault();

                    ConsultaSolicitudesOBJ consultaSolicitudes = new ConsultaSolicitudesOBJ();

                    //Agregar solicitudes recibidas.
                    consultaSolicitudes.ID_EMPLEO = datos.ID_EMPLEO.Value;
                    consultaSolicitudes.ID_CATEGORIA = datos.ID_CATEGORIA.Value;
                    consultaSolicitudes.EXP_MINIMA = datos.EXP_MINIMA.Value;
                    consultaSolicitudes.GRADO_ESTUDIO = datos.GRADO_ESTUDIO;
                    consultaSolicitudes.COMPANIA = datos.COMPANIA;
                    consultaSolicitudes.EMPLEO_NOMBRE = datos.EMPLEO_NOMBRE;
                    consultaSolicitudes.ESTADO_PUESTO = datos.ESTADO_PUESTO;
                    consultaSolicitudes.DESCRIPCION = datos.DESCRIPCION;
                    consultaSolicitudes.REQUISITOS = datos.REQUISITOS;
                    consultaSolicitudes.CORREO_RECLUTADOR = datos.CORREO_RECLUTADOR;
                    consultaSolicitudes.categoria_descripcion = datos.categoria_descripcion;
                    consultaSolicitudes.CORREO_CANDIDATO = datos.CORREO_CANDIDATO;


                    context.Dispose();
                    return consultaSolicitudes;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public List<ConsultaSolicitudesOBJ> VerSolicitudes()
        {
            List<ConsultaSolicitudesOBJ> resultado = new List<ConsultaSolicitudesOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Ver_Solicitudes();

                    foreach (var item in datos)
                    {
                        resultado.Add(new ConsultaSolicitudesOBJ
                        {
                            //Agregar solicitudes recibidas.
                            ID_EMPLEO = item.ID_EMPLEO.Value,
                            ID_CATEGORIA = item.ID_CATEGORIA.Value,
                            EXP_MINIMA = item.EXP_MINIMA.Value,
                            GRADO_ESTUDIO = item.GRADO_ESTUDIO,
                            COMPANIA = item.COMPANIA,
                            EMPLEO_NOMBRE = item.EMPLEO_NOMBRE,
                            ESTADO_PUESTO = item.ESTADO_PUESTO,
                            DESCRIPCION = item.DESCRIPCION,
                            REQUISITOS = item.REQUISITOS,
                            CORREO_RECLUTADOR = item.CORREO_RECLUTADOR,
                            categoria_descripcion = item.categoria_descripcion,
                            id_solicitud = item.ID_SOLICITUD,
                            CORREO_CANDIDATO = item.CORREO_CANDIDATO

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

        public void InsertarSolicitud(SolicitudesOBJ solicitud)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    context.SP_Insertar_Solicitudes(
                    solicitud.correo_candidato,
                    (int)solicitud.id_empleo);
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

        public ConsultaSolicitudesRespuestaOBJ RespuestaConsulta(int indicador, string mensaje, List<ConsultaSolicitudesOBJ> datos)
        {
            ConsultaSolicitudesRespuestaOBJ response = new ConsultaSolicitudesRespuestaOBJ();

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
                response.DatosRespuesta = new List<ConsultaSolicitudesOBJ>();
            }

            return response;
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