using BaseDatos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BaseDatos.BDFactura
{
    public class BDFactura
    {
        public string GuardarFactura(Entidades.EntFactura.Factura Factura, List<Entidades.EntFactura.DetalleFactura> ListDetalleFactura)
        {
            string resultado = "";

            try
            {
                using (var bd = new PruebaEntities())
                {
                    
                    //var dos = bd.Factura;
                    using (var tran = new TransactionScope())
                    {
                        //dos.Add(Factura);
                        //var uno = bd.Factura;
                        //uno.Add(Factura);
                        bd.Factura.Add(Factura);
                        bd.SaveChanges();

                        ListDetalleFactura.ForEach(n =>
                        {
                            n.IdFactura = Factura.Id;
                            bd.DetalleFactura.Add(n);                           
                        });

                        bd.SaveChanges();

                        tran.Complete();
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = "Error: " + ex.Message;
                
            }

            return resultado;
        }
    }
}
