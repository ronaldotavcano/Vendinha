using Vendinha.Desktop.screens;

namespace Vendinha.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // botão listar clientes
        private void button1_Click(object sender, EventArgs e)
        {
            using var telaListagem = new FormListagemClientes();
            telaListagem.ShowDialog();
        }

        // botão listar dívida
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            FormCriarCliente formCriar = new FormCriarCliente();
            formCriar.Show();
        }

        private void btnCriarDivida_Click(object sender, EventArgs e)
        {
            FormCriarDivida formCriar = new FormCriarDivida();
            formCriar.Show();
        }
    }
}
