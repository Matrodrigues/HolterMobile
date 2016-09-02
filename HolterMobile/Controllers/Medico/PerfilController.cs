using HolterMobile.Facade;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolterMobile.Controllers.Medico
{
    public class PerfilController : Controller
    {
        public ActionResult Atualizar()
        {
            int medicoId = Convert.ToInt32(Session["MedicoId"]);

            CadastrarPacienteVM vm = new CadastrarPacienteVM();
            MedicoFacade facade = new MedicoFacade();

            vm = facade.CarregaDadosMedico(medicoId);

            return View("~/Views/Medico/Perfil/Atualizar.cshtml", vm);
        }
    }
}