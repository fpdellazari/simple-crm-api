using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Entities {
    public class Sale {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
