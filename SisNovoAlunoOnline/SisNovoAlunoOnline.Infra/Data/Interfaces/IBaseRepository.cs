using SisNovoAlunoOnline.Infra.Data.Entities;
using System;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Infra.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetOne(Guid id, bool loadDependencies = true);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> SelectById(Guid Id);
    }
}
