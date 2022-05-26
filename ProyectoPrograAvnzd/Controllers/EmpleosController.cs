using ProyectoPrograAvnzd.Entities;
using ProyectoPrograAvnzd.Models;
using ProyectoPrograAvnzd.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProyectoPrograAvnzd.Controllers
{
    public class EmpleosController : ApiController
    {
        EmpleosModel modelEmpleos = new EmpleosModel();

        [HttpGet]
        [Route("api/Empleos/ConsultarEmpleos")]
        public EmpleosRespuestaOBJ ConsultarEmpleos()
        {
            try
            {
                var resultado = modelEmpleos.ConsultarEmpleos();
                return modelEmpleos.ArmarRespuesta(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Empleos/ConsultarEmpleo")]
        public EmpleosRespuestaOBJ ConsultarEmpleo( int idEmpleo)
        {
            try
            {
                var resultado = modelEmpleos.ConsultarEmpleo(idEmpleo);
                return modelEmpleos.ArmarRespuesta(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Empleos/ConsultarCategorias")]
        public CategoriaRespuestaOBJ ConsultarCategorias()
        {
            try
            {
                var resultado = modelEmpleos.ConsultarCategoria();
                return modelEmpleos.RespuestaCategoria(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelEmpleos.RespuestaCategoria(99, ex.Message, new List<CategoriasOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Empleos/FiltrarCategorias")]
        public EmpleosRespuestaOBJ FiltrarCategorias(int categoria)
        {
            try
            {
                var resultado = modelEmpleos.FiltrarPorCategoria(categoria);
                return modelEmpleos.ArmarRespuesta(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
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
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }

        [HttpGet]
        [Route("api/Empleos/VerEmpleoInteligente")]
        public EmpleosRespuestaOBJ VerEmpleoInteligente (int categoria, int experiencia, string gradoEstudio)
        {
            try
            {
                var resultado = modelEmpleos.EmpleoInteligente(categoria, experiencia, gradoEstudio);
                return modelEmpleos.ArmarRespuesta(200, "OK", resultado);
            }
            catch (Exception ex)
            {
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }


        [HttpPost]
        [Route("api/Empleos/InsertarEmpleo")]
        public EmpleosRespuestaOBJ InsertarEmpleo(EmpleosOBJ empleo)
        {
                try
                {
                    modelEmpleos.InsertarEmpleo(empleo);
                    return modelEmpleos.ArmarRespuesta(200, "Empleo insertado correctamente.", new List<EmpleosOBJ>());
                }
                catch (Exception ex)
                {
                    return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
                }
        }

        [HttpPut]
        [Route("api/Empleos/ActualizarEmpleo")]
        public EmpleosRespuestaOBJ ActualizarEmpleo(EmpleosOBJ empleo)
        {
            using (var context = new WorknetEntities())
                try
            {
                    modelEmpleos.ActualizarEmpleo(empleo);
                    return modelEmpleos.ArmarRespuesta(200, "Empleo insertado correctamente.", new List<EmpleosOBJ>());


                }
                catch (Exception ex)
            {
                return modelEmpleos.ArmarRespuesta(99, ex.Message, new List<EmpleosOBJ>());
            }
        }

    }
}