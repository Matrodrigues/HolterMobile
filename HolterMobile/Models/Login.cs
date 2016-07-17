using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolterMobile.Models
{
    [Table("TB_LOGIN")]
    public class Login
    {
        [Key]
        public int id_login { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public int id_perfil { get; set; }
        [ForeignKey("id_perfil")]
        public Perfil perfil { get; set; }

        public string ds_username { get; set; }

        public string ds_senha { get; set; }
    }
}