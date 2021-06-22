﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGOALB_BACK.Models
{
    [Table("Permiso")]
    public class Permiso
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public List<RolxPermiso> RolxPermiso { get; set; }
    }
}