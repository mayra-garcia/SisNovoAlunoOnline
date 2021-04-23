using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Entities;
using SisNovoAlunoOnline.Infra.Data.Interfaces;
using System;

namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class TelefoneUserRepository : BaseRepository<TelefoneUserEntity>, ITelefoneUserRepository
    {
        public TelefoneUserRepository(DataContext dataContext,IServiceProvider serviceProvider) : base(dataContext,serviceProvider) { }
    }
}
