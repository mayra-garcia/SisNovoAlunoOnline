using System.Text;

namespace SisNovoAlunoOnline.Domain.Exceptions
{
    public class EntityValidateException : BusinessException
    {
        public EntityValidateException(string message) : base(message) { }

        public EntityValidateException(StringBuilder messages) : base(messages.ToString()) { }
    }
}