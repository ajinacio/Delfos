using Delfos.DBConnect;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Delfos.Application
{
    public class MovimentoApp
    {
        private DBSQLServer dbaccess;
        EntidadeApp entidadeApp = new EntidadeApp();
        ContaApp contaApp = new ContaApp();
        private CultureInfo cultEN = new CultureInfo("en-EN");

        private Movimento one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Movimento()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Entidade = entidadeApp.oneId(int.Parse(dataTable.Rows[position]["entidade"].ToString())),
                    Conta = contaApp.oneId(int.Parse(dataTable.Rows[position]["conta"].ToString())),
                    Ano = int.Parse(dataTable.Rows[position]["ano"].ToString()),
                    Mes = int.Parse(dataTable.Rows[position]["mes"].ToString()),
                    Devedor = Double.Parse(dataTable.Rows[position]["devedor"].ToString()),
                    Credor = Double.Parse(dataTable.Rows[position]["credor"].ToString()),
                };
                return registro;
            }
            else
                return new Movimento();
        }

        private Movimento one(string crud, List<string> par)
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

        private List<Movimento> listStandart(string crud, List<string> par)
        {
            var list = new List<Movimento>();
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

        private void insert(Movimento movimento)
        {
            var dados = new List<string>();
            dados.Add(movimento.Entidade.Id.ToString());
            dados.Add(movimento.Conta.Id.ToString());
            dados.Add(movimento.Ano.ToString());
            dados.Add(movimento.Mes.ToString());
            dados.Add(movimento.Devedor.ToString(cultEN));
            dados.Add(movimento.Credor.ToString(cultEN));

            var crud = "INSERT INTO movimentos(entidade, conta, ano, mes, devedor, credor) " +
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

        private void update(Movimento movimento)
        {
            var dados = new List<string>();
            dados.Add(movimento.Entidade.Id.ToString());
            dados.Add(movimento.Conta.Id.ToString());
            dados.Add(movimento.Ano.ToString());
            dados.Add(movimento.Mes.ToString());
            dados.Add(movimento.Devedor.ToString(cultEN));
            dados.Add(movimento.Credor.ToString(cultEN));
            dados.Add(movimento.Id.ToString());

            var crud = "UPDATE movimentos SET entidade=@dados0, conta=@dados1, " +
                 "ano=@dados2, mes=@dados3, devedor=@dados4, credor=@dados5 WHERE id=@dados6";

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

        public void save(Movimento movimento)
        {
            if (movimento.Id > 0)
                update(movimento);
            else
                insert(movimento);
        }

        public void delete(Movimento movimento)
        {
            var dados = new List<string>();
            dados.Add(movimento.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM movimentos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void update(Lancamento lc, string ie)
        {
            Movimento movimento = oneConta(lc.Entidade.Id, lc.Conta.Id, lc.Data.Month, lc.Data.Year);

            if (ie == "I")
            {
                if (movimento.Id == 0)
                {
                    movimento.Entidade = lc.Entidade;
                    movimento.Conta = lc.Conta;
                    movimento.Mes = lc.Data.Month;
                    movimento.Ano = lc.Data.Year;
                    if (lc.DC == "D") movimento.Devedor = lc.Valor;
                    if (lc.DC == "C") movimento.Credor = lc.Valor;

                    insert(movimento);
                }
                else
                {
                    if (lc.DC == "D") movimento.Devedor += lc.Valor;
                    if (lc.DC == "C") movimento.Credor += lc.Valor;

                    update(movimento);
                }
            }
            else
            {
                if (lc.DC == "D") movimento.Devedor -= lc.Valor;
                if (lc.DC == "C") movimento.Credor -= lc.Valor;

                if (movimento.Devedor == 0 && movimento.Credor == 0)
                    delete(movimento);
                else
                    update(movimento);
            }
        }

        public Movimento oneConta(int entidade, int conta, int mes, int ano)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(conta.ToString());
            dados.Add(ano.ToString());
            dados.Add(mes.ToString());

            return one("SELECT * FROM movimentos WHERE entidade=@dados0 AND conta=@dados1 " +
                "AND ano=@dados2 AND mes=@dados3", dados);
        }

        public List<Movimento> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM movimentos ORDER BY id", dados);
        }

        public List<Movimento> listTipo(int entidade, int ano, int mes)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(ano.ToString());
            dados.Add(mes.ToString());

            return listStandart("SELECT * FROM movimentos WHERE entidade=@dados0 " +
                "AND ano=@dados1, AND mes=@dados2", dados);
        }
    }
}
