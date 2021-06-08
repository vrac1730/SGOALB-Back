﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Categoria")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}