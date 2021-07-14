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
        [Required]
        public string codigo { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string descripcion { get; set; }

        [DisplayName("Marca")]
        [Required]
        public string marca { get; set; }

        [DisplayName("Stock mínimo")]
        [Range(00000, 9999, ErrorMessage = "Valor positivo")]
        public int stock_min { get; set; }

        [DisplayName("Stock máximo")]
        public int stock_max { get; set; }
        [DisplayName("Cantidad")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public int cantidad { get; set; }
        [DisplayName("Categoría")]
        public int idCategoria { get; set; }
        [DisplayName("Alerta")]
        public int idAlerta { get; set; }

        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }
       
        //public List<DetalleSalida> DetalleSalida { get; set; }
        public List<Cotizacion> Cotizacion { get; set; }
    }
}