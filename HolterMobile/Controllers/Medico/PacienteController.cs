using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolterMobile.Models.ViewModel;

namespace HolterMobile.Controllers.Medico
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Cadastrar()
        {
            return View("~/Views/Medico/Paciente/Cadastrar.cshtml");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarPacienteVM dados)
        {
            if (ModelState.IsValid)
            {

            }

            return View("~/Views/Medico/Paciente/Cadastrar.cshtml", dados);
        }

        public ActionResult Listar()
        {
            return View("~/Views/Medico/Paciente/Listar.cshtml");
        }
    }
}