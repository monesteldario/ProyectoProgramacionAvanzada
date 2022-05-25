using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentelellaTemplate.Entities
{
    public class UsuarioCandidatoOBJ
    {
        public string correo_candidato { get; set; }
        public string nombre_candidato { get; set; }
        public string apellido_candidato { get; set; }
        public string grado_estudio { get; set; }
        public int experiencia { get; set; }
        public int telefono_candidato { get; set; }
        public long area_interes { get; set; }
        public string descripcion_area_interes { get; set; }
        public string contrasena { get; set; }
        public string confirmar_contrasena { get; set; }
    }


}