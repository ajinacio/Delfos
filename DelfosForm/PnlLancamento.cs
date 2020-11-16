using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelfosForm
{
    public class PnlLancamento : Panel
    {
        public TextBox txbCodConta = new TextBox();
        public TextBox txbConta = new TextBox();
        public TextBox txbCodHist = new TextBox();
        public TextBox txbHist = new TextBox();
        public TextBox txbComplemento = new TextBox();
        public TextBox txbValor = new TextBox();
        public TextBox txbDC = new TextBox();

        public PnlLancamento()
        {
            this.Size = new System.Drawing.Size(832, 24);
            this.BackColor = System.Drawing.Color.AliceBlue;

            txbCodConta.Location = new System.Drawing.Point(2, 2);
            txbCodConta.Size = new System.Drawing.Size(60, 20);
            txbCodConta.Name = "txbCodConta";
            txbCodConta.Click += new System.EventHandler(this.txbCodConta_Click);
            txbCodConta.ReadOnly = true;

            txbConta.Location = new System.Drawing.Point(65, 2);
            txbConta.Size = new System.Drawing.Size(200, 20);
            txbConta.Name = "txbConta";
            txbConta.Click += new System.EventHandler(this.txbConta_Click);
            txbConta.ReadOnly = true;

            txbCodHist.Location = new System.Drawing.Point(268, 2);
            txbCodHist.Size = new System.Drawing.Size(30, 20);
            txbCodHist.Name = "txbCodHist";
            txbCodHist.Click += new System.EventHandler(this.txbCodHist_Click);
            txbCodHist.ReadOnly = true;
            txbCodHist.TextAlign = HorizontalAlignment.Center;

            txbHist.Location = new System.Drawing.Point(301, 2);
            txbHist.Size = new System.Drawing.Size(200, 20);
            txbHist.Name = "txbHist";
            txbHist.Click += new System.EventHandler(this.txbHist_Click);
            txbHist.ReadOnly = true;

            txbComplemento.Location = new System.Drawing.Point(504, 2);
            txbComplemento.Size = new System.Drawing.Size(200, 20);
            txbComplemento.Name = "txbComplemento";
            txbComplemento.Click += new System.EventHandler(this.txbComplemento_Click);
            txbComplemento.ReadOnly = true;

            txbValor.Location = new System.Drawing.Point(707, 2);
            txbValor.Size = new System.Drawing.Size(100, 20);
            txbValor.Name = "txbValor";
            txbValor.Click += new System.EventHandler(this.txbValor_Click);
            txbValor.ReadOnly = true;
            txbValor.TextAlign = HorizontalAlignment.Right;

            txbDC.Location = new System.Drawing.Point(810, 2);
            txbDC.Size = new System.Drawing.Size(20, 20);
            txbDC.Name = "txbDC";
            txbDC.Click += new System.EventHandler(this.txbDC_Click);
            txbDC.ReadOnly = true;
            txbDC.TextAlign = HorizontalAlignment.Center;

            this.Controls.Add(txbCodConta);
            this.Controls.Add(txbConta);
            this.Controls.Add(txbCodHist);
            this.Controls.Add(txbHist);
            this.Controls.Add(txbComplemento);
            this.Controls.Add(txbValor);
            this.Controls.Add(txbDC);
        }

        private void txbCodConta_Click(object sender, EventArgs e)
        {
            aoClickar(txbCodConta);
        }

        private void txbConta_Click(object sender, EventArgs e)
        {
            aoClickar(txbConta);
        }

        private void txbCodHist_Click(object sender, EventArgs e)
        {
            aoClickar(txbCodHist);
        }

        private void txbHist_Click(object sender, EventArgs e)
        {
            aoClickar(txbHist);
        }

        private void txbComplemento_Click(object sender, EventArgs e)
        {
            aoClickar(txbComplemento);
        }
        private void txbValor_Click(object sender, EventArgs e)
        {
            aoClickar(txbValor);
        }

        private void txbDC_Click(object sender, EventArgs e)
        {
            aoClickar(txbDC);
        }

        private void aoClickar(Control control)
        {
            foreach (Control ctl in control.Parent.Parent.Controls)
                if (ctl.BackColor != Color.CadetBlue) ctl.BackColor = Color.AliceBlue;

            if (control.Parent.BackColor != Color.CadetBlue)
            {
                int ct = 8;
                control.Parent.BackColor = Color.Red;

                control.Parent.Parent.Parent.Controls[ct].Controls[14].Text = control.Parent.Controls[0].Text;
                control.Parent.Parent.Parent.Controls[ct].Controls[12].Text = control.Parent.Controls[1].Text;
                control.Parent.Parent.Parent.Controls[ct].Controls[15].Text = control.Parent.Controls[2].Text;
                control.Parent.Parent.Parent.Controls[ct].Controls[11].Text = control.Parent.Controls[3].Text;
                control.Parent.Parent.Parent.Controls[ct].Controls[7].Text = control.Parent.Controls[4].Text;
                control.Parent.Parent.Parent.Controls[ct].Controls[5].Text = control.Parent.Controls[5].Text;


                if (control.Parent.Controls[6].Text == "D")
                {
                    control.Parent.Parent.Parent.Controls[ct].Controls[2].Tag = "D";
                    control.Parent.Parent.Parent.Controls[ct].Controls[2].Focus();
                }

                if (control.Parent.Controls[6].Text == "C")
                    control.Parent.Parent.Parent.Controls[ct].Controls[2].Tag = "C";

                if (control.Parent.Controls[6].Text == "D")
                    control.Parent.Parent.Parent.Controls[ct].Controls[1].Tag = "D";

                if (control.Parent.Controls[6].Text == "C")
                {
                    control.Parent.Parent.Parent.Controls[ct].Controls[1].Tag = "C";
                    control.Parent.Parent.Parent.Controls[ct].Controls[1].Focus();
                }
            }

        }
    }
}
