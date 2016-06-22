using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_PERFIL")]
    public class Perfil
    {
        [Key]
        public int id_perfil { get; set; }
        public string ds_perfil { get; set; }
    }
}