using SimpleCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Services {
    public interface ICustomerService {
        IEnumerable<CustomerModel> Get();
        void Insert(CustomerModel customerModel);
    }
}
