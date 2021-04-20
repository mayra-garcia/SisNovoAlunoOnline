using Microsoft.AspNetCore.Mvc;
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Threading.Tasks;

namespace SisNovoAlunoOnline.Controllers
{
    [Route("novoAlunoOnlie/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _baseUserService;

        public UserController(IUserRepository baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserEntity user)
        {
            if (user == null)
                return NotFound();

             await _baseUserService.InsertAsync(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserEntity user)
        {
            if (user == null)
                return NotFound();

           await _baseUserService.UpdateAsync(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return NotFound();

            Execute(() =>
            {
                _baseUserService.DeleteAsync(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Execute(() => _baseUserService.Select());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           if (string.IsNullOrEmpty(id.ToString()))
                return NotFound();

            return Execute(() => _baseUserService.SelectAsync(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}