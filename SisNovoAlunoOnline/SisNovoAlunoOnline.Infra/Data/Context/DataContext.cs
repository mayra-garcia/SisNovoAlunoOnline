using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Mapping;

namespace SisNovoAlunoOnline.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMapping().Configure);
            modelBuilder.Entity<AddressEntity>(new AddressMapping().Configure);
        }

    }
}
