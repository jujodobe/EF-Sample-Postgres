using api.clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace api.clientes.Data
{
    public class Programacion8vo : DbContext
    {
        public Programacion8vo(DbContextOptions<Programacion8vo> options) : base(options)
        {

        }

        public DbSet<Clientes> Clientes => Set<Clientes>();
    }
}
