using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models {
    public class ProductModel {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
