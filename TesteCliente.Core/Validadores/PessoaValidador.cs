using FluentValidation;
using TesteCliente.Core.Auxiliares.VO;
using TesteCliente.Core.Extensoes.Validadores;

namespace TesteCliente.Core.Validadores
{
    public class PessoaValidador : AbstractValidator<PessoaCadastroVO>
    {
        public PessoaValidador()
        {
            RuleFor(i => i.Email).NotEmpty()
                                 .WithMessage("O campo e-mail não pode ser vazio.")
                                 .EmailAddress()
                                 .WithMessage("Formato de e-mail incorreto.");

            RuleFor(i => i.Telefone).ValidarTelefone()
                                    .When(p => p.Telefone != null)
                                    .WithMessage("O telefone informado é inválido");
        }
    }
}
