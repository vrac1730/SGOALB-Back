using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("DetalleFactura")]
    public class DetalleFactura
    {
        public int idProducto { get; set; }
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }
        public int idFactura { get; set; }
        [ForeignKey("idFactura")]
        public virtual Factura Factura { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }
    }
}