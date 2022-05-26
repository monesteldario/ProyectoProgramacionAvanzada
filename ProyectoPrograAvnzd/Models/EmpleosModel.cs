using ProyectoPrograAvnzd.BaseDatos;
using ProyectoPrograAvnzd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Models
{
    public class EmpleosModel
    {
        public List<EmpleosOBJ> ConsultarEmpleo(int IdEmpleo)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.EMPLEOS
                                 where x.ID_EMPLEO == IdEmpleo
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        resultado.Add(new EmpleosOBJ
                        {
                            id_empleo = item.ID_EMPLEO,
                            id_categoria = item.ID_CATEGORIA,
                            correo_reclutador = item.CORREO_RECLUTADOR,
                            empleo_nombre = item.EMPLEO_NOMBRE,
                            exp_minima = item.EXP_MINIMA,
                            grado_estudio = item.GRADO_ESTUDIO,
                            compania = item.COMPANIA,
                            estado_puesto = item.ESTADO_PUESTO,
                            descripcion = item.DESCRIPCION,
                            requisitos = item.REQUISITOS
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

        public List<EmpleosOBJ> ConsultarEmpleos()
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Llenar_Empleos();

                    foreach (var item in datos)
                    {
                        resultado.Add(new EmpleosOBJ
                        {
                             id_empleo = item.ID_EMPLEO,
                             id_categoria = item.ID_CATEGORIA,
                             correo_reclutador = item.CORREO_RECLUTADOR,
                             empleo_nombre = item.EMPLEO_NOMBRE,
                             exp_minima = item.EXP_MINIMA,
                             grado_estudio = item.GRADO_ESTUDIO,
                             compania = item.COMPANIA,
                             estado_puesto = item.ESTADO_PUESTO,
                             descripcion = item.DESCRIPCION,
                             requisitos = item.REQUISITOS,
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

        public List<EmpleosOBJ> FiltrarPorCategoria(int idCategoria)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Filtrar_Categorias(idCategoria);

                    foreach (var item in datos)
                    {
                        resultado.Add(new EmpleosOBJ
                        {
                             id_empleo = item.ID_EMPLEO,
                             id_categoria = item.ID_CATEGORIA,
                             correo_reclutador = item.CORREO_RECLUTADOR,
                             empleo_nombre = item.EMPLEO_NOMBRE,
                             exp_minima = item.EXP_MINIMA,
                             grado_estudio = item.GRADO_ESTUDIO,
                             compania = item.COMPANIA,
                             estado_puesto = item.ESTADO_PUESTO,
                             descripcion = item.DESCRIPCION,
                             requisitos = item.REQUISITOS,
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

        public List<EmpleosOBJ> FiltrarPorReclutador(string correoReclutador)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Empleos_Publicados(correoReclutador);

                    foreach (var item in datos)
                    {
                        resultado.Add(new EmpleosOBJ
                        {
                            id_empleo = item.ID_EMPLEO,
                            id_categoria = item.ID_CATEGORIA,
                            correo_reclutador = item.CORREO_RECLUTADOR,
                            empleo_nombre = item.EMPLEO_NOMBRE,
                            exp_minima = item.EXP_MINIMA,
                            grado_estudio = item.GRADO_ESTUDIO,
                            compania = item.COMPANIA,
                            estado_puesto = item.ESTADO_PUESTO,
                            descripcion = item.DESCRIPCION,
                            requisitos = item.REQUISITOS,
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
        public void InsertarEmpleo(EmpleosOBJ empleo)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    context.SP_Insertar_Empleo(
                        empleo.empleo_nombre,
                        empleo.requisitos,
                        empleo.descripcion,
                        empleo.compania,
                        (int)empleo.id_categoria,
                        empleo.correo_reclutador,
                        "Activo",
                        empleo.exp_minima,
                        empleo.grado_estudio);
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

        public void ActualizarEmpleo(EmpleosOBJ empleo)
        {
            using (var context = new WorknetEntities())
            {
                try
                {
                    var resultado = (from x in context.EMPLEOS
                                     where x.ID_EMPLEO == empleo.id_empleo
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {

                        resultado.ID_EMPLEO = empleo.id_empleo;
                        resultado.ID_CATEGORIA = empleo.id_categoria;
                        resultado.CORREO_RECLUTADOR = empleo.correo_reclutador;
                        resultado.EMPLEO_NOMBRE = empleo.empleo_nombre;
                        resultado.EXP_MINIMA = empleo.exp_minima;
                        resultado.GRADO_ESTUDIO = empleo.grado_estudio;
                        resultado.COMPANIA = empleo.compania;
                        resultado.ESTADO_PUESTO = empleo.estado_puesto;
                        resultado.DESCRIPCION = empleo.descripcion;
                        resultado.REQUISITOS = empleo.requisitos;

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

        public List<CategoriasOBJ> ConsultarCategoria()
        {
            List<CategoriasOBJ> resultado = new List<CategoriasOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Categorias();

                    foreach (var item in datos)
                    {
                        resultado.Add(new CategoriasOBJ
                        {
                            id_categoria = item.id_Categoria,                    
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
        public List<EmpleosOBJ> EmpleoInteligente(int categoria, int experiancia, string estudio)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Empleo_Inteligente(categoria, experiancia, estudio);

                    foreach (var item in datos)
                    {
                        resultado.Add(new EmpleosOBJ
                        {
                            id_empleo = item.ID_EMPLEO,
                            id_categoria = item.ID_CATEGORIA,
                            correo_reclutador = item.CORREO_RECLUTADOR,
                            empleo_nombre = item.EMPLEO_NOMBRE,
                            exp_minima = item.EXP_MINIMA,
                            grado_estudio = item.GRADO_ESTUDIO,
                            compania = item.COMPANIA,
                            estado_puesto = item.ESTADO_PUESTO,
                            descripcion = item.DESCRIPCION,
                            requisitos = item.REQUISITOS
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

        public EmpleosRespuestaOBJ ArmarRespuesta(int indicador, string mensaje, List<EmpleosOBJ> datos)
        {
            EmpleosRespuestaOBJ response = new EmpleosRespuestaOBJ();

            if (indicador == 200)
            {
                response.CodigoRespuesta = indicador;
                response.DescripcionRespuesta = mensaje;
                response.DatosRespuesta = datos;
            }
            else
            {
                response.CodigoRespuesta = indicador;
                response.DescripcionRespuesta = mensaje;
                response.DatosRespuesta = new List<EmpleosOBJ>();
            }

            return response;
        }


        public CategoriaRespuestaOBJ RespuestaCategoria(int indicador, string mensaje, List<CategoriasOBJ> datos)
        {
            CategoriaRespuestaOBJ response = new CategoriaRespuestaOBJ();

            if (indicador == 200)
            {
                response.CodigoRespuesta = indicador;
                response.DescripcionRespuesta = mensaje;
                response.DatosRespuesta = datos;
            }
            else
            {
                response.CodigoRespuesta = indicador;
                response.DescripcionRespuesta = mensaje;
                response.DatosRespuesta = new List<CategoriasOBJ>();
            }

            return response;
        }


    }
}