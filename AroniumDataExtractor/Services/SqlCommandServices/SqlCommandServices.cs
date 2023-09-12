using AroniumDataExtractor.Models.QueryResultModels;
using AroniumDataExtractor.Services.DatabaseServices;

namespace AroniumDataExtractor.Services.SqlCommandServices
{
    /// <summary>
    /// Provides SQL query services.
    /// </summary>
    public class SqlCommandServices : ISqlCommandServices
    {
        private readonly IDatabaseService _databaseService;

        public SqlCommandServices(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// Retrieves all total number of each product purchased by a customer for a specified date range.
        /// </summary>
        /// <param name="startDate">Start of the date range.</param>
        /// <param name="endDate">End of the date range.</param>
        /// <returns></returns>
        public CustomerItemQuantities GetCustomerItemQuantities(DateTime startDate, DateTime endDate)
        {
            CustomerItemQuantities customerItemQuantities = new CustomerItemQuantities();

            using (var command = _databaseService.Connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                            c.Name AS CustomerName,
                                            p.Name AS ProductName,
                                            SUM(di.Quantity) AS TotalQuantitySold
                                        FROM Customer AS c
                                        JOIN Document AS d ON c.Id = d.CustomerId
                                        JOIN DocumentItem AS di ON d.Id = di.DocumentId
                                        JOIN Product AS p ON di.ProductId = p.Id
                                        WHERE d.Date >= date($startDate)
                                        AND d.Date <= date($endDate)
                                        GROUP BY c.Name, p.Id, p.Name
                                        ORDER BY CustomerName, TotalQuantitySold DESC";

                command.Parameters.AddWithValue("startDate", startDate.Date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("endDate", endDate.Date.ToString("yyyy-MM-dd"));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerItemQuantities.CustomerName.Add(reader.GetString(0));
                        customerItemQuantities.Products.Add(reader.GetString(1));
                        customerItemQuantities.Quantities.Add(reader.GetInt32(2));
                    }
                }

                return customerItemQuantities;
            }
        }
    }
}
