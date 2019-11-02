using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EncriptarDesencriptar
    {
        public string Encriptar(string texto, string key)
        {
            return Seguridad.EncripDecrip.Encriptar(texto, key);
        }

        public string Desencriptar(string textoEncriptado, string key)
        {
            return Seguridad.EncripDecrip.Desencriptar(textoEncriptado, key);
        }
    }
}
