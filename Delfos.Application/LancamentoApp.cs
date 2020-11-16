using Delfos.DBConnect;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Delfos.Application
{
    public class LancamentoApp
    {
        private DBSQLServer dbaccess;
        private CultureInfo cult = new CultureInfo("pt-BR");
        private CultureInfo cultEN = new CultureInfo("en-EN");

        private Lancamento one(DataTable dataTable, int position)
        {
            EntidadeApp entidadeApp = new EntidadeApp();
            ContaApp contaApp = new ContaApp();
            HistoricoApp historicoApp = new HistoricoApp();

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Lancamento()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Entidade = entidadeApp.oneId(int.Parse(dataTable.Rows[position]["entidade"].ToString())),
                    Numero = int.Parse(dataTable.Rows[position]["numero"].ToString()),
                    Data = DateTime.Parse(dataTable.Rows[position]["data"].ToString()),
                    DC = dataTable.Rows[position]["dc"].ToString(),
                    Conta = contaApp.oneId(int.Parse(dataTable.Rows[position]["conta"].ToString())),
                    Historico = historicoApp.oneId(int.Parse(dataTable.Rows[position]["historico"].ToString())),
                    Complemento = dataTable.Rows[position]["complemento"].ToString(),
                    Valor = Double.Parse(dataTable.Rows[position]["valor"].ToString())
                };
                return registro;
            }
            else
                return new Lancamento();
        }

        private Lancamento one(string crud, List<string> par)
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

        private List<Lancamento> listStandart(string crud, List<string> par)
        {
            var list = new List<Lancamento>();
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

        private void insert(Lancamento lancamento)
        {
            var dados = new List<string>();
            dados.Add(lancamento.Entidade.Id.ToString());
            dados.Add(lancamento.Numero.ToString());
            dados.Add(lancamento.Data.ToString("yyyy/MM/dd", cult));
            dados.Add(lancamento.DC);
            dados.Add(lancamento.Conta.Id.ToString());
            dados.Add(lancamento.Historico.Id.ToString());
            dados.Add(lancamento.Complemento);
            dados.Add(lancamento.Valor.ToString(cultEN));

            var crud = "INSERT INTO lancamentos(entidade, numero, data, dc, " +
                "conta, historico, complemento, valor) VALUES (@dados0, @dados1, " +
                "@dados2, @dados3, @dados4, @dados5, @dados6, @dados7)";

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

        private void update(Lancamento lancamento)
        {
            var dados = new List<string>();

            dados.Add(lancamento.Entidade.Id.ToString());
            dados.Add(lancamento.Numero.ToString());
            dados.Add(lancamento.Data.ToString("yyyy/MM/dd", cult));
            dados.Add(lancamento.DC);
            dados.Add(lancamento.Conta.Id.ToString());
            dados.Add(lancamento.Historico.Id.ToString());
            dados.Add(lancamento.Complemento);
            dados.Add(lancamento.Valor.ToString());
            dados.Add(lancamento.Id.ToString());

            var crud = "UPDATE lancamentos SET entidade=@dados0, numero=@dados1, data=@dados2, " +
                 "dc=@dados3, conta=@dados4, historico=@dados5, complemento=@dados6, " +
                 "valor=@dados7 WHERE id=@dados8";

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

        public void save(Lancamento lancamento)
        {
            if (lancamento.Id > 0)
                update(lancamento);
            else
                insert(lancamento);
        }

        public void delete(Lancamento lancamento)
        {
            var dados = new List<string>();
            dados.Add(lancamento.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM lancamentos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Lancamento oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM lancamentos WHERE id=" + id, dados);
        }

        public Lancamento oneNumero(int num)
        {
            var dados = new List<string>();
            return one("SELECT * FROM lancamentos WHERE numero='" + num + "'", dados);
        }

        public List<Lancamento> listMes(int entidade, int ano, int mes)
        {
            DateTime dtinicial = DateTime.Parse("01/" + mes.ToString() + "/" + ano.ToString());
            DateTime dtfinal;

            if (mes == 2)
            {
                if (ano % 4 == 0)
                    dtfinal = DateTime.Parse("29/" + mes.ToString() + "/" + ano.ToString());
                else
                    dtfinal = DateTime.Parse("28/" + mes.ToString() + "/" + ano.ToString());
            }
            else
            {
                if (mes < 8)
                {
                    if (mes % 2 == 0)
                        dtfinal = DateTime.Parse("30/" + mes.ToString() + "/" + ano.ToString());
                    else
                        dtfinal = DateTime.Parse("31/" + mes.ToString() + "/" + ano.ToString());
                }
                else
                {
                    if (mes % 2 == 0)
                        dtfinal = DateTime.Parse("31/" + mes.ToString() + "/" + ano.ToString());
                    else
                        dtfinal = DateTime.Parse("30/" + mes.ToString() + "/" + ano.ToString());
                }
            }

            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(dtinicial.ToString("yyyy/MM/dd", cult));
            dados.Add(dtfinal.ToString("yyyy/MM/dd", cult));
            return listStandart("SELECT * FROM lancamentos WHERE entidade = @dados0 AND " +
                "data >= @dados1 AND data <= @dados2 ORDER BY numero", dados);
        }

        public List<Lancamento> listNumero(int numero)
        {
            var dados = new List<string>();
            dados.Add(numero.ToString());

            return listStandart("SELECT * FROM lancamentos WHERE numero = @dados0", dados);
        }

        public List<Lancamento> Diario(int ent, DateTime dtinicial, DateTime dtfinal)
        {
            var dados = new List<string>();
            dados.Add(ent.ToString());
            dados.Add(dtinicial.ToString("yyyy/MM/dd", cult));
            dados.Add(dtfinal.ToString("yyyy/MM/dd", cult));
            return listStandart("SELECT * FROM lancamentos WHERE entidade = @dados0 AND " +
                "data >= @dados1 AND data <= @dados2 ", dados);
        }

        public List<Lancamento> Razao(int ent, int conta, DateTime dtinicial, DateTime dtfinal)
        {
            var dados = new List<string>();
            dados.Add(ent.ToString());
            dados.Add(conta.ToString());
            dados.Add(dtinicial.ToString("yyyy/MM/dd", cult));
            dados.Add(dtfinal.ToString("yyyy/MM/dd", cult));
            return listStandart("SELECT * FROM lancamentos WHERE entidade = @dados0 AND " +
                "conta = @dados1 AND data >= @dados2 AND data <= @dados3", dados);
        }

    }
}
