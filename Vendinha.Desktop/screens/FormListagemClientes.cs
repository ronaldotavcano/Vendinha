using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Vendinha.Services;

namespace Vendinha.Desktop.screens
{
    public partial class FormListagemClientes : Form
    {
        private ClienteService cliente = new ClienteService();
        private int paginaAtual = 1;
        private const int QuantidadePorPagina = 10;
        private int totalPaginas = 1;

        public FormListagemClientes()
        {
            InitializeComponent();

            dvgClientes.ReadOnly = true;
            dvgClientes.AllowUserToAddRows = false;

            DataGridViewButtonColumn btnPagar = new DataGridViewButtonColumn();
            btnPagar.HeaderText = "Ação";
            btnPagar.Name = "btnPagar";
            btnPagar.Text = "Pagar";
            btnPagar.UseColumnTextForButtonValue = true;

            dvgClientes.Columns.Add(btnPagar);

            CarregarTabela();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dvgClientes.Columns[e.ColumnIndex].Name == "btnPagar")
                {
                    string cpfCliente = dvgClientes.Rows[e.RowIndex].Cells["Cpf"].Value.ToString();

                    bool sucesso = cliente.PagarDivida(cpfCliente);

                    if (sucesso)
                    {
                        MessageBox.Show("Dívida paga com sucesso!");
                        CarregarTabela();
                    }
                    else
                    {
                        MessageBox.Show("Este cliente não possui dívidas em aberto.");
                    }
                }
            }
        }

        private void FormListagemClientes_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaAtual = 1;
            CarregarTabela();
        }

        private void CarregarTabela()
        {
            try
            {
                string pesquisa = txtBusca.Text;

                if (pesquisa == "Buscar por nome ou CPF ")
                {
                    pesquisa = "";
                }

                var dados = cliente.ListarParaGrid(pesquisa, paginaAtual, QuantidadePorPagina);
                dvgClientes.DataSource = dados;

                if (dvgClientes.Columns["Nome"] != null)
                    dvgClientes.Columns["Nome"].HeaderText = "Nome do cliente";

                if (dvgClientes.Columns["Cpf"] != null)
                    dvgClientes.Columns["Cpf"].HeaderText = "CPF";

                if (dvgClientes.Columns["Email"] != null)
                    dvgClientes.Columns["Email"].HeaderText = "E-mail";

                if (dvgClientes.Columns["DataNascimento"] != null)
                {
                    dvgClientes.Columns["DataNascimento"].HeaderText = "Nascimento";
                    dvgClientes.Columns["DataNascimento"].DefaultCellStyle.Format = "d";
                }

                if (dvgClientes.Columns["TotalDividas"] != null)
                {
                    dvgClientes.Columns["TotalDividas"].HeaderText = "Dívida";
                    dvgClientes.Columns["TotalDividas"].DefaultCellStyle.Format = "C2";
                }

                if (dvgClientes.Columns["btnPagar"] != null)
                {
                    dvgClientes.Columns["btnPagar"].DisplayIndex = dvgClientes.Columns.Count - 1;
                }

                decimal totalGeral = cliente.ObterTotalDividasGeral(pesquisa);
                lbl.Text = $"Total da dívida: R$ {totalGeral:N2}";

                totalPaginas = cliente.ObterTotalPaginas(pesquisa, QuantidadePorPagina);
                if (totalPaginas == 0) totalPaginas = 1;

                lblPagina.Text = $"Página {paginaAtual} de {totalPaginas}";

                btnAnterior.Enabled = paginaAtual > 1;
                btnProximo.Enabled = paginaAtual < totalPaginas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: ", ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaAtual > 1)
            {
                paginaAtual--;
                CarregarTabela();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (paginaAtual < totalPaginas)
            {
                paginaAtual++;
                CarregarTabela();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            paginaAtual = 1;
            CarregarTabela();
        }
    }
}
