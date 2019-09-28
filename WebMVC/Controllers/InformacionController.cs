using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class InformacionController : Controller
    {
        // GET: Informacion
        public ActionResult VistaAngular()
        {
            return View();
        }

        public JsonResult CargarTabla()
        {
            List<DatosTabla> listaDatos = new List<Models.DatosTabla>();
            DatosTabla datos = new Models.DatosTabla();

            //comentario

            datos.Id = 1;
            datos.Nombre = "Nombre 1";
            datos.Descripcion = "Descripcion 1";
            listaDatos.Add(datos);

            datos = new Models.DatosTabla();
            datos.Id = 2;
            datos.Nombre = "Nombre 2";
            datos.Descripcion = "Descripcion 2";
            listaDatos.Add(datos);

            datos = new Models.DatosTabla();
            datos.Id = 3;
            datos.Nombre = "Nombre 3";
            datos.Descripcion = "Descripcion 3";
            listaDatos.Add(datos);

            return Json(listaDatos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarRegistroTabla()
        {
            return Json(new DatosTabla(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarRegistroTabla2(List<DatosTabla> ListaDatos)
        {
            DatosTabla datosTabla = new DatosTabla();
            datosTabla.Id = 5;
            datosTabla.Nombre = "Nombre 5";
            datosTabla.Descripcion = "Descripcion 5";
            ListaDatos.Add(datosTabla);

            return Json(ListaDatos, JsonRequestBehavior.AllowGet);

        }
    }
}