using System;
using Vendinha.Models;

Console.WriteLine("Digite o nome: ");
var nome = Console.ReadLine();

Console.WriteLine("Digite o CPF: ");
var cpf = Console.ReadLine();

Console.WriteLine("Digite o email: ");
var email = Console.ReadLine();

Console.WriteLine("Digite a data de nascimento: ");
var data = DateTime.Parse(Console.ReadLine());

var cliente = new Cliente();

cliente.Nome = nome;
cliente.Email = email;
cliente.DataNascimento = data;
cliente.Cpf = cpf;

cliente.PublicarDados();

