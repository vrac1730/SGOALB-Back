using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class OrdenSalida
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime fecha { get; set; }
        public string codigo { get; set; }
        public string estado { get; set; }

        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        public List<DetalleSalida> DetalleSalida { get; set; }
    }
}