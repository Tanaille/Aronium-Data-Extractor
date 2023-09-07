namespace SqliteTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<string> products = new List<string>();
            List<int> quantities = new List<int>();

            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\netadmin\\OneDrive - Ferrum High School\\Desktop\\pos.db"))
            {
                connection.Open();

                int customerCount = 0;
                int rowCounter = 0;

                var command3 = connection.CreateCommand();
                command3.CommandText = @"SELECT COUNT(Id) AS NumberOfCustomers
                                        FROM Customer";

                using (var reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                        customerCount = reader3.GetInt32(0);
                }

                using (var package = new ExcelPackage(@"C:\Users\netadmin\OneDrive - Ferrum High School\Desktop\testExcel.xlsx"))
                {
                    var worksheet = package.Workbook.Worksheets.Add("SQLite");

                    int counter = 0;

                    worksheet.Cells["A1"].Value = "CUSTOMER";
                    worksheet.Cells["B1"].Value = "PRODUCT";
                    worksheet.Cells["C1"].Value = "QUANTITY";

                    for (int i = 1; i < customerCount; i++)
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = @"SELECT 
                                            p.NAME AS ProductName,
                                            SUM(di.Quantity) AS TotalQuantitySold
                                        FROM Customer AS c
                                        JOIN Document AS d ON c.Id = d.CustomerId
                                        JOIN DocumentItem AS di ON d.Id = di.DocumentId
                                        JOIN Product AS p ON di.ProductId = p.Id
                                        WHERE c.Id = $id
                                        AND d.Date >= date($startDate)
                                        AND d.Date <= date($endDate)
                                        GROUP BY p.Id, p.Name
                                        ORDER BY TotalQuantitySold DESC";

                        command.Parameters.AddWithValue("id", i);
                        command.Parameters.AddWithValue("startDate", "2022-09-01");
                        command.Parameters.AddWithValue("endDate", "2023-09-07");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(reader.GetString(0));
                                quantities.Add(reader.GetInt32(1));
                            }
                        }

                        var command2 = connection.CreateCommand();
                        command2.CommandText = @"SELECT Name FROM Customer WHERE Id = $id";

                        command2.Parameters.AddWithValue("id", i);


                        string customer = "";

                        using (var reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                customer = reader2.GetString(0);
                            }
                        }

                        string cellC = string.Empty;
                        for (int j = 0; j < products.Count; j++)
                        {
                            string CellA = "A" + (counter + 2).ToString();
                            worksheet.Cells[CellA].Value = customer;

                            string cellB = "B" + (counter + 2).ToString();
                            worksheet.Cells[cellB].Value = products[j];

                            cellC = "C" + (counter + 2).ToString();
                            worksheet.Cells[cellC].Value = quantities[j];

                            counter++;
                            rowCounter++;

                        }



                        products.Clear();
                        quantities.Clear();
                    }

                    string tableRange = "A1:" + "C" + (rowCounter + 1);
                    var range = worksheet.Cells[tableRange];
                    var table = worksheet.Tables.Add(range, "myTable");
                    table.ShowHeader = true;
                    table.HeaderRowStyle.Font.Bold = true;
                    worksheet.Cells.AutoFitColumns();

                    package.Save();

                }
            }
        }
    }
}