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
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string descripcion { get; set; }

        [DisplayName("Marca")]
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string marca { get; set; }

        [DisplayName("Stock mínimo")]
        [Range(000, 25, ErrorMessage = "Valor positivo, no mayor a 25")]
        public int stock_min { get; set; }

        [DisplayName("Stock máximo")]
        [Range(0000, 1000, ErrorMessage = "Valor positivo, no mayor a 1000")]
        public int stock_max { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        [DisplayName("Categoría")]
        public int idCategoria { get; set; }
        [DisplayName("Alerta")]
        public int idAlerta { get; set; }

        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }
       
        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}