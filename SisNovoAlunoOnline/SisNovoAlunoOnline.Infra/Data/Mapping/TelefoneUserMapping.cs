using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisNovoAlunoOnline.Infra.Data.Entities;

namespace SisNovoAlunoOnline.Infra.Data.Mapping
{
    class TelefoneUserMapping : IEntityTypeConfiguration<TelefoneUserEntity>
    {
        public void Configure(EntityTypeBuilder<TelefoneUserEntity> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Numero).IsRequired().HasMaxLength(9);

            builder.Property(prop => prop.DDD).IsRequired();

            builder.HasOne(bld => bld.UserEntity)
                .WithMany(bld => bld.TelefoneUser)
                .HasForeignKey(bld => bld.UserId)
                .HasPrincipalKey(bld => bld.Id)
                .HasConstraintName("FKUserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
