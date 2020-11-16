using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Delfos.DBConnect
{
    public class DBSQLServer
    {
        private readonly SqlConnection conex;

        public DBSQLServer()
        {
            var strcnx = "server = GRUMIO\\MANDII;Initial Catalog = Delfos; User ID = sa; Password=12tres;";
            conex = new SqlConnection(strcnx);
            conex.Open();
        }

        public async void commandExecuteNonQuery(string strQuery, List<string> par)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conex
            };

            for (int i = 0; i < par.Count; i++)
            {
                try
                {
                    cmdComando.Parameters.Add(new SqlParameter("@dados" +
                        i.ToString(), par[i]));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@dados" +
                        i.ToString(), DateTime.Parse(par[i])));
                }
            }

            cmdComando.ExecuteNonQuery();
        }

        public DataTable Datatable(string strQuery, List<string> par)
        {
            var dt = new DataTable();
            var da = new SqlDataAdapter();

            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conex
            };


            for (int i = 0; i < par.Count; i++)
            {
                try
                {
                    cmdComando.Parameters.Add(new SqlParameter("@dados" +
                        i.ToString(), par[i]));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@dados" +
                        i.ToString(), DateTime.Parse(par[i])));
                }
            }

            da.SelectCommand = cmdComando;
            da.Fill(dt);

            return dt;
        }

        // Não retirar as chaves
        public void Dispose()
        {
            if (conex.State == ConnectionState.Open) conex.Close();
        }
    }
}
