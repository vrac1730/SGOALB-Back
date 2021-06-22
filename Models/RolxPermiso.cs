using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Rol_Permiso")]
    public class RolxPermiso
    {
        public int idRol { get; set; } 
        public int idPermiso { get; set; }

        [ForeignKey("idPermiso")]
        public virtual Permiso Permiso { get; set; }
        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }
    }
}