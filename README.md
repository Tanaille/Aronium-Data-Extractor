# Aronium Data Extractor

A simple application built with C# using .NET 7 and .NET MAUI that extracts data from an Aronium POS SQLite database and exports it to a Microsoft Excel workbook.

## Report Generation

The purpose of this application is to generate a report containing the customer name, product name and quantity of each product sold. The reason for this is that while Aronium can natively generate reports containing the quantity of all products sold for a specific customer, it is unable to create a report containing the quantities of all products sold to ALL customers. When pulling quarterly reports for this purpose, this necessitated generating potentially hundreds of individual customer reports.

This application simplifies the process by exporting the product sales data to an Excel workbook. The data is automatically formatted as a searchable, sortable and filterable table. 

## Usage

Run the application, select the start and end date, select the Aronium pos.db SQLite database file and click "Generate Report". The report is automatically saved to the user's desktop.

## Platforms

The application is designed to run on Microsoft Windows.

## Dependencies

None. All required dependencies are included in the application folder.

## Third Party Tools

The application makes use of the .NET MAUI Community Toolkit and EPPlus package created by EPPlus Software AB, using a noncommercial license.
