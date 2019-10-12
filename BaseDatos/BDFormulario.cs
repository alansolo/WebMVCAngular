using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class BDFormulario:BD
    {
        public object GetFormulario(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }

        public object UpdateFormulario(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }

        public object InsertFormulario(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }

    }
}
