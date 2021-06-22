using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("DetalleCompra")]
    public class DetalleCompra
    {
        [Key]
        public int id { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }
        public int idOrdenCompra { get; set; }
        public int idProducto { get; set; }
        public int idProveedor { get; set; }

        [ForeignKey("idOrdenCompra")]
        public virtual OrdenCompra OrdenCompra { get; set; }
        [ForeignKey("idProducto, idProveedor")]
        public virtual Cotizacion Cotizacion { get; set; }
    }
}