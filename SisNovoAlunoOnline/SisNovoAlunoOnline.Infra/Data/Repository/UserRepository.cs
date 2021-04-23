using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Entities;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;

namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {

        public UserRepository(DataContext dataContext, IServiceProvider serviceProvider) : base(dataContext,serviceProvider) { }
    }
}
