using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Factura()
        {
            return View();
        }

        public JsonResult CargaInicial()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarFactura()
        {
            string resultado = "";

            //LA CONEXION A NEGOCIO
            Negocio.NegFactura.NegFactura negFactura = new Negocio.NegFactura.NegFactura();

            //LLENAR OBJETO FACTURA
            Entidades.EntFactura.Factura Factura = new Entidades.EntFactura.Factura();
            Factura.Concepto = "Factura nueva";
            Factura.Monto = 5000;
            Factura.RFC = "SOSOSM8777878";
            Factura.Direccion = "NORTE 45 455 B";

            //LLENAR OBJETOS DETALLE FACTURA
            List<Entidades.EntFactura.DetalleFactura> ListDetalleFactura = new List<Entidades.EntFactura.DetalleFactura>();
            Entidades.EntFactura.DetalleFactura DetalleFactura = new Entidades.EntFactura.DetalleFactura();

            DetalleFactura.Producto = "Pantalon";
            DetalleFactura.Cantidad = 2;
            DetalleFactura.Importe = 100;
            DetalleFactura.SubTotal = 90;
            DetalleFactura.Iva = 10;
            DetalleFactura.Total = 200;
            ListDetalleFactura.Add(DetalleFactura);

            DetalleFactura = new Entidades.EntFactura.DetalleFactura();
            DetalleFactura.Producto = "Falda";
            DetalleFactura.Cantidad = 3;
            DetalleFactura.Importe = 150;
            DetalleFactura.SubTotal = 400;
            DetalleFactura.Iva = 50;
            DetalleFactura.Total = 450;
            ListDetalleFactura.Add(DetalleFactura);

            DetalleFactura = new Entidades.EntFactura.DetalleFactura();
            DetalleFactura.Producto = "Blusa";
            DetalleFactura.Cantidad = 1;
            DetalleFactura.Importe = 50;
            DetalleFactura.SubTotal = 45;
            DetalleFactura.Iva = 5;
            DetalleFactura.Total = 50;
            ListDetalleFactura.Add(DetalleFactura);


            resultado = negFactura.GuardarFactura(Factura, ListDetalleFactura);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}