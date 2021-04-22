using FluentValidation;
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Service.Services
{
    public class BaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.InsertAsync(obj);
            return obj;
        }

        public void Delete(Guid id) => _baseRepository.DeleteAsync(id);

        public IList<TEntity> Get() => _baseRepository.Select();
        public async Task<TEntity> GetById(Guid id) => await _baseRepository.SelectAsync(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj,Activator.CreateInstance<TValidator>());
            _baseRepository.UpdateAsync(obj);
            return obj;
        }

        private async void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Registros não detectados");
            await validator.ValidateAndThrowAsync(obj);
        }
    }
}
