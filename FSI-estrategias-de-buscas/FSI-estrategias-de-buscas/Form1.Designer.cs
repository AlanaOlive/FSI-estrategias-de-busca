namespace FSI_estrategias_de_buscas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbOrigem = new ComboBox();
            cbDestino = new ComboBox();
            cbAlgoritmo = new ComboBox();
            btnBuscar = new Button();
            txtResultadoCaminho = new TextBox();
            txtResultadoDist = new TextBox();
            txtResultadoNos = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtResultadoNosA = new TextBox();
            txtResultadoDistA = new TextBox();
            txtResultadoCaminhoA = new TextBox();
            SuspendLayout();
            // 
            // cbOrigem
            // 
            cbOrigem.FormattingEnabled = true;
            cbOrigem.Location = new Point(12, 26);
            cbOrigem.Name = "cbOrigem";
            cbOrigem.RightToLeft = RightToLeft.No;
            cbOrigem.Size = new Size(121, 23);
            cbOrigem.TabIndex = 0;
            // 
            // cbDestino
            // 
            cbDestino.FormattingEnabled = true;
            cbDestino.Location = new Point(139, 26);
            cbDestino.Name = "cbDestino";
            cbDestino.RightToLeft = RightToLeft.No;
            cbDestino.Size = new Size(121, 23);
            cbDestino.TabIndex = 1;
            // 
            // cbAlgoritmo
            // 
            cbAlgoritmo.FormattingEnabled = true;
            cbAlgoritmo.Location = new Point(266, 26);
            cbAlgoritmo.Name = "cbAlgoritmo";
            cbAlgoritmo.RightToLeft = RightToLeft.No;
            cbAlgoritmo.Size = new Size(121, 23);
            cbAlgoritmo.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(393, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.RightToLeft = RightToLeft.No;
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtResultadoCaminho
            // 
            txtResultadoCaminho.Location = new Point(12, 78);
            txtResultadoCaminho.Name = "txtResultadoCaminho";
            txtResultadoCaminho.RightToLeft = RightToLeft.No;
            txtResultadoCaminho.Size = new Size(375, 23);
            txtResultadoCaminho.TabIndex = 5;
            // 
            // txtResultadoDist
            // 
            txtResultadoDist.Location = new Point(12, 107);
            txtResultadoDist.Name = "txtResultadoDist";
            txtResultadoDist.RightToLeft = RightToLeft.No;
            txtResultadoDist.Size = new Size(375, 23);
            txtResultadoDist.TabIndex = 6;
            // 
            // txtResultadoNos
            // 
            txtResultadoNos.Location = new Point(12, 136);
            txtResultadoNos.Name = "txtResultadoNos";
            txtResultadoNos.RightToLeft = RightToLeft.No;
            txtResultadoNos.Size = new Size(375, 23);
            txtResultadoNos.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(47, 15);
            label1.TabIndex = 8;
            label1.Text = "Origem";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 8);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(47, 15);
            label2.TabIndex = 9;
            label2.Text = "Destino";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 8);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(61, 15);
            label3.TabIndex = 10;
            label3.Text = "Algoritmo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 60);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(52, 15);
            label4.TabIndex = 11;
            label4.Text = "Terrestre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 174);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(38, 15);
            label5.TabIndex = 15;
            label5.Text = "Aéreo";
            // 
            // txtResultadoNosA
            // 
            txtResultadoNosA.Location = new Point(12, 250);
            txtResultadoNosA.Name = "txtResultadoNosA";
            txtResultadoNosA.RightToLeft = RightToLeft.No;
            txtResultadoNosA.Size = new Size(375, 23);
            txtResultadoNosA.TabIndex = 14;
            // 
            // txtResultadoDistA
            // 
            txtResultadoDistA.Location = new Point(12, 221);
            txtResultadoDistA.Name = "txtResultadoDistA";
            txtResultadoDistA.RightToLeft = RightToLeft.No;
            txtResultadoDistA.Size = new Size(375, 23);
            txtResultadoDistA.TabIndex = 13;
            // 
            // txtResultadoCaminhoA
            // 
            txtResultadoCaminhoA.Location = new Point(12, 192);
            txtResultadoCaminhoA.Name = "txtResultadoCaminhoA";
            txtResultadoCaminhoA.RightToLeft = RightToLeft.No;
            txtResultadoCaminhoA.Size = new Size(375, 23);
            txtResultadoCaminhoA.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(label5);
            Controls.Add(txtResultadoNosA);
            Controls.Add(txtResultadoDistA);
            Controls.Add(txtResultadoCaminhoA);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResultadoNos);
            Controls.Add(txtResultadoDist);
            Controls.Add(txtResultadoCaminho);
            Controls.Add(btnBuscar);
            Controls.Add(cbAlgoritmo);
            Controls.Add(cbDestino);
            Controls.Add(cbOrigem);
            Name = "Form1";
            Text = "FSI Estrategias";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ComboBox cbOrigem;
        private ComboBox cbDestino;
        private ComboBox cbAlgoritmo;
        private Button btnBuscar;
        private TextBox txtResultadoCaminho;
        private TextBox txtResultadoDist;
        private TextBox txtResultadoNos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtResultadoNosA;
        private TextBox txtResultadoDistA;
        private TextBox txtResultadoCaminhoA;
    }
}