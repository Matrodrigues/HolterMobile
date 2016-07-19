using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Medico
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Cadastrar()
        {
            return View("~/Views/Medico/Paciente/Cadastrar.cshtml");
        }
    }
}