using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteCliente.Core.Modelos;
using TesteCliente.Modelos;

namespace TesteCliente.Persistencia.Repositorios.EFCore.Mapeamentos
{
    public class PessoaMapeamento : ElementoRegistroMapeamentoAbstrato<Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Pessoa))
                   .Property(o => o.Nome)
                   .HasMaxLength(100)
                   .IsUnicode(false);

            builder.Property(o => o.Telefone)
                   .HasMaxLength(30);

            builder.Property(o => o.Email)
                   .HasMaxLength(50);

            builder.OwnsOne(p => p.Endereco, pBuilder =>
            {
                pBuilder.ToTable(nameof(Endereco))
                  .Property(o => o.Logradouro)
                  .HasMaxLength(100)
                  .IsUnicode(false);

                pBuilder.Property(o => o.Numero)
                        .HasMaxLength(5);

                pBuilder.Property(o => o.Bairro)
                       .HasMaxLength(30);

                pBuilder.Property(o => o.Cidade)
                       .HasMaxLength(30);

                pBuilder.Property(o => o.UF)
                       .HasMaxLength(2);
            });
        }
    }
}
