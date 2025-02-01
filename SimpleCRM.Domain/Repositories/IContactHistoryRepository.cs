using SimpleCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Repositories {
    public interface IContactHistoryRepository {
        IEnumerable<ContactHistory> Get();
        void Insert(ContactHistory contactHistory);
    }
}
