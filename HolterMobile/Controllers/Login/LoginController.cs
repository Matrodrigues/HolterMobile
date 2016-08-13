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
                else
                {
                    Session["MedicoId"] = logged;
                    return Redirect("/Relatorio/Relatorio");
                }
            }           

            return View("Login", dados);
        }
    }
}