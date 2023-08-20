using FluentValidation;

namespace TesteCliente.Core.Extensoes.Validadores
{
    public static class ValidadorExtensao
    {
        public static IRuleBuilderOptions<T, string> ValidarTelefone<T>(this IRuleBuilder<T, string> regra)
        {
            return regra.SetValidator(new TelefoneStringValidador<T>());
        }
    }
}
