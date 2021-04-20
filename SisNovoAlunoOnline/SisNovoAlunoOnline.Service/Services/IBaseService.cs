using FluentValidation;
using SisNovoAlunoOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Service.Services
{
   public interface IUserRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(Guid id);

        IList<TEntity> Get();

        Task<TEntity> GetById(Guid id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
