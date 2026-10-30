using Vendinha.Contexts;
using Vendinha.Models;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace Vendinha.Services
{
    public class ClienteService
    {
        private VendinhaDbContext context;
        public ClienteService(VendinhaDbContext context)
        {
          this.context = context;
        }

        public ClienteService() : this(new VendinhaDbContext(ConnectionString))
        {
        // executa primeiro o construtor com parametros e depois o sem
        }

        private const string ConnectionString = "Server=localhost; Port=5432; Database=vendinha; User Id=ronaldotc; Password=teste123;";

        public bool CriarCliente(Cliente cliente, out List<ValidationResult> erros)
        {
            if(!ValidarCliente(cliente, out erros))
            {
                return false;
            }
            cliente.DataNascimento = cliente.DataNascimento.ToUniversalTime();
            context.Add(cliente);
            context.SaveChanges();
            return true;
        }

        public bool ValidarCliente(Cliente cliente, out List<ValidationResult> erros)
    {
        var context = new ValidationContext(cliente);
        erros = new List<ValidationResult>();

        return Validator.TryValidateObject(cliente, context, erros, true);
    }

        public List<Cliente> Consultar()
    {
        var resultado = context.Clientes.OrderBy(a => a.Nome).ToList();
        return resultado;
    }
    }
}

