using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Entities
{
    public class SolicitudesOBJ
    {
            public long id_solicitud{ get; set; }
            public long id_empleo{ get; set; }
            public string correo_candidato { get; set; }
            public DateTime fecha_solcitud { get; set; }
    }

    public class SolicitudesRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<SolicitudesOBJ> DatosRespuesta { get; set; }
    }

    public class ConsultaSolicitudesOBJ

    {
        public long ID_EMPLEO { get; set; }
        public long ID_CATEGORIA { get; set; }
        public int EXP_MINIMA { get; set; }
        public string GRADO_ESTUDIO { get; set; }
        public string COMPANIA { get; set; }
        public string EMPLEO_NOMBRE { get; set; }
        public string ESTADO_PUESTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string REQUISITOS { get; set; }
        public string CORREO_RECLUTADOR { get; set; }
        public string categoria_descripcion { get; set; }
    }

    public class ConsultaSolicitudesRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<ConsultaSolicitudesOBJ> DatosRespuesta { get; set; }
    }


}


