using SisNovoAlunoOnline.Domain.Exceptions;
using SisNovoAlunoOnline.Infra.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SisNovoAlunoOnline.Infra.Data
{
    public static class EntityExtension
    {
        public static void Validate(this BaseEntity entity, bool validateId = false)
        {
            if (entity is null)
            {
                throw new EntityValidateException("Entidade em estado nulo ou não definido.");
            }
            else if (validateId && entity.Id.ToString() is null)
            {
                throw new EntityValidateException("ID não definido para atualização de dados.");
            }

            var validations = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            if (!Validator.TryValidateObject(entity, context, validations, true))
            {
                var messages = new StringBuilder();
                validations.ForEach(item => messages.AppendLine(item.ErrorMessage));
                throw new EntityValidateException(messages);
            }

            entity.AdditionalValidations();
        }
    }
}
