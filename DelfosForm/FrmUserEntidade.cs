using Delfos.Application;
using Delfos.Domain;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DelfosForm
{
    public partial class FrmUserEntidade : Form
    {
        EntidadeApp entidadeApp = new EntidadeApp();
        Usuario usuario;
        CompetenciaApp competenciaApp = new CompetenciaApp();
        List<Competencia> competencias = new List<Competencia>();
        FrmMain frm;

        public FrmUserEntidade(Usuario user)
        {
            InitializeComponent();
            usuario = user;
            lblUsuario.Text = "Usuário: " + usuario.Nome;
        }

        private void FrmUserEntidade_Load(object sender, System.EventArgs e)
        {
            cbbEntidade.Items.Clear();
            foreach (int ident in usuario.Entidades)
                cbbEntidade.Items.Add(entidadeApp.oneId(ident).Descricao);

            if (usuario.Entidades.Count > 0) cbbEntidade.Text = cbbEntidade.Items[0].ToString();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, System.EventArgs e)
        {
            bool fl = false;
            competencias = competenciaApp.listEntidade(entidadeApp.oneDescricao(cbbEntidade.Text).Id);
            foreach (Competencia comp in competencias)
                if (comp.Aberto == "S") fl = true;

            if (fl)
            {
                frm = new FrmMain(usuario, entidadeApp.oneDescricao(cbbEntidade.Text));
                frm.Show();
                this.Dispose();
            }
            else
            {
                var result = MessageBox.Show("Deseja abrir uma competência?",
                    "Não há competência aberta para essa entidade",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                
                if (result == DialogResult.Yes)
                {
                    FrmCompEnt frm = new FrmCompEnt(entidadeApp.oneDescricao(cbbEntidade.Text));
                    frm.ShowDialog();
                }
            }
        }
    }
}
