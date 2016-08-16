using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_CHAT")]
    public class Chat
    {
        [Key]
        public long id { get; set; }
        
        public int id_usuario_emissor { get; set; }

        public int id_usuario_receptor { get; set; }

        public DateTime horario { get; set; }

        public string mensagem { get; set; }

    }
}