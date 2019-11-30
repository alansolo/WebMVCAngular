using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSPrueba2
{
    public class ServicioWeb2
    {
        public static int HolaServicio2()
        {
            com.dneonline.www.Calculator calcular = new com.dneonline.www.Calculator();

            return calcular.Add(1, 2);
        }
    }
}
