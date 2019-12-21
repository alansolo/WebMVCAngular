using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        public JsonResult ValidarLogin(string usuario, string password)
        {
            
            string mensaje = "";

            if (usuario == "alumno" && password == "alumno123")
            {
                mensaje = "OK";

                Models.Login login = new Models.Login();
                login.usuario = usuario;
                login.password = password;

                Session["Usuario"] = login;
                //Response.Redirect("/Informacion/VistaAngular", true);
            }
            else
            {
                mensaje = "El usuario y/o password son incorrectos.";
            }

            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }

    }
}