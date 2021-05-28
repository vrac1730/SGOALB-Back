using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }
        public double costo { get; set; }
        public int cantidad { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime fecha_ingreso { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime fecha_salida { get; set; }
        public int stock_min { get; set; }

        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        public int idEstado { get; set; }
        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }
        public int idLocal { get; set; }
        [ForeignKey("idLocal")]
        public Local Local { get; set; }
        public int idAlmacen { get; set; }
        [ForeignKey("idAlmacen")]
        public Almacen Almacen { get; set; }
        public List<DetalleCompra> DetalleCompra { get; set; }
        public List<DetalleSalida> DetalleSalida { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }
        public List<Cotizacion> Cotizacion { get; set; }
    }
}