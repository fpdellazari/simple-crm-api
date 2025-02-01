using SimpleCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Entities {
    public class ContactHistory {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ContactStatus Type { get; set; }
        public DateTime ContactDate { get; set; }
        public string Notes { get; set; }

        public Customer Customer { get; set; }
    }
}
