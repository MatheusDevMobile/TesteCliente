namespace TesteCliente.Core.Extensoes
{
    public static class StringExtensao
    {
        public static bool LimpoNuloBranco(this string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }
    }
}