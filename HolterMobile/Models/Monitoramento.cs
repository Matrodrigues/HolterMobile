using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace HolterMobile.Models
{
    [Table("TB_MONITORAMENTO")]
    public class Monitoramento
    {
        [Key]
        public int id_monitoramento { get; set; }

        //public int id_medico { get; set; }
        //[ForeignKey("id_medico")]
        //public Usuario medico { get; set; }

        public int id_paciente { get; set; }
        [ForeignKey("id_paciente")]
        public Usuario paciente { get; set; }

        public int id_aparelho { get; set; }
        [ForeignKey("id_aparelho")]
        public Aparelho aparelho { get; set; }

        public int bpm { get; set; }
        public DateTime horario { get; set; }

        public int id_atividade { get; set; }
        [ForeignKey("id_atividade")]
        public Atividade atividade { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

    }
}