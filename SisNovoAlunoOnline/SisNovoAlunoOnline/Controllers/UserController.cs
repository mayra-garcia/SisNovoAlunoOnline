using Microsoft.AspNetCore.Mvc;
using SisNovoAlunoOnline.Infra.Data.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
namespace SisNovoAlunoOnline.Controllers
{
    [Route("novoAlunoOnlie/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserEntity>
    {
        public UserController(IUserRepository baseUserService) : base(baseUserService) { }
    }
}