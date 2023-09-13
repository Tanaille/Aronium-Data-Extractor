# Aronium Data Extractor

A simple application built with C# using .NET 7 and .NET MAUI that extracts data from an Aronium POS SQLite database and exports it to a Microsoft Excel workbook.

## Report Generation

The purpose of this application is to generate a report containing the customer name, product name and quantity of each product sold. The reason for this is that while Aronium can natively generate reports containing the quantity of all products sold for a specific customer, it is unable to create a report containing the quantities of all products sold to ALL customers. When pulling quarterly reports for this purpose, this necessitated generating potentially hundreds of individual customer reports.

This application simplifies the process by exporting the product sales data to an Excel workbook. The data is automatically formatted as a searchable, sortable and filterable table. 

## Usage

Download the latest release from the [releases](https://github.com/Tanaille/Aronium-Data-Extractor/releases) page. Extract the AroniumDataExtractor.zip file and run the AroniumDataExtractor.exe file. Select the start and end date, select the Aronium pos.db SQLite database file (which can be found in **%LocalAppData%\Aronium\Data** and click "Generate Report". The report is automatically saved to the user's desktop.

![Application](https://github.com/Tanaille/Aronium-Data-Extractor/assets/34229043/e8cfee27-8473-4fe8-adbb-d4015178edad)

## Additional Information

The Aronium POS database schema can be found [HERE](https://github.com/Tanaille/Aronium-Data-Extractor/blob/master/Images/Aronium%20Database%20Schema.pdf). This schema has been generated using 
DbVisualizer and has been provided to simply the creation of new report generation methods.

## Platforms

The application is designed to run on Microsoft Windows.

## Dependencies

None. All required dependencies are included in the application folder.

## Third Party Tools

The application makes use of the .NET MAUI Community Toolkit and EPPlus package created by EPPlus Software AB, using a noncommercial license.
