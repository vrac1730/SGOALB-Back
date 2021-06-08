﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class OrdenCompra
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Código de orden")]
        public string codigo { get; set; }
        [Column(TypeName = "datetime2")]
        [DisplayName("Fecha de Orden")]
        public DateTime fecha_orden { get; set; }
        [DisplayName("Fecha de Pago")]
        public DateTime fecha_pago { get; set; }
        [DisplayName("Monto Total")]
        public double monto_total { get; set; }
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }

        public List<DetalleCompra> DetalleCompras { get; set; }

    }
}