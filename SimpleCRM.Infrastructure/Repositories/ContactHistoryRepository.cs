using Dapper;
using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Infrastructure.Repositories {
    public class ContactHistoryRepository : IContactHistoryRepository {

        private readonly IDbConnection _dbConnection;

        public ContactHistoryRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public IEnumerable<ContactHistory> Get() {

            string query = @" SELECT ch.Id, 
                                     ch.CustomerId, 
                                     ch.Type, 
                                     ch.ContactDate, 
                                     ch.Notes, 
                                     c.Id, 
                                     c.Name, 
                                     c.Age, 
                                     c.Phone, 
                                     c.Email, 
                                     c.CreatedAt, 
                                     c.UpdatedAt
                              FROM ContactHistory ch
                              INNER JOIN Customer c ON ch.CustomerId = c.Id; ";

            var contactHistories = _dbConnection.Query<ContactHistory, Customer, ContactHistory>(query,
                (contactHistory, customer) => {
                    contactHistory.Customer = customer;
                    return contactHistory;
                }, splitOn: "Id").ToList();

            return contactHistories;
        }

        public void Insert(ContactHistory contactHistory) {

            string query = @" INSERT INTO ContactHistory (CustomerId, 
                                                          Type, 
                                                          Notes)
                                    VALUES (@CustomerId, 
                                            @Type, 
                                            @Notes); ";

            _dbConnection.Execute(query, contactHistory);
        }
    }
}
