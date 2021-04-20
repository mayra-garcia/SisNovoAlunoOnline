using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisNovoAlunoOnline.Domain.Entities;

namespace SisNovoAlunoOnline.Infra.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome).IsRequired().HasMaxLength(60);

            builder.Property(prop => prop.Email);

            builder.Property(prop => prop.Telefone).IsRequired();

            builder.Property(prop => prop.Idade).IsRequired();
        }
    }
}
