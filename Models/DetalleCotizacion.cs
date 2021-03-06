using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("DetalleCotizacion")]
    public class DetalleCotizacion
    {
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public double costo { get; set; }
        public int idAlerta { get; set; }
        public int idCotizacion { get; set; }

        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }
        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }
        [ForeignKey("idCotizacion")]
        public Cotizacion Cotizacion { get; set; }
        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }
    }
}