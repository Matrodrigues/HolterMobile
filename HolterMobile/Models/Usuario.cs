﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }

        [StringLength(1)]
        [Column(TypeName = "char")]
        public string sexo { get; set; }

        public DateTime dt_nasc { get; set; }
        public int bpm_min { get; set; }
        public int bpm_max { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }

    }
}