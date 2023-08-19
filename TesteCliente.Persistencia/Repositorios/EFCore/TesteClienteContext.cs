using Microsoft.EntityFrameworkCore;
using TesteCliente.Persistencia.Repositorios.EFCore.Mapeamentos;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class TesteClienteContext : DbContext
    {
        public TesteClienteContext(DbContextOptions<TesteClienteContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PessoaMapeamento());
        }
    }
}
