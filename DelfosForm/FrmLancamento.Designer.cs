namespace DelfosForm
{
    partial class FrmLancamento
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblDebito = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlIncluir = new System.Windows.Forms.Panel();
            this.btnNovoConta = new System.Windows.Forms.Button();
            this.rbtCredito = new System.Windows.Forms.RadioButton();
            this.rbtDebito = new System.Windows.Forms.RadioButton();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbValor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txbComplemento = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbHist = new System.Windows.Forms.TextBox();
            this.txbConta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbbCodConta = new System.Windows.Forms.ComboBox();
            this.cbbCodHist = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnExcluirLanc = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbEvento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbCodEvento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mtbDataLanc = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDataLanc = new System.Windows.Forms.DateTimePicker();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGridLanc = new DelfosForm.PnlGridLancamento();
            this.pnlLancCabecalho = new DelfosForm.PnlLancamento();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlIncluir.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlGridLanc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 522);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblDiferenca);
            this.panel3.Controls.Add(this.btnExcluir);
            this.panel3.Controls.Add(this.pnlGridLanc);
            this.panel3.Controls.Add(this.lblDebito);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lblCredito);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pnlIncluir);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(10, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(856, 451);
            this.panel3.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(326, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Diferença:";
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.AutoSize = true;
            this.lblDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenca.Location = new System.Drawing.Point(406, 425);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(56, 16);
            this.lblDiferenca.TabIndex = 28;
            this.lblDiferenca.Text = "000000";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Red;
            this.btnExcluir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExcluir.Location = new System.Drawing.Point(740, 421);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(106, 25);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblDebito
            // 
            this.lblDebito.AutoSize = true;
            this.lblDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebito.Location = new System.Drawing.Point(62, 425);
            this.lblDebito.Name = "lblDebito";
            this.lblDebito.Size = new System.Drawing.Size(56, 16);
            this.lblDebito.TabIndex = 25;
            this.lblDebito.Text = "000000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(150, 425);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Crédito:";
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.Location = new System.Drawing.Point(210, 425);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(56, 16);
            this.lblCredito.TabIndex = 23;
            this.lblCredito.Text = "000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Débito:";
            // 
            // pnlIncluir
            // 
            this.pnlIncluir.BackColor = System.Drawing.Color.Silver;
            this.pnlIncluir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIncluir.Controls.Add(this.btnNovoConta);
            this.pnlIncluir.Controls.Add(this.rbtCredito);
            this.pnlIncluir.Controls.Add(this.rbtDebito);
            this.pnlIncluir.Controls.Add(this.btnIncluir);
            this.pnlIncluir.Controls.Add(this.label3);
            this.pnlIncluir.Controls.Add(this.txbValor);
            this.pnlIncluir.Controls.Add(this.label13);
            this.pnlIncluir.Controls.Add(this.txbComplemento);
            this.pnlIncluir.Controls.Add(this.label12);
            this.pnlIncluir.Controls.Add(this.label11);
            this.pnlIncluir.Controls.Add(this.label9);
            this.pnlIncluir.Controls.Add(this.txbHist);
            this.pnlIncluir.Controls.Add(this.txbConta);
            this.pnlIncluir.Controls.Add(this.label10);
            this.pnlIncluir.Controls.Add(this.cbbCodConta);
            this.pnlIncluir.Controls.Add(this.cbbCodHist);
            this.pnlIncluir.Location = new System.Drawing.Point(10, 81);
            this.pnlIncluir.Name = "pnlIncluir";
            this.pnlIncluir.Size = new System.Drawing.Size(711, 112);
            this.pnlIncluir.TabIndex = 20;
            // 
            // btnNovoConta
            // 
            this.btnNovoConta.BackColor = System.Drawing.Color.Silver;
            this.btnNovoConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoConta.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnNovoConta.Location = new System.Drawing.Point(648, 53);
            this.btnNovoConta.Name = "btnNovoConta";
            this.btnNovoConta.Size = new System.Drawing.Size(51, 48);
            this.btnNovoConta.TabIndex = 23;
            this.btnNovoConta.Text = "Novo";
            this.btnNovoConta.UseVisualStyleBackColor = false;
            this.btnNovoConta.Click += new System.EventHandler(this.btnNovoConta_Click);
            // 
            // rbtCredito
            // 
            this.rbtCredito.AutoSize = true;
            this.rbtCredito.Location = new System.Drawing.Point(494, 82);
            this.rbtCredito.Name = "rbtCredito";
            this.rbtCredito.Size = new System.Drawing.Size(58, 17);
            this.rbtCredito.TabIndex = 22;
            this.rbtCredito.TabStop = true;
            this.rbtCredito.Text = "Crédito";
            this.rbtCredito.UseVisualStyleBackColor = true;
            this.rbtCredito.Enter += new System.EventHandler(this.rbtCredito_Enter);
            this.rbtCredito.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rbtCredito_KeyUp);
            // 
            // rbtDebito
            // 
            this.rbtDebito.AutoSize = true;
            this.rbtDebito.Location = new System.Drawing.Point(494, 59);
            this.rbtDebito.Name = "rbtDebito";
            this.rbtDebito.Size = new System.Drawing.Size(56, 17);
            this.rbtDebito.TabIndex = 21;
            this.rbtDebito.TabStop = true;
            this.rbtDebito.Text = "Débito";
            this.rbtDebito.UseVisualStyleBackColor = true;
            this.rbtDebito.Enter += new System.EventHandler(this.rbtDebito_Enter);
            this.rbtDebito.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rbtDebito_KeyUp);
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIncluir.Location = new System.Drawing.Point(558, 53);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(84, 48);
            this.btnIncluir.TabIndex = 20;
            this.btnIncluir.Text = "Incluir / Alterar";
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Valor";
            // 
            // txbValor
            // 
            this.txbValor.BackColor = System.Drawing.SystemColors.Window;
            this.txbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbValor.Location = new System.Drawing.Point(303, 77);
            this.txbValor.Name = "txbValor";
            this.txbValor.Size = new System.Drawing.Size(179, 22);
            this.txbValor.TabIndex = 17;
            this.txbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbValor_KeyUp);
            this.txbValor.Leave += new System.EventHandler(this.txbValor_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Complemento do Histórico";
            // 
            // txbComplemento
            // 
            this.txbComplemento.BackColor = System.Drawing.SystemColors.Window;
            this.txbComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbComplemento.Location = new System.Drawing.Point(9, 77);
            this.txbComplemento.Name = "txbComplemento";
            this.txbComplemento.Size = new System.Drawing.Size(283, 22);
            this.txbComplemento.TabIndex = 15;
            this.txbComplemento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbComplemento_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(414, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Histórico Padrão";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(350, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Cód.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Descrição da Conta";
            // 
            // txbHist
            // 
            this.txbHist.BackColor = System.Drawing.Color.LightBlue;
            this.txbHist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbHist.Location = new System.Drawing.Point(417, 28);
            this.txbHist.Name = "txbHist";
            this.txbHist.ReadOnly = true;
            this.txbHist.Size = new System.Drawing.Size(282, 15);
            this.txbHist.TabIndex = 11;
            // 
            // txbConta
            // 
            this.txbConta.BackColor = System.Drawing.Color.LightBlue;
            this.txbConta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbConta.Location = new System.Drawing.Point(110, 28);
            this.txbConta.Name = "txbConta";
            this.txbConta.ReadOnly = true;
            this.txbConta.Size = new System.Drawing.Size(236, 15);
            this.txbConta.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Código da Conta";
            // 
            // cbbCodConta
            // 
            this.cbbCodConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodConta.FormattingEnabled = true;
            this.cbbCodConta.Location = new System.Drawing.Point(10, 25);
            this.cbbCodConta.Name = "cbbCodConta";
            this.cbbCodConta.Size = new System.Drawing.Size(95, 24);
            this.cbbCodConta.TabIndex = 0;
            this.cbbCodConta.TextChanged += new System.EventHandler(this.cbbCodConta_TextChanged);
            this.cbbCodConta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCodConta_KeyPress);
            this.cbbCodConta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbCodConta_KeyUp);
            this.cbbCodConta.Leave += new System.EventHandler(this.cbbCodConta_Leave);
            // 
            // cbbCodHist
            // 
            this.cbbCodHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodHist.FormattingEnabled = true;
            this.cbbCodHist.Location = new System.Drawing.Point(353, 25);
            this.cbbCodHist.Name = "cbbCodHist";
            this.cbbCodHist.Size = new System.Drawing.Size(58, 24);
            this.cbbCodHist.TabIndex = 2;
            this.cbbCodHist.TextChanged += new System.EventHandler(this.cbbCodHist_TextChanged);
            this.cbbCodHist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbHist_KeyUp);
            this.cbbCodHist.Leave += new System.EventHandler(this.cbbCodHist_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.btnExcluirLanc);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Controls.Add(this.btnNovo);
            this.panel2.Location = new System.Drawing.Point(727, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 180);
            this.panel2.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(31, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Inteiro";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "Lançamento";
            // 
            // btnExcluirLanc
            // 
            this.btnExcluirLanc.Location = new System.Drawing.Point(23, 86);
            this.btnExcluirLanc.Name = "btnExcluirLanc";
            this.btnExcluirLanc.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirLanc.TabIndex = 3;
            this.btnExcluirLanc.Text = "Excluir";
            this.btnExcluirLanc.UseVisualStyleBackColor = true;
            this.btnExcluirLanc.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(23, 120);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 40);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(23, 51);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tan;
            this.groupBox1.Controls.Add(this.txbEvento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbCodEvento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(329, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evento";
            // 
            // txbEvento
            // 
            this.txbEvento.BackColor = System.Drawing.Color.LightBlue;
            this.txbEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEvento.Location = new System.Drawing.Point(58, 31);
            this.txbEvento.Name = "txbEvento";
            this.txbEvento.ReadOnly = true;
            this.txbEvento.Size = new System.Drawing.Size(313, 22);
            this.txbEvento.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Descrição:";
            // 
            // txbCodEvento
            // 
            this.txbCodEvento.Location = new System.Drawing.Point(9, 32);
            this.txbCodEvento.Name = "txbCodEvento";
            this.txbCodEvento.Size = new System.Drawing.Size(26, 21);
            this.txbCodEvento.TabIndex = 3;
            this.txbCodEvento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbCodEvento_KeyUp);
            this.txbCodEvento.Leave += new System.EventHandler(this.txbCodEvento_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Código:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.mtbDataLanc);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dtpDataLanc);
            this.panel4.Controls.Add(this.txbNumero);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(10, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 62);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // mtbDataLanc
            // 
            this.mtbDataLanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataLanc.Location = new System.Drawing.Point(11, 25);
            this.mtbDataLanc.Mask = "00/00/0000";
            this.mtbDataLanc.Name = "mtbDataLanc";
            this.mtbDataLanc.Size = new System.Drawing.Size(71, 22);
            this.mtbDataLanc.TabIndex = 21;
            this.mtbDataLanc.ValidatingType = typeof(System.DateTime);
            this.mtbDataLanc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbDataLanc_KeyUp);
            this.mtbDataLanc.Leave += new System.EventHandler(this.mtbDataLanc_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data:";
            // 
            // dtpDataLanc
            // 
            this.dtpDataLanc.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataLanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataLanc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataLanc.Location = new System.Drawing.Point(11, 25);
            this.dtpDataLanc.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpDataLanc.Name = "dtpDataLanc";
            this.dtpDataLanc.Size = new System.Drawing.Size(88, 22);
            this.dtpDataLanc.TabIndex = 6;
            this.dtpDataLanc.ValueChanged += new System.EventHandler(this.dtpDataLanc_ValueChanged);
            this.dtpDataLanc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpDataLanc_KeyUp);
            // 
            // txbNumero
            // 
            this.txbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNumero.Location = new System.Drawing.Point(123, 25);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(66, 22);
            this.txbNumero.TabIndex = 5;
            this.txbNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbNumero_KeyUp);
            this.txbNumero.Leave += new System.EventHandler(this.txbNumero_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Número:";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(816, 17);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(50, 30);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Heading", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 8);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(241, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "L a n ç a m e n t o s";
            // 
            // pnlGridLanc
            // 
            this.pnlGridLanc.AutoScroll = true;
            this.pnlGridLanc.BackColor = System.Drawing.Color.Gray;
            this.pnlGridLanc.Controls.Add(this.pnlLancCabecalho);
            this.pnlGridLanc.Location = new System.Drawing.Point(10, 200);
            this.pnlGridLanc.Name = "pnlGridLanc";
            this.pnlGridLanc.Size = new System.Drawing.Size(836, 215);
            this.pnlGridLanc.TabIndex = 26;
            // 
            // pnlLancCabecalho
            // 
            this.pnlLancCabecalho.BackColor = System.Drawing.Color.CadetBlue;
            this.pnlLancCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLancCabecalho.Location = new System.Drawing.Point(2, 2);
            this.pnlLancCabecalho.Name = "pnlLancCabecalho";
            this.pnlLancCabecalho.Size = new System.Drawing.Size(832, 26);
            this.pnlLancCabecalho.TabIndex = 0;
            // 
            // FrmLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(896, 542);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLancamento_Load);
            this.Click += new System.EventHandler(this.FrmLancamento_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlIncluir.ResumeLayout(false);
            this.pnlIncluir.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlGridLanc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbCodEvento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbCodConta;
        private System.Windows.Forms.TextBox txbConta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbbCodHist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbComplemento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbHist;
        private System.Windows.Forms.Panel pnlIncluir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbValor;
        private System.Windows.Forms.TextBox txbEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDataLanc;
        private System.Windows.Forms.MaskedTextBox mtbDataLanc;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtCredito;
        private System.Windows.Forms.RadioButton rbtDebito;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovo;
        private PnlGridLancamento pnlGridLanc;
        private System.Windows.Forms.Button btnExcluir;
        private PnlLancamento pnlLancCabecalho;
        private System.Windows.Forms.Button btnNovoConta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDiferenca;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnExcluirLanc;
    }
}