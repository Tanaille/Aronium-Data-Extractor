using AroniumDataExtractor.Views;

namespace AroniumDataExtractor
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("databaseselection", typeof(DatabaseSelectionView));
        }
    }
}