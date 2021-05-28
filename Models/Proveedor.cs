using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class Proveedor
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public long telefono { get; set; }
        public long ruc { get; set; }
        public string razon_social { get; set; }

        public List<Cotizacion> Cotizacion { get; set; }
    }
}