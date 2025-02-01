using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models {
    public class ContactHistoryModel {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ContactStatus Type { get; set; }
        public DateTime ContactDate { get; set; }
        public string Notes { get; set; }
        public CustomerModel? Customer{ get; set; }
    }
}
