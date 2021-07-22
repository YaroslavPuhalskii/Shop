using Shop.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Shop.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string name, string password)
        {
            bool user = FormsAuthentication.Authenticate(name, password);
            if (user)
            {
                FormsAuthentication.SetAuthCookie(name, false);
            }

            return user;
        }
    }
}