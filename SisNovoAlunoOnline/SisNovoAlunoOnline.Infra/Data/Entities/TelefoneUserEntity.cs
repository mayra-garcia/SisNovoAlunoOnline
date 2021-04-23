using SisNovoAlunoOnline.Domain.Attibutes;
using SisNovoAlunoOnline.Infra.Data.Interface;
using System;
using System.Text.Json.Serialization;

namespace SisNovoAlunoOnline.Infra.Data.Entities
{
    public class TelefoneUserEntity : BaseEntity
    {
        public string Numero { get; set; }
        public string DDD { get; set; }
        public Guid UserId { get; set; }

        //[JsonIgnore]
        [LoadEntity(NameForeignKey = nameof(UserId), TypeRepository = typeof(IUserRepository))]
        public virtual UserEntity UserEntity { get; set; }
    }
}
