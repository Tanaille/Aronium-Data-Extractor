using AroniumDataExtractor.Models.QueryResultModels;

namespace AroniumDataExtractor.Services.SqlCommandServices
{
    public interface ISqlCommandServices
    {
        string ConnectionString { get; set; }

        CustomerItemQuantities GetCustomerItemQuantities(DateTime startDate, DateTime endDate);
    }
}