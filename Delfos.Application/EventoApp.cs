using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class EventoApp
    {
        private DBSQLServer dbaccess;

        private Evento one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Evento()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Codigo = int.Parse(dataTable.Rows[position]["codigo"].ToString()),
                    Descricao = dataTable.Rows[position]["descricao"].ToString()
                };
                return registro;
            }
            else
                return new Evento();
        }

        private Evento one(string crud, List<string> par)
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

        private List<Evento> listStandart(string crud, List<string> par)
        {
            var list = new List<Evento>();
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

        private void insert(Evento evento)
        {
            var dados = new List<string>();
            dados.Add(evento.Codigo.ToString());
            dados.Add(evento.Descricao);

            var crud = "INSERT INTO eventos(codigo, descricao) VALUES (@dados0, @dados1)";

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

        private void update(Evento evento)
        {
            var dados = new List<string>();
            dados.Add(evento.Codigo.ToString());
            dados.Add(evento.Descricao);
            dados.Add(evento.Id.ToString());

            var crud = "UPDATE eventos SET codigo=@dados0, descricao=@dados1, WHERE id=@dados2";

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

        public void save(Evento evento)
        {
            if (evento.Id > 0)
                update(evento);
            else
                insert(evento);
        }

        public void delete(Evento evento)
        {
            var dados = new List<string>();
            dados.Add(evento.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM eventos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Evento oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM eventos WHERE id=" + id, dados);
        }

        public Evento oneCodigo(int cod)
        {
            var dados = new List<string>();
            return one("SELECT * FROM eventos WHERE codigo=" + cod, dados);
        }

        public List<Evento> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM eventos ORDER BY id", dados);
        }
    }
}
