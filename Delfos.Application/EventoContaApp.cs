using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class EventoContaApp
    {
        private DBSQLServer dbaccess;

        private EventoConta one(DataTable dataTable, int position)
        {
            EventoApp eventoApp = new EventoApp();
            ContaApp contaApp = new ContaApp();
            HistoricoApp historicoApp = new HistoricoApp();

            if (dataTable.Rows.Count > 0)
            {
                var registro = new EventoConta()
                {
                    evento = eventoApp.oneId(int.Parse(dataTable.Rows[position]["evento"].ToString())),
                    conta = contaApp.oneId(int.Parse(dataTable.Rows[position]["conta"].ToString())),
                    historico = historicoApp.oneId(int.Parse(dataTable.Rows[position]["historico"].ToString())),
                    DC = dataTable.Rows[position]["dc"].ToString()
                };
                return registro;
            }
            else
                return new EventoConta();
        }

        private EventoConta one(string crud, List<string> par)
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

        private List<EventoConta> listStandart(string crud, List<string> par)
        {
            var list = new List<EventoConta>();
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

        public void save(EventoConta eventoConta)
        {
            var dados = new List<string>();
            dados.Add(eventoConta.evento.Id.ToString());
            dados.Add(eventoConta.conta.Id.ToString());
            dados.Add(eventoConta.historico.Id.ToString());
            dados.Add(eventoConta.DC);

            var crud = "INSERT INTO userent(evento, conta, historico, dc) " +
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

        public void deleteAll(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM eventoConta WHERE evento=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void deleteConta(int evento, int conta)
        {
            var dados = new List<string>();
            dados.Add(evento.ToString());
            dados.Add(conta.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM eventoConta WHERE evento=@dados0 AND conta=@dados1";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public List<EventoConta> listEvento(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM eventoconta WHERE evento=@dados0", dados);
        }
    }
}
