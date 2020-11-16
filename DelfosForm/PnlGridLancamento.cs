using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delfos.Domain;
using System.Windows.Forms;
using System.Drawing;

namespace DelfosForm
{
    public class PnlGridLancamento : Panel
    {
        public int positionLanc = 4;
        public int ptName = 0;
        PnlLancamento pnlLancamento;

        public PnlGridLancamento()
        {

        }

        public string add(string[] dados)
        {
            int pos = -1;
            int i;
            for (i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Controls[0].Text == dados[0])
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                foreach (Control control in this.Controls)
                    if (control.BackColor != Color.CadetBlue)
                        control.BackColor = Color.AliceBlue;

                pnlLancamento = new PnlLancamento();

                pnlLancamento.txbCodConta.Text = dados[0];
                pnlLancamento.txbConta.Text = dados[1];
                pnlLancamento.txbCodHist.Text = dados[2];
                pnlLancamento.txbHist.Text = dados[3];
                pnlLancamento.txbComplemento.Text = dados[4];
                pnlLancamento.txbValor.Text = dados[5];
                pnlLancamento.txbDC.Text = dados[6];

                positionLanc += 24;
                ptName += 1;
                pnlLancamento.Location = new System.Drawing.Point(2, positionLanc);
                pnlLancamento.Name = "pnlLanc" + ptName.ToString();
                pnlLancamento.BackColor = Color.Red;
                this.Controls.Add(pnlLancamento);
                return "";
            }
            else
            {
                string ant = this.Controls[i].Controls[5].Text;
                this.Controls[i].Controls[0].Text = dados[0];
                this.Controls[i].Controls[1].Text = dados[1];
                this.Controls[i].Controls[2].Text = dados[2];
                this.Controls[i].Controls[3].Text = dados[3];
                this.Controls[i].Controls[4].Text = dados[4];
                this.Controls[i].Controls[5].Text = dados[5];
                this.Controls[i].Controls[6].Text = dados[6];
                return ant;
            }
        }
    }
}
