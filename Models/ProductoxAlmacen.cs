using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class ProductoxAlmacen
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public int idProducto { get; set; }        
        public int idAlmacen { get; set; }

        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }
        [ForeignKey("idAlmacen")]
        public virtual Almacen Almacen { get; set; }
    }
}