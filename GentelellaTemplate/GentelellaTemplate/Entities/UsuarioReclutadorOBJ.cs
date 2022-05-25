using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentelellaTemplate.Entities
{
    public class UsuarioReclutadorOBJ
    {
        public string correo_reclutador { get; set; }
        public string nombre_reclutador { get; set; }
        public string apellido_reclutador { get; set; }
        public string compania { get; set; }
        public int telefono_reclutador { get; set; }

        public string contrasena { get; set; }
        public string confirmar_contrasena { get; set; }
        public long id_rol { get; set; }
    }
}