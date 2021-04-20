using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _dataContext;
        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task DeleteAsync(Guid id)
        {
             _dataContext.Set<TEntity>().Remove(await SelectAsync(id));
             await _dataContext.SaveChangesAsync();
        }

        public async Task InsertAsync(TEntity obj)
        {
            await _dataContext.Set<TEntity>().AddAsync(obj);
            await _dataContext.SaveChangesAsync();
        }

        public IList<TEntity> Select() =>  _dataContext.Set<TEntity>().ToList();

        public async Task<TEntity> SelectAsync(Guid id) => await _dataContext.Set<TEntity>().FindAsync(id);

        public async Task UpdateAsync(TEntity obj)
        {
            _dataContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
    }
}
