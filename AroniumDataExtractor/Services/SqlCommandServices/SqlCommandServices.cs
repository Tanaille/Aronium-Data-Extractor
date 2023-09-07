using AroniumDataExtractor.Services.DatabaseServices;
using System.Data.SQLite;

namespace AroniumDataExtractor.Services.SqlCommandServices
{
    public class SqlCommandServices
    {
        private readonly IDatabaseService _databaseService;

        public SqlCommandServices(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int GetNumberOfCustomers()
        {
            int customerCount = 0;

            using (SQLiteCommand command = _databaseService.Connection.CreateCommand())
            {
                command.CommandText = @"SELECT COUNT(Id) AS NumberOfCustomers
                                    FROM Customer";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        customerCount = reader.GetInt32(0);
                }
            };

            return customerCount;
        }

        public string GetCustomerName(int id)
        {
            string customerName = string.Empty;

            using (var command = _databaseService.Connection.CreateCommand())
            {
                command.CommandText = @"SELECT Name FROM Customer WHERE Id = $id";

                command.Parameters.AddWithValue("id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerName = reader.GetString(0);
                    }
                }
            };

            return customerName;
        }
    }
}
