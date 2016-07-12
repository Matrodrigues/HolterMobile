using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }
    }
}