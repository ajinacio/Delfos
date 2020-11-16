using Delfos.Application;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DelfosForm
{
    public partial class FrmCompEnt : Form
    {
        EntidadeApp entidadeApp = new EntidadeApp();
        CompetenciaApp competenciaApp = new CompetenciaApp();
        Competencia competencia;
        List<Competencia> competencias;
        Entidade entidade;
        SaldoApp saldoApp = new SaldoApp();
        List<Saldo> saldos = new List<Saldo>();
        Saldo saldo;

        public FrmCompEnt(Entidade _entidade)
        {
            InitializeComponent();

            entidade = _entidade;

            if (entidade.Descricao.Length < 38)
                lblEntidade1.Text = entidade.Descricao;
            else
            {
                for (int i = 38; i > -1; i--)
                {
                    if (entidade.Descricao.Substring(i, 1) == " ")
                    {
                        lblEntidade1.Text = entidade.Descricao.Substring(0, i);
                        lblEntidade2.Text = entidade.Descricao.Substring(i + 1, entidade.Descricao.Length - i - 2);
                        break;
                    }
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            bool fl = true;
            competencias = competenciaApp.listEntidade(entidade.Id);
            foreach (Competencia comp in competencias)
                if (comp.Aberto == "S") fl = false;

            if (fl)
            {
                competencia = new Competencia();
                competencia.Entidade = entidade;
                competencia.Ano = int.Parse(txbAno.Text);
                competencia.Aberto = "S";
                competenciaApp.save(competencia);

                if (competencias.Count > 0)
                    saldos = saldoApp.listFinal(entidade.Id, competencias[competencias.Count - 1].Ano);

                foreach (Saldo sld in saldos)
                {
                    saldo = new Saldo();
                    saldo.Entidade = entidade;
                    saldo.Conta = sld.Conta;
                    saldo.Ano = int.Parse(txbAno.Text);
                    saldo.Tipo = "I";
                    saldo.Valor = sld.Valor;
                    saldo.DC = sld.DC;

                    saldoApp.save(saldo);
                }

                MessageBox.Show("Competência " + txbAno.Text + " aberta com sucesso.");
                this.Dispose();
            }
            else
                MessageBox.Show("Entidade já possui competência aberta.");
        }
    }
}
