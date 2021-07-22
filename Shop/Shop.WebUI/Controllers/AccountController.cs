using System;
using System.Collections.Generic;
using System.Linq;
using Shop.WebUI.Infrastructure.Abstract;
using System.Web;
using System.Web.Mvc;
using Shop.WebUI.Models;
using Shop.Domain.Entities;
using Shop.Domain.Abstract;
using System.Web.Security;

namespace Shop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        readonly IAuthProvider authProvider;
        readonly IUserRepository userRepository;

        //public AccountController(IAuthProvider provider)
        //{
        //    authProvider = provider;
        //}

        public AccountController(IUserRepository userrepository)
        {
            userRepository = userrepository;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                User newUser = userRepository.CreateUser(user);
                if (newUser != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    TempData["message"] = string.Format("{0} has been added", user.Name);
                    return RedirectToAction("Login", "Account");
                }
            }

            return View();
        }
    }
}