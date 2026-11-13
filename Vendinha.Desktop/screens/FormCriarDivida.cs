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
    public partial class FormCriarDivida : Form
    {
        private DividaService divida = new DividaService();
        public FormCriarDivida()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtValor.Text.Trim(), out decimal valorDesejado))
            {
                MessageBox.Show("Por favor, introduza um valor financeiro válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var novaDivida = new Divida
            {
                ClienteCpf = txtCpf.Text.Trim(),
                Valor = valorDesejado,
                DividaPaga = false,
                DataCriacao = DateTime.UtcNow,
                DataPagamento = null
            };

            bool sucesso = divida.Criar(novaDivida, out List<ValidationResult> erros);

            if (sucesso)
            {
                MessageBox.Show("Dívida lançada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                txtCpf.Clear();
                txtValor.Clear();
            }
            else
            {  
                string mensagensErro = "Não foi possível lançar a dívida:\n\n";
                foreach (var erro in erros)
                {
                    mensagensErro += $"- {erro.ErrorMessage}\n";
                }
                MessageBox.Show(mensagensErro, "Operação Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
