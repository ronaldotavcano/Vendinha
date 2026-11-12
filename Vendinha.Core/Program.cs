using Vendinha.Models;
using Vendinha.Services;

var clienteService = new ClienteService();
var dividaService = new DividaService();

while (true)
{
    Console.WriteLine("\n--- MENU VENDINHA ---");
    Console.WriteLine("1 - Consultar clientes");
    Console.WriteLine("2 - Criar cliente");
    Console.WriteLine("3 - Consultar dívidas");
    Console.WriteLine("4 - Criar dívida");
    Console.Write("Digite a opção: ");

    int opcao = 0;

    try
    {
        opcao = int.Parse(Console.ReadLine()!);
    }
    catch(FormatException ex)
    {
        Console.WriteLine("Opção inválida! {0}", ex.Message);
    }

    if(opcao == 1)
    {
        var clientes = clienteService.Consultar();
        Console.WriteLine("===============================");
        foreach(var cliente in clientes)
        {
            cliente.PublicarDados();
            Console.WriteLine("===============================");
        }
    }
    else if (opcao == 2)
    {
        Console.WriteLine("Digite o nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine("Digite o cpf: ");
        var cpf = Console.ReadLine();

        Console.WriteLine("Digite o email: ");
        var email = Console.ReadLine();

        Console.WriteLine("Digite a data de nascimento: ");
        var data = DateTime.Parse(Console.ReadLine()!);

        var cliente = new Cliente();

        cliente.Nome = nome;
        cliente.Cpf = cpf;
        cliente.DataNascimento = data;
        cliente.Email = email;
        var sucesso = clienteService.CriarCliente(cliente, out var errors);

        if (sucesso)
        {
            Console.WriteLine("Cadastrado com sucesso!");
        }
        else
        {
            foreach(var erro in errors)
            {
                Console.WriteLine("{0}: {1}", erro.MemberNames.First(), erro.ErrorMessage);
            }
            Console.WriteLine("Erro ao cadastrar");
        }
    }
    else if (opcao == 3)
    {
        var dividas = dividaService.Consultar();
        Console.WriteLine("\n=================");

        if (dividas.Count == 0)
        {
            Console.WriteLine("Nenhuma dívida cadastrada.");
        }
        else
        {
            foreach (var divida in dividas)
            {
                divida.PublicarDados();
                Console.WriteLine("=================");
            }
        }
    }
    else if (opcao == 4)
    {
        Console.Write("Digite o CPF do Cliente: ");
        var cpf = Console.ReadLine();

        Console.Write("Digite o Valor da Dívida: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            var divida = new Divida
            {
                ClienteCpf = cpf,
                // valor tem que ser feito com , 
                Valor = valor,
                DataCriacao = DateTime.Now.ToUniversalTime(), 
                DividaPaga = false
            };

            var sucesso = dividaService.Criar(divida, out var erros);

            
            if (sucesso)
            {
                Console.WriteLine("Cadastrado com sucesso!");
            }
            else
            {
                foreach (var erro in erros)
                {
                    Console.WriteLine("{0}: {1}", erro.MemberNames.First(), erro.ErrorMessage);
                }
                Console.WriteLine("Erro ao cadastrar");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }
}