using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using Vendinha.Contexts;
using Vendinha.Models;

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

        private const string ConnectionString = "Server=localhost; Port=5432; Database=vendinha; User Id=postgres; Password=postgres;";

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

        private static bool CpfEhValido(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            string cpf_temporario = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse( cpf_temporario[i].ToString() ) * multiplicador1[i];
            }

            int resto = soma % 11;

            if ( resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            
            string digito = resto.ToString();
            cpf_temporario = cpf_temporario + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse( cpf_temporario[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public bool ValidarCliente(Cliente cliente, out List<ValidationResult> erros)
    {
        var vcontext = new ValidationContext(cliente);
        erros = new List<ValidationResult>();

        var valida = Validator.TryValidateObject(cliente, vcontext, erros, true);

        if (!string.IsNullOrEmpty(cliente.Cpf) && !CpfEhValido(cliente.Cpf))
        {
            erros.Add(new ValidationResult("O CPF informado não é válido!"));
            valida = false;
        }

        var existenteCpf = context.Clientes.Any(c => c.Cpf == cliente.Cpf);

        if (existenteCpf)
        {
            erros.Add(new ValidationResult($"O CPF {cliente.Cpf} já está cadastrado!", ["Cpf"]));
            valida = false;
        }

        var existenteEmail = context.Clientes.Any(c => c.Email == cliente.Email);
        
        if (existenteEmail)
        {
            erros.Add(new ValidationResult($"O e-mail {cliente.Email} já está cadastrado!", ["Email"] ));
            valida = false;
        }

        return valida;
    }

        public List<Cliente> Consultar()
    {
        var resultado = context.Clientes.OrderBy(a => a.Nome).ToList();
        return resultado;
    }

        public List<Cliente> ListarParaGrid(string pesquisa = "", int paginaAtual = 1, int quantidadePorPagina = 10)
        {
            
            var query = context.Clientes.Include(c => c.Dividas).AsQueryable();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                query = query.Where(c => c.Nome.Contains(pesquisa));
            }

            var resultado = query
                .ToList()
                .Select(c => {
                    c.TotalDividas = c.Dividas.Where(d => !d.DividaPaga).Sum(d => d.Valor);
                    return c;
                })
                .OrderByDescending(c => c.TotalDividas)
                .Skip((paginaAtual - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();

            return resultado;
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

        public int ObterTotalPaginas(string pesquisa = "", int quantidadePorPagina = 10)
        {
            var query = context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                pesquisa = pesquisa.ToLower();
                query = query.Where(c => c.Nome.ToLower().Contains(pesquisa) ||
                                         c.Cpf.Contains(pesquisa));
            }
            int totalRegistros = query.Count();

            return (int)Math.Ceiling((double)totalRegistros / quantidadePorPagina);
        }
    }
}

