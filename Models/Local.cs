using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Local")]
    public class Local
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Local")]
        public string nombre { get; set; }
        public string direccion { get; set; }
        public long telefono { get; set; }
        public long ruc { get; set; }
        public string razon_social { get; set; }
    }
}