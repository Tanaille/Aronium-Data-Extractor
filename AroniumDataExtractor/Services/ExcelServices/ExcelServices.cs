using AroniumDataExtractor.Models.QueryResultModels;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace AroniumDataExtractor.Services.ExcelServices
{
    /// <summary>
    /// Contains methods to write database information to an Excel worksheet.
    /// </summary>
    public class ExcelServices : IExcelServices
    {
        public ExcelServices()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        /// <summary>
        /// Writes data stored in a CustomerItemQuantities object to an Excel worksheet.
        /// </summary>
        /// <param name="customerItemQuantities">CustomerItemQuantities object containg the data to be written to Excel.</param>
        /// <param name="startDate">Data search start date.</param>
        /// <param name="endDate">Data search end date.</param>
        public void WriteDataToWorksheet(CustomerItemQuantities customerItemQuantities, DateTime startDate, DateTime endDate)
        {
            // Create Excel worksheet
            string excelFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                $"\\OneDrive - Ferrum High School\\Desktop" +
                $"\\Account Product Report - {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.xlsx";

            ExcelPackage package = new ExcelPackage(excelFilePath);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products per Customer");

            // Worksheet headers
            worksheet.Cells["A1"].Value = $"ACCOUNT PRODUCT REPORT FOR PERIOD {startDate.Date.ToString("yyyy/MM/dd")} TO {endDate.Date.ToString("yyyy/MM/dd")}";
            worksheet.Cells["A2"].Value = $"GENERATED ON: {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}";
            worksheet.Cells["A3"].Value = "ACCOUNT";
            worksheet.Cells["B3"].Value = "PRODUCT";
            worksheet.Cells["C3"].Value = "QUANTITY";

            // Write data from customerItemQuantities to the worksheet, starting at row 3
            for (int i = 0; i < customerItemQuantities.CustomerName.Count(); i++)
            {
                worksheet.Cells["A" + (i + 4).ToString()].Value = customerItemQuantities.CustomerName[i];

                worksheet.Cells["B" + (i + 4).ToString()].Value = customerItemQuantities.Products[i];

                worksheet.Cells["C" + (i + 4).ToString()].Value = customerItemQuantities.Quantities[i];
            }

            // Worksheet title and headers
            worksheet.Cells["A1:C1"].Merge = true;
            worksheet.Cells["A1:C1"].Style.Font.Bold = true;
            worksheet.Cells["A1:C1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells["A2:C2"].Merge = true;
            worksheet.Cells["A2:C2"].Style.Font.Bold = true;
            worksheet.Cells["A2:C2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            // Convert the data to a table and add some formatting
            string tableRange = "A3:C" + (customerItemQuantities.CustomerName.Count() + 3);
            var range = worksheet.Cells[tableRange];
            var table = worksheet.Tables.Add(range, "CustomerItemQuantities");
            table.ShowHeader = true;
            table.HeaderRowStyle.Font.Bold = true;
            table.ShowTotal = true;
            table.Columns[2].TotalsRowFunction = RowFunctions.Sum;
            worksheet.Cells.AutoFitColumns();

            package.Save();
        }
    }
}
