using Microsoft.EntityFrameworkCore;
using TesteCliente.Modelos;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class PessoaRepositorio : RepositorioLeituraEFCore<Pessoa>
    {
        public PessoaRepositorio(DbContext context) : base(context)
        {
        }
    }
}
