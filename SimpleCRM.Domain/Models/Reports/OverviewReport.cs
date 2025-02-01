using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Models.Reports {
    public class OverviewReport {
        public int TotalContacts { get; set; }
        public int TotalProductiveContacts { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal TotalSalesValue { get; set; }
        public decimal AverageTicket { get; set; }
        public decimal ConversionRate { get; set; }
    }
}
