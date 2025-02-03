using SimpleCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.RequestModels {
    public class ContactHistoryCreateRequest {

        [Required(ErrorMessage = "O Id do cliente é obrigatório.")]
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "O tipo de contato é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O tipo de contato deve ser um número entre 1 e 5.")]
        public ContactType? Type { get; set; }

        public string? Notes { get; set; }
    }
}
