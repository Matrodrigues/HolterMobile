using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolterMobile.DAO;
using HolterMobile.Models;
using HolterMobile.Facade;

namespace HolterMobile.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM dados)
        {
            Session["MedicoId"] = null;

            if (ModelState.IsValid)
            {
                LoginFacade facade = new LoginFacade();

                int logged = facade.IsValid(dados);

                if (logged == 0)
                    return Redirect("/Login/Login#InvalidUser");
                else if (logged == 9)
                {
                    Session["MedicoId"] = logged;
                    return Redirect("/Admin/Listar");
                }
                else
                {
                    Session["MedicoId"] = logged;
                    return Redirect("/Medico/Paciente/Listar");
                }
            }           

            return View("Login", dados);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["MedicoId"] = null;
            return View("~/Views/Login/Login.cshtml");
        }
    }
}