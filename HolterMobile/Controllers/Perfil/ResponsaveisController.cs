using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Perfil
{
    public class ResponsaveisController : Controller
    {
        // GET: Responsaveis
        public ActionResult Responsaveis()
        {
            return View();
        }

        public ActionResult Teste()
        {
            return View("Perfil");
        }
    }
}