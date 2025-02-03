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
        public string? Name { get; set; }

        [Required(ErrorMessage = "A idade do cliente é obrigatória.")]
        [Range(16, 200, ErrorMessage = "A idade deve estar entre 0 e 200 anos.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "O telefone do cliente é obrigatório.")]
        [RegularExpression(@"^\d{8,12}$", ErrorMessage = "O telefone deve conter entre 8 e 12 dígitos, sem espaços ou caracteres especiais.")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string? Email { get; set; }
    }
}
