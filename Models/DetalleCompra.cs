using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class DetalleCompra
    {
        public int idProducto { get; set; }
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }
   
        public int idOrdenCompra { get; set; }
        [ForeignKey("idOrdenCompra")]
        public virtual OrdenCompra OrdenCompra { get; set; }

        public int cantidad { get; set; }
        public double total { get; set; }
    }
}