using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolterMobile.Models.ViewModel;
using HolterMobile.Models;
using HolterMobile.Facade;
using HolterMobile.DAO;

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
                PacienteFacade facade = new PacienteFacade();
                dados.idLogado = Convert.ToInt32(Session["MedicoId"]);

                facade.CadastrarPaciente(dados);

                return Redirect("/Medico/Paciente/Cadastrar#Sucesso");
            }

            return View("~/Views/Medico/Paciente/Cadastrar.cshtml", dados);
        }

        public ActionResult Listar()
        {
            PacienteFacade facade = new PacienteFacade();

            int medicoId = Convert.ToInt32(Session["MedicoId"]);

            ListaUsuarioVM vm = facade.ListaPacientes(medicoId);

            return View("~/Views/Medico/Paciente/Listar.cshtml", vm);
        }

        public ActionResult Alterar(int idPaciente)
        {
            PacienteFacade facade = new PacienteFacade();

            CadastrarPacienteVM vm = new CadastrarPacienteVM();
            vm.idPaciente = idPaciente;
            vm = facade.CarregaPaciente(idPaciente);

            return View("~/Views/Medico/Paciente/Alterar.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Alterar(CadastrarPacienteVM vm)
        {
            if (ModelState.IsValid)
            {
                PacienteFacade facade = new PacienteFacade();
                vm.idLogado = Convert.ToInt32(Session["MedicoId"]);

                if (facade.AlterarPaciente(vm))
                    return Redirect("/Medico/Paciente/Alterar/" + vm.idPaciente + "#Sucesso");
                else
                    return Redirect("/Medico/Paciente/Alterar/" + vm.idPaciente + "#Erro");
            }

            return View("~/Views/Medico/Paciente/Alterar.cshtml", vm);
        }

        public ActionResult Chat(int IdPaciente)
        {

            return View("~/Views/Medico/Paciente/Chat.cshtml");
        }

        [HttpGet]
        public ActionResult Excluir(int idPaciente)
        {
            PacienteFacade facade = new PacienteFacade();

            if (facade.ExcluirPaciente(idPaciente))
                return Redirect("/Medico/Paciente/Listar/#ExcluidoSucesso");
            else
                return Redirect("/Medico/Paciente/Listar/#ExcluidoErro");
        }

        [HttpGet]
        public ActionResult Relatorio(int idPaciente)
        {
            RelatorioVM vm = new RelatorioVM();

            UsuarioDao uDao = new UsuarioDao();

            vm.usuario = uDao.PegaUsuario(idPaciente);

            vm.idade = GetAge(vm.usuario.dt_nasc);

            vm.dataInicial = DateTime.Today;

            vm.dataFinal = DateTime.Today.AddDays(1);

            return View("~/Views/Medico/Paciente/Relatorio.cshtml", vm);
        }

        private int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        [HttpGet]
        public ActionResult PegaMedicoes(int idPaciente, string dataInicial, string dataFinal)
        {
            RelatorioVM vm = new RelatorioVM();

            if (dataInicial == "" && dataFinal == "")
            {
                dataInicial = DateTime.Today.ToShortDateString();
                dataFinal = DateTime.Today.AddDays(1).ToShortDateString();
            }

            vm.dataInicial = Convert.ToDateTime(dataInicial);
            vm.dataFinal = Convert.ToDateTime(dataFinal);
            vm.idPaciente = idPaciente;

            /* TESTE

            for (int i = 1; i < 10; i++)
            {
                Monitoramento m = new Monitoramento();

                m.horario = new DateTime().AddDays(i);
                m.bpm = 80;

                vm.listaMedidas.Add(m);
            }

            var teste = vm.listaMedidas;

            return Json(teste, JsonRequestBehavior.AllowGet);
            */

            PacienteFacade f = new PacienteFacade();

            vm = f.CarregaRelatorio(vm);

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

    }
}