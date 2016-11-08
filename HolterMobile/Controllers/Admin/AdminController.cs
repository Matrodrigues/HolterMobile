using HolterMobile.Facade;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HolterMobile.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Listar()
        {
            AdminFacade facade = new AdminFacade();

            int AdmId = Convert.ToInt32(Session["MedicoId"]);

            ListaUsuarioVM vm = facade.ListaMedicos(AdmId);

            return View("~/Views/Admin/Listar.cshtml", vm);
        }

        public ActionResult Cadastrar()
        {
            return View("~/Views/Admin/Cadastrar.cshtml");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarPacienteVM dados)
        {
            if (ModelState.IsValid)
            {
                AdminFacade facade = new AdminFacade();
                dados.idLogado = Convert.ToInt32(Session["MedicoId"]);

                facade.CadastrarMedico(dados);

                return Redirect("/Admin/Cadastrar#Sucesso");
            }

            return View("~/Views/Admin/Cadastrar.cshtml", dados);
        }

        public ActionResult Alterar(int idPaciente)
        {
            PacienteFacade facade = new PacienteFacade();

            CadastrarPacienteVM vm = new CadastrarPacienteVM();
            vm.idPaciente = idPaciente;
            vm = facade.CarregaPaciente(idPaciente);

            return View("~/Views/Admin/Alterar.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Alterar(CadastrarPacienteVM vm)
        {
            vm.altura = 0;
            vm.bpm_max = 0;
            vm.bpm_min = 0;
            vm.peso = 0;

            if (ModelState.IsValid)
            {
                AdminFacade facade = new AdminFacade();
                vm.idLogado = Convert.ToInt32(Session["MedicoId"]);

                if (facade.AlterarMedico(vm))
                    return Redirect("/Medico/Admin/Alterar/" + vm.idPaciente + "#Sucesso");
                else
                    return Redirect("/Medico/Admin/Alterar/" + vm.idPaciente + "#Erro");
            }

            return View("~/Views/Admin/Alterar.cshtml", vm);
        }
    }
}