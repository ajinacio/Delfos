using Delfos.DBConnect;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Delfos.Application
{
    public class SaldoApp
    {
        private DBSQLServer dbaccess;
        EntidadeApp entidadeApp = new EntidadeApp();
        ContaApp contaApp = new ContaApp();
        private CultureInfo cultEN = new CultureInfo("en-EN");

        private Saldo one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Saldo()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Entidade = entidadeApp.oneId(int.Parse(dataTable.Rows[position]["entidade"].ToString())),
                    Conta = contaApp.oneId(int.Parse(dataTable.Rows[position]["conta"].ToString())),
                    Ano = int.Parse(dataTable.Rows[position]["ano"].ToString()),
                    Tipo = dataTable.Rows[position]["tipo"].ToString(),
                    Valor = Double.Parse(dataTable.Rows[position]["valor"].ToString()),
                    DC = dataTable.Rows[position]["dc"].ToString()
                };
                return registro;
            }
            else
                return new Saldo();
        }

        private Saldo one(string crud, List<string> par)
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

        private List<Saldo> listStandart(string crud, List<string> par)
        {
            var list = new List<Saldo>();
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

        private void insert(Saldo saldo)
        {
            var dados = new List<string>();
            dados.Add(saldo.Entidade.Id.ToString());
            dados.Add(saldo.Conta.Id.ToString());
            dados.Add(saldo.Ano.ToString());
            dados.Add(saldo.Tipo);
            dados.Add(saldo.Valor.ToString(cultEN));
            dados.Add(saldo.DC);

            var crud = "INSERT INTO saldos(entidade, conta, ano, tipo, valor, dc) " +
                "VALUES (@dados0, @dados1, @dados2, @dados3, @dados4, @dados5)";

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

        private void update(Saldo saldo)
        {
            var dados = new List<string>();
            dados.Add(saldo.Entidade.Id.ToString());
            dados.Add(saldo.Conta.Id.ToString());
            dados.Add(saldo.Ano.ToString());
            dados.Add(saldo.Tipo);
            dados.Add(saldo.Valor.ToString(cultEN));
            dados.Add(saldo.DC);
            dados.Add(saldo.Id.ToString());

            var crud = "UPDATE saldos SET entidade=@dados0, conta=@dados1, " +
                 "ano=@dados2, tipo=@dados3, valor=@dados4, dc=@dados5 WHERE id=@dados6";

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

        public void save(Saldo saldo)
        {
            if (saldo.Id > 0)
                update(saldo);
            else
                insert(saldo);
        }

        public void delete(Saldo saldo)
        {
            var dados = new List<string>();
            dados.Add(saldo.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM saldos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Saldo oneConta(int entidade, int conta, int ano, string tipo)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(conta.ToString());
            dados.Add(ano.ToString());
            dados.Add(tipo);

            return one("SELECT * FROM saldos WHERE entidade=@dados0 AND conta=@dados1 " +
                "AND ano=@dados2 AND tipo=@dados3", dados);
        }

        public List<Saldo> listFinal(int entidade, int ano)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(ano.ToString());

            return listStandart("SELECT * FROM saldos WHERE entidade=@dados0 " +
                "AND ano=@dados1 AND tipo='F'", dados);
        }

        public List<Saldo> listInicial(int entidade, int ano)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(ano.ToString());

            return listStandart("SELECT * FROM saldos WHERE entidade=@dados0 " +
                "AND ano=@dados1 AND tipo='I'", dados);
        }
    }
}
