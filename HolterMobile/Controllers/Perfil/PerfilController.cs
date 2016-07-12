using HolterMobile.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Perfil
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        [CustomAuthorize]
        public ActionResult Perfil()
        {
            return View();
        }
    }
}