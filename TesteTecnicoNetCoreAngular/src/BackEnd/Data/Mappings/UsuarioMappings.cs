using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Mappings
{
    public class UsuarioMappings : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.SobreNome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasQueryFilter(p => p.Ativo == true);

            builder.ToTable("Usuarios");
        }
    }
}
