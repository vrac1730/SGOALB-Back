using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class DetalleSalida
    {
        [Key]
        public int id{ get; set; }        
        public int cantidad { get; set; }
        public string observacion { get; set; }
        public int idProducto { get; set; }
        public int idOrdenSalida { get; set; }

        [ForeignKey("idOrdenSalida")]
        public virtual OrdenSalida OrdenSalida { get; set; }
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }        
    }
}