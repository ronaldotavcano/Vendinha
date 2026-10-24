using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Vendinha.Models;

internal class Cliente
{
    [Required, StringLength(80, MinimumLength =4)]
    public string Nome {get; set;}
    [Required, StringLength(11)]
    public string Cpf{get; set;}
    private string email;
    [Required]
    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value.ToLower().Trim();
        }
    }
    [Required]
    public DateTime DataNascimento{get; set;}
    [Range(12, 80)]
    public int Idade
    {
        get
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if(DataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
    }

    public void PublicarDados()
    {
        Console.WriteLine("\nDados do Cliente");
        Console.WriteLine("Nome: {0}", Nome);
        Console.WriteLine("Cpf: {0}", Cpf);
        Console.WriteLine("Email: {0}", Email);
        Console.WriteLine("Idade: {0}", Idade);
    }
}