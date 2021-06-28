using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("DetalleSolicitud")]
    public class DetalleSalida
    {
        [Key]
        public int id{ get; set; }        
        [DisplayName("Cantidad Requerida")]
        public int cantSolicitada { get; set; }
        public int cantEntregada { get; set; }
        public string observacion { get; set; }
        [DisplayName("Producto")]
        public int idProducto { get; set; }
        public int idOrdenSalida { get; set; }

        [ForeignKey("idOrdenSalida")]
        public OrdenSalida OrdenSalida { get; set; }
        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }        
    }
}