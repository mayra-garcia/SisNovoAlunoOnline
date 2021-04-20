﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SisNovoAlunoOnline.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
    }
}
