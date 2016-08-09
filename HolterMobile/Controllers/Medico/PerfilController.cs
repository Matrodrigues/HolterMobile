using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Medico
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Atualizar()
        {
            return View("~/Views/Medico/Perfil/Atualizar.cshtml");
        }
    }
}