using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class DetalleFactura
    {
        [Key]
        public int id { get; set; }
        public int idFactura { get; set; }
        [ForeignKey("idFactura")]
        public virtual Factura Factura { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }
    }
}