using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.RequestModels {
    public class CustomerCreateRequest {

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Range(0, 200, ErrorMessage = "A idade deve estar entre 0 e 200 anos.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "O telefone do cliente é obrigatório.")]
        [Phone(ErrorMessage = "O telefone informado é inválido.")]
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Email { get; set; }
    }
}
