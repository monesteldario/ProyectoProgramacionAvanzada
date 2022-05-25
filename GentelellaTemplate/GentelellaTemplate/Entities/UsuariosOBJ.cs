using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentelellaTemplate.Entities
{
    public class UsuariosOBJ
    {
        public string correo { get; set; }
        public string contrasena { get; set; }
        public long id_rol { get; set; }
    }


    public class UsuariosClaveOBJ
    {
        public string correo { get; set; }
        public string contrasena1 { get; set; }
        public string contrasena2 { get; set; }
        public long id_rol { get; set; }
    }

    public class UsuariosRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<UsuariosOBJ> DatosRespuesta { get; set; }
    }
}