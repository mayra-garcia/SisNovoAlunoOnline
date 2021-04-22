using System;
using System.Collections.Generic;
using System.Text;

namespace SisNovoAlunoOnline.Domain.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LoadEntityAttribute : Attribute
    {
        public string NameForeignKey { get; set; }
        public Type TypeRepository { get; set; }
    }
}