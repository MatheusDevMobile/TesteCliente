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
            CreateMap<PessoaCadastroVO, Pessoa>().ForMember(p => p.Id, map => map.MapFrom(vo => Guid.NewGuid().ToString()))
                                                 .ForPath(p => p.Endereco.Logradouro, map => map.MapFrom(vo => vo.Logradouro))
                                                 .ForPath(p => p.Endereco.Bairro, map => map.MapFrom(vo => vo.Bairro))
                                                 .ForPath(p => p.Endereco.Numero, map => map.MapFrom(vo => vo.Numero))
                                                 .ForPath(p => p.Endereco.Cep, map => map.MapFrom(vo => vo.Cep))
                                                 .ForPath(p => p.Endereco.Cidade, map => map.MapFrom(vo => vo.Cidade))
                                                 .ForPath(p => p.Endereco.UF, map => map.MapFrom(vo => vo.UF)); 
        }
    }
}
