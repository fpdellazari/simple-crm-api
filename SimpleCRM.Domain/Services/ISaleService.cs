using SimpleCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Services {
    public interface ISaleService {
        IEnumerable<SaleModel> Get();
        void Insert(SaleModel saleModel);
    }
}
