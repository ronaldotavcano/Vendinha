using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using Vendinha.Contexts;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class DividaService
    {
        private VendinhaDbContext context;

        public DividaService(VendinhaDbContext context)
        {
          this.context = context;
        }

        public DividaService() : this(new VendinhaDbContext(ConnectionString))
        {
        }

        private const string ConnectionString = "Server=localhost; Port=5432; Database=vendinha; User Id=postgres; Password=postgres;";

        public List<Divida> Consultar()
        {
            var resultado = context.Dividas.ToList();
            return resultado;
        }

        public bool Criar(Divida divida, out List<ValidationResult> erros)
        {
            if (!Validar(divida, out erros))
            {
                return false;
            }

            divida.DataCriacao = DateTime.UtcNow;

            context.Dividas.Add(divida);
            context.SaveChanges();
            
            return true;
        }

        public bool Validar(Divida divida, out List<ValidationResult> erros)
        {
            var vcontext = new ValidationContext(divida);
            erros = new List<ValidationResult>();
            var valida = Validator.TryValidateObject(divida, vcontext, erros, true);

            var clienteExiste = context.Clientes.Any(c => c.Cpf == divida.ClienteCpf);

            if (!clienteExiste)
            {
                erros.Add(new ValidationResult($"O CPF {divida.ClienteCpf} não está cadastrado!", ["ClienteCpf"]));
                valida = false;
            }

            if (clienteExiste && !divida.DividaPaga)
            {
                var dividaEmAberto = context.Dividas.Any(d => d.ClienteCpf == divida.ClienteCpf && !d.DividaPaga);

                if (dividaEmAberto)
                {
                    erros.Add(new ValidationResult("Este cliente já possui uma dívida em aberto. Não é possível cadastrar outra."));
                    valida = false;
                }
            }

            return valida;
        }

        public bool PagarDivida(string cpf)
        {
            var cliente = context.Clientes
                                  .Include(c => c.Dividas)
                                  .FirstOrDefault(c => c.Cpf == cpf);

            if (cliente == null || !cliente.Dividas.Any(d => d.DividaPaga == false))
            {
                return false;
            }

            var dividaAberta = cliente.Dividas.FirstOrDefault(d => d.DividaPaga == false);

            if (dividaAberta != null)
            {
                dividaAberta.DividaPaga = true;
                dividaAberta.DataPagamento = DateTime.Now.ToUniversalTime();
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public decimal ObterTotalDividasGeral(string pesquisa = "")
        {
            var query = context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                pesquisa = pesquisa.ToLower();
                query = query.Where(c => c.Nome.ToLower().Contains(pesquisa) ||
                                         c.Cpf.Contains(pesquisa));
            }

            return query.SelectMany(c => c.Dividas)
                        .Where(d => d.DividaPaga == false)
                        .Sum(d => d.Valor);
        }
    }
}