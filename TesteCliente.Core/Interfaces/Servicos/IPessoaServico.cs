using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Modelos;

namespace TesteCliente.Core.Interfaces.Servicos
{
    public interface IPessoaServico
    {
        Task CadastrarAsync(PessoaCadastroVO pessoaCadastro);
        Task<List<PessoaVO>> ObterTodosAsync();
        Task<PessoaDetalheVO> ObterDetalheAsync(string idCliente);
    }
}
