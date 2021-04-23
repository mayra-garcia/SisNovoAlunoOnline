using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SisNovoAlunoOnline.Domain.Attibutes;
using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext databaseContext;
        private readonly IServiceProvider serviceProvider;

        public BaseRepository(DataContext databaseContext, IServiceProvider _serviceProvider)
        {
            this.databaseContext = databaseContext;
            this.serviceProvider = _serviceProvider;
        }

        protected virtual void BeforeModified(StateEntity stateEntity, TEntity entity) { }

        protected virtual void AfterModified(StateEntity stateEntity, TEntity entity) { }

        private async Task<PropertyInfo[]> LoadPropertiesEntitiesAsync(object entity)
        {
            var properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<LoadEntityAttribute>();
                if (attribute != null && !string.IsNullOrWhiteSpace(attribute.NameForeignKey) && attribute.TypeRepository != null)
                {
                    var foreignKey = entity.GetType().GetProperty(attribute.NameForeignKey);
                    if (foreignKey != null)
                    {
                        var valueObject = foreignKey.GetValue(entity);
                        if (valueObject != null)
                        {
                            Guid idLoad = (Guid)valueObject;

                            var repository = serviceProvider.GetRequiredService(attribute.TypeRepository);
                            var entityObject = repository.GetType().GetMethod(nameof(GetOne)).Invoke(repository, new object[] { idLoad, false });

                            if (entityObject != null)
                            {
                                property.SetValue(entity, entityObject);
                            }
                        }
                    }
                }
            }
            return properties;
        }

        public async Task<TEntity> GetOne(Guid id, bool loadDependencies = true)
        {
            var entity = await SelectById(id);

            if (entity is null)
            {
                throw new Exception($"Nenhum resultado encontrado para o id: {id}.");
            }

            if (loadDependencies)
            {
                LoadPropertiesEntitiesAsync(entity);
            }

            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            BeforeModified(StateEntity.Inserted, entity);
            databaseContext.Add(entity);
            databaseContext.SaveChanges();
            AfterModified(StateEntity.Inserted, entity);
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            BeforeModified(StateEntity.Updated, entity);
            TEntity entityDb = await GetOne(entity.Id, false);
            databaseContext.Entry(entityDb).State = EntityState.Modified;
            databaseContext.Entry(entityDb).CurrentValues.SetValues(entity);
            databaseContext.SaveChanges();
            AfterModified(StateEntity.Updated, entity);
            return entityDb;
        }

        public async Task Delete(Guid id)
        {
            TEntity entity = await GetOne(id, false);
            BeforeModified(StateEntity.Deleted, entity);
            databaseContext.Entry(entity).State = EntityState.Deleted;
            databaseContext.Remove(entity);
            databaseContext.SaveChanges();
            AfterModified(StateEntity.Deleted, entity);
        }

        public async Task<TEntity> SelectById(Guid id) => await databaseContext.Set<TEntity>().FindAsync(id);
    }
    public enum StateEntity
    {
        Inserted = 1,
        Updated = 2,
        Deleted = 3
    }
}
