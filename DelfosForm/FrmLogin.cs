using Delfos.Application;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DelfosForm
{
    public partial class FrmLogin : Form
    {
        FrmUserEntidade frmUserEntidade;
        FrmMain frmMain;
        UsuarioApp app = new UsuarioApp();
        Usuario user = new Usuario();
        CompetenciaApp competenciaApp = new CompetenciaApp();
        List<Competencia> competencias =  new List<Competencia>();
        EntidadeApp entidadeApp = new EntidadeApp();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CONFIRMAtextBox.Visible = false;
            CONFIRMAlabel.Visible = false;
        }

        private void LOGINtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

                if (LOGINtextBox.Text != "")
                {
                    user = app.oneLogin(LOGINtextBox.Text);
                    SENHAtextBox.Focus();
                }
            }
        }

        private void CANCELARbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ENTRARbutton_Click(object sender, EventArgs e)
        {
            if (LOGINtextBox.Text != "" & SENHAtextBox.Text != "")
            {
                if (CONFIRMAtextBox.Visible)
                {
                    if (CONFIRMAtextBox.Text != "")
                    {
                        if (SENHAtextBox.Text == CONFIRMAtextBox.Text)
                        {
                            user.Senha = SENHAtextBox.Text;
                            app.save(user);
                            entrar();
                        }
                        else
                        {
                            MessageBox.Show("Confirmação da senha diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CONFIRMAtextBox.Focus();
                        }
                    }
                }
                else
                {
                    if (user.Senha == SENHAtextBox.Text)
                    {
                        entrar();
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha não cadastrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SENHAtextBox.Text = "";
                        LOGINtextBox.Text = "";
                        LOGINtextBox.Focus();
                    }
                }
            }
        }

        private void SENHAtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (LOGINtextBox.Text == "")
                {
                    MessageBox.Show("Usuário em branco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SENHAtextBox.Text = "";
                    LOGINtextBox.Text = "";
                    LOGINtextBox.Focus();
                }
                else
                {
                    if (SENHAtextBox.Text == "")
                    {
                        MessageBox.Show("Senha em branco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SENHAtextBox.Text = "";
                        LOGINtextBox.Text = "";
                        LOGINtextBox.Focus();
                    }
                    else
                    {
                        if (CONFIRMAtextBox.Visible) CONFIRMAtextBox.Focus();
                        else
                        {
                            user = app.oneLogin(LOGINtextBox.Text);
                            if (user.Senha == SENHAtextBox.Text)
                            {
                                entrar();
                            }
                            else
                            {
                                MessageBox.Show("Login ou senha não cadastrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SENHAtextBox.Text = "";
                                LOGINtextBox.Text = "";
                                LOGINtextBox.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void CONFIRMAtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (SENHAtextBox.Text == CONFIRMAtextBox.Text)
                {
                    user.Senha = SENHAtextBox.Text;
                    app.save(user);
                    entrar();
                }
                else
                    MessageBox.Show("Confirmação de senha diferente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LOGINtextBox_Leave(object sender, EventArgs e)
        {
            user = app.oneLogin(LOGINtextBox.Text);
            if (user.Id > 0 & user.Senha == "")
            {
                CONFIRMAlabel.Visible = true;
                CONFIRMAtextBox.Visible = true;
            }
        }

        private void entrar()
        {
            bool fl = false;
            if (user.Entidades.Count == 1)
            {
                competencias = competenciaApp.listEntidade(user.Entidades[0]);
                foreach (Competencia comp in competencias)
                    if (comp.Aberto == "S") fl = true;

                if (fl)
                {
                    frmMain = new FrmMain(user, entidadeApp.oneId(user.Entidades[0]));
                    frmMain.Show();
                }
                else
                {
                    frmUserEntidade = new FrmUserEntidade(user);
                    frmUserEntidade.Show();
                }
            }
            else
            {
                frmUserEntidade = new FrmUserEntidade(user);
                frmUserEntidade.Show();
            }
            this.Dispose();
        }
    }
}
