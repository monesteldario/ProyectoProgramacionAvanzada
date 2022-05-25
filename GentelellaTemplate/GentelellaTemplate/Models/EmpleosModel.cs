using GentelellaTemplate.BaseDatos;
using GentelellaTemplate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GentelellaTemplate.Models
{
    public class EmpleosModel
    {
        public EmpleosOBJ ConsultarEmpleo(long IdEmpleo)
        {
            EmpleosOBJ resultado = new EmpleosOBJ();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var dato = context.SP_Consultar_Empleo(IdEmpleo).FirstOrDefault();

                    resultado.id_empleo = dato.ID_EMPLEO;
                    resultado.categoria_descripcion = dato.categoria_descripcion;
                    resultado.correo_reclutador = dato.CORREO_RECLUTADOR;
                    resultado.empleo_nombre = dato.EMPLEO_NOMBRE;
                    resultado.exp_minima = dato.EXP_MINIMA;
                    resultado.grado_estudio = dato.GRADO_ESTUDIO;
                    resultado.compania = dato.COMPANIA;
                    resultado.estado_puesto = dato.ESTADO_PUESTO;
                    resultado.descripcion = dato.DESCRIPCION;
                    resultado.requisitos = dato.REQUISITOS;

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

        public List<EmpleosOBJ> ConsultarEmpleosPorCategoria(long categoria)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Filtrar_Categorias((int)categoria);

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
                    var reclutador = (from x in context.RECLUTADORES
                                      where x.CORREO_RECLUTADOR == empleo.correo_reclutador
                                      select x).FirstOrDefault();


                    context.SP_Insertar_Empleo(
                    empleo.empleo_nombre,
                    empleo.requisitos,
                    empleo.descripcion,
                    reclutador.COMPANIA,
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

        public List<SelectListItem> ConsultarCategorias()
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Consultar_Categorias();

                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.id_Categoria.ToString(),
                            Text = item.categoria_descripcion
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


        public List<VerCategoriasOBJ> VerCategorias()
        {
            List<VerCategoriasOBJ> resultado = new List<VerCategoriasOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = (from x in context.CATEGORIAS
                                 select x).ToList();


                    foreach (var item in datos)
                    {
                        resultado.Add(new VerCategoriasOBJ
                        {
                            ID_CATEGORIA = item.ID_CATEGORIA,
                            CAT_DESCRIPCION = item.CATEGORIA_DESCRIPCION.ToString(),


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

        public List<SelectListItem> LlenarEstudios()
        {
            List<SelectListItem> estudios = new List<SelectListItem>();
            using (var context = new WorknetEntities())
            {
                try
                {

                    estudios.Add(new SelectListItem
                    {
                        Value = "Noveno Año",
                        Text = "Noveno Año"
                    });

                    estudios.Add(new SelectListItem
                    {
                        Value = "Bachiller Colegial",
                        Text = "Bachiller Colegial"
                    });

                    estudios.Add(new SelectListItem
                    {
                        Value = "Técnico Medio",
                        Text = "Técnico Medio"
                    });

                    estudios.Add(new SelectListItem
                    {
                        Value = "Bachiller Universitario",
                        Text = "Bachiller Universitario"
                    });

                    estudios.Add(new SelectListItem
                    {
                        Value = "Licenciado",
                        Text = "Licenciado"
                    });

                    return estudios;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public List<SelectListItem> LlenarEstado()
        {
            List<SelectListItem> estado = new List<SelectListItem>();
            using (var context = new WorknetEntities())
            {
                try
                {

                    estado.Add(new SelectListItem
                    {
                        Value = "Activo",
                        Text = "Activo"
                    });

                    estado.Add(new SelectListItem
                    {
                        Value = "Inactivo",
                        Text = "Inactivo"
                    });

                    return estado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public List<EmpleosOBJ> EmpleoInteligente(int categoria, int experiencia, string estudio)
        {
            List<EmpleosOBJ> resultado = new List<EmpleosOBJ>();
            using (var context = new WorknetEntities())
            {
                try
                {
                    var datos = context.SP_Empleo_Inteligente(categoria, experiencia, estudio);

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
                            categoria_descripcion = item.CATEGORIA_DESCRIPCION
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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }

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