using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [DisplayName("Marca")]
        public string marca { get; set; }

        [DisplayName("Stock mínimo")]
        public int stock_min { get; set; }

        [DisplayName("Stock máximo")]
        public int stock_max { get; set; }

        public int idCategoria { get; set; }      
        public int idEstado { get; set; }

        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }
       
        public List<DetalleSalida> DetalleSalida { get; set; }
        public List<Cotizacion> Cotizacion { get; set; }
    }
}