using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Core.Auxiliares;
using TesteCliente.Core.Interfaces.Servicos;

namespace TesteCliente.Controller
{
    [SwaggerTag("Ações relacionadas ao Cliente")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        protected IPessoaServico Servico { get; }
        public PessoaController(IPessoaServico servico)
        {
            Servico = servico;
        }
        [HttpPost("Cadastrar")]
        [SwaggerOperation(Summary = "Cadastra clientes", Description = "")]
        [SwaggerResponse(200, "Cadastrado com sucesso", typeof(PessoaCadastroVO))]
        [SwaggerResponse(500, "Erro interno do servidor", typeof(ErroResposta))]
        public async Task<IActionResult> CadastrarAsync([FromBody] PessoaCadastroVO pessoa)
        {
            await Servico.CadastrarAsync(pessoa);
            return Ok(pessoa);
        }

        [HttpGet("ObterTodosClientes")]
        [SwaggerOperation(Summary = "Obtem todos os clientes", Description = "Retorna os dados de todos os clientes")]
        [SwaggerResponse(200, "Dados encontrados", typeof(List<PessoaVO>))]
        [SwaggerResponse(500, "Erro interno do servidor", typeof(ErroResposta))]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var clientes = await Servico.ObterTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("ObterDetalhes/{idCliente}")]
        [SwaggerOperation(Summary = "Obtem os detalhes do cliente", Description = "Retorna os dados do cliente filtrado pelo id do cliente")]
        [SwaggerResponse(200, "Dado encontrado", typeof(PessoaDetalheVO))]
        [SwaggerResponse(500, "Erro interno do servidor", typeof(ErroResposta))]
        public async Task<IActionResult> ObterDetalhesAsync(string idCliente)
        {
            var detalhesCliente = await Servico.ObterDetalheAsync(idCliente);
            return Ok(detalhesCliente);
        }
    }
}
