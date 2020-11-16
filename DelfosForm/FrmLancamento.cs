using Delfos.Application;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DelfosForm
{
    public partial class FrmLancamento : Form
    {
        ConvNumero cv = new ConvNumero();
        ContaApp contaApp = new ContaApp();
        EntidadeApp entidadeApp = new EntidadeApp();
        Entidade entidade;
        List<Conta> contas;
        HistoricoApp historicoApp = new HistoricoApp();
        List<Historico> historicos;
        Lancamento lancamento = new Lancamento();
        LancamentoApp lancamentoApp = new LancamentoApp();
        List<Lancamento> lancamentos;
        List<Lancamento> lancConta;
        Evento evento = new Evento();
        EventoApp eventoApp = new EventoApp();
        EventoConta eventoConta = new EventoConta();
        EventoContaApp eventoContaApp = new EventoContaApp();
        List<EventoConta> eventoContas = new List<EventoConta>();
        SaldoApp saldoApp = new SaldoApp();
        MovimentoApp movimentoApp = new MovimentoApp();
        ConvNumero cn = new ConvNumero();

        double vlrDebito = 0;
        double vlrCredito = 0;
        int NumeroLanc = 0;

        public FrmLancamento(Entidade _entidade)
        {
            InitializeComponent();
            entidade = _entidade;
        }

        private void FrmLancamento_Load(object sender, EventArgs e)
        {

            lblDebito.Text = "";
            lblCredito.Text = "";
            lblDiferenca.Text = "";

            contas = contaApp.listNivel(5);
            historicos = historicoApp.listAll();

            foreach (Historico historico in historicos)
                cbbCodHist.Items.Add(historico.Codigo);

            dtpDataLanc.Value = DateTime.Now;

            pnlLancCabecalho.txbCodConta.Text = "Código";
            pnlLancCabecalho.txbConta.Text = "Descrição da Conta";
            pnlLancCabecalho.txbCodHist.Text = "Cód.";
            pnlLancCabecalho.txbHist.Text = "Histórico Padrão";
            pnlLancCabecalho.txbComplemento.Text = "Complemento";
            pnlLancCabecalho.txbValor.Text = "Valor";
            pnlLancCabecalho.txbValor.Size = new System.Drawing.Size(122, 24);
            pnlLancCabecalho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lancamentos = lancamentoApp.listMes(entidade.Id, dtpDataLanc.Value.Year, dtpDataLanc.Value.Month);

            if (lancamentos.Count == 0)
                NumeroLanc = 1;
            else
                NumeroLanc = lancamentos[lancamentos.Count - 1].Numero + 1;

            txbNumero.Text = NumeroLanc.ToString();
        }

        private void cbbCodConta_KeyUp(object sender, KeyEventArgs e)
        {
            cbbCodConta.DroppedDown = false;
            if (e.KeyValue == 13)
            {
                string digitos;
                bool fl;
                cbbCodConta.Items.Clear();

                e.Handled = true;
                if (cbbCodConta.Text.Length == 1)
                {
                    if (Char.IsNumber(cbbCodConta.Text, 0))
                    {

                        foreach (Conta conta in contas)
                            if (conta.Codigo.Substring(0, 1) == cbbCodConta.Text)
                                cbbCodConta.Items.Add(conta.Codigo);
                    }
                }

                if (cbbCodConta.Text.Length > 1)
                {
                    if (Char.IsNumber(cbbCodConta.Text, 0) && Char.IsNumber(cbbCodConta.Text, 1))
                    {
                        if (cbbCodConta.Text.Length < 7)
                        {
                            fl = true;
                            for (int i = 0; i < cbbCodConta.Text.Length; i++)
                            {
                                if (!Char.IsNumber(cbbCodConta.Text, i)) fl = false;
                            }

                            if (fl)
                            {
                                digitos = "";
                                for (int i = 0; i < cbbCodConta.Text.Length; i++)
                                {
                                    if (i > 0 && i < 5) digitos += ".";
                                    digitos += cbbCodConta.Text.Substring(i, 1);
                                }
                                cbbCodConta.Text = digitos;

                                foreach (Conta conta in contas)
                                    if (conta.Codigo.Substring(0, cbbCodConta.Text.Length) == cbbCodConta.Text)
                                        cbbCodConta.Items.Add(conta.Codigo);
                            }
                        }
                    }
                    else
                    {
                        if (Char.IsNumber(cbbCodConta.Text, 0) && cbbCodConta.Text.Substring(1, 1) == ".")
                        {
                            if (cbbCodConta.Text.Length < 11)
                            {
                                foreach (Conta conta in contas)
                                    if (conta.Codigo.Substring(0, cbbCodConta.Text.Length) == cbbCodConta.Text)
                                        cbbCodConta.Items.Add(conta.Codigo);
                            }
                        }
                    }
                }

                if (cbbCodConta.Items.Count == 0)
                    cbbCodConta.Text = "";

                if (cbbCodConta.Items.Count == 1)
                    cbbCodConta.Text = cbbCodConta.Items[0].ToString();

                if (cbbCodConta.Items.Count > 1)
                    cbbCodConta.DroppedDown = true;

                cbbCodConta.Select(cbbCodConta.Text.Length, 1);
                txbConta.Text = contaApp.oneCodigo(cbbCodConta.Text).Descricao;
                cbbCodHist.Focus();
            }

        }

        private void cbbCodConta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dtpDataLanc_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataLanc.Value == DateTime.Parse("01/01/2000"))
                mtbDataLanc.Text = "";
            else mtbDataLanc.Text = dtpDataLanc.Value.ToString().Substring(0, 10);
        }

        private void mtbDataLanc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    dtpDataLanc.Value = DateTime.Parse(mtbDataLanc.Text);
                }
                catch
                {
                    dtpDataLanc.Value = DateTime.Parse("01/01/2000");
                }
                txbNumero.Focus();
            }
        }

        private void mtbDataLanc_Leave(object sender, EventArgs e)
        {
            try
            {
                dtpDataLanc.Value = DateTime.Parse(mtbDataLanc.Text);
            }
            catch
            {
                dtpDataLanc.Value = DateTime.Parse("01/01/2000");

            }
        }

        private void dtpDataLanc_KeyUp(object sender, KeyEventArgs e)
        {
            txbNumero.Focus();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbHist_KeyUp(object sender, KeyEventArgs e)
        {
            cbbCodHist.DroppedDown = false;
            if (e.KeyValue == 13)
            {

                if (cbbCodHist.Text.Length == 1)
                {
                    cbbCodHist.Text = "00" + cbbCodHist.Text;
                }

                if (cbbCodHist.Text.Length == 2)
                {
                    cbbCodHist.Text = "0" + cbbCodHist.Text;
                }

                cbbCodHist.Select(cbbCodHist.Text.Length, 1);
                txbHist.Text = historicoApp.oneCodigo(cbbCodHist.Text).Descricao;
                txbComplemento.Focus();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txbNumero.Text != "" && cbbCodConta.Text != "" && cbbCodHist.Text != "" &&
                txbValor.Text != "" && (rbtDebito.Checked || rbtCredito.Checked))
            {

                string[] stDados = new string[7];
                stDados[0] = cbbCodConta.Text;
                stDados[1] = txbConta.Text;
                stDados[2] = cbbCodHist.Text;
                stDados[3] = txbHist.Text;
                stDados[4] = txbComplemento.Text;
                stDados[5] = txbValor.Text;
                if (rbtDebito.Checked) stDados[6] = "D";
                if (rbtCredito.Checked) stDados[6] = "C";
                string ant = pnlGridLanc.add(stDados);

                if (ant == "")
                {

                    if (rbtDebito.Checked)
                    {
                        vlrDebito += cn.desformatar(txbValor.Text);
                        lblDebito.Text = cn.formatar(vlrDebito.ToString());
                    }
                    if (rbtCredito.Checked)
                    {
                        vlrCredito += cn.desformatar(txbValor.Text);
                        lblCredito.Text = cn.formatar(vlrCredito.ToString());
                    }

                    if (vlrDebito > vlrCredito)
                        lblDiferenca.Text = cn.formatar((vlrDebito - vlrCredito).ToString()) + "D";

                    if (vlrCredito > vlrDebito)
                        lblDiferenca.Text = cn.formatar((vlrCredito - vlrDebito).ToString()) + "C";

                    if (vlrCredito == vlrDebito) lblDiferenca.Text = "";
                }
                else
                {
                    if (rbtDebito.Checked)
                    {
                        vlrDebito += (cn.desformatar(txbValor.Text) - cn.desformatar(ant));
                        lblDebito.Text = cn.formatar(vlrDebito.ToString());
                    }
                    if (rbtCredito.Checked)
                    {
                        vlrCredito += (cn.desformatar(txbValor.Text) - cn.desformatar(ant));
                        lblCredito.Text = cn.formatar(vlrCredito.ToString());
                    }

                    if (vlrDebito > vlrCredito)
                        lblDiferenca.Text = cn.formatar((vlrDebito - vlrCredito).ToString()) + "D";

                    if (vlrCredito > vlrDebito)
                        lblDiferenca.Text = cn.formatar((vlrCredito - vlrDebito).ToString()) + "C";

                    if (vlrCredito == vlrDebito) lblDiferenca.Text = "";
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnlGridLanc_Click(object sender, EventArgs e)
        {

        }

        private void FrmLancamento_Click(object sender, EventArgs e)
        {
            label4.Text = ActiveControl.Parent.Name;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlGridLanc.Controls)
            {
                if (control.BackColor == Color.Red)
                {
                    if (control.Controls[6].Text == "D")
                    {
                        vlrDebito -= cn.desformatar(control.Controls[5].Text);
                        lblDebito.Text = cn.formatar(vlrDebito.ToString());
                    }
                    else
                    {
                        vlrCredito -= cn.desformatar(control.Controls[5].Text);
                        lblCredito.Text = cn.formatar(vlrCredito.ToString());
                    }

                    if (vlrDebito > vlrCredito)
                        lblDiferenca.Text = cn.formatar((vlrDebito - vlrCredito).ToString()) + "D";

                    if (vlrCredito > vlrDebito)
                        lblDiferenca.Text = cn.formatar((vlrCredito - vlrDebito).ToString()) + "C";

                    if (vlrCredito == vlrDebito) lblDiferenca.Text = "";

                    pnlGridLanc.Controls.Remove(control);
                }
            }

            pnlGridLanc.ptName = 0;
            pnlGridLanc.positionLanc = -23;
            foreach (Control control in pnlGridLanc.Controls)
            {
                pnlGridLanc.ptName += 1;
                pnlGridLanc.positionLanc += 25;
                control.Name = "pnlLanc" + pnlGridLanc.ptName.ToString();
                control.Location = new System.Drawing.Point(2, pnlGridLanc.positionLanc);
            }

        }

        private void rbtDebito_Enter(object sender, EventArgs e)
        {
            if (rbtDebito.Tag == "D") rbtDebito.Checked = true;
            if (rbtDebito.Tag == "C") rbtDebito.Checked = false;
            rbtDebito.Tag = "";
        }

        private void rbtCredito_Enter(object sender, EventArgs e)
        {
            if (rbtCredito.Tag == "D") rbtCredito.Checked = false;
            if (rbtCredito.Tag == "C") rbtCredito.Checked = true;
            rbtCredito.Tag = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnNovoConta_Click(object sender, EventArgs e)
        {
            cbbCodConta.Text = "";
            txbConta.Text = "";
            cbbCodHist.Text = "";
            txbHist.Text = "";
            txbComplemento.Text = "";
            txbValor.Text = "";
            rbtDebito.Checked = false;
            rbtCredito.Checked = false;
        }

        private void limpar()
        {
            dtpDataLanc.Value = DateTime.Now;

            txbCodEvento.Text = "";
            txbEvento.Text = "";

            txbNumero.Text = "";
            cbbCodConta.Text = "";
            txbConta.Text = "";
            cbbCodHist.Text = "";
            txbHist.Text = "";
            txbComplemento.Text = "";
            txbValor.Text = "";
            rbtDebito.Checked = false;
            rbtCredito.Checked = false;
            lblDebito.Text = "";
            lblCredito.Text = "";
            lblDiferenca.Text = "";
            vlrDebito = 0;
            vlrCredito = 0;

            Control control;

            while (pnlGridLanc.Controls.Count > 1)
            {
                control = pnlGridLanc.Controls[1];
                pnlGridLanc.Controls.Remove(control);
            }

            lancamentos = lancamentoApp.listMes(entidade.Id, dtpDataLanc.Value.Year, dtpDataLanc.Value.Month);

            if (lancamentos.Count == 0)
                NumeroLanc = 1;
            else
                NumeroLanc = lancamentos[lancamentos.Count - 1].Numero + 1;

            txbNumero.Text = NumeroLanc.ToString();
            pnlGridLanc.positionLanc = 4;
            pnlGridLanc.ptName = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (vlrDebito == vlrCredito && pnlGridLanc.Controls.Count > 1)
            {
                lancConta = lancamentoApp.listNumero(int.Parse(txbNumero.Text));
                foreach (Lancamento lanc in lancConta)
                    lancamentoApp.delete(lanc);

                foreach (Control control in pnlGridLanc.Controls)
                {
                    if (control.BackColor != Color.CadetBlue)
                    {
                        lancamento = new Lancamento();

                        lancamento.Entidade = entidadeApp.oneId(1);
                        lancamento.Data = dtpDataLanc.Value;
                        lancamento.Numero = int.Parse(txbNumero.Text);
                        lancamento.Conta = contaApp.oneCodigo(control.Controls[0].Text);
                        lancamento.Historico = historicoApp.oneCodigo(control.Controls[2].Text);
                        lancamento.Complemento = control.Controls[4].Text;
                        lancamento.Valor = cn.desformatar(control.Controls[5].Text);
                        lancamento.DC = control.Controls[6].Text;

                        if (lancamento.Valor > 0)
                        {
                            lancamentoApp.save(lancamento);
                            movimentoApp.update(lancamento, "I");
                        }
                    }
                }

                limpar();
            }
        }

        private void txbNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cbbCodConta.Focus();
            }
        }

        private void txbComplemento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txbValor.Focus();
            }
        }

        private void txbValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnIncluir.Focus();
            }
        }

        private void rbtDebito_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                rbtCredito.Focus();
            }
        }

        private void rbtCredito_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnIncluir.Focus();
            }
        }

        private void txbValor_Leave(object sender, EventArgs e)
        {
            txbValor.Text = cn.formatar(txbValor.Text);
        }

        private void txbCodEvento_Leave(object sender, EventArgs e)
        {
            string[] stDados;

            txbCodEvento.Text = txbCodEvento.Text.PadLeft(2, '0');
            evento = eventoApp.oneCodigo(int.Parse(txbCodEvento.Text));
            txbEvento.Text = evento.Descricao;
            eventoContas = eventoContaApp.listEvento(evento.Id);

            foreach (EventoConta ec in eventoContas)
            {
                stDados = new string[7];
                stDados[0] = contaApp.oneId(ec.conta.Id).Codigo;
                stDados[1] = contaApp.oneId(ec.conta.Id).Descricao;
                stDados[2] = historicoApp.oneId(ec.historico.Id).Codigo;
                stDados[3] = historicoApp.oneId(ec.historico.Id).Descricao;
                stDados[4] = "";
                stDados[5] = "0,00";
                stDados[6] = ec.DC;

                pnlGridLanc.add(stDados);
            }
        }

        private void txbCodEvento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txbEvento.Focus();
            }
        }

        private void txbNumero_Leave(object sender, EventArgs e)
        {
            if (int.Parse(txbNumero.Text) > NumeroLanc) txbNumero.Text = NumeroLanc.ToString();
            string nm = txbNumero.Text;
            limpar();
            txbNumero.Text = nm;

            string[] stDados;

            eventoContas = eventoContaApp.listEvento(evento.Id);
            lancamentos = lancamentoApp.listNumero(int.Parse(txbNumero.Text));
            vlrDebito = 0;
            vlrCredito = 0;

            foreach (Lancamento lc in lancamentos)
            {
                stDados = new string[7];
                stDados[0] = contaApp.oneId(lc.Conta.Id).Codigo;
                stDados[1] = contaApp.oneId(lc.Conta.Id).Descricao;
                stDados[2] = historicoApp.oneId(lc.Historico.Id).Codigo;
                stDados[3] = historicoApp.oneId(lc.Historico.Id).Descricao;
                stDados[4] = lc.Complemento;
                stDados[5] = cn.formatar(lc.Valor.ToString());
                stDados[6] = lc.DC;
                if (lc.DC == "D") vlrDebito += lc.Valor;

                pnlGridLanc.add(stDados);
            }
            vlrCredito = vlrDebito;
            lblDebito.Text = cn.formatar(vlrDebito.ToString());
            lblCredito.Text = cn.formatar(vlrCredito.ToString());
            lblDiferenca.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lancConta = lancamentoApp.listNumero(int.Parse(txbNumero.Text));
            foreach (Lancamento lanc in lancConta)
            {
                lancamentoApp.delete(lanc);
                movimentoApp.update(lanc, "E");
            }
            limpar();
        }

        private void cbbCodConta_Leave(object sender, EventArgs e)
        {
            txbConta.Text = contaApp.oneCodigo(cbbCodConta.Text).Descricao;
        }

        private void cbbCodHist_Leave(object sender, EventArgs e)
        {
            txbHist.Text = historicoApp.oneCodigo(cbbCodHist.Text).Descricao;
        }

        private void cbbCodConta_TextChanged(object sender, EventArgs e)
        {
            txbConta.Text = contaApp.oneCodigo(cbbCodConta.Text).Descricao;
        }

        private void cbbCodHist_TextChanged(object sender, EventArgs e)
        {
            txbHist.Text = historicoApp.oneCodigo(cbbCodHist.Text).Descricao; 
        }
    }
}
