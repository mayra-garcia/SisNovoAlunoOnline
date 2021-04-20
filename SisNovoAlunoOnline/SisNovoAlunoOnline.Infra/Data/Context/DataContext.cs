using Microsoft.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMapping().Configure);
        }
    }
}
