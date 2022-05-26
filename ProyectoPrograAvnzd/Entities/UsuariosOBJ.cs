using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvnzd.Entities
{
    public class UsuariosOBJ
    {
        public string correo { get; set; }
        public string contrasena { get; set; }
        public long id_rol { get; set; }
    }

    public class UsuariosRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<UsuariosOBJ> DatosRespuesta { get; set; }
    }
}