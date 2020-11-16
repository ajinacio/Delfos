using Delfos.Application;
using Delfos.Domain;
using System;
using System.Windows.Forms;

namespace DelfosForm
{
    public partial class FrmMain : Form
    {
        Usuario usuario;
        Entidade entidade;
        EntidadeApp entidadeApp = new EntidadeApp();
        public FrmMain(Usuario _usuario, Entidade _entidade)
        {
            InitializeComponent();
            usuario = _usuario;
            entidade = _entidade;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLancamento_Click(object sender, EventArgs e)
        {
            FrmLancamento frm = new FrmLancamento(entidade);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmRelatorios frm = new FrmRelatorios(entidade);
            frm.ShowDialog();
        }
    }
}
