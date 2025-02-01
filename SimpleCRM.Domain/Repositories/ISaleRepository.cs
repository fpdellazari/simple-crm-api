using SimpleCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Repositories {
    public interface ISaleRepository {
        IEnumerable<Sale> Get();
        void Insert(Sale sale);
    }
}
