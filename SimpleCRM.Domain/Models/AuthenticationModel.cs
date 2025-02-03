using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models {
    public class AuthenticationModel {

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório.")]
        public string? Password { get; set; }

    }
}
