using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;   
namespace FicticiaSAWeb.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Usuario u, string returnUrl)
        {
            if (validationUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.usuario, false);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Clientes");
            
            }
            TempData["mensaje"] = "Usuario o Contraseña incorrectos";
            return View(u);
        }

        private bool validationUser(Models.Usuario u)
        {
            if (u.usuario == "admin" && u.contrasenia == "admin")
            {
                return true;
            }
            return false;              
        
        }

        public ActionResult LogOut() {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }

    }
}