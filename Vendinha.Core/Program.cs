using Vendinha.Models;
using Vendinha.Services;

var service = new ClienteService();

while (true)
{
    Console.WriteLine("\n1 - Consultar clientes");
    Console.WriteLine("2 - Criar cliente");
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
        var clientes = service.Consultar();
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
        var sucesso = service.CriarCliente(cliente, out var errors);

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
}



