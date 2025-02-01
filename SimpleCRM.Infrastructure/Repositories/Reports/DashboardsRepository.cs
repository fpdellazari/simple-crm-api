using Dapper;
using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Models.Reports;
using SimpleCRM.Domain.Repositories.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Infrastructure.Repositories.Reports {
    public class DashboardsRepository : IDashboardsRepository {

        private readonly IDbConnection _dbConnection;

        public DashboardsRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public OverviewReport Get() {

            string query = @" SELECT COUNT(ch.Id) AS TotalContacts, 
                                     NULLIF(COUNT(CASE WHEN ch.Type IN (1, 2) THEN 1 END), 0) AS TotalProductiveContacts, 
                                     (SELECT COUNT(s.Id) FROM Sale s) AS TotalSalesCount, 
                                     (SELECT SUM(s.TotalPrice) FROM Sale s) AS TotalSalesValue,
                                     (SELECT AVG(s.TotalPrice) FROM Sale s) AS AverageTicket,
                                     (CAST((SELECT COUNT(s.Id) FROM Sale s) AS DECIMAL) / NULLIF(COUNT(CASE WHEN ch.Type IN (1, 2) THEN 1 END), 0)) * 100 AS ConversionRate
                              FROM ContactHistory ch; ";

            var overviewReport = _dbConnection.Query<OverviewReport>(query).FirstOrDefault();
            return overviewReport;
        }

    }
}
