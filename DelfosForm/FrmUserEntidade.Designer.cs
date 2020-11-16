namespace DelfosForm
{
    partial class FrmUserEntidade
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
            this.cbbEntidade = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbEntidade
            // 
            this.cbbEntidade.FormattingEnabled = true;
            this.cbbEntidade.Location = new System.Drawing.Point(31, 129);
            this.cbbEntidade.Name = "cbbEntidade";
            this.cbbEntidade.Size = new System.Drawing.Size(492, 21);
            this.cbbEntidade.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnEntrar);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbEntidade);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 232);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 21);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(33, 168);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(127, 21);
            this.btnEntrar.TabIndex = 4;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.DarkGray;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUsuario.Location = new System.Drawing.Point(142, 53);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 20);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escolha a Entidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(103, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sistema Delfos - Contabilidade";
            // 
            // FrmUserEntidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(580, 252);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUserEntidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUserEntidade";
            this.Load += new System.EventHandler(this.FrmUserEntidade_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbEntidade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label label2;
    }
}