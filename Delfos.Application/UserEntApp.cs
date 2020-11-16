using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class UserEntApp
    {
        private DBSQLServer dbaccess;

        private UserEnt one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {
                var registro = new UserEnt()
                {
                    usuario = int.Parse(dataTable.Rows[position]["usuario"].ToString()),
                    entidade = int.Parse(dataTable.Rows[position]["entidade"].ToString())
                };
                return registro;
            }
            else
                return new UserEnt();
        }

        private UserEnt one(string crud, List<string> par)
        {
            dbaccess = new DBSQLServer();

            try
            {
                var dataTable = dbaccess.Datatable(crud, par);
                return one(dataTable, 0);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        private List<UserEnt> listStandart(string crud, List<string> par)
        {
            var list = new List<UserEnt>();
            dbaccess = new DBSQLServer();

            try
            {
                var dataTable = dbaccess.Datatable(crud, par);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    list.Add(one(dataTable, i));
            }
            finally
            {
                dbaccess.Dispose();
            }
            return list;
        }

        public void save(UserEnt userEnt)
        {
            var dados = new List<string>();
            dados.Add(userEnt.usuario.ToString());
            dados.Add(userEnt.entidade.ToString());

            var crud = "INSERT INTO userent(usuario, entidade) " +
                "VALUES (@dados0, @dados1)";

            dbaccess = new DBSQLServer();

            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void deleteUsuario(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM userent WHERE usuario=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void deleteEntidade(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM userent WHERE entidade=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public List<UserEnt> listUsuario(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM userent WHERE usuario=@dados0", dados);
        }

        public List<UserEnt> listEntidade(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM userent WHERE entidade=@dados0", dados);
        }

    }
}
