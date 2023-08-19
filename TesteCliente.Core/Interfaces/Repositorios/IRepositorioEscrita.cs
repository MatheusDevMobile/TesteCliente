namespace TesteCliente.Core.Interfaces.Repositorios
{
    public interface IRepositorioEscrita<T>
    {
        Task AdicionarAsync(T entidade);
    }
}
