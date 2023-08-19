using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteCliente.Core.Interfaces;

namespace TesteCliente.Persistencia.Repositorios.EFCore.Mapeamentos
{
    public abstract class ElementoRegistroMapeamentoAbstrato<T> : IEntityTypeConfiguration<T> where T : class, IElementoRegistro
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .HasMaxLength(40)
                   .IsUnicode(false);
        }
    }
}
