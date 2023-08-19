using TesteCliente.Core.Auxiliares;

namespace TesteCliente.Extensoes
{
    public static class ExceptionExtensao
    {
        public static ErroResposta ParaErroResposta(this Exception ex, string codigoErro = "400")
        {
            return new ErroResposta(codigoErro, ex.Message);
        }
    }
}