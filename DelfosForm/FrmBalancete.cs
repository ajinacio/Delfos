using Delfos.Application;
using Delfos.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace DelfosForm
{
    public partial class FrmBalancete : Form
    {

        Entidade entidade;
        List<Lancamento> lancamentos;
        LancamentoApp lancamentoApp = new LancamentoApp();

        public FrmBalancete()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
            
            texto = "BALANCETE";
            tabCab.Rows[2].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes8b);
            tabCab.Rows[2].Cells[0].VerticalAlignment = VerticalAlignment.Center;

            tabCab.Rows[2].Cells[2].Paragraphs[0].Append("Página:   ", textFormat.FTimes8b);
            tabCab.Rows[2].Cells[2].Paragraphs[0].AppendPageNumber(PageNumberFormat.normal);
            tabCab.Rows[2].Cells[2].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[2].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            //////////  End - Header /////////////
            
            ////// - Begin - Termo de Abertura //////
        }
    }
}
