using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_DADOS_MONITORADOS")]
    public class DadoMonitorado
    {
        [Key]
        public int id_dados { get; set; }

        public int id_monitor { get; set; }
        [ForeignKey("id_monitoramento")]
        public Monitoramento monitor { get; set; }

        public int temperatura { get; set; }
        public int batimento { get; set; }
        public DateTime horario { get; set; }
    }
}