using ProyectoPrograAvnzd.BaseDatos;
using ProyectoPrograAvnzd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Models
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
                            ID_EMPLEO = item.ID_EMPLEO,
                            ID_CATEGORIA = item.ID_CATEGORIA,
                            EXP_MINIMA = item.EXP_MINIMA,
                            GRADO_ESTUDIO = item.GRADO_ESTUDIO,
                            COMPANIA = item.COMPANIA,
                            EMPLEO_NOMBRE = item.EMPLEO_NOMBRE,
                            ESTADO_PUESTO = item.ESTADO_PUESTO,
                            DESCRIPCION = item.DESCRIPCION,
                            REQUISITOS = item.REQUISITOS,
                            CORREO_RECLUTADOR = item.CORREO_RECLUTADOR,
                            categoria_descripcion = item.categoria_descripcion
                        }) ;
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
                            ID_EMPLEO = item.ID_EMPLEO,
                            ID_CATEGORIA = item.ID_CATEGORIA,
                            EXP_MINIMA = item.EXP_MINIMA,
                            GRADO_ESTUDIO = item.GRADO_ESTUDIO,
                            COMPANIA = item.COMPANIA,
                            EMPLEO_NOMBRE = item.EMPLEO_NOMBRE,
                            ESTADO_PUESTO = item.ESTADO_PUESTO,
                            DESCRIPCION = item.DESCRIPCION,
                            REQUISITOS = item.REQUISITOS,
                            CORREO_RECLUTADOR = item.CORREO_RECLUTADOR,
                            categoria_descripcion = item.categoria_descripcion
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

        public SolicitudesRespuestaOBJ ArmarRespuesta(int indicador, string mensaje, List<SolicitudesOBJ> datos)
        {
            SolicitudesRespuestaOBJ response = new SolicitudesRespuestaOBJ();

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
                response.DatosRespuesta = new List<SolicitudesOBJ>();
            }

            return response;
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

    }
}