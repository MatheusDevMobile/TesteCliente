namespace TesteCliente.Core.Auxiliares
{
    public class ErroResposta
    {
        public ErroResposta()
        {
        }
        public ErroResposta(string mensagem)
        {
            Mensagem = mensagem;
        }
        public ErroResposta(string codigoErro, string mensagem) : this(mensagem)
        {
            CodigoErro = codigoErro;
        }

        public string Mensagem { get; set; }
        public string CodigoErro { get; set; }
    }
}