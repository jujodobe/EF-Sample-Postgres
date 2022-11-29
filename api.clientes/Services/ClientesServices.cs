using api.clientes.Data;
using api.clientes.Models;
using api.clientes.Validaciones;

namespace api.clientes.Services
{
    public class ClientesServices : IClientesValidations
    {
        public async Task<string> addClientes(Clientes clientes, Programacion8vo db)
        {
            db.Clientes.Add(clientes);
            await db.SaveChangesAsync();
            return "Dators insertados correctamente";
        }
    }
}
