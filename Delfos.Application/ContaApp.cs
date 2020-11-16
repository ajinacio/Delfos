using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class ContaApp
    {
        private DBSQLServer dbaccess;

        private Conta one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Conta()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    PlanoContas = int.Parse(dataTable.Rows[position]["planocontas"].ToString()),
                    Codigo = dataTable.Rows[position]["codigo"].ToString(),
                    Descricao = dataTable.Rows[position]["descricao"].ToString(),
                    Nivel = int.Parse(dataTable.Rows[position]["nivel"].ToString())
                };
                return registro;
            }
            else
                return new Conta();
        }

        private Conta one(string crud, List<string> par)
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

        private List<Conta> listStandart(string crud, List<string> par)
        {
            var list = new List<Conta>();
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

        private void insert(Conta conta)
        {
            var dados = new List<string>();
            dados.Add(conta.PlanoContas.ToString());
            dados.Add(conta.Codigo);
            dados.Add(conta.Descricao);
            dados.Add(conta.Nivel.ToString());

            var crud = "INSERT INTO contas(planocontas, codigo, descricao, nivel) " +
                "VALUES (@dados0, @dados1, @dados2, @dados3)";

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

        private void update(Conta conta)
        {
            var dados = new List<string>();
            dados.Add(conta.PlanoContas.ToString());
            dados.Add(conta.Codigo);
            dados.Add(conta.Descricao);
            dados.Add(conta.Nivel.ToString());
            dados.Add(conta.Id.ToString());

           var crud = "UPDATE contas SET planocontas=@dados0, codigo=@dados1, descricao=@dados2, " +
                "nivel=@dados3 WHERE id=@dados4";

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

        public void save(Conta conta)
        {
            if (conta.Id > 0)
                update(conta);
            else
                insert(conta);
        }

        public void delete(Conta conta)
        {
            var dados = new List<string>();
            dados.Add(conta.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM contas WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Conta oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM contas WHERE id=" + id, dados);
        }

        public Conta oneCodigo(string cod)
        {
            var dados = new List<string>();
            return one("SELECT * FROM contas WHERE codigo='" + cod + "'", dados);
        }

        public List<Conta> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM contas ORDER BY id", dados);
        }

        public List<Conta> listPlano(int plano)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM contas WHERE planoconta=" + plano, dados);
        }

        public List<Conta> listNivel(int nivel)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM contas WHERE nivel=" + nivel, dados);
        }
    }
}
