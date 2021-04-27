using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Exchange.WebServices.Data;

namespace SisNovoAlunoOnline.Infra.Data.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            //Definindo a tabela de Address
            builder.ToTable("Address");

            //Corrigir os campos da tabela Address

            builder.Property(prop => prop.Address).IsRequired().HasMaxLength(60); 

        }
    }
}
