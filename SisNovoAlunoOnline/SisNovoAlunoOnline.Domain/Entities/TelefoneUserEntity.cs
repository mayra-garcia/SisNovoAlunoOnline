using System;
using System.Text.Json.Serialization;

namespace SisNovoAlunoOnline.Domain.Entities
{
    public class TelefoneUserEntity : BaseEntity
    {
        public string Numero { get; set; }
        public string DDD { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public virtual UserEntity UserEntity { get; set; }
    }
}
