using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Solicitud")]
    public class OrdenSalida
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Código de Solicitud")]
        public string codigo { get; set; }
        [Column(TypeName = "datetime2"), DisplayName("Fecha"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fecha { get; set; }        
        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Encargado")]
        public int idUsuario { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set; }

        public List<DetalleSalida> DetalleSalida { get; set; }
    }
}