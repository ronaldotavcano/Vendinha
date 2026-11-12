using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendinha.Models
{
    public class Divida
    {
        public int Id {get; set;}

        [Required, StringLength(11)]
        public string ClienteCpf {get; set;}

        [Required, Range(0.01, 999999.99)]
        public decimal Valor { get; set; }

        public bool DividaPaga { get; set; } = false;

        public DateTime DataCriacao{get; set;}

        public DateTime? DataPagamento{get; set;}
    
    
    public virtual void PublicarDados()
        {
            Console.WriteLine("ID: {0}", Id);
            Console.WriteLine("CPF do Cliente: {0}", ClienteCpf);
            Console.WriteLine("Valor: R$ {0:F2}", Valor);
            Console.WriteLine("Situação: {0}", DividaPaga ? "Paga" : "Pendente");
            Console.WriteLine("Data de Criação: {0:dd/MM/yyyy}", DataCriacao);
            
            if (DataPagamento.HasValue)
            {
                Console.WriteLine("Data de Pagamento: {0:dd/MM/yyyy}", DataPagamento);
            }
        }
    }
}