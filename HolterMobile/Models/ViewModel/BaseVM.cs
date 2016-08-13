using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolterMobile.Enum;

namespace HolterMobile.Models.ViewModel
{
    public class BaseVM
    {
        public string nome { get; set; }
        public int idLogado { get; set; }
        public EnumPerfil perfil { get; set; }
    }
}