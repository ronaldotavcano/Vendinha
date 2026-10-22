using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Vendinha.Models;

namespace Vendinha.Services;

internal class ClienteService
{
    private List<Cliente> lista = new List<Cliente>();

    public bool CriarCliente(Cliente cliente, out List<ValidationResult> erros)
    {
        if(!ValidarCliente(cliente, out erros))
        {
            return false;
        }

        lista.Add(cliente);
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
        return lista.ToList();
    }
}


