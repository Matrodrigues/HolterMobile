using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolterMobile.Models.ViewModel;
using HolterMobile.Facade;

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

            CadastrarPacienteVM vm = new CadastrarPacienteVM();



            return View("~/Views/Medico/Paciente/Alterar.cshtml", vm);
        }

        public ActionResult Chat(int IdPaciente)
        {

            return View("~/Views/Medico/Paciente/Chat.cshtml");
        }

    }
}