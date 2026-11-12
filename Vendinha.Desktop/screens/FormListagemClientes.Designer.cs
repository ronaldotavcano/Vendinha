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
            btnVoltarHome = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgClientes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dvgClientes
            // 
            dvgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgClientes.Location = new Point(337, 206);
            dvgClientes.Name = "dvgClientes";
            dvgClientes.Size = new Size(753, 529);
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
            label2.Location = new Point(633, 158);
            label2.Name = "label2";
            label2.Size = new Size(135, 45);
            label2.TabIndex = 2;
            label2.Text = "Clientes";
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(790, 219);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(190, 23);
            txtBusca.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(998, 219);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnVoltarHome
            // 
            btnVoltarHome.BackColor = SystemColors.ActiveCaption;
            btnVoltarHome.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltarHome.Location = new Point(1238, 672);
            btnVoltarHome.Name = "btnVoltarHome";
            btnVoltarHome.Size = new Size(142, 63);
            btnVoltarHome.TabIndex = 5;
            btnVoltarHome.Text = "Voltar";
            btnVoltarHome.UseVisualStyleBackColor = false;
            btnVoltarHome.Click += btnVoltarHome_Click;
            // 
            // FormListagemClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 779);
            Controls.Add(btnVoltarHome);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusca);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(dvgClientes);
            Name = "FormListagemClientes";
            Text = "FormListagemClientes";
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
    }
}