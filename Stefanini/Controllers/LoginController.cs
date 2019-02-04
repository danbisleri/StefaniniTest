using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Services;
using Entities;
using Stefanini.Models;

namespace Stefanini.Controllers
{
    public class LoginController : Controller
    {
        private readonly Service<UserSys> _login = new Service<UserSys>();

        //public LoginController()
        //{
        //    //_login = new Login();
        //}

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Stefanini.Models.Login model)
        {
            if (ModelState.IsValid)
            {
                string error;
                if (CanLogin(model.Email, FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "MD5"), out error))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if(!String.IsNullOrWhiteSpace(error))
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View("Index", model);
        }

        public bool CanLogin(string email, string password, out string error)
        {
            try
            {
                var user =  _login.GetAll().Where( l => l.Email == email && FormsAuthentication.HashPasswordForStoringInConfigFile(l.Password, "MD5") == password).FirstOrDefault();

                if (user != null)
                {
                    error = null;
                    return true;
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            error = "The email and/or password entered is invalid. Please try again.";
            return false;
        }
    }
}