using Delfos.Domain;
using Delfos.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Globalization;
using System.Linq;

namespace DelfosForm
{
    public partial class FrmDiario : Form
    {
        Entidade entidade;
        List<Lancamento> lancamentos;
        LancamentoApp lancamentoApp = new LancamentoApp();
        private CultureInfo cult = new CultureInfo("pt-BR");

        public FrmDiario(Entidade _entidade)
        {
            InitializeComponent();
            entidade = _entidade;
        }

        private void tabelaCab(Table tab)
        {
            TextFormat textFormat = new TextFormat();
            tab.Rows[0].Cells[0].Paragraphs[0].Font("Times New Roman");
            tab.Rows[0].Cells[0].Paragraphs[0].FontSize(8);

            lancamentos = lancamentoApp.Diario(entidade.Id, DateTime.Parse("01/01/" + txbAno.Text), DateTime.Parse("31/12/" + txbAno.Text));

            tab.Rows[tab.Rows.Count - 1].Cells[0].Width = 50;
            tab.Rows[tab.Rows.Count - 1].Cells[0].Paragraphs[0].Append("Data", textFormat.FTimes8B);
            tab.Rows[tab.Rows.Count - 1].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            tab.Rows[tab.Rows.Count - 1].Cells[1].Width = 15;
            tab.Rows[tab.Rows.Count - 1].Cells[1].Paragraphs[0].Append("Num", textFormat.FTimes8B);
            tab.Rows[tab.Rows.Count - 1].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            tab.Rows[tab.Rows.Count - 1].Cells[2].Width = 180;
            tab.Rows[tab.Rows.Count - 1].Cells[2].Paragraphs[0].Append("Conta", textFormat.FTimes8B);
            tab.Rows[tab.Rows.Count - 1].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            tab.Rows[tab.Rows.Count - 1].Cells[3].Width = 223;
            tab.Rows[tab.Rows.Count - 1].Cells[3].Paragraphs[0].Append("Histórico", textFormat.FTimes8B);
            tab.Rows[tab.Rows.Count - 1].Cells[3].VerticalAlignment = VerticalAlignment.Center;

            tab.Rows[tab.Rows.Count - 1].Cells[4].Width = 70;
            tab.Rows[tab.Rows.Count - 1].Cells[4].Paragraphs[0].Append("Valor", textFormat.FTimes8B);
            tab.Rows[tab.Rows.Count - 1].Cells[4].Paragraphs[0].Alignment = Alignment.right;
            tab.Rows[tab.Rows.Count - 1].Cells[4].VerticalAlignment = VerticalAlignment.Center;
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            TextFormat textFormat = new TextFormat();
            ConvNumero convNumero = new ConvNumero();
            string texto;
            Paragraph parag;
            Paragraph paragAssina;

            DateTime dtinicial = DateTime.Parse("01/01/2000");
            DateTime dtfinal = DateTime.Parse("01/01/2000");

            string arq = "Diario_" + entidade.Sigla.TrimEnd() + "_" + txbAno.Text + ".docx";
            var document = DocX.Create(arq);

            document.MarginLeft = 25;
            document.MarginRight = 3;
            document.PageLayout.Orientation = Xceed.Document.NET.Orientation.Portrait;
            Border border = new Border();
            border.Color = Color.Transparent;

            document.AddHeaders();

            document.DifferentFirstPage = false;
            document.DifferentOddAndEvenPages = false;

            ///// Begin - Header ////////

            var tabCab = document.Headers.Odd.InsertTable(3, 3);

            int lateral = 150;
            int central = 250;

            tabCab.Rows[0].Cells[0].Width = lateral;
            tabCab.Rows[0].Cells[1].Width = central;
            tabCab.Rows[0].Cells[2].Width = lateral;

            tabCab.Rows[1].Cells[0].Width = lateral;
            tabCab.Rows[1].Cells[1].Width = central;
            tabCab.Rows[1].Cells[2].Width = lateral;

            tabCab.Rows[2].Cells[0].Width = lateral;
            tabCab.Rows[2].Cells[1].Width = central;
            tabCab.Rows[2].Cells[2].Width = lateral;

            tabCab.Rows[0].MergeCells(0, 1);
            tabCab.SetBorder(TableBorderType.InsideH, border);
            tabCab.SetBorder(TableBorderType.InsideV, border);

            texto = entidade.Descricao;
            tabCab.Rows[0].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[0].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            texto = "Data de Emissão: " + DateTime.Now.ToString("dd/MM/yyyy");
            tabCab.Rows[0].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[0].Cells[1].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[0].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            texto = "Hora:         " + DateTime.Now.ToString("HH'h'mm");
            tabCab.Rows[1].Cells[2].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[1].Cells[2].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[1].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            texto = "CNPJ: " + entidade.CNPJ;
            tabCab.Rows[1].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[1].Cells[0].VerticalAlignment = VerticalAlignment.Center;
            //82040923 - CPP
            texto = "LIVRO DIÁRIO";
            tabCab.Rows[2].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[2].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            tabCab.Rows[2].Cells[2].Paragraphs[0].Append("Página:   ", textFormat.FTimes8b);
            tabCab.Rows[2].Cells[2].Paragraphs[0].AppendPageNumber(PageNumberFormat.normal);
            tabCab.Rows[2].Cells[2].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[2].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            //////////  End - Header /////////////

            ////// - Begin - Termo de Abertura //////

            document.InsertParagraph();
            document.InsertParagraph();

            texto = "TERMO DE ABERTURA";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes16BS);
            parag.Alignment = Alignment.center;
            document.InsertParagraph();
            document.InsertParagraph();
            document.InsertParagraph();

            parag = document.InsertParagraph("");
            parag.Alignment = Alignment.both;
            parag.IndentationAfter = 60;
            parag.IndentationBefore = 50;
            parag.LineSpacing = 20.0f;

            document.MarginLeft = 25;
            document.MarginRight = 3;
            document.MarginBottom = 35;

            document.InsertParagraph();
            document.InsertParagraph();

            Paragraph paragData = document.InsertParagraph("", false, textFormat.FTimes14b);
            paragData.Alignment = Alignment.center;

            document.InsertParagraph();
            document.InsertParagraph();

            int numSpace = 1;
            if ((entidade.Titular.Trim().Length + entidade.Contador.Trim().Length) < 60)
                numSpace = 60 - entidade.Titular.Trim().Length - entidade.Contador.Trim().Length;

            texto = entidade.Titular.Trim() + string.Concat(Enumerable.Repeat(" ", numSpace)) + entidade.Contador.Trim();
            paragAssina = document.InsertParagraph(texto, false, textFormat.FTimes14b);
            paragAssina.Alignment = Alignment.center;

            numSpace = 1;
            if ((entidade.Cargo.Trim().Length + entidade.RegContador.Trim().Length) < 60)
                numSpace = 70 - entidade.Cargo.Trim().Length - entidade.RegContador.Trim().Length;

            texto = entidade.Cargo.Trim() + string.Concat(Enumerable.Repeat(" ", numSpace)) + entidade.RegContador.Trim();
            paragAssina = document.InsertParagraph(texto, false, textFormat.FTimes14b);
            paragAssina.Alignment = Alignment.center;

            paragAssina.IndentationBefore = 40;

            document.InsertParagraph();
            document.InsertParagraph().InsertPageBreakAfterSelf();

            ////// - End - Termo de Abertura //////

            var tab = document.InsertTable(1, 5);
            tabelaCab(tab);

            if (lancamentos.Count > 0)
            {
                dtinicial = lancamentos[0].Data;
                dtfinal = lancamentos[lancamentos.Count - 1].Data;
            }

            int contRows = 0;
            int contPage = 2;

            foreach (Lancamento lanc in lancamentos)
            {
                contRows += 1;

                if (contRows > 70)
                {
                    document.InsertParagraph().InsertPageBreakAfterSelf();
                    tab = document.InsertTable(1, 5);
                    tabelaCab(tab);
                    contPage += 1;
                    contRows = 1;
                }

                tab.InsertRow();

                tab.Rows[tab.Rows.Count - 1].Cells[0].Width = 50;
                tab.Rows[tab.Rows.Count - 1].Cells[0].Paragraphs[0].Append(lanc.Data.ToShortDateString(), textFormat.FTimes8b);
                tab.Rows[tab.Rows.Count - 1].Cells[0].VerticalAlignment = VerticalAlignment.Center;

                tab.Rows[tab.Rows.Count - 1].Cells[1].Width = 15;
                tab.Rows[tab.Rows.Count - 1].Cells[1].Paragraphs[0].Append(lanc.Numero.ToString(), textFormat.FTimes8b);
                tab.Rows[tab.Rows.Count - 1].Cells[4].Paragraphs[0].Alignment = Alignment.center;
                tab.Rows[tab.Rows.Count - 1].Cells[1].VerticalAlignment = VerticalAlignment.Center;

                tab.Rows[tab.Rows.Count - 1].Cells[2].Width = 180;
                tab.Rows[tab.Rows.Count - 1].Cells[2].Paragraphs[0].Append(lanc.Conta.Codigo +
                    " - " + lanc.Conta.Descricao, textFormat.FTimes8b);
                tab.Rows[tab.Rows.Count - 1].Cells[2].VerticalAlignment = VerticalAlignment.Center;

                tab.Rows[tab.Rows.Count - 1].Cells[3].Width = 223;
                tab.Rows[tab.Rows.Count - 1].Cells[3].Paragraphs[0].Append(lanc.Historico.Descricao.Trim() +
                    " " + lanc.Complemento.Trim(), textFormat.FTimes8b);
                tab.Rows[tab.Rows.Count - 1].Cells[3].VerticalAlignment = VerticalAlignment.Center;

                tab.Rows[tab.Rows.Count - 1].Cells[4].Width = 70;
                tab.Rows[tab.Rows.Count - 1].Cells[4].Paragraphs[0].Append(convNumero.formatar(lanc.Valor.ToString()) +
                    lanc.DC, textFormat.FTimes8b);
                tab.Rows[tab.Rows.Count - 1].Cells[4].Paragraphs[0].Alignment = Alignment.right;
                tab.Rows[tab.Rows.Count - 1].Cells[4].VerticalAlignment = VerticalAlignment.Center;
            }

            tabCab.Rows[2].Cells[1].Paragraphs[0].Append("Período: " +
                dtinicial.ToString("dd/MM/yyyy", cult) + " a " + dtfinal.ToString("dd/MM/yyyy", cult), textFormat.FTimes8b);
            tabCab.Rows[2].Cells[1].Paragraphs[0].Alignment = Alignment.center;
            tabCab.Rows[2].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            texto = "Este livro contém " + contPage + " folhas numeradas " +
            "sequencialmente de 1" + " a " + contPage + " e servirá para " +
            "o registro da escrituração contábil da empresa " + entidade.Descricao.Trim() +
            ", CNPJ " + entidade.CNPJ + " referente ao exercício de " + txbAno.Text +
            ", conforme normas vigentes.";
            parag.Append(texto, textFormat.FTimes14b);

            texto = "Manaus, " + extenso(dtinicial);
            paragData.Append(texto, textFormat.FTimes14b);

            /// Begin - Termo de Encerramento ///

            document.InsertParagraph().InsertPageBreakAfterSelf();
            document.InsertParagraph();
            document.InsertParagraph();

            contPage += 1;

            texto = "TERMO DE ENCERRAMENTO";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes16BS);
            parag.Alignment = Alignment.center;
            document.InsertParagraph();
            document.InsertParagraph();
            document.InsertParagraph();

            texto = "Este livro contém " + contPage + " folhas numeradas " +
            "sequencialmente de 1" + " a " + contPage + " e serviu para " +
            "o registro da escrituração contábil da empresa " + entidade.Descricao.Trim() +
            ", CNPJ " + entidade.CNPJ + " referente ao exercício de " + txbAno.Text +
            ", conforme normas vigentes.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes14b);
            parag.Append(" folhas numeradas ", textFormat.FTimes14b);
            parag.Alignment = Alignment.both;

            parag.IndentationAfter = 60;
            parag.IndentationBefore = 50;
            parag.LineSpacing = 20.0f;
            document.MarginLeft = 25;
            document.MarginRight = 3;
            document.InsertParagraph();
            document.InsertParagraph();

            parag = document.InsertParagraph("Manaus, " + extenso(dtfinal), false, textFormat.FTimes14b);
            parag.Alignment = Alignment.center;

            document.InsertParagraph();
            document.InsertParagraph();

            numSpace = 1;
            if ((entidade.Titular.Trim().Length + entidade.Contador.Trim().Length) < 60)
                numSpace = 60 - entidade.Titular.Trim().Length - entidade.Contador.Trim().Length;

            texto = entidade.Titular.Trim() + string.Concat(Enumerable.Repeat(" ", numSpace)) + entidade.Contador.Trim();
            parag = document.InsertParagraph(texto, false, textFormat.FTimes14b);
            parag.Alignment = Alignment.center;

            numSpace = 1;
            if ((entidade.Cargo.Trim().Length + entidade.RegContador.Trim().Length) < 60)
                numSpace = 70 - entidade.Cargo.Trim().Length - entidade.RegContador.Trim().Length;

            texto = entidade.Cargo.Trim() + string.Concat(Enumerable.Repeat(" ", numSpace)) + entidade.RegContador.Trim();
            paragAssina = document.InsertParagraph(texto, false, textFormat.FTimes14b);
            paragAssina.Alignment = Alignment.center;

            paragAssina.IndentationBefore = 40;

            /// End - Termo de Encerramento ///

            try
            {
                document.Save();
            }
            catch { }

            //DocX.ConvertToPdf(document, "ConvertedDocument.pdf");
            Process.Start("WINWORD.EXE", arq);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbAno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) btnProcessar.Focus();
        }

        private string extenso(DateTime dt)
        {
            string extenso;

            if (dt.Day == 1) extenso = "1º de ";
            else
                extenso = dt.Day.ToString() + " de ";

            if (dt.Month == 1) extenso += "janeiro de ";
            if (dt.Month == 2) extenso += "fevereiro de ";
            if (dt.Month == 3) extenso += "março de ";
            if (dt.Month == 4) extenso += "abril de ";
            if (dt.Month == 5) extenso += "maio de ";
            if (dt.Month == 6) extenso += "junho de ";
            if (dt.Month == 7) extenso += "julho de ";
            if (dt.Month == 8) extenso += "agosto de ";
            if (dt.Month == 9) extenso += "setembro de ";
            if (dt.Month == 10) extenso += "outubro de ";
            if (dt.Month == 11) extenso += "novembro de ";
            if (dt.Month == 12) extenso += "dezembro de ";

            extenso += dt.Year.ToString();

            return extenso;
        }
    }
}
