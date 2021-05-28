using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime fecha { get; set; }
        public double total { get; set; }
        public double igv { get; set; }

        public int idProveedor { get; set; }
        [ForeignKey("idProveedor")]
        public virtual Proveedor Proveedor { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }
    }
}