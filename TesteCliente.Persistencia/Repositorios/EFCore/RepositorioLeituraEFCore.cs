using Microsoft.EntityFrameworkCore;
using TesteCliente.Core.Interfaces;
using TesteCliente.Core.Interfaces.Repositorios;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class RepositorioLeituraEFCore<T> : IRepositorioLeitura<T> where T : class, IElementoRegistro
    {
        protected DbContext Context { get; }

        public RepositorioLeituraEFCore(DbContext context)
        {
            Context = context;
        }
        public async Task<T> ObterPorIdAsync(string id)
        {
            return await Context.FindAsync<T>(id);
        }
        public IOrderedQueryable<T> ObterTodos()
        {
            var lista = OrdenarPadrao(GetDbSet().AsQueryable());
            return lista;
        }
        public IOrderedQueryable<T> OrdenarPadrao(IQueryable<T> query)
        {
            return query.OrderBy(e => e.Id);
        }
        private IQueryable<T> GetDbSet()
        {
            return Context.Set<T>();
        }
    }
}