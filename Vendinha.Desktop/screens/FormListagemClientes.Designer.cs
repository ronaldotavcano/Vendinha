namespace Vendinha.Desktop.screens
{
    partial class FormListagemClientes
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
            dvgClientes = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            txtBusca = new TextBox();
            btnBuscar = new Button();
            lbl = new Label();
            btnAnterior = new Button();
            btnProximo = new Button();
            lblPagina = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgClientes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dvgClientes
            // 
            dvgClientes.AllowUserToAddRows = false;
            dvgClientes.AllowUserToDeleteRows = false;
            dvgClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dvgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgClientes.Location = new Point(364, 269);
            dvgClientes.Name = "dvgClientes";
            dvgClientes.Size = new Size(748, 299);
            dvgClientes.TabIndex = 0;
            dvgClientes.CellContentClick += dvgClientes_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1453, 100);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold);
            label1.Location = new Point(502, 25);
            label1.Name = "label1";
            label1.Size = new Size(393, 59);
            label1.TabIndex = 0;
            label1.Text = "Vendinha Ronaldo";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(364, 148);
            label2.Name = "label2";
            label2.Size = new Size(336, 45);
            label2.TabIndex = 2;
            label2.Text = "Listagem dos Clientes";
            label2.Click += label2_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(364, 223);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(586, 23);
            txtBusca.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(999, 222);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(113, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.Location = new Point(813, 641);
            lbl.Name = "lbl";
            lbl.Size = new Size(137, 30);
            lbl.TabIndex = 5;
            lbl.Text = "label-dividas";
            lbl.Click += lbl_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(940, 574);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(37, 23);
            btnAnterior.TabIndex = 6;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProximo.Location = new Point(983, 574);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(37, 23);
            btnProximo.TabIndex = 7;
            btnProximo.Text = ">";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(1037, 579);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(38, 15);
            lblPagina.TabIndex = 8;
            lblPagina.Text = "label3";
            // 
            // FormListagemClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 779);
            Controls.Add(lblPagina);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(lbl);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusca);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(dvgClientes);
            Name = "FormListagemClientes";
            Text = "FormListagemClientes";
            Load += FormListagemClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dvgClientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dvgClientes;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox txtBusca;
        private Button btnBuscar;
        private Button btnVoltarHome;
        private Label lbl;
        private Button btnAnterior;
        private Button btnProximo;
        private Label lblPagina;
    }
}