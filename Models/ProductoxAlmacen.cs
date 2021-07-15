using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("ProductoAlmacen")]
    public class ProductoxAlmacen
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idAlerta { get; set; }
        public int idAlmacen { get; set; }

        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }
        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }
        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }
        [ForeignKey("idAlmacen")]
        public Almacen Almacen { get; set; }
    }
}