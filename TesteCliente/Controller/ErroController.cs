using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesteCliente.Core.Auxiliares;
using TesteCliente.Core.Properties;
using TesteCliente.Extensoes;

namespace TesteCliente.Controller
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErroController : ControllerBase
    {
        [Route("/erro")]
        public IActionResult Erro()
        {
            var contextoErro = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (contextoErro.Error is ArgumentException erroArgumento)
                return BadRequest(erroArgumento.ParaErroResposta());

            if (contextoErro.Error is KeyNotFoundException erroNaoEncontrado)
                return NotFound(erroNaoEncontrado.ParaErroResposta(codigoErro: "404"));

            if (contextoErro.Error is Exception erroBase)
                return BadRequest(erroBase.ParaErroResposta());

            return StatusCode(500, new ErroResposta(codigoErro: "500", mensagem: Resources.ErroProcessoGenericoMsg));
        }
    }
}