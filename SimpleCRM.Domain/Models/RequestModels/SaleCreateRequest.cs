using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.RequestModels {
    public class SaleCreateRequest {

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que 0.")]
        public int Quantity { get; set; }
    }
}
