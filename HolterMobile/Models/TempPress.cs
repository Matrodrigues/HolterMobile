using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_TEMP_PRESS")]
    public class TempPress
    {
        [Key]
        public int id { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public DateTime horario { get; set; }

        public double temperatura { get; set; }

        public double pressao { get; set; }
    }
}