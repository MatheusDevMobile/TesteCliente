using Microsoft.EntityFrameworkCore;
using TesteCliente.Core.Interfaces;
using TesteCliente.Core.Interfaces.Repositorios;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class RepositorioLeituraEFCore<T> : IRepositorioLeitura<T>, IRepositorioEscrita<T> where T : class, IElementoRegistro
    {
        protected DbContext Contexto { get; }

        public RepositorioLeituraEFCore(DbContext contexto)
        {
            Contexto = contexto;
        }
        public async Task<T> ObterPorIdAsync(string id)
        {
            return await Contexto.FindAsync<T>(id);
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
            return Contexto.Set<T>();
        }

        public async Task AdicionarAsync(T entidade)
        {
            await Contexto.AddAsync(entidade);
            await Contexto.SaveChangesAsync();
        }
    }
}