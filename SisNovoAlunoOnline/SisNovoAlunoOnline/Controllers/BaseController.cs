using Microsoft.AspNetCore.Mvc;
using SisNovoAlunoOnline.Domain;
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Controllers
{
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseController(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public virtual async Task<TEntity> Post([FromBody] TEntity entity)
        {
            entity.Validate();
            return await repository.Add(entity);
        }

        [HttpPut]
        public virtual async void Put([FromBody] TEntity entity)
        {
            entity.Validate(validateId: true);
            await repository.Update(entity);
        }

        [HttpDelete]
        public virtual async void Delete(Guid id) => await repository.Delete(id);


        [Route("id/{id:Guid}"), HttpGet]
        public virtual async Task<TEntity> GetOne(Guid id) => await repository.GetOne(id);

    }
}
