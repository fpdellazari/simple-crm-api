using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Entities {
    public class Customer {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
