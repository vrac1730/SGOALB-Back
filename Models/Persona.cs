using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public long dni { get; set; }
        [DisplayName("Encargado")]
        public string nombre { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public long celular { get; set; }
    }
}