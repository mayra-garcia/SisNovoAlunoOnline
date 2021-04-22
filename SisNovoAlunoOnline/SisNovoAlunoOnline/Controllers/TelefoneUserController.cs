using Microsoft.AspNetCore.Mvc;
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Interfaces;

namespace SisNovoAlunoOnline.Controllers
{
    [Route("novoAlunoOnlie/[controller]")]
    [ApiController]
    public class TelefoneUserController : BaseController<TelefoneUserEntity>
    {
        public TelefoneUserController(ITelefoneUserRepository baseUserService) : base(baseUserService) { }
    }
}
