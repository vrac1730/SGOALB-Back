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
        public DateTime fecha { get; set; }
        public string codigo { get; set; }
        public string estado { get; set; }
        public int id_Usuario { get; set; }
        [ForeignKey("id_Usuaio")]
        public virtual Usuario Usuario { get; set; }
        public List<DetalleSalida> DetalleSalida { get; set; }
    }
}