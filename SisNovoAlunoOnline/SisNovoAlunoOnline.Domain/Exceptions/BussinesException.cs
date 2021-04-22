using System;
namespace SisNovoAlunoOnline.Domain.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string message, Exception innerException) : base(message, innerException) { }

        public BusinessException(string message) : base(message) { }
    }
}
