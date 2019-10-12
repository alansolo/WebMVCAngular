using Negocio;
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

            listaDatos = listaDatos.Where(n => n.Id == 1 || n.Id == 3).OrderBy(m => m.Nombre).ToList();

            listaDatos.ForEach(n =>
            {
                n.Descripcion = listaDatos.Sum(x => x.Id).ToString();
            });

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

        public JsonResult LlenarFormulario()
        {
            Formulario formulario = new Formulario();

            formulario.Nombre = "Kiba";
            formulario.ApellidoPaterno = "Husky";
            formulario.ApellidoMaterno = "Alaska";

            return Json(formulario, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PasarDatos(Formulario Formulario_JSON)
        {

            string nombre = Formulario_JSON.Nombre;

            Negocio.NegFormulario negFormulario = new NegFormulario();

            List<Formulario> ListaFormulario = negFormulario.GetFormulario();


            return Json(ListaFormulario, JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult EditarFormulario(Formulario Formulario_Editar)
        {
            var elemento = Formulario_Editar;

            Negocio.NegFormulario negFormulario = new NegFormulario();

            string resultado = "";

            resultado = negFormulario.UpdateFormulario(Formulario_Editar);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertFormulario(Formulario Formulario_Insert)
        {
            Negocio.NegFormulario negFormulario = new NegFormulario();

            List<Formulario> ListaFormulario = new List<Formulario>();

            ListaFormulario = negFormulario.InsertFormulario(Formulario_Insert);

            if(ListaFormulario.Count > 0)
            {
                Formulario_Insert = ListaFormulario.FirstOrDefault();
            }


            return Json(Formulario_Insert, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Inicializar()
        {
            Formulario formulario = new Formulario();

            return Json(formulario, JsonRequestBehavior.AllowGet);
        }
    }
}