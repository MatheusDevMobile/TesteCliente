namespace TesteCliente.Core.Interfaces.Repositorios
{
    public interface IRepositorioLeitura<T>
    {
        public Task<T> ObterPorIdAsync(string id);
        public IOrderedQueryable<T> ObterTodos();
    }
}
