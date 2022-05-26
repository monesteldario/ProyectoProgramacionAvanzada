using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Entities
{
    public class CandidatosOBJ
    {
        //Objeto (Clase)
        //Propiedades
        public string correo_candidato { get; set; }
        public string nombre_candidato { get; set; }
        public string apellido_candidato { get; set; }
        public string grado_estudio { get; set; }
        public int experiencia { get; set; }
        public int telefono_candidato { get; set; }
        public long area_interes { get; set; }
        public string categoria_descripcion { get; set; }
    }

    public class CandidatosRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<CandidatosOBJ> DatosRespuesta { get; set; }
    }
}