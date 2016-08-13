using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.Models.ViewModel
{
    public class ListaUsuarioVM : BaseVM
    {
        public List<Usuario> usuarios { get; set; }

        public string filtroNome { get; set; }
    }
}