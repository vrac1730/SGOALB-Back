using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Encargado")]
        public string nombre { get; set; }

        public int idLocal { get; set; }
        [ForeignKey("idLocal")]
        public Local Local { get; set; }

        public List<UsuarioxRol> UsuarioxRol { get; set; }
        public List<OrdenCompra> OrdenCompra { get; set; }
        public List<OrdenSalida> OrdenSalida { get; set; }
    }
}