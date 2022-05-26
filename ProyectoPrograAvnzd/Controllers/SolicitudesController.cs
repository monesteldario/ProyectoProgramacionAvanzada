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
    public class SolicitudesController : ApiController
    {
        SolicitudesModel modelSolicitudes = new SolicitudesModel();

        [HttpGet]
        [Route("api/Solicitudes/ConsultarSolicitudes")]
        public ConsultaSolicitudesRespuestaOBJ ConsultarSolicitudes(string correo)
        {
            try
            {
                var resultado = modelSolicitudes.ConsultarSolicitudes(correo);
                return modelSolicitudes.RespuestaConsulta(0, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelSolicitudes.RespuestaConsulta(99, ex.Message, new List<ConsultaSolicitudesOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Solicitudes/VerSolicitudes")]
        public ConsultaSolicitudesRespuestaOBJ VerSolicitudes( )
        {
            try
            {
                var resultado = modelSolicitudes.VerSolicitudes( );
                return modelSolicitudes.RespuestaConsulta(0, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelSolicitudes.RespuestaConsulta(99, ex.Message, new List<ConsultaSolicitudesOBJ>());
            }
        }

        [HttpPost]
        [Route("api/Solicitudes/InsertarSolicitud")]
        public SolicitudesRespuestaOBJ InsertarSolicitud(SolicitudesOBJ solicitud)
        {
            try
            {
                modelSolicitudes.InsertarSolicitud(solicitud);
                return modelSolicitudes.ArmarRespuesta(0, "Solicitud enviada correctamente.", new List<SolicitudesOBJ>());
            }
            catch (Exception ex)
            {
                return modelSolicitudes.ArmarRespuesta(99, ex.Message, new List<SolicitudesOBJ>());
            }
        }

    }
}
