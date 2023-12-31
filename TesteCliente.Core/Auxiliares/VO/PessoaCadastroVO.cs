﻿using TesteCliente.Core.Enum;

namespace TesteCliente.Core.Auxiliares.VO
{
    public class PessoaCadastroVO
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
