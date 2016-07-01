using HolterMobile.DB;
using HolterMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolterMobile.DAO
{
    public class PerfilDao
    {
        public List<Perfil> GetPerfil()
        {
            HolterMobileDB db = new HolterMobileDB();
            return db.perfil.ToList();
        }
    }
}