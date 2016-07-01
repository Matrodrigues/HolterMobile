using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class UsuarioDao
    {
        public List<Usuario> GetUsuarios()
        {
            HolterMobileDB db = new HolterMobileDB();
            return db.usuario.ToList();
        }
    }
}