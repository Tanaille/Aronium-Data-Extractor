using AroniumDataExtractor.Models.QueryResultModels;

namespace AroniumDataExtractor.Services.SqlCommandServices
{
    public interface ISqlCommandServices
    {
        CustomerItemQuantities GetCustomerItemQuantities(DateTime startDate, DateTime endDate);
    }
}