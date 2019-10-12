using BaseDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegFormulario
    {
        public List<Formulario> GetFormulario()
        {
            List<Formulario> ListFormulario = new List<Formulario>();

            BaseDatos.BDFormulario bdFormulario = new BaseDatos.BDFormulario();

            object resultado = new object();

            DataTable dtResultado = new DataTable();

            StringBuilder sbResultado = new StringBuilder();

            resultado = bdFormulario.GetFormulario("GetFormulario", new List<BaseDatos.Parametro>());

            dtResultado = (DataTable)resultado;

            if (dtResultado.Rows.Count > 0)
            {
                sbResultado.Append("[");

                dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                {
                    sbResultado.Append(n[0].ToString());
                });

                sbResultado.Append("]");
            }


            var jsonListUsuario = JsonConvert.DeserializeObject<Formulario[]>(sbResultado.ToString());

            ListFormulario = jsonListUsuario.ToList();


            return ListFormulario;
        }

        public string UpdateFormulario(Formulario formulario)
        {
            string sResultado = "";
            object resultado = new object();
            DataTable dtResultado = new DataTable();

            BaseDatos.BDFormulario bdFormulario = new BaseDatos.BDFormulario();

            List<Parametro> ListaParametro = new List<Parametro>();

            Parametro parametro = new Parametro();

            parametro.Nombre = "Id";
            parametro.Valor = formulario.Id;
            ListaParametro.Add(parametro);

            parametro = new Parametro();

            parametro.Nombre = "Nombre";
            parametro.Valor = formulario.Nombre;
            ListaParametro.Add(parametro);

            parametro = new Parametro();

            parametro.Nombre = "ApellidoPaterno";
            parametro.Valor = formulario.ApellidoPaterno;
            ListaParametro.Add(parametro);

            parametro = new Parametro();

            parametro.Nombre = "ApellidoMaterno";
            parametro.Valor = formulario.ApellidoMaterno;
            ListaParametro.Add(parametro);


            resultado = bdFormulario.UpdateFormulario("UpdateFormulario", ListaParametro);

            dtResultado = (DataTable)resultado;

            if (dtResultado.Rows.Count > 0)
            {
                sResultado = "OK";
            }
            else
            {
                sResultado = "ERROR";
            }

            return sResultado;
        }

        public List<Formulario> InsertFormulario(Formulario formulario)
        {
            object resultado = new object();
            List<Formulario> ListFormulario = new List<Formulario>();

            StringBuilder sbResultado = new StringBuilder();

            DataTable dtResultado = new DataTable();

            BaseDatos.BDFormulario bdFormulario = new BaseDatos.BDFormulario();

            List<Parametro> ListaParametro = new List<Parametro>();

            Parametro parametro = new Parametro();

            parametro.Nombre = "Nombre";
            parametro.Valor = formulario.Nombre;
            ListaParametro.Add(parametro);

            parametro = new Parametro();

            parametro.Nombre = "ApellidoPaterno";
            parametro.Valor = formulario.ApellidoPaterno;
            ListaParametro.Add(parametro);

            parametro = new Parametro();

            parametro.Nombre = "ApellidoMaterno";
            parametro.Valor = formulario.ApellidoMaterno;
            ListaParametro.Add(parametro);


            resultado = bdFormulario.InsertFormulario("InsertFormulario", ListaParametro);

            dtResultado = (DataTable)resultado;

            if (dtResultado.Rows.Count > 0)
            {
                sbResultado.Append("[");

                dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                {
                    sbResultado.Append(n[0].ToString());
                });

                sbResultado.Append("]");
            }


            var jsonListUsuario = JsonConvert.DeserializeObject<Formulario[]>(sbResultado.ToString());

            ListFormulario = jsonListUsuario.ToList();


            return ListFormulario;
        }

    }
}
