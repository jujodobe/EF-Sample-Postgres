using api.clientes.Models;

namespace api.clientes.Validaciones
{
    public interface IClientesValidations
    {
        public Task<string> addClientes(Clientes clientes);
    }
}
