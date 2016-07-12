using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolterMobile.Enum;

namespace HolterMobile.Models.ViewModel
{
    public class BaseVM
    {
        protected string nome { get; set; }
        protected EnumPerfil perfil { get; set; }
    }
}