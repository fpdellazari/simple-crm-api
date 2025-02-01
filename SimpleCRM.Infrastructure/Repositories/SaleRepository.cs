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
    public class SaleRepository : ISaleRepository {

        private readonly IDbConnection _dbConnection;

        public SaleRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Sale> Get() {

            string query = @" SELECT s.Id, 
                                     s.CustomerId, 
                                     s.ProductId, 
                                     s.Quantity, 
                                     s.UnitPrice, 
                                     s.TotalPrice, 
                                     s.SaleDate,
                                     c.Id, 
                                     c.Name, 
                                     c.Age, 
                                     c.Phone, 
                                     c.Email, 
                                     c.CreatedAt, 
                                     c.UpdatedAt,
                                     p.Id, 
                                     p.Name, 
                                     p.Price
                                FROM Sale s
                                INNER JOIN Customer c ON s.CustomerId = c.Id
                                INNER JOIN Product p ON s.ProductId = p.Id; ";

            var sales = _dbConnection.Query<Sale, Customer, Product, Sale>(query,
                (sale, customer, product) => {
                    sale.Customer = customer;
                    sale.Product = product;
                    return sale;
                }, splitOn: "Id,Id").ToList();

            return sales;
        }

        public void Insert(Sale sale) {

            string query = @" INSERT INTO Sale (CustomerId, 
                                                ProductId, 
                                                Quantity, 
                                                UnitPrice, 
                                                TotalPrice)
                            SELECT @CustomerId, 
                                    @ProductId, 
                                    @Quantity, 
                                    p.Price AS UnitPrice, 
                                    p.Price * @Quantity AS TotalPrice
                            FROM Product p
                            WHERE p.Id = @ProductId; ";

            _dbConnection.Execute(query, sale);
        }
    }
}
