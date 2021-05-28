using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Cotizacion")]
    public class Cotizacion
    {
        
        public int idProducto { get; set; }
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }

        public int idProveedor { get; set; }
        [ForeignKey("idProveedor")]
        public virtual Proveedor Proveedor { get; set; }

        public double costo { get; set; }
    }
}