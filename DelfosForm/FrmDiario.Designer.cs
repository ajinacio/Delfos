namespace DelfosForm
{
    partial class FrmDiario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbAno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnProcessar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbAno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 172);
            this.panel1.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(38, 131);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(51, 21);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(38, 102);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(217, 23);
            this.btnProcessar.TabIndex = 14;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(111, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Diário";
            // 
            // txbAno
            // 
            this.txbAno.Location = new System.Drawing.Point(193, 57);
            this.txbAno.Name = "txbAno";
            this.txbAno.Size = new System.Drawing.Size(63, 20);
            this.txbAno.TabIndex = 12;
            this.txbAno.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbAno_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Informar o exercício:";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(204, 131);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(51, 21);
            this.btnFechar.TabIndex = 16;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FrmDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(320, 194);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDiario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnFechar;
    }
}