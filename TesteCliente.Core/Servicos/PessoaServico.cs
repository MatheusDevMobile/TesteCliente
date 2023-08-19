using AutoMapper;
using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Core.Interfaces.Repositorios;
using TesteCliente.Core.Interfaces.Servicos;
using TesteCliente.Modelos;

namespace TesteCliente.Core.Servicos
{
    public class PessoaServico : IPessoaServico
    {
        protected IMapper Mapper { get; }
        protected IRepositorioLeitura<Pessoa> Repositorio { get; }
        public PessoaServico(IRepositorioLeitura<Pessoa> repositorio, IMapper mapper)
        {
            Repositorio = repositorio;
            Mapper = mapper;
        }

        public async Task<PessoaDetalheVO> ObterDetalheAsync(string idCliente)
        {
            var pessoa = await Repositorio.ObterPorIdAsync(idCliente);
            return Mapper.Map<PessoaDetalheVO>(pessoa);
        }

        public async Task<List<PessoaVO>> ObterTodosAsync()
        {
            return await Task.Run(() =>
            {
                var pessoas = Repositorio.ObterTodos().ToList();
                return Mapper.Map<List<PessoaVO>>(pessoas);
            });
        }

        public async Task CadastrarAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
