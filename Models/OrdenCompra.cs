using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("OrdenCompra")]
    public class OrdenCompra
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Código de orden")]
        public string codigo { get; set; }
        [Column(TypeName = "datetime2"), DisplayName("Fecha de Orden"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaOrden { get; set; }
        [DisplayName("Fecha de Pago"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaPago { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Monto Total")]
        public double? montoTotal { get; set; }
        [DisplayName("Encargado")]
        public int idUsuario { get; set; }
        [DisplayName("Proveedor")]
        public int idProveedor { get; set; }

        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("idProveedor")]
        public virtual Proveedor Proveedor { get; set; } 

        public List<DetalleCompra> DetalleCompras { get; set; }
    }
}