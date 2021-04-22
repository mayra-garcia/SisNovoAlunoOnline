using SisNovoAlunoOnline.Domain.Entities;
using SisNovoAlunoOnline.Infra.Data.Context;
using SisNovoAlunoOnline.Infra.Data.Interfaces;
namespace SisNovoAlunoOnline.Infra.Data.Repository
{
    public class TelefoneUserRepository : BaseRepository<TelefoneUserEntity>, ITelefoneUserRepository
    {

        public TelefoneUserRepository(DataContext dataContext) : base(dataContext) { }
    }
}
