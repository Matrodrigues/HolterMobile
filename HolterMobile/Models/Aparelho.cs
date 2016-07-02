using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolterMobile.Models
{
    [Table("TB_APARELHO")]
    public class Aparelho
    {
        [Key]
        public int id_aparelho { get; set; }
        public string modelo { get; set; }
    }
}