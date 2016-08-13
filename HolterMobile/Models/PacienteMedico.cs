using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_PACIENTE_MEDICO")]
    public class PacienteMedico
    {
        [Key]
        public int id { get; set; }

        public int id_paciente { get; set; }

        public int id_medico { get; set; }

    }
}