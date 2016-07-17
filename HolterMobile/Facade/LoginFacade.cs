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
            l = dao.GetLogin(login.usuario, login.senha, Convert.ToInt32(login.area));

            if (l != null)
            {
                FormsAuthentication.SetAuthCookie(l.ds_username, true);
                return 1;
            }

            return 0;            
        }
    }
}