using Bogus;
using Microsoft.EntityFrameworkCore;
using TesteCliente.Core.Enum;
using TesteCliente.Core.Modelos;
using TesteCliente.Modelos;

namespace TesteCliente.Persistencia.Repositorios.EFCore
{
    public class SementeDados
    {
        protected DbContext Context { get; }
        public SementeDados(DbContext context)
        {
            Context = context;
        }

        public Pessoa Pessoa { get; protected set; }

        public void CriarDados()
        {
            CriarPessoas();
            Context.SaveChanges();
        }
        private void CriarPessoas()
        {
            var pessoasFake = new Faker<Pessoa>("pt_BR").CustomInstantiator(f => new Pessoa
            {
                Id = Guid.NewGuid().ToString(),
                Nome = f.Name.FullName(),
                Email = f.Internet.Email(),
                Telefone = f.Phone.PhoneNumber(),
                Endereco = new Endereco
                {
                    Logradouro = f.Address.StreetAddress(),
                    Numero = f.Random.Number(100, 999).ToString(),
                    Cep = f.Address.ZipCode(),
                    Bairro = f.Address.StreetSuffix(),
                    Cidade = f.Address.City(),
                    UF = f.Random.Enum<UnidadeFederativa>().ToString(),
                }

            }).Generate(5).ToArray();

            Context.AddRange(pessoasFake);
        }
    }
}