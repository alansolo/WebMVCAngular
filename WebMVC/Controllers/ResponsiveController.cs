using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class ResponsiveController : Controller
    {
        // GET: Responsive
        public ActionResult Responsive()
        {
            string vari = WSPrueba.ServicioPrueba.HolaServicio();

            int uno = WSPrueba2.ServicioWeb2.HolaServicio2();

            //WCFPrueba.Service1 service = new WCFPrueba.Service1();

            //int dos = service.OperacionChicharronera(10, 2);

            ServiceWCF.Service1Client client = new ServiceWCF.Service1Client();
            int tres = client.OperacionChicharronera(10, 2);

            return View();
        }
    }
}