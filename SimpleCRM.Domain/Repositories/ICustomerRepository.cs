using SimpleCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Repositories {
    public interface ICustomerRepository {
        IEnumerable<Customer> Get();
        void Insert(Customer customer);
    }
}
