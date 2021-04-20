
using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Interface;

namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {

        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}
