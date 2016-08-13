using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_ATIVIDADES")]
    public class Atividade
    {
        [Key]
        public int id_atividade { get; set; }
        public string descricao { get; set; }
    }
}