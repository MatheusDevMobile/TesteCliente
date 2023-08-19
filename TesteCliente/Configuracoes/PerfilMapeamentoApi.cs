using AutoMapper;
using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Modelos;

namespace TesteCliente.Configuracoes
{
    public class PerfilMapeamentoApi : Profile
    {
        public PerfilMapeamentoApi()
        {
            CreateMap<Pessoa, PessoaDetalheVO>();
            CreateMap<Pessoa, PessoaVO>();
        }
    }
}
