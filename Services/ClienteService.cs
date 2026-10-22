using System.ComponentModel.DataAnnotations;
using Npgsql;
using Vendinha.Models;

namespace Vendinha.Services;

internal class ClienteService
{
    private string ConnectionString = "Server=localhost; Port=5432; Database=vendinha; User Id=ronaldotc; Password=***teste123***;";

    public bool CriarCliente(Cliente cliente, out List<ValidationResult> erros)
    {
        if(!ValidarCliente(cliente, out erros))
        {
            return false;
        }

        var conexao = new NpgsqlConnection(ConnectionString);
        conexao.Open();

        var sql = """
                INSERT INTO clientes(cpf, nome, email, datanascimento) 
                VALUES (@p1, @p2, @p3, @p4)
            """;

        var comando = new NpgsqlCommand(sql, conexao);

        comando.Parameters.Add("p1", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente.Cpf;
        comando.Parameters.Add("p2", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente.Nome;
        comando.Parameters.Add("p3", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente.Email;
        comando.Parameters.Add("p4", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = cliente.DataNascimento;

        var linhas = comando.ExecuteNonQuery();
            
        return linhas == 1;
    }

    public bool ValidarCliente(Cliente cliente, out List<ValidationResult> erros)
    {
        var context = new ValidationContext(cliente);
        erros = new List<ValidationResult>();

        return Validator.TryValidateObject(cliente, context, erros, true);
    }

    public List<Cliente> Consultar()
    {
        var conexao = new NpgsqlConnection(ConnectionString);
        conexao.Open();

        var sql = """
            select cpf, nome, email, datanascimento
            from clientes
        """;

        var comando = new NpgsqlCommand(sql, conexao);

        var leitor = comando.ExecuteReader();

        var resultado = new List<Cliente>();

        while (leitor.Read()) 
        {
            var cliente = new Cliente()
            {
                Cpf = leitor.GetString(0),
                Nome = leitor.GetString(1),
                Email = leitor.GetString(2),
                DataNascimento = leitor.GetDateTime(3)
            };
            resultado.Add(cliente);
        }

        return resultado;

    }
}


