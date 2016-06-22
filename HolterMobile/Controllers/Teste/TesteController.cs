using HolterMobile.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Teste
{
    public class TesteController : Controller
    {
        public ActionResult Teste()
        {
            PerfilDao perfilDao = new PerfilDao();
            perfilDao.GetPerfil();


            return View("TesteView");
        }
    }
}