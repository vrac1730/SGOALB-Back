using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("UsuarioxRol")]
    public class UsuarioxRol
    {
        //[Key]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        
        //[Key]
        public int idRol { get; set; }
        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }
    }
}