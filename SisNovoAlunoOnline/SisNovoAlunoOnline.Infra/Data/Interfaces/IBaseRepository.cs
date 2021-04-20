using SisNovoAlunoOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Infra.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(Guid id);
        IList<TEntity> Select();
        Task<TEntity> SelectAsync(Guid id);
    }
}
