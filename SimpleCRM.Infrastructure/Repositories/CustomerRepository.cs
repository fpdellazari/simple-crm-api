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
    public class CustomerRepository : ICustomerRepository {

        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Customer> Get() {

            string query = @" SELECT Id, 
                                     Name, 
                                     Age, 
                                     Phone, 
                                     Email, 
                                     CreatedAt, 
                                     UpdatedAt 
                              FROM Customer; ";

            var customers = _dbConnection.Query<Customer>(query).ToList();
            return customers;
        }

        public void Insert(Customer customer) {

            string query = @" INSERT INTO Customer (Name, 
                                                    Age, 
                                                    Phone, 
                                                    Email)
                                    VALUES (@Name, 
                                            @Age, 
                                            @Phone, 
                                            @Email); ";

            _dbConnection.Execute(query, customer);
        }

        public void Update(Customer customer) {

            string query = @" UPDATE Customer SET Name = @Name,
				                                  Age = @Age,
				                                  Phone = @Phone,
				                                  Email = @Email,
				                                  UpdatedAt = GETDATE()
                                     WHERE Id = @Id; ";

            _dbConnection.Execute(query, customer);
        }

    }
}
