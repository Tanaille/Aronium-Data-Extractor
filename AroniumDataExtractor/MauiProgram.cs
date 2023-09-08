using AroniumDataExtractor.Services.DatabaseServices;
using AroniumDataExtractor.Services.ExcelServices;
using AroniumDataExtractor.Services.FileServices;
using AroniumDataExtractor.Services.SqlCommandServices;
using AroniumDataExtractor.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace AroniumDataExtractor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Register pages
            builder.Services.AddSingleton<MainPage>();

            // Register views
            builder.Services.AddSingleton<DatabaseSelectionView>();

            // Register services
            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
            builder.Services.AddTransient<IFilePickerService, FilePickerService>();
            builder.Services.AddSingleton<IFilePickerFileTypes, FilePickerFileTypes>();
            builder.Services.AddSingleton<IExcelServices, ExcelServices>();
            builder.Services.AddSingleton<ISqlCommandServices, SqlCommandServices>();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}