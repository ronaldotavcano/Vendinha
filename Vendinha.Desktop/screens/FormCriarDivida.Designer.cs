namespace Vendinha.Desktop.screens
{
    partial class FormCriarDivida
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
            panel1 = new Panel();
            label1 = new Label();
            txtCpf = new TextBox();
            txtValor = new TextBox();
            btnSalvar = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(504, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold);
            label1.Location = new Point(37, 25);
            label1.Name = "label1";
            label1.Size = new Size(393, 59);
            label1.TabIndex = 0;
            label1.Text = "Vendinha Ronaldo";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(144, 205);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(169, 23);
            txtCpf.TabIndex = 1;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(144, 272);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(169, 23);
            txtValor.TabIndex = 2;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(222, 320);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(91, 36);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Lançar Dívida";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 178);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "Cpf do cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 245);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Valor da Dívida";
            // 
            // FormCriarDívida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnSalvar);
            Controls.Add(txtValor);
            Controls.Add(txtCpf);
            Controls.Add(panel1);
            Name = "FormCriarDívida";
            Text = "FormCriarDívida";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtCpf;
        private TextBox txtValor;
        private Button btnSalvar;
        private Label label2;
        private Label label3;
    }
}