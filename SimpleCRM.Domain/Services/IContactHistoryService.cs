using SimpleCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Services {
    public interface IContactHistoryService {
        IEnumerable<ContactHistoryModel> Get();
        void Insert(ContactHistoryModel customerModel);
    }
}
