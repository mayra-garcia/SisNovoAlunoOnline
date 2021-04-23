using Microsoft.EntityFrameworkCore;
using SisNovoAlunoOnline.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            Assembly currentAssembly = typeof(DataContext).Assembly;

            IEnumerable<Type> efMappingTypes = currentAssembly.GetTypes().Where(tp =>
                tp.FullName.StartsWith("SisNovoAlunoOnline.Infra.Data.Mapping.") &&
                tp.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}
