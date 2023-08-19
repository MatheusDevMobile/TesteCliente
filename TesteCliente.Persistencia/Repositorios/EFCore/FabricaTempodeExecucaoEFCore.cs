using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class FabricaBancoTempoExecucaoEF : IDesignTimeDbContextFactory<TesteClienteContext>
    {
        public TesteClienteContext CreateDbContext(string[] args)
        {
            var opcoes = new DbContextOptionsBuilder<TesteClienteContext>().UseLazyLoadingProxies()
                                                                           .UseSqlServer("Server=localhost,1433;Initial Catalog=sqldb-testecliente;User ID=sa;Password=testeCliente1433; TrustServerCertificate=true; Trusted_Connection=false;").Options;
            return new TesteClienteContext(opcoes);
        }
    }
}
