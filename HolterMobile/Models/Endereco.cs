using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_ENDERECO")]
    public class Endereco
    {
        [Key]
        public int id_endereco { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public Boolean fl_principal { get; set; }
        public string cep { get; set; }
        public string complemento { get; set; }
        public string numero { get; set; }

    }
}