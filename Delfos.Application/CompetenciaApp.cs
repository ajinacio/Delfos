using Delfos.DBConnect;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Delfos.Application
{
    public class CompetenciaApp
    {
        private DBSQLServer dbaccess;
        EntidadeApp entidadeApp = new EntidadeApp();
        private CultureInfo cultEN = new CultureInfo("en-EN");

        private Competencia one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Competencia()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Entidade = entidadeApp.oneId(int.Parse(dataTable.Rows[position]["entidade"].ToString())),
                    Ano = int.Parse(dataTable.Rows[position]["ano"].ToString()),
                    Aberto = dataTable.Rows[position]["aberto"].ToString()
                };
                return registro;
            }
            else
                return new Competencia();
        }

        private Competencia one(string crud, List<string> par)
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

        private List<Competencia> listStandart(string crud, List<string> par)
        {
            var list = new List<Competencia>();
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

        private void insert(Competencia competencia)
        {
            var dados = new List<string>();
            dados.Add(competencia.Entidade.Id.ToString());
            dados.Add(competencia.Ano.ToString());
            dados.Add(competencia.Aberto);

            var crud = "INSERT INTO competencias(entidade, ano, aberto) " +
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

        private void update(Competencia competencia)
        {
            var dados = new List<string>();
            dados.Add(competencia.Entidade.Id.ToString());
            dados.Add(competencia.Ano.ToString());
            dados.Add(competencia.Aberto);
            dados.Add(competencia.Id.ToString());

            var crud = "UPDATE competencias SET entidade=@dados0, ano=@dados1, " +
                 "aberto=@dados2 WHERE id=@dados3";

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

        public void save(Competencia competencia)
        {
            if (competencia.Id > 0)
                update(competencia);
            else
                insert(competencia);
        }

        public void delete(Competencia competencia)
        {
            var dados = new List<string>();
            dados.Add(competencia.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM competencias WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Competencia oneId(int id)
        {
            var dados = new List<string>();

            return one("SELECT * FROM competencias WHERE id" + id, dados);
        }

        public Competencia oneAno(int entidade, int ano)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());
            dados.Add(ano.ToString());

            return one("SELECT * FROM competencias WHERE entidade=@dados0 AND ano=@dados1", dados);
        }

        public List<Competencia> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM competencias ORDER BY ano", dados);
        }

        public List<Competencia> listEntidade(int entidade)
        {
            var dados = new List<string>();
            dados.Add(entidade.ToString());

            return listStandart("SELECT * FROM competencias WHERE entidade=@dados0 ORDER BY ano", dados);
        }
    }
}
