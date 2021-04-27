using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SisNovoAlunoOnline.Domain.Entities
{
    class AddressEntity : BaseEntity
    {
        [Required]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
    }
}
