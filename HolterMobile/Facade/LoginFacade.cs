using HolterMobile.DAO;
using HolterMobile.Models;
using HolterMobile.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HolterMobile.Facade
{
    public class LoginFacade
    {
        public int IsValid(LoginVM login)
        {
            LoginDao dao = new LoginDao();
            Login l = new Login();
            l = dao.GetLogin(login.usuario, login.senha, 1);

            if (l != null)
            {
                FormsAuthentication.SetAuthCookie(l.ds_username, true);
                return l.id_usuario;
            }

            return 0;            
        }
    }
}