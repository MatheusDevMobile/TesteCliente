using AutoMapper;
using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Core.Extensoes;
using TesteCliente.Core.Interfaces.Repositorios;
using TesteCliente.Core.Interfaces.Servicos;
using TesteCliente.Modelos;

namespace TesteCliente.Core.Servicos
{
    public class PessoaServico : IPessoaServico
    {
        protected IMapper Mapper { get; }
        protected IRepositorioLeitura<Pessoa> RepositorioLeitura { get; }
        protected IRepositorioEscrita<Pessoa> RepositorioEscrita { get; }
        public PessoaServico(IRepositorioLeitura<Pessoa> repositorioLeitura, IMapper mapper, IRepositorioEscrita<Pessoa> repositorioEscrita)
        {
            RepositorioLeitura = repositorioLeitura;
            RepositorioEscrita = repositorioEscrita;
            Mapper = mapper;
        }

        public async Task<PessoaDetalheVO> ObterDetalheAsync(string idCliente)
        {
            var pessoa = await RepositorioLeitura.ObterPorIdAsync(idCliente);
            return Mapper.Map<PessoaDetalheVO>(pessoa);
        }

        public async Task<List<PessoaVO>> ObterTodosAsync()
        {
            return await Task.Run(() =>
            {
                var pessoas = RepositorioLeitura.ObterTodos().ToList();
                return Mapper.Map<List<PessoaVO>>(pessoas);
            });
        }

        public async Task CadastrarAsync(PessoaCadastroVO pessoaCadastro)
        {
            var pessoaPersistencia = Mapper.Map<Pessoa>(pessoaCadastro);
            await RepositorioEscrita.AdicionarAsync(pessoaPersistencia);
        }
    }
}
