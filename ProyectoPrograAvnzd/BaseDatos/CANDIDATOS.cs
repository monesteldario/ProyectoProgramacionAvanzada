//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPrograAvnzd.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CANDIDATOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CANDIDATOS()
        {
            this.SOLICITUDES = new HashSet<SOLICITUDES>();
        }
    
        public string NOMBRE_CANDIDATO { get; set; }
        public string APELLIDO_CANDIDATO { get; set; }
        public int EXP_CANDIDATO { get; set; }
        public string GRADO_ESTUDIO { get; set; }
        public int TELEFONO_CANDIDATO { get; set; }
        public long AREA_INTERES { get; set; }
        public string CORREO_USUARIO { get; set; }
    
        public virtual CATEGORIAS CATEGORIAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUDES> SOLICITUDES { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}
