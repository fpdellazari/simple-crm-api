using SimpleCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.RequestModels {
    public class ContactHistoryCreateRequest {
        public int CustomerId { get; set; }
        public ContactStatus Type { get; set; }
        public string Notes { get; set; }
    }
}
