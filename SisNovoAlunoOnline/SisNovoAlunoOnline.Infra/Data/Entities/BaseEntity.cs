using System;

namespace SisNovoAlunoOnline.Infra.Data.Entities
{
   public class BaseEntity
    {
        public virtual Guid Id { get; set; }

        public virtual void AdditionalValidations() { }
    }
}
