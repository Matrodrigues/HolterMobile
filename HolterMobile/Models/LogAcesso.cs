using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_LOG_ACESSO")]
    public class LogAcesso
    {
        [Key]
        public int id_log { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public int id_perfil { get; set; }
        [ForeignKey("id_perfil")]
        public Perfil perfil { get; set; }

        public DateTime horario { get; set; }
    }
}