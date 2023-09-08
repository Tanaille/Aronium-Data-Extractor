using AroniumDataExtractor.Services.DatabaseServices;
using AroniumDataExtractor.Services.ExcelServices;
using AroniumDataExtractor.Services.FileServices;
using AroniumDataExtractor.Services.SqlCommandServices;

namespace AroniumDataExtractor.Views;

public partial class DatabaseSelectionView : ContentPage
{
    private readonly IDatabaseService _databaseService;
    private readonly IFilePickerService _filePickerService;
    private readonly IFilePickerFileTypes _filePickerFileTypes;
    private readonly IExcelServices _excelServices;

    private string databaseFilePath;

    public DatabaseSelectionView(IDatabaseService databaseService,
                                IFilePickerService filePickerService,
                                 IFilePickerFileTypes filePickerFileTypes,
                                 IExcelServices excelServices)
    {
        InitializeComponent();

        // Services
        _databaseService = databaseService;
        _filePickerService = filePickerService;
        _filePickerFileTypes = filePickerFileTypes;
        _excelServices = excelServices;

        // Event subscriptions
        DatabaseSelectionButton.Clicked += DatabaseSelectionButton_Clicked;
        GenerateReportButton.Clicked += GenerateReportButton_Clicked;

        // Set starting window size
        var appWindow = Application.Current.Windows.FirstOrDefault();

        if (appWindow != null)
        {
            appWindow.Width = 450;
            appWindow.Height = 450;
        }
    }

    private void GenerateReportButton_Clicked(object sender, EventArgs e)
    {
        // Get start and end date
        DateTime startDate = StartDatePicker.Date;
        DateTime endDate = EndDatePicker.Date;

        // Retrieve the data from the database
        SqlCommandServices sqlCommandServices = new SqlCommandServices(_databaseService);
        sqlCommandServices.ConnectionString = databaseFilePath;

        var queryResult = sqlCommandServices.GetCustomerItemQuantities(startDate, endDate);

        // Write results to and Excel file
        _excelServices.WriteDataToWorksheet(queryResult, startDate, endDate);
    }

    private async void DatabaseSelectionButton_Clicked(object sender, EventArgs e)
    {
        // Get database file path
        databaseFilePath = (await _filePickerService.PickAndShow(_filePickerFileTypes.PickOptions)).FullPath;
    }
}