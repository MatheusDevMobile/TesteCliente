using TesteCliente.Core.Interfaces;
using TesteCliente.Core.Modelos;

namespace TesteCliente.Modelos
{
    public class Pessoa : IElementoRegistro
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
