using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class UsuarioxRol
    {        
        public int idUsuario { get; set; }         
        public int idRol { get; set; }
    
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }
    }
}