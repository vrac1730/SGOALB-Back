using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        public List<UsuarioxRol> UsuarioxRol { get; set; }
        public List<OrdenCompra> OrdenCompra { get; set; }
        public List<OrdenSalida> OrdenSalida { get; set; }
    }
}