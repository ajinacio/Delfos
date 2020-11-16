namespace DelfosForm
{
    partial class FrmCompEnt
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
            this.lblEntidade2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.txbAno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEntidade1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.lblEntidade2);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnProcessar);
            this.panel1.Controls.Add(this.txbAno);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblEntidade1);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 299);
            this.panel1.TabIndex = 0;
            // 
            // lblEntidade2
            // 
            this.lblEntidade2.AutoSize = true;
            this.lblEntidade2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidade2.ForeColor = System.Drawing.Color.Maroon;
            this.lblEntidade2.Location = new System.Drawing.Point(37, 108);
            this.lblEntidade2.Name = "lblEntidade2";
            this.lblEntidade2.Size = new System.Drawing.Size(51, 16);
            this.lblEntidade2.TabIndex = 7;
            this.lblEntidade2.Text = "label1";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(253, 250);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(41, 27);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(59, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Abertura de Competência";
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(40, 208);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(254, 23);
            this.btnProcessar.TabIndex = 4;
            this.btnProcessar.Text = "Processar Abertura de Competência";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // txbAno
            // 
            this.txbAno.Location = new System.Drawing.Point(232, 161);
            this.txbAno.Name = "txbAno";
            this.txbAno.Size = new System.Drawing.Size(63, 20);
            this.txbAno.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abrir competência do ano:";
            // 
            // lblEntidade1
            // 
            this.lblEntidade1.AutoSize = true;
            this.lblEntidade1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidade1.ForeColor = System.Drawing.Color.Maroon;
            this.lblEntidade1.Location = new System.Drawing.Point(36, 92);
            this.lblEntidade1.Name = "lblEntidade1";
            this.lblEntidade1.Size = new System.Drawing.Size(51, 16);
            this.lblEntidade1.TabIndex = 0;
            this.lblEntidade1.Text = "label1";
            // 
            // FrmCompEnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(350, 321);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompEnt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCompEnt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.TextBox txbAno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEntidade1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblEntidade2;
    }
}