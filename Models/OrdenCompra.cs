using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class OrdenCompra
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "datetime2")]
        public string codigo { get; set; }
        public DateTime fecha_orden { get; set; }
        public DateTime fecha_pago { get; set; }
        public double monto_total { get; set; }
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        public List<DetalleCompra> DetalleCompras { get; set; }

    }
}