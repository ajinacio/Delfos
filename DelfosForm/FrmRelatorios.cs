using Delfos.Application;
using Delfos.Domain;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Globalization;

namespace DelfosForm
{
    public partial class FrmRelatorios : Form
    {
        Entidade entidade;
        ContaApp contaApp = new ContaApp();
        List<Conta> contas = new List<Conta>();
        HistoricoApp historicoApp = new HistoricoApp();
        List<Historico> historicos = new List<Historico>();

        public FrmRelatorios(Entidade _entidade)
        {
            InitializeComponent();
            entidade = _entidade;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDiario_Click(object sender, EventArgs e)
        {
            FrmDiario frm = new FrmDiario(entidade);
            frm.ShowDialog();
        }

        private void btnPlanoContas_Click(object sender, EventArgs e)
        {
            TextFormat textFormat = new TextFormat();
            string texto;
            Paragraph parag;

            string arq = "Plano_de_Contas.docx";
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

            texto = "PLANO DE CONTAS";
            tabCab.Rows[2].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[2].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            tabCab.Rows[2].Cells[2].Paragraphs[0].Append("Página:   ", textFormat.FTimes8b);
            tabCab.Rows[2].Cells[2].Paragraphs[0].AppendPageNumber(PageNumberFormat.normal);
            tabCab.Rows[2].Cells[2].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[2].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            contas = contaApp.listAll();

            bool fl = false;
            foreach (Conta conta in contas)
            {
                if (fl && conta.Nivel != 5)
                {
                    document.InsertParagraph();
                    fl = false;
                }

                texto = conta.Codigo + " - " + conta.Descricao;
                if (conta.Nivel == 5)
                    parag = document.InsertParagraph(texto, false, textFormat.FTimes12B);
                else
                    parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);

                if (conta.Nivel > 1)
                    parag.IndentationBefore = 10 * (conta.Nivel - 1);

                if (conta.Nivel < 5) document.InsertParagraph();
                if (conta.Nivel == 5) fl = true;
            }

            try
            {
                document.Save();
            }
            catch { }

            Process.Start("WINWORD.EXE", arq);
        }

        private void btnHistPadrao_Click(object sender, EventArgs e)
        {
            TextFormat textFormat = new TextFormat();
            string texto;
            Paragraph parag;

            string arq = "Plano_de_Historicos_Padroes.docx";
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
            tabCab.Rows[1].Cells[0].Paragraphs[0].Font("Times New Roman");
            tabCab.Rows[1].Cells[0].Paragraphs[0].FontSize(8);
            tabCab.Rows[1].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            texto = "PLANO DE HISTÓRICOS PADRÕES";
            tabCab.Rows[2].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[2].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            tabCab.Rows[2].Cells[2].Paragraphs[0].Append("Página:   ", textFormat.FTimes8b);
            tabCab.Rows[2].Cells[2].Paragraphs[0].AppendPageNumber(PageNumberFormat.normal);
            tabCab.Rows[2].Cells[2].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[2].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            historicos = historicoApp.listAll();
            CultureInfo cult = new CultureInfo("pt-BR");

            document.InsertParagraph();
            foreach (Historico historico in historicos)
                parag = document.InsertParagraph(historico.Codigo + " - " + historico.Descricao, false, textFormat.FTimes12b);

            try
            {
                document.Save();
            }
            catch { }

            Process.Start("WINWORD.EXE", arq);
        }
    }
}
