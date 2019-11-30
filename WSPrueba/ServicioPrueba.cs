using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSPrueba
{
    public class ServicioPrueba
    {
        public static string HolaServicio()
        {
            ServiceReference1.CalculatorSoapClient client = new ServiceReference1.CalculatorSoapClient();

            int hola = client.Add(1, 2);

            return hola.ToString();
        }
    }
}
