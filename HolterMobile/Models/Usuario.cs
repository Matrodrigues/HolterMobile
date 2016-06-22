using System;
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
    }
}