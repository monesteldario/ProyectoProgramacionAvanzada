using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Entities
{
    public class EmpleosOBJ
    {
        public long id_empleo { get; set; }
        public long id_categoria { get; set; }
        public string correo_reclutador { get; set; }
        public string empleo_nombre { get; set; }
        public int exp_minima { get; set; }
        public string grado_estudio { get; set; }
        public string compania { get; set; }
        public string estado_puesto { get; set; }
        public string descripcion{ get; set; }
        public string requisitos { get; set; }

        public string categoria_descripcion { get; set; }
    }

    public class EmpleosRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<EmpleosOBJ> DatosRespuesta { get; set; }

    }

    public class CategoriasOBJ
    {
        public long id_categoria { get; set; }
        public string categoria_descripcion { get; set; }
    }

    public class CategoriaRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<CategoriasOBJ> DatosRespuesta { get; set; }
    }


    }