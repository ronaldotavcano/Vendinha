using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha.Desktop.screens
{
    public partial class FormCriarCliente : Form
    {
        private ClienteService cliente = new ClienteService();
        public FormCriarCliente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var novoCliente = new Cliente
            {
                Nome = txtNome.Text.Trim(),
                Cpf = txtCpf.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DataNascimento = dtpDataNascimento.Value
            };

            bool sucesso = cliente.CriarCliente(novoCliente, out List<ValidationResult> erros);

            if (sucesso)
            {
                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNome.Clear();
                txtCpf.Clear();
                txtEmail.Clear();
                dtpDataNascimento.Value = DateTime.Now;
            }
            else
            {
                
                string mensagensErro = "Não foi possível salvar o cliente:\n\n";
                foreach (var erro in erros)
                {
                    mensagensErro += $"- {erro.ErrorMessage}\n";
                }

                MessageBox.Show(mensagensErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
