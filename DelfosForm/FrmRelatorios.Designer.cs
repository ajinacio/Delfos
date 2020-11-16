namespace DelfosForm
{
    partial class FrmRelatorios
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
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnHistPadrao = new System.Windows.Forms.Button();
            this.btnPlanoContas = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLivroCaixa = new System.Windows.Forms.Button();
            this.btnRazao = new System.Windows.Forms.Button();
            this.btnDiario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.btnHistPadrao);
            this.panel1.Controls.Add(this.btnPlanoContas);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnLivroCaixa);
            this.panel1.Controls.Add(this.btnRazao);
            this.panel1.Controls.Add(this.btnDiario);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 426);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(40, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sistema Delfos - Contabilidade";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(155, 359);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 26);
            this.button7.TabIndex = 6;
            this.button7.Text = "Sair";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnHistPadrao
            // 
            this.btnHistPadrao.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistPadrao.Location = new System.Drawing.Point(24, 271);
            this.btnHistPadrao.Name = "btnHistPadrao";
            this.btnHistPadrao.Size = new System.Drawing.Size(400, 26);
            this.btnHistPadrao.TabIndex = 5;
            this.btnHistPadrao.Text = "Plano de Histórico Padrão";
            this.btnHistPadrao.UseVisualStyleBackColor = true;
            this.btnHistPadrao.Click += new System.EventHandler(this.btnHistPadrao_Click);
            // 
            // btnPlanoContas
            // 
            this.btnPlanoContas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanoContas.Location = new System.Drawing.Point(24, 239);
            this.btnPlanoContas.Name = "btnPlanoContas";
            this.btnPlanoContas.Size = new System.Drawing.Size(400, 26);
            this.btnPlanoContas.TabIndex = 4;
            this.btnPlanoContas.Text = "Plano de Contas";
            this.btnPlanoContas.UseVisualStyleBackColor = true;
            this.btnPlanoContas.Click += new System.EventHandler(this.btnPlanoContas_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(24, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(400, 26);
            this.button4.TabIndex = 3;
            this.button4.Text = "Balancete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnLivroCaixa
            // 
            this.btnLivroCaixa.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLivroCaixa.Location = new System.Drawing.Point(24, 154);
            this.btnLivroCaixa.Name = "btnLivroCaixa";
            this.btnLivroCaixa.Size = new System.Drawing.Size(400, 26);
            this.btnLivroCaixa.TabIndex = 2;
            this.btnLivroCaixa.Text = "Livro Caixa";
            this.btnLivroCaixa.UseVisualStyleBackColor = true;
            // 
            // btnRazao
            // 
            this.btnRazao.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazao.Location = new System.Drawing.Point(24, 122);
            this.btnRazao.Name = "btnRazao";
            this.btnRazao.Size = new System.Drawing.Size(400, 26);
            this.btnRazao.TabIndex = 1;
            this.btnRazao.Text = "Razão";
            this.btnRazao.UseVisualStyleBackColor = true;
            // 
            // btnDiario
            // 
            this.btnDiario.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiario.Location = new System.Drawing.Point(24, 90);
            this.btnDiario.Name = "btnDiario";
            this.btnDiario.Size = new System.Drawing.Size(400, 26);
            this.btnDiario.TabIndex = 0;
            this.btnDiario.Text = "Diário";
            this.btnDiario.UseVisualStyleBackColor = true;
            this.btnDiario.Click += new System.EventHandler(this.btnDiario_Click);
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(473, 446);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelatorios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHistPadrao;
        private System.Windows.Forms.Button btnPlanoContas;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLivroCaixa;
        private System.Windows.Forms.Button btnRazao;
        private System.Windows.Forms.Button btnDiario;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
    }
}