using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace TesteCliente.Core.Extensoes.Validadores
{
    public class TelefoneStringValidador<T> : PropertyValidator<T, string>
    {
        public override string Name => "TelefoneStringValidador";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (value.LimpoNuloBranco())
                return false;

            var resultado = Regex.IsMatch(value, @"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
            return resultado;
        }
    }
}
