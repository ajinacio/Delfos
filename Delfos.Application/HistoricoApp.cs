using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class HistoricoApp
    {
        private DBSQLServer dbaccess;

        private Historico one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Historico()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Plano = int.Parse(dataTable.Rows[position]["plano"].ToString()),
                    Codigo = dataTable.Rows[position]["codigo"].ToString(),
                    Descricao = dataTable.Rows[position]["descricao"].ToString()
                };
                return registro;
            }
            else
                return new Historico();
        }

        private Historico one(string crud, List<string> par)
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

        private List<Historico> listStandart(string crud, List<string> par)
        {
            var list = new List<Historico>();
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

        private void insert(Historico historico)
        {
            var dados = new List<string>();
            dados.Add(historico.Plano.ToString());
            dados.Add(historico.Codigo);
            dados.Add(historico.Descricao);

            var crud = "INSERT INTO historicos(plano, codigo, descricao) " +
                "VALUES (@dados0, @dados1, @dados2)";

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

        private void update(Historico historico)
        {
            var dados = new List<string>();
            dados.Add(historico.Plano.ToString());
            dados.Add(historico.Codigo);
            dados.Add(historico.Descricao);
            dados.Add(historico.Id.ToString());

            var crud = "UPDATE historicos SET plano=@dados0, codigo=@dados1, descricao=@dados2, " +
                 "WHERE id=@dados3";

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

        public void save(Historico historico)
        {
            if (historico.Id > 0)
                update(historico);
            else
                insert(historico);
        }

        public void delete(Historico historico)
        {
            var dados = new List<string>();
            dados.Add(historico.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM historicos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Historico oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM historicos WHERE id=" + id, dados);
        }

        public Historico oneCodigo(string cod)
        {
            var dados = new List<string>();
            return one("SELECT * FROM historicos WHERE codigo='" + cod + "'", dados);
        }

        public List<Historico> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM historicos ORDER BY id", dados);
        }

        public List<Historico> listPlano(int plano)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM historicos WHERE plano=" + plano, dados);
        }
    }
}
