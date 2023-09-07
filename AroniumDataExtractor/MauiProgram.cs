using AroniumDataExtractor.Services.DatabaseServices;
using AroniumDataExtractor.Views;
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

            builder
                .UseMauiApp<App>()
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