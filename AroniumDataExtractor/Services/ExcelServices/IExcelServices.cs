using AroniumDataExtractor.Models.QueryResultModels;

namespace AroniumDataExtractor.Services.ExcelServices
{
    public interface IExcelServices
    {
        void WriteDataToWorksheet(CustomerItemQuantities customerItemQuantities, DateTime startDate, DateTime endDate);
    }
}