using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.NegFactura
{
    public class NegFactura
    {
        public string GuardarFactura(Entidades.EntFactura.Factura Factura, List<Entidades.EntFactura.DetalleFactura> ListDetalleFactura)
        {
            string resultado = "";
            
            try
            {
                BaseDatos.BDFactura.BDFactura bdFactura = new BaseDatos.BDFactura.BDFactura();

                resultado = bdFactura.GuardarFactura(Factura, ListDetalleFactura);
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
            }

            return resultado;
        }
    }
}
