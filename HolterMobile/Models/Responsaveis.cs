using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_RESPONSAVEIS")]
    public class Responsaveis
    {
        [Key]
        public int id_responsavel { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public string nome { get; set; }

        public string tel_responsavel { get; set; }
    }
}