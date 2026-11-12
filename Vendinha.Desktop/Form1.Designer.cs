namespace Vendinha.Desktop
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnCriarDivida = new Button();
            btnListarDividas = new Button();
            btnCadastrarCliente = new Button();
            btnListarCliente = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1453, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(483, 23);
            label1.Name = "label1";
            label1.Size = new Size(458, 59);
            label1.TabIndex = 0;
            label1.Text = "Vendinha do Ronaldo";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(btnCriarDivida);
            panel2.Controls.Add(btnListarDividas);
            panel2.Controls.Add(btnCadastrarCliente);
            panel2.Controls.Add(btnListarCliente);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(409, 678);
            panel2.TabIndex = 1;
            // 
            // btnCriarDivida
            // 
            btnCriarDivida.BackColor = SystemColors.ButtonHighlight;
            btnCriarDivida.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCriarDivida.Location = new Point(12, 439);
            btnCriarDivida.Name = "btnCriarDivida";
            btnCriarDivida.Size = new Size(349, 71);
            btnCriarDivida.TabIndex = 4;
            btnCriarDivida.Text = "Criar Dívida";
            btnCriarDivida.UseVisualStyleBackColor = false;
            btnCriarDivida.Click += btnCriarDivida_Click;
            // 
            // btnListarDividas
            // 
            btnListarDividas.BackColor = SystemColors.ButtonHighlight;
            btnListarDividas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListarDividas.Location = new Point(12, 324);
            btnListarDividas.Name = "btnListarDividas";
            btnListarDividas.Size = new Size(349, 71);
            btnListarDividas.TabIndex = 3;
            btnListarDividas.Text = "Listar Dívidas";
            btnListarDividas.UseVisualStyleBackColor = false;
            btnListarDividas.Click += button2_Click;
            // 
            // btnCadastrarCliente
            // 
            btnCadastrarCliente.BackColor = SystemColors.ButtonHighlight;
            btnCadastrarCliente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrarCliente.Location = new Point(12, 212);
            btnCadastrarCliente.Name = "btnCadastrarCliente";
            btnCadastrarCliente.Size = new Size(349, 71);
            btnCadastrarCliente.TabIndex = 2;
            btnCadastrarCliente.Text = "Cadastrar Cliente";
            btnCadastrarCliente.UseVisualStyleBackColor = false;
            btnCadastrarCliente.Click += btnCadastrarCliente_Click;
            // 
            // btnListarCliente
            // 
            btnListarCliente.BackColor = SystemColors.ButtonHighlight;
            btnListarCliente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListarCliente.Location = new Point(12, 103);
            btnListarCliente.Name = "btnListarCliente";
            btnListarCliente.Size = new Size(349, 71);
            btnListarCliente.TabIndex = 1;
            btnListarCliente.Text = "Listar Clientes";
            btnListarCliente.UseVisualStyleBackColor = false;
            btnListarCliente.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 25);
            label2.Name = "label2";
            label2.Size = new Size(254, 45);
            label2.TabIndex = 0;
            label2.Text = "Funcionalidades";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1453, 778);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Button btnListarCliente;
        private Button btnCriarDivida;
        private Button btnListarDividas;
        private Button btnCadastrarCliente;
    }
}
