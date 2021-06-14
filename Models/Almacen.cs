﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class Almacen
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }

        public List<ProductoxAlmacen> ProductoxAlmacen { get; set; }
    }
}