using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HolterMobile.Models.ViewModel
{
    public class LocalizacaoVM
    {
        public int idPaciente { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string horario { get; set; }
    }
}