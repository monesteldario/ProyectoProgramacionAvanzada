using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Entities
{
    public class ReclutadoresOBJ
    {
        public string correo_reclutador { get; set; }
        public string nombre_reclutador { get; set; }
        public string apellido_reclutador { get; set; }
        public string compania { get; set; }
        public int telefono_reclutador { get; set; }
    }

    public class ReclutadoresRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<ReclutadoresOBJ> DatosRespuesta { get; set; }
    
    }
}