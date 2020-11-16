using Delfos.DBConnect;
using Delfos.Domain;
using System.Collections.Generic;
using System.Data;

namespace Delfos.Application
{
    public class UsuarioApp
    {
        private DBSQLServer dbaccess;

        private Usuario one(DataTable dataTable, int position)
        {
            EntidadeApp entidadeApp = new EntidadeApp();

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Usuario()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Nome = dataTable.Rows[position]["nome"].ToString(),
                    Login = dataTable.Rows[position]["login"].ToString(),
                    Senha = dataTable.Rows[position]["senha"].ToString(),
                    Entidades = entidadeApp.listUsuario(int.Parse(dataTable.Rows[position]["id"].ToString()))
                };
                return registro;
            }
            else
                return new Usuario();
        }

        private Usuario one(string crud, List<string> par)
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

        private List<Usuario> listStandart(string crud, List<string> par)
        {
            var list = new List<Usuario>();
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

        private void insert(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Nome.ToString());
            dados.Add(usuario.Login);
            dados.Add(usuario.Senha);

            var crud = "INSERT INTO usuarios(nome, login, senha) " +
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

        private void update(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Nome.ToString());
            dados.Add(usuario.Login);
            dados.Add(usuario.Senha);
            dados.Add(usuario.Id.ToString());

            var crud = "UPDATE usuarios SET nome=@dados0, login=@dados1, senha=@dados2, " +
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

        public void save(Usuario usuario)
        {
            if (usuario.Id > 0)
                update(usuario);
            else
                insert(usuario);
        }

        public void delete(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Id.ToString());

            dbaccess = new DBSQLServer();
            var crud = "DELETE FROM usuarios WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Usuario oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE id=" + id, dados);
        }

        public Usuario oneNome(string nome)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE nome='" + nome + "'", dados);
        }

        public Usuario oneLogin(string log)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE login='" + log + "'", dados);
        }

        public List<Usuario> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM usuarios ORDER BY id", dados);
        }

        public List<int> listEntidade(int ent)
        {
            UserEntApp userEntApp = new UserEntApp();
            List<UserEnt> luserEnts = userEntApp.listEntidade(ent);
            List<int> lusuario = new List<int>();

            foreach (UserEnt userEnt in luserEnts)
                lusuario.Add(userEnt.usuario);

            return lusuario;
        }
    }
}
