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

        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}