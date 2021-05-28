using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        public List<UsuarioxRol> UsuarioxRol { get; set; }
    }
}