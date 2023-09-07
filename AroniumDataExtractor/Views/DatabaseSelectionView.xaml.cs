using AroniumDataExtractor.Services.DatabaseServices;

namespace AroniumDataExtractor.Views;

public partial class DatabaseSelectionView : ContentPage
{
    private readonly IDatabaseService _databaseService;

    public DatabaseSelectionView(IDatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;

        // Event subscriptions
        DatabaseSelectionButton.Clicked += DatabaseSelectionButton_Clicked;

        // Set starting window size
        var appWindow = Application.Current.Windows.FirstOrDefault();

        if (appWindow != null)
        {
            appWindow.Width = 450;
            appWindow.Height = 450;
        }

    }

    private void DatabaseSelectionButton_Clicked(object sender, EventArgs e)
    {
        _databaseService.Connect(@"C:\Users\netadmin\OneDrive - Ferrum High School\Desktop\pos.db");
    }
}