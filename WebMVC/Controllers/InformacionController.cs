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

        public JsonResult UtilizarEF()
        {

            List<Tabla_1> tabla1 = new List<Tabla_1>();
            List<Table_2> tabla2 = new List<Table_2>();

            var tablaFusion = new Object();

            Tabla_1 tabla1_a = new Tabla_1();
            tabla1_a.Nombre = "Agregado";
            tabla1_a.Id = 7;


            using (var bd = new PruebaEntities1())
            {
                //SELECT
                //tabla1 = (from bdL in bd.Tabla_1
                //                       //where bdL.Id == 1
                //                       select bdL).ToList();

                //tabla2 = (from bdL2 in bd.Table_2
                //              //where bdL.Id == 1
                //          select bdL2).ToList();

                //tablaFusion = (from tf1 in bd.Tabla_1.Where(n => n.Id >= 2)
                //               from tf2 in bd.Table_2
                //               where tf1.Id == tf2.Id
                //               select new { tf1, tf2 }).ToList();



                for (int j = 0; j <= 100; j++)
                {
                    var tab = new Tabla_1()
                    {
                        Nombre = "don" + j
                    };

                    //INSERT
                    bd.Tabla_1.Add(tab);
                }

                //Task<int> k = bd.SaveChangesAsync();               


                bd.Table_2.Add(new Table_2() { Id = 1, Nombre = "Nom", Descripcion = "Descrip" });

                int i = bd.SaveChanges();

                //UPDATE
                bd.Tabla_1.Where(n => n.Nombre == "don").ToList().ForEach(m =>
                {
                    m.Nombre = "Nuevo don";
                });

                //DELETE
                bd.Tabla_1.RemoveRange(bd.Tabla_1.Where(n => n.Id >= 4));

                //int i = bd.SaveChanges();


            }


            List<Tabla_1> dos = tabla1.Where(n => n.Id >= 3).ToList();

            decimal total = dos.Sum(n => n.Id);

            decimal max = dos.Max(n => n.Id);

            string nombre = dos.Select(n => n.Nombre).FirstOrDefault();

            var tres = (from dosL in dos
                        select new
                        {
                            dosL.Id,
                            otro = dosL.Id + 10,
                            dosL.Nombre
                        }).ToList();

            var cuatro = (from t1 in tabla1.Where(n => n.Id == 1)
                          from t2 in tabla2.Where(n => n.Nombre == "Chevrolet")
                          where t1.Id == t2.Id
                          select new { t1.Id, t1.Nombre, Nombre2 = t2.Nombre, t2.Descripcion }).ToList();


            var cinco = (from u1 in tabla1
                         select new Table_2 { Id = u1.Id, Nombre = u1.Nombre, Descripcion = u1.Nombre + "_desc" }).ToList();

            var seis = tabla1.Where(n => n.Id == 1).ToList();

            var siete = (from a1 in tabla1
                         where a1.Id == 1
                         select a1).ToList();

            var ocho = tabla2.Select(n => n.Nombre).Distinct().ToList();

            var nueve = tabla1.Select(n => n.Id).Except(tabla2.Select(n => n.Id));

            var diez = tabla2.OrderBy(n => n.Id).ThenByDescending(m => m.Nombre).ThenBy(x => x.Id).ToList();

            tabla2.ForEach(n =>
            {
                n.Id = n.Id + 10;

                n.Nombre = n.Nombre + "_A";
            });

            tabla2.Remove(tabla2.FirstOrDefault());

            tabla2.RemoveAll(n => n.Id > 3);

            tabla2.RemoveAt(0);

            tabla2.RemoveRange(0, 1);

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public JsonResult EncriptarCadena(string cadena)
        {
            Session["HolaMundo"] = "Este es un dato que se guarda en la variable de sesion";

            Negocio.EncriptarDesencriptar enc = new EncriptarDesencriptar();

            string cadenaEncriptada = enc.Encriptar(cadena, "claseseguridad1234+*+*");

            return Json(cadenaEncriptada, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesencriptarCadena(string cadenaEncriptada)
        {
            Negocio.EncriptarDesencriptar enc = new EncriptarDesencriptar();

            string cadena = enc.Desencriptar(cadenaEncriptada, "claseseguridad1234+*+*");

            return Json(cadena, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PruebaLayout()
        {
            return View();
        }

        public ActionResult PruebaLayout2()
        {
            return View();
        }
    }
}