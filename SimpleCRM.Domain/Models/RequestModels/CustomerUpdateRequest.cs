using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.RequestModels {
    public class CustomerUpdateRequest : CustomerCreateRequest {

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int? Id { get; set; }

    }
}
