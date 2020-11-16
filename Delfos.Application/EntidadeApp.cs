using Delfos.DBConnect;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class EntidadeApp
    {
        private DBSQLServer dbaccess;

        private Entidade one(DataTable dataTable, int position)
        {
            UsuarioApp usuarioApp = new UsuarioApp();

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Entidade()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Codigo = dataTable.Rows[position]["codigo"].ToString(),
                    Descricao = dataTable.Rows[position]["descricao"].ToString(),
                    Sigla = dataTable.Rows[position]["sigla"].ToString(),
                    Endereco = dataTable.Rows[position]["endereco"].ToString(),
                    CNPJ = dataTable.Rows[position]["cnpj"].ToString(),
                    Telefone = dataTable.Rows[position]["telefone"].ToString(),
                    PlanoConta = int.Parse(dataTable.Rows[position]["planoconta"].ToString()),
                    PlanoHist = int.Parse(dataTable.Rows[position]["planohist"].ToString()),
                    Titular = dataTable.Rows[position]["titular"].ToString(),
                    Cargo = dataTable.Rows[position]["cargo"].ToString(),
                    Contador = dataTable.Rows[position]["contador"].ToString(),
                    RegContador = dataTable.Rows[position]["regcontador"].ToString(),
                    Usuarios = usuarioApp.listEntidade(int.Parse(dataTable.Rows[position]["id"].ToString()))
                };
                return registro;
            }
            else
                return new Entidade();
        }

        private Entidade one(string crud, List<string> par)
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

        private List<Entidade> listStandart(string crud, List<string> par)
        {
            var list = new List<Entidade>();
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

        private void insert(Entidade entidade)
        {
            UserEntApp userEntApp = new UserEntApp();
            UsuarioApp usuarioApp = new UsuarioApp();
            UserEnt userEnt = new UserEnt();

            var dados = new List<string>();

            dados.Add(entidade.Codigo);
            dados.Add(entidade.Descricao);
            dados.Add(entidade.Sigla);
            dados.Add(entidade.Endereco);
            dados.Add(entidade.CNPJ);
            dados.Add(entidade.Telefone);
            dados.Add(entidade.PlanoConta.ToString());
            dados.Add(entidade.PlanoHist.ToString());
            dados.Add(entidade.Titular);
            dados.Add(entidade.Cargo);
            dados.Add(entidade.Contador);
            dados.Add(entidade.RegContador);

            var crud = "INSERT INTO entidades(codigo, descricao, sigla, endereco, " +
                "cnpj, telefone, planoconta, planohist, titular, cargo, contador, " +
                "regcontador) VALUES (@dados0, @dados1, @dados2, @dados3, @dados4, " +
                "@dados5, @dados6, @dados7, @dados8, @dados9, @dados10, @dados11)";

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

        private void update(Entidade entidade)
        {
            UserEntApp userEntApp = new UserEntApp();
            UsuarioApp usuarioApp = new UsuarioApp();
            UserEnt userEnt = new UserEnt();

            var dados = new List<string>();
            dados.Add(entidade.Codigo);
            dados.Add(entidade.Descricao);
            dados.Add(entidade.Sigla);
            dados.Add(entidade.Endereco);
            dados.Add(entidade.CNPJ);
            dados.Add(entidade.Telefone);
            dados.Add(entidade.PlanoConta.ToString());
            dados.Add(entidade.PlanoHist.ToString());
            dados.Add(entidade.Titular);
            dados.Add(entidade.Cargo);
            dados.Add(entidade.Contador);
            dados.Add(entidade.RegContador);
            dados.Add(entidade.Id.ToString());

            var crud = "UPDATE entidades SET codigo=@dados0, descricao=@dados1, sigla=@dados2, " +
                 "endereco=@dados3, cnpj=@dados4, telefone=@dados5, planoconta=@dados6, " +
                 "planohist=@dados7, titular=@dados8, cargo=@dados9, contador=@dados10, " +
                 "regcontador=@dados11 WHERE id=@dados12";

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

        public void save(Entidade entidade)
        {
            if (entidade.Id > 0)
                update(entidade);
            else
                insert(entidade);
        }

        public void delete(Entidade entidade)
        {
            var dados = new List<string>();
            dados.Add(entidade.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM entidades WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Entidade oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidades WHERE id=" + id, dados);
        }

        public Entidade oneCodigo(string cod)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidades WHERE codigo='" + cod + "'", dados);
        }

        public Entidade oneDescricao(string descr)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidades WHERE descricao='" + descr + "'", dados);
        }

        public Entidade oneSigla(string sigla)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidade WHERE sigla='" + sigla + "'", dados);
        }

        public Entidade oneCNPJ(string cnpj)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidades WHERE cnpj='" + cnpj + "'", dados);
        }

        public Entidade oneTelefone(string tel)
        {
            var dados = new List<string>();
            return one("SELECT * FROM entidades WHERE telefone='" + tel + "'", dados);
        }
        public List<Entidade> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM entidades ORDER BY id", dados);
        }

        public List<Entidade> listPlanoConta(int plano)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM entidades WHERE planoconta=" + plano, dados);
        }

        public List<Entidade> listPlanoHist(int plano)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM entidades WHERE planohist=" + plano, dados);
        }

        public List<int> listUsuario(int ent)
        {
            UserEntApp userEntApp = new UserEntApp();
            List<UserEnt> luserEnts = userEntApp.listUsuario(ent);
            List<int> lentidade = new List<int>();

            foreach (UserEnt userEnt in luserEnts)
                lentidade.Add(userEnt.entidade);

            return lentidade;
        }
    }
}
