using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Contas.Domain;

namespace MyBank.Contas.Data.Mappings
{
    public class ContaCorrenteMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {

            builder.HasKey(c => c.NumeroConta);

            builder.Property(c => c.NumeroConta)
                .IsRequired()
                .HasColumnType("varchar(5)"); 
                        
            builder.Property(c => c.Saldo)
                .IsRequired()
                .HasColumnType("double");

            builder.ToTable("Contas");
        }

    }
}
